﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Dominio.Entidades
{
    public class GrupoUsuario
    {
        public GrupoUsuario(Usuario usuario, Grupo grupo, Boolean aprovado)
        {
            Usuario = usuario;
            Grupo = grupo;
            Aprovado = aprovado;
        }

        protected GrupoUsuario()
        {
        }

        public int Id { get; private set; }

        public Usuario Usuario { get; private set; }
        public Grupo Grupo { get; private set; }
        public Boolean Aprovado { get; private set; }

        public List<string> ValidarEntrada()
        {
            List<string> mensagens = new List<string>();

            if (Usuario == null)
                mensagens.Add("Deve ter um Usuario vinculada.");

            if (Grupo == null)
                mensagens.Add("Deve ter um Grupo vinculada.");

            return mensagens;
        }
    }
}
