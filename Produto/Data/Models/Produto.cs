using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("Produtos")]
    public class Produto : Base
    {
        public Categoria Categoria { get; set; }
        public decimal Peso { get; set; }
        public string CorPrincipal { get; set; }
    }
}
