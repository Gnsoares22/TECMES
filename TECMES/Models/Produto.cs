using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TECMES.Models
{
    public class Produto
    {
        [Key]
        public int Id {get;set;}

        [Required]
        public string Nome { get; set; }

        [Required]
        public decimal preco { get; set; }

        [Required]
        public int quantidade { get; set; }

        public virtual ICollection<Pedido> Pedido { get; set; }
    
        public virtual ICollection<OrdemProducao> ordemProducao { get; set; }

        public virtual ICollection<OrdemProducaoSequencia> OrdemProducaoSequencia { get; set; }
    }
}
