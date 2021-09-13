using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dio.Series {
    public class Serie : EntidadeBase {

        // Atributos
        private Genero Genero { get; set; }

        private string Titulo { get; set; }

        private string Descricao { get; set; }

        private int Ano { get; set; }

        private bool Excluido { get; set; }

        //Metodos

        public Serie(int id, Genero Genero, string Titulo, string Descricao, int Ano) {

            this.id = id;
            this.Genero = Genero;
            this.Titulo = Titulo;
            this.Descricao = Descricao;
            this.Ano = Ano;
            this.Excluido = false;
        }

        public override string ToString() {

            string retorno = "";
            retorno += "Genero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descricao: " + this.Descricao + Environment.NewLine;
            retorno += "Ano: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;

        }

        public string retornaTitulo() {

            return this.Titulo;

        }

        public int retornaId() {

            return this.id;
        }

        public bool retornaExcluido() {

            return this.Excluido;
        }

        public void Excluir() {

            this.Excluido = true;
        }
    }
}
