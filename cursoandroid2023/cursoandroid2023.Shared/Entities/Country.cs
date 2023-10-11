using System.ComponentModel.DataAnnotations;

namespace cursoandroid2023.Shared.Entities
{
    public class Country
    {
        public int Id { get; set; }

        [Display(Name = "Pais")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caractéres")]
        public string Name { get; set; } = null!;

        [Display(Name = "Nacionalidad")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caractéres")]
        public string Nationality { get; set; } = null!;

        public int PeopleId { get; set; }

        public Person? People { get; set; }



    }
}
