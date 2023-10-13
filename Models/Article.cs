using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MigrationsExample.Models
{
    public class Article
    {
        [Key]
        public int ID { get; set; }
        [StringLength(255 , MinimumLength =5 , ErrorMessage ="khong duoc duoi 5 kitu") ]
        [Required(ErrorMessage =" Khong Duoc de tronng")]
        [Column(TypeName ="nvarchar")]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
        [Column(TypeName ="ntext")]
        public string Content {set; get;}
    }
}