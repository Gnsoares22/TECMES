using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TECMES.Models
{
    public class OrdemProducaoStatus
    {
        [Key]
        public int Id {get; set; }

        public string Status { get; set; }

        public virtual ICollection<OrdemProducao> OrdemProducao { get; set; }

        public virtual ICollection<OrdemProducaoSequencia> sequencia { get; set; }


    }
}
