﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Dominio.Entidades
{
    public class Grupo
    {
        public Grupo(string nome, string foto)
        {
            Nome = nome;
            Foto = foto;
        }

        protected Grupo()
        {
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Foto { get; private set; }

        public List<string> ValidarEntrada()
        {
            List<string> mensagens = new List<string>();

            if (string.IsNullOrWhiteSpace(Nome))
                mensagens.Add("Nome não pode ser nulo.");

            if (Nome.Length > 50)
                mensagens.Add("O tamanho máximo são 50 caracteres.");

            if (string.IsNullOrWhiteSpace(Foto))
                mensagens.Add("Foto não pode ser nula.");

            if (Foto.Length > 500)
                mensagens.Add("O tamanho máximo são 500 caracteres.");

            return mensagens;
        }
    }
}
