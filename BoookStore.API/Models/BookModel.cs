using System.ComponentModel.DataAnnotations;

namespace BoookStore.API.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Champ obligatoire")]
        public string Title { get; set; }
        public string Desription { get; set; }

    }
}
