using System.ComponentModel.DataAnnotations;
using Core.Entities;
using Core.Enums;

namespace Application.InputModels.FormulationTableInputModels
{
    public class UpdateFormulationTableInputModel
    {
        public ICollection<UpdateFormulationRowInputModel> CompoundFormulationRows { get; set; } = [];
        public ICollection<UpdateFormulationRowInputModel> BasicFormulationRows { get; set; } = [];

        public FormulationTable ToEntity()
        {
            var tableData = new FormulationTableData
            {
                CompoundFormulationRows = CompoundFormulationRows.Select(c => c.ToEntity()).ToList(),
                BasicFormulationRows = BasicFormulationRows.Select(c => c.ToEntity()).ToList()
            };

            var formulationTable = new FormulationTable();

            formulationTable.SetTableData(tableData);

            return formulationTable;
        }
    }

    public class UpdateFormulationRowInputModel
    {
        [Required(ErrorMessage = "Leaf Columns are required.")]
        public ICollection<UpdateFormulationColumnInputModel> FormulationColumns { get; set; } = [];

        public FormulationRowData ToEntity()
        {
            return new FormulationRowData
            {
                FormulationColumns = FormulationColumns.Select(c => c.ToEntity()).ToList()
            };
        }
    }

    public class UpdateFormulationColumnInputModel
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