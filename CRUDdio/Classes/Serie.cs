using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDdio
{
    public class Serie : EntidadeBase
    {
        //Atributos
        private Genero Genero { get; set; } //enum
       public string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this. Descricao = descricao;
            this.Ano = ano;
            Excluido = false;
        } 

        //Métodos
        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + Genero + Environment.NewLine;
            retorno += "Título: " + Titulo + Environment.NewLine;
            retorno += "Descrição: " + Descricao + Environment.NewLine;
            retorno += "Excluido: " + Excluido + Environment.NewLine;
            retorno += "Ano de Início " + Ano;
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return Id;
        }

        public void Excluir()
        {
            Excluido = true;
        }

        public bool RetornaExcluido()
        {
            return Excluido;
        }

    }
}
