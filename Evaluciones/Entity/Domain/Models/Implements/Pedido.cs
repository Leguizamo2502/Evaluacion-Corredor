using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Domain.Models.Base;

namespace Entity.Domain.Models.Implements
{
    public class Pedido : BaseModel
    {

        public int Cantidad { get; set; }
        public DateTime FechaPedido { get; set; }

        public int ClienteId { get; set; }
        public int ProductoId { get; set; }      
                
 
        public virtual Cliente Cliente { get; set; }
        public virtual Producto Producto { get; set; }

     


    }
}
