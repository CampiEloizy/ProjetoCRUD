using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoCRUD.Models
{
    internal class Despesa
    {
        public int idDespesa { get; set; }
        public double valorDespesa { get; set; }
        public DateTime dataPag {  get; set; }
        public DateTime dataVenc{ get; set; }
        public string status {  get; set; }
        public int idCaixaFK { get; set; }
    }
}
