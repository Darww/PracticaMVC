using System.ComponentModel.DataAnnotations;
namespace PracticaMVC.Models
{
    public class Marcas
    {

        [Key]
        public int Id_marcas { get; set; }
        public string? nombre_marca { get; set; }
        public string? estados {  get; set; }
        
    }
}
