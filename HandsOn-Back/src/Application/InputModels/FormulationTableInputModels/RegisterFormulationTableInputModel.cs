using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Core.Entities;
using Core.Enums;

namespace Application.InputModels.FormulationTableInputModels
{
    public class RegisterFormulationTableInputModel
    {
        [Required(ErrorMessage = "Leaf fertilizer rows are required.")]
        public ICollection<RegisterFormulationRowInputModel> CompoundFormulationRows { get; set; } = [];

        [Required(ErrorMessage = "Soil fertilizer rows are required.")]
        public ICollection<RegisterFormulationRowInputModel> BasicFormulationRows { get; set; } = [];

        [Required(ErrorMessage = "Culture is required.")]
        public Guid CultureId { get; set; }

        public FormulationTable ToEntity()
        {
            var tableData = new FormulationTableData
            {
                CompoundFormulationRows = CompoundFormulationRows.Select(r => r.ToEntity()).ToList(),
                BasicFormulationRows = BasicFormulationRows.Select(r => r.ToEntity()).ToList()
            };

            var formulationTable = new FormulationTable
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.Now
            };

            formulationTable.SetTableData(tableData);

            return formulationTable;
        }
    }

    public class RegisterFormulationRowInputModel
    {
        [Required(ErrorMessage = "Leaf Columns are required.")]
        public ICollection<RegisterFormulationColumnInputModel> FormulationColumns { get; set; } = [];

        public FormulationRowData ToEntity()
        {
            return new FormulationRowData
            {
                FormulationColumns = FormulationColumns.Select(c => c.ToEntity()).ToList()
            };
        }
    }

    public class RegisterFormulationColumnInputModel
    {
        [Required(ErrorMessage = "NAmount is required.")]
        [Range(0, float.MaxValue, ErrorMessage = "NAmount cannot be negative")]
        public float NAmount { get; set; }

        [Required(ErrorMessage = "PAmount is required.")]
        [Range(0, float.MaxValue, ErrorMessage = "PAmount cannot be negative")]
        public float PAmount { get; set; }

        [Required(ErrorMessage = "KAmount is required.")]
        [Range(0, float.MaxValue, ErrorMessage = "KAmount cannot be negative")]
        public float KAmount { get; set; }

        [Required(ErrorMessage = "BAmount is required.")]
        [Range(0, float.MaxValue, ErrorMessage = "BAmount cannot be negative")]
        public float BAmount { get; set; }

        public FormulationColumnData ToEntity()
        {
            return new FormulationColumnData
            {
                NAmount = NAmount,
                PAmount = PAmount,
                KAmount = KAmount,
                BAmount = BAmount
            };
        }
    }
}