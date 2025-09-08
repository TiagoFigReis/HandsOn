using Core.Entities;
using Core.Enums;

namespace Application.ViewModels
{
    public class FormulationTableViewModel
    {
        public Guid Id { get; set; }
        public bool Standard { get; set; }

        public ICollection<FormulationRowViewModel> CompoundFormulationRows { get; set; } = [];
        public ICollection<FormulationRowViewModel> BasicFormulationRows { get; set; } = [];

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Guid CultureId { get; set; }

        public static FormulationTableViewModel FromEntity(FormulationTable formulationTable)
        {
            var tableData = formulationTable.GetTableData();

            return new FormulationTableViewModel
            {
                Id = formulationTable.Id,
                Standard = formulationTable.Standard,

                CompoundFormulationRows = tableData.CompoundFormulationRows
                    .Select(FormulationRowViewModel.FromEntity)
                    .ToList(),

                BasicFormulationRows = tableData.BasicFormulationRows
                    .Select(FormulationRowViewModel.FromEntity)
                    .ToList(),

                CreatedAt = formulationTable.CreatedAt,
                UpdatedAt = formulationTable.UpdatedAt,

                CultureId = formulationTable.CultureId
            };
        }
    }

    public class FormulationRowViewModel
    {
        public ICollection<FormulationColumnViewModel> FormulationColumns { get; set; } = [];

        public static FormulationRowViewModel FromEntity(FormulationRowData formulationRow)
        {
            return new FormulationRowViewModel
            {
                FormulationColumns = formulationRow.FormulationColumns
                    .Select(FormulationColumnViewModel.FromEntity)
                    .ToList()
            };
        }
    }

    public class FormulationColumnViewModel
    {
        public float NAmount { get; set; }
        public float PAmount { get; set; }
        public float KAmount { get; set; }
        public float BAmount { get; set; }

        public static FormulationColumnViewModel FromEntity(FormulationColumnData formulationColumn)
        {
            return new FormulationColumnViewModel
            {
                NAmount = formulationColumn.NAmount,
                PAmount = formulationColumn.PAmount,
                KAmount = formulationColumn.KAmount,
                BAmount = formulationColumn.BAmount
            };
        }
    }
}