using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTime.WebApi.Models
{
    public class NotificacaoModel
    {
        public int IdUsuario { get; set; }
        public int IdEstabelecimento { get; set; }
        public int IdGrupo { get; set; }
        public bool Visibilidade { get; private set; }        
    }
}