using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace PracticaMVC.Models
{
    public class marcas
    {

        [Key]
        [DisplayName("Id de Marca")]
        public int Id_marcas { get; set; }
        [DisplayName("Nombre de la Marca")]
        [Required(ErrorMessage = "El nombre de la marca No es opcional!")]
        public string? nombre_marca { get; set; }
        [DisplayName("Estado")]
        [StringLength(1, ErrorMessage = "La canridad maxima de caracteres valida es {1}")]
        public string? estados {  get; set; }
        
    }
}
