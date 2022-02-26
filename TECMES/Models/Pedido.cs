using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TECMES.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        public int ProdutoID { get; set; }

        [DisplayName("Descricao")]
        public virtual string Descricao { get; set; }

        [DisplayName("Produto")]
        public virtual Produto produto { get; set; }

        public int ClienteID { get; set; }

        [DisplayName("Cliente")]
        public virtual Cliente cliente { get; set; }

        [DisplayName("Quantidade Requisitada")]
        [Required(ErrorMessage = "Informe a quantidade")]
        [Range(1, 9999999, ErrorMessage = "A quantidade deve ser maior que zero")]
        public int? Quantidade { get; set; }

        public ICollection<OrdemProducao> ordemProducao { get; set; }

    }
}
