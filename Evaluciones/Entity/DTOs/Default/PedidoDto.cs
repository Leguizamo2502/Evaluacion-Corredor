using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.DTOs.Base;

namespace Entity.DTOs.Default
{
    public class PedidoDto : BaseDto
    {
        public int Cantidad { get; set; }
        public DateTime FechaPedido { get; set; }

        public int ClienteId { get; set; }
        
        public int ProductoId { get; set; }
    }
}
