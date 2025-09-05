using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Application.InputModels.CultureInputModels
{
    public class UpdateCultureInputModel
    {
        [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        [MinLength(1, ErrorMessage = "Name cannot be empty.")]
        public string? Name { get; set; }

        public Culture ToEntity()
        {
            return new Culture()
            {
                Name = Name!
            };
        }
    }
}