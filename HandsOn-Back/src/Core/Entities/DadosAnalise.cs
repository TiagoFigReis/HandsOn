using System.Text.Json.Serialization;
using System.Collections.Generic;
using Core.Enums;

namespace Core.Entities
{

    public class DadosAnalise
    {
        [JsonPropertyName("amostras_solo")]
        public List<AmostraSolo>? AmostrasSolo { get; set; }
        [JsonPropertyName("amostras_foliar")]
        public List<AmostraFoliar>? AmostrasFoliar { get; set; }
    }

    public class AmostraSolo
    {
        [JsonPropertyName("id_amostra")]
        public string? IdAmostra { get; set; }

        [JsonPropertyName("identificacao_talhao")]
        public string? IdentificacaoTalhao { get; set; }


        [JsonPropertyName("fosforo_p")]
        public decimal? FosforoP { get; set; }

        [JsonPropertyName("potassio_k")]
        public decimal? PotassioK { get; set; }

        [JsonPropertyName("calcio_ca")]
        public decimal? CalcioCa { get; set; }

        [JsonPropertyName("magnesio_mg")]
        public decimal? MagnesioMg { get; set; }

        [JsonPropertyName("Aluminio_al")]
        public decimal? AluminioAl { get; set; }

        [JsonPropertyName("ph_h2o")]
        public decimal? PhH2O { get; set; }

        [JsonPropertyName("acidez_potencial_h_al_cmolc_dm3")]
        public decimal? AcidezPotencialHAlCmolcDm3 { get; set; }

        [JsonPropertyName("soma_bases_sb_cmolc_dm3")]
        public decimal? SomaBasesSbCmolcDm3 { get; set; }

        [JsonPropertyName("ctc_ph7_T_cmolc_dm3")]
        public decimal? CtcPh7TCmolcDm3 { get; set; }

        [JsonPropertyName("saturacao_bases_v_percent")]
        public decimal? SaturacaoBasesVPercent { get; set; }

        [JsonPropertyName("materia_organica_mo_percent")]
        public decimal? MateriaOrganicaMoPercent { get; set; }

        [JsonPropertyName("boro_b")]
        public decimal? BoroB { get; set; }

        [JsonPropertyName("cobre_cu")]
        public decimal? CobreCu { get; set; }

        [JsonPropertyName("ferro_fe")]
        public decimal? FerroFe { get; set; }

        [JsonPropertyName("manganes_mn")]
        public decimal? ManganesMn { get; set; }

        [JsonPropertyName("zinco_zn")]
        public decimal? ZincoZn { get; set; }

        [JsonPropertyName("enxofre_s")]
        public decimal? EnxofreS { get; set; }
    }

    public class AmostraFoliar
    {
        [JsonPropertyName("id_amostra")]
        public string? IdAmostra { get; set; }

        [JsonPropertyName("identificacao_talhao")]
        public string? IdentificacaoTalhao { get; set; }


        [JsonPropertyName("fosforo_p")]
        public decimal? FosforoP { get; set; }

        [JsonPropertyName("potassio_k")]
        public decimal? PotassioK { get; set; }

        [JsonPropertyName("calcio_ca")]
        public decimal? CalcioCa { get; set; }

        [JsonPropertyName("magnesio_mg")]
        public decimal? MagnesioMg { get; set; }

        [JsonPropertyName("nitrogenio_n")]
        public decimal? NitrogenioN { get; set; }

        [JsonPropertyName("boro_b")]
        public decimal? BoroB { get; set; }

        [JsonPropertyName("cobre_cu")]
        public decimal? CobreCu { get; set; }

        [JsonPropertyName("ferro_fe")]
        public decimal? FerroFe { get; set; }

        [JsonPropertyName("manganes_mn")]
        public decimal? ManganesMn { get; set; }

        [JsonPropertyName("zinco_zn")]
        public decimal? ZincoZn { get; set; }

        [JsonPropertyName("enxofre_s")]
        public decimal? EnxofreS { get; set; }
    }


    public class PlotsData
    {
        [JsonPropertyName("plots")]
        public List<AnalisePlot> Plots { get; set; } = [];
    }

    public class AnalisePlot
    {
        public string? CultureType { get; set; } = "Café";

        [JsonPropertyName("plotName")]
        public string? PlotName { get; set; }

        public int ExpectedProductivity { get; set; } = 30;

        public float Width { get; set; } = 3.5f;

        public float Height { get; set; } = 0.6f;

        [JsonPropertyName("nutrients")]
        public List<Nutrient> Nutrients { get; set; } = [];
    }

    public class Nutrient
    {
        [JsonPropertyName("header")]
        public int Header { get; set; }

        [JsonPropertyName("value")]
        public decimal? Value { get; set; }
    }

    public static class DataTransformer
    {
        public static PlotsData TransformSoil(DadosAnalise dadosAnalise)
        {
            var plotsData = new PlotsData
            {
                Plots = new List<AnalisePlot>()
            };

            if (dadosAnalise?.AmostrasSolo == null)
            {
                return plotsData;
            }

            foreach (var amostra in dadosAnalise.AmostrasSolo)
            {
                var plot = new AnalisePlot
                {
                    PlotName = amostra.IdentificacaoTalhao,
                    Nutrients = new List<Nutrient>
                {

                    new Nutrient { Header = (int)NutrientHeader.P, Value = amostra.FosforoP },
                    new Nutrient { Header = (int)NutrientHeader.K, Value = amostra.PotassioK },
                    new Nutrient { Header = (int)NutrientHeader.Ca, Value = amostra.CalcioCa },
                    new Nutrient { Header = (int)NutrientHeader.Mg, Value = amostra.MagnesioMg },
                    new Nutrient { Header = (int)NutrientHeader.S, Value = amostra.EnxofreS },
                    new Nutrient { Header = (int)NutrientHeader.Zn, Value = amostra.ZincoZn },
                    new Nutrient { Header = (int)NutrientHeader.B, Value = amostra.BoroB },
                    new Nutrient { Header = (int)NutrientHeader.Cu, Value = amostra.CobreCu },
                    new Nutrient { Header = (int)NutrientHeader.Mn, Value = amostra.ManganesMn },
                    new Nutrient { Header = (int)NutrientHeader.Fe, Value = amostra.FerroFe },
                    new Nutrient { Header = (int)NutrientHeader.AlSaturation, Value = amostra.AluminioAl },
                    new Nutrient { Header = (int)NutrientHeader.PhH2O, Value = amostra.PhH2O },
                    new Nutrient { Header = (int)NutrientHeader.BasesSaturation, Value = amostra.SaturacaoBasesVPercent },
                    new Nutrient { Header = (int)NutrientHeader.CTCpH7, Value = amostra.CtcPh7TCmolcDm3 },
                    new Nutrient { Header = (int)NutrientHeader.PotentialAcidity, Value = amostra.AcidezPotencialHAlCmolcDm3 },
                    new Nutrient { Header = (int)NutrientHeader.OrganicMatter, Value = amostra.MateriaOrganicaMoPercent },
                    new Nutrient { Header = (int)NutrientHeader.SumBases, Value = amostra.SomaBasesSbCmolcDm3 },
                }
                };

                plotsData.Plots.Add(plot);
            }

            return plotsData;
        }
    
    public static PlotsData TransformFoliar(DadosAnalise dadosAnalise)
    {
        var plotsData = new PlotsData
        {
            Plots = new List<AnalisePlot>()
        };

        if (dadosAnalise?.AmostrasFoliar == null)
        {
            return plotsData; 
        }

        foreach (var amostra in dadosAnalise.AmostrasFoliar)
        {
            var plot = new AnalisePlot
            {
                PlotName = amostra.IdentificacaoTalhao,
                Nutrients = new List<Nutrient>
                {
                    
                    new Nutrient { Header = (int)NutrientHeader.N, Value = amostra.NitrogenioN },
                    new Nutrient { Header = (int)NutrientHeader.P, Value = amostra.FosforoP },
                    new Nutrient { Header = (int)NutrientHeader.K, Value = amostra.PotassioK },
                    new Nutrient { Header = (int)NutrientHeader.Ca, Value = amostra.CalcioCa },
                    new Nutrient { Header = (int)NutrientHeader.Mg, Value = amostra.MagnesioMg },
                    new Nutrient { Header = (int)NutrientHeader.S, Value = amostra.EnxofreS },
                    new Nutrient { Header = (int)NutrientHeader.Zn, Value = amostra.ZincoZn },
                    new Nutrient { Header = (int)NutrientHeader.B, Value = amostra.BoroB },
                    new Nutrient { Header = (int)NutrientHeader.Cu, Value = amostra.CobreCu },
                    new Nutrient { Header = (int)NutrientHeader.Mn, Value = amostra.ManganesMn },
                    new Nutrient { Header = (int)NutrientHeader.Fe, Value = amostra.FerroFe }
                }
            };

            plotsData.Plots.Add(plot);
        }

        return plotsData;
    }
}
}