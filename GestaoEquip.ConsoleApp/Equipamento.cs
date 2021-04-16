using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEquip.ConsoleApp
{
    class Equipamento
    {
        private string nome;
        private double preco;
        private int numeroSerie;
        private DateTime dataFabricacao;
        private string fabricante;

        public Equipamento(string nome, double preco, int numeroSerie, DateTime dataFabricacao, string fabricante)
        {
            this.Nome = nome;
            this.Preco = preco;
            this.NumeroSerie = numeroSerie;
            this.DataFabricacao = dataFabricacao;
            this.Fabricante = fabricante;
        }

        public string Nome { get => nome; set => nome = value; }
        public double Preco { get => preco; set => preco = value; }
        public int NumeroSerie { get => numeroSerie; set => numeroSerie = value; }
        public DateTime DataFabricacao { get => dataFabricacao; set => dataFabricacao = value; }
        public string Fabricante { get => fabricante; set => fabricante = value; }

        public override string ToString()
        {
            return $"Nome do equipamento: {Nome}\nPreço do equipamento: {Preco}\nNúmero de série: {NumeroSerie}" +
                $"\nData de Fabricação: {DataFabricacao}\nFabricante: {Fabricante}";
        }
    }
}
