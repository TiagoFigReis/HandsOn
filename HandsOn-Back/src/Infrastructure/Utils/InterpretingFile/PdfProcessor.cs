using Core.Repositories;
using Python.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utils.InterpretingFile
{
    public class PdfProcessor : IPdfProcessor
    {
        /// Corrige a orientação das páginas de um PDF e retorna os bytes do arquivo corrigido e seu caminho.
        public async Task<(byte[]? correctedPdfBytes, string correctedFilePath)> CorrectOrientationAsync(string filePath)
        {
            return await Task.Run(() =>
            {
                using (Py.GIL())
                {
                    try
                    {
                        // Importa as bibliotecas Python necessárias
                        dynamic pdfplumber = Py.Import("pdfplumber");
                        dynamic pikepdf = Py.Import("pikepdf");
                        dynamic os = Py.Import("os");
                        dynamic collections = Py.Import("collections");

                        var correcoes_necessarias = new PyDict();

                        // Abre o PDF com pdfplumber para detectar a rotação
                        using (var pdf = pdfplumber.open(filePath))
                        {

                            for (int i = 0; i < pdf.pages.Length(); i++)
                            {
                                var page = pdf.pages[i];
                                int rotacao_conteudo = DetectarRotacaoConteudo(page, collections);
                                if (rotacao_conteudo != 0)
                                {
                                    int rotacao_para_corrigir = (360 - rotacao_conteudo) % 360;
                                    correcoes_necessarias[i.ToPython()] = rotacao_para_corrigir.ToPython();
                                }
                            }

                            pdf.close();
                        }

                        // Se nenhuma correção for necessária, retorna o caminho original
                        if (correcoes_necessarias.Length() == 0)
                        {
                            return ((byte[]?)null, filePath);
                        }

                        // Gera o nome do arquivo corrigido
                        string baseName = os.path.basename(filePath).ToString();
                        string dirName = os.path.dirname(filePath).ToString();
                        string fileNameWithoutExt = os.path.splitext(baseName)[0].ToString();
                        string nome_arquivo_corrigido = os.path.join(dirName, $"{fileNameWithoutExt}_corrigido.pdf").ToString();

                        // Usa pikepdf para aplicar a rotação e salvar o novo arquivo
                        using (var pdf_para_corrigir = pikepdf.open(filePath))
                        {
                            foreach (var item in correcoes_necessarias.Items())
                            {
                                int num_pagina = item[0].As<int>();
                                int rotacao_a_aplicar = item[1].As<int>();

                                var pagina = pdf_para_corrigir.pages[num_pagina];
                                pagina.Rotate = rotacao_a_aplicar;
                            }
                            pdf_para_corrigir.save(nome_arquivo_corrigido);

                            pdf_para_corrigir.close();
                        }

                        byte[] fileBytes = File.ReadAllBytes(nome_arquivo_corrigido);
                        return (fileBytes, nome_arquivo_corrigido);
                    }
                    catch (PythonException ex)
                    {
                        throw new InvalidOperationException($"Ocorreu um erro no script Python de correção de orientação: {ex.Message}", ex);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            });
        }

        /// Extrai texto e tabelas de um arquivo PDF.
        public async Task<string> ExtractTextAsync(string filePath)
        {
            return await Task.Run(() =>
            {
                if (!File.Exists(filePath))
                {
                    return "";
                }

                var fullContent = new StringBuilder();

                using (Py.GIL())
                {
                    try
                    {
                        dynamic pdfplumber = Py.Import("pdfplumber");

                        using (var pdf = pdfplumber.open(filePath))
                        {
                            for (int i = 0; i < pdf.pages.Length(); i++)
                            {
                                var page = pdf.pages[i];
                                fullContent.AppendLine($"--- CONTEÚDO DA PÁGINA {i + 1} ---\n");

                                // Extrai texto
                                string text = page.extract_text(x_tolerance: 2)?.ToString() ?? "";
                                if (!string.IsNullOrWhiteSpace(text))
                                {
                                    fullContent.AppendLine("### Texto da Página:");
                                    fullContent.AppendLine(text + "\n");
                                }

                                // Extrai tabelas e aplica uma formatação com separações por |
                                var tables = page.extract_tables();

                                if (tables is not null && tables.Length() > 0)
                                {
                                    fullContent.AppendLine("### Tabelas Encontradas:");
                                    for (int j = 0; j < tables?.Length(); j++)
                                    {
                                        var table = tables[j];

                                        if (table is null || table.Length() == 0) continue;

                                        fullContent.AppendLine($"--- Tabela {j + 1} ---");

                                        var headerCellsPy = table?[0];
                                        if (headerCellsPy == null) continue;

                                        var headerCells = new List<dynamic>();
                                        foreach (var cell in headerCellsPy)
                                        {
                                            headerCells.Add(cell);
                                        }

                                        string header = "| " + string.Join(" | ", headerCells.Select(new Func<dynamic, string>(cell => (cell?.ToString() ?? "").Replace("\n", " ")))) + " |";
                                        string separator = "| " + string.Join(" | ", headerCells.Select(new Func<dynamic, string>(_ => "---"))) + " |";

                                        fullContent.AppendLine(header);
                                        fullContent.AppendLine(separator);

                                        for (int rowIndex = 1; rowIndex < table?.Length(); rowIndex++)
                                        {
                                            var rowCellsPy = table[rowIndex];
                                            if (rowCellsPy == null) continue;

                                            var rowCells = new List<dynamic>();
                                            foreach (var cell in rowCellsPy)
                                            {
                                                rowCells.Add(cell);
                                            }

                                            string bodyRow = "| " + string.Join(" | ", rowCells.Select(new Func<dynamic, string>(cell => (cell?.ToString() ?? "").Replace("\n", " ")))) + " |";
                                            fullContent.AppendLine(bodyRow);
                                        }
                                        fullContent.AppendLine();
                                    }
                                }
                            }
                            pdf.close();
                        }
                    }
                    catch (PythonException ex)
                    {
                        throw new InvalidOperationException($"Ocorreu um erro no script Python de extração de texto: {ex.Message}", ex);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    
                }
                return fullContent.ToString();
            });
        }

        /// Lógica de detecção de rotação.
        private int DetectarRotacaoConteudo(dynamic page, dynamic collections)
        {
            var chars = page.chars;
            if (chars.Length() == 0) return 0;

            var votes = collections.Counter();

            /*
            a, b, c, d são componentes da matriz de transformação de cada caractere.
            a e d: Controlam principalmente a escala nos eixos X e Y.
            Se a e d são positivos, o caractere está na sua orientação normal.
            Se a e d são negativos, o caractere está invertido, indicando rotação de 180°.
            b e c: São os principais responsáveis pela rotação.
            Em um texto sem rotação, b e c são muito próximos de zero.
            Quando o texto é rotacionado, eles assumem valores positivos ou negativos girando o caractere.
            */

            foreach (var ch in chars)
            {
                var matrix = ch["matrix"];
                double a = matrix[0].As<double>();
                double b = matrix[1].As<double>();
                double c = matrix[2].As<double>();
                double d = matrix[3].As<double>();

                if (a > 0 && d > 0 && Math.Abs(b) < 0.1 && Math.Abs(c) < 0.1) votes[0.ToPython()] += 1;
                else if (b > 0 && c < 0 && Math.Abs(a) < 0.1 && Math.Abs(d) < 0.1) votes[270.ToPython()] += 1;
                else if (a < 0 && d < 0 && Math.Abs(b) < 0.1 && Math.Abs(c) < 0.1) votes[180.ToPython()] += 1;
                else if (b < 0 && c > 0 && Math.Abs(a) < 0.1 && Math.Abs(d) < 0.1) votes[90.ToPython()] += 1;
            }

            if (votes.Length() == 0) return 0;
            
            var mostCommon = votes.most_common(1);
            if (mostCommon.Length() == 0) return 0;

            return mostCommon[0][0].As<int>();
        }
    }
}

