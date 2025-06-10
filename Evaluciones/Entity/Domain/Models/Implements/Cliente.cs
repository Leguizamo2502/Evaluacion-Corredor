using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Domain.Models.Base;

namespace Entity.Domain.Models.Implements
{
    public class Cliente : BaseModel
    {
        public string Nombre { get; set; }           
        public string Correo { get; set; }          
        public string Telefono { get; set; }

        public List<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
