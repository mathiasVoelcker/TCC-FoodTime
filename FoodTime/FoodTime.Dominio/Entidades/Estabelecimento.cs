﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Dominio.Entidades
{
    public class Estabelecimento
    {

        protected Estabelecimento()
        {
        }

        protected Estabelecimento(string nome, string telefone, Endereco endereco, List<Categoria> categoria, DateTime horaAbertura, DateTime horaFechamento, decimal precoMedio, List<String> fotos, List<Preferencia> preferencias)
        {
            Nome = nome;
            Telefone = telefone;
            Endereco = endereco;
            Categorias = categoria;
            HorarioAbertura = horaAbertura;
            HorarioFechamento = horaFechamento;
            PrecoMedio = precoMedio;
            Fotos = fotos;
            Preferencias = preferencias;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Telefone { get; private set; }
        public Endereco Endereco { get; private set; }
        public List<Categoria> Categorias { get; private set; }
        public List<String> Fotos { get; private set; }
        public List<Preferencia> Preferencias { get; private set; }
        public DateTime HorarioAbertura { get; private set; }
        public DateTime HorarioFechamento { get; private set; }
        public decimal PrecoMedio { get; private set; }

        


        public List<string> ValidarEntrada()
        {
            List<string> mensagens = new List<string>();

            if (string.IsNullOrEmpty(Nome))
                mensagens.Add("Nome não pode ser nulo.");

            if (Nome.Length>100)
                mensagens.Add("Tamanho máximo 100 caracteres");

            if (string.IsNullOrEmpty(Telefone))
                mensagens.Add("Telefone não pode ser nulo.");

            if (Nome.Length > 20)
                mensagens.Add("Tamanho máximo 100 caracteres");

            if (Endereco==null)
                mensagens.Add("Deve conter um Endereço atrelado ao Estabelecimento");

            if (Fotos==null)
                mensagens.Add("A Lista de Fotos não pode ser nula.");

            if (Categorias == null)
                mensagens.Add("A Lista de Categorias não pode ser nula.");

            if (Preferencias == null)
                mensagens.Add("A Lista de Preferencias não pode ser nula.");

            if (HorarioAbertura == null)
                mensagens.Add("Horario de abertura não pode ser nulo.");

            if (HorarioFechamento == null)
                mensagens.Add("Horario de fechamento não pode ser nulo.");

            if (PrecoMedio==0)
                mensagens.Add("O Estabelecimento deve conter um preço médio");

            return mensagens;
        }

    }
}