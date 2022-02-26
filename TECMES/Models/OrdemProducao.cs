using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TECMES.Models
{
    public class OrdemProducao
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Quantidade")]
        public int? quantidade { get; set; }

        [DisplayName("Prazo")]
        public DateTime? Prazo { get; set; }

        [DisplayName("Produto Requisitado")]
        public int ProdutoID { get; set; }

        public Produto produtos { get; set; }

        [DisplayName("Status de Producao")]
        public int StatusID { get; set; }
        public virtual OrdemProducaoStatus status { get; set; }

        [DisplayName("Maquina")]
        public int? MaquinaID { get; set; }
        public virtual Maquina maquinas { get; set; }

        [DisplayName("Pedido")]
        [Required(ErrorMessage = "Informe o pedido liberado")]
        public int PedidoID { get; set; }
        public virtual Pedido pedido { get; set; }

        public virtual ICollection<OrdemProducaoSequencia> sequencia { get; set; }
    }
}
