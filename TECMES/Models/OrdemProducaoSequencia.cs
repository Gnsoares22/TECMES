using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TECMES.Models
{
    public class OrdemProducaoSequencia
    {
        [Key]
        public int Id { get; set; }

        public int OrdemProducaoID { get; set; }
        public OrdemProducao ordemProducao;

        public int ProdutoID {get;set;}
        public virtual Produto produto { get; set; }

        public int Quantidade { get; set; }
        
        public int NumeroSequencia { get; set; }

    }
}
