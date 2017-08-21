using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    [Table("Haberler")]
    public class Haber
    {
        [StringLength(255)]
        public string title { get; set; }
        public DateTime pubdate { get; set; }

        [StringLength(255)]
        public string link { get; set; }
        public string description { get; set; }

        [Key]
        [StringLength(255)]
        public string guid { get; set; }

    }
}
