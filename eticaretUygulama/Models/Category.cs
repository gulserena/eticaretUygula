using System.ComponentModel.DataAnnotations;

namespace eticaretUygulama.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Display(Name ="Kategori Adı")]
        [Required(ErrorMessage ="Bu Alan Boş Bırakılmaz")]
        public string? CategoryName { get; set; }

        virtual public List<Products> Products { get; set; }    


    }
}
