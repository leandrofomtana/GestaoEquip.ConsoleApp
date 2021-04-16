using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEquip.ConsoleApp
{
    class Chamado
    {
        private string titulo;
        private string descricao;
        private Equipamento equipamento;
        private DateTime dataAbertura;

        public Chamado(string titulo, string descricao, Equipamento equipamento, DateTime dataAbertura)
        {
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Equipamento = equipamento;
            this.DataAbertura = dataAbertura;
        }

        public string Titulo { get => titulo; set => titulo = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public DateTime DataAbertura { get => dataAbertura; set => dataAbertura = value; }
        internal Equipamento Equipamento { get => equipamento; set => equipamento = value; }

        public string DiasAbertos()
        {
            string diasAbertos = (DateTime.Now - DataAbertura).Days.ToString();
            return diasAbertos;
        }

        public override string ToString()
        {
            return $"Título do chamado: {Titulo}\nDescrição do chamado: {Descricao}\nEquipamento: " +
                $"{Equipamento.Nome}\nData de Abertura: {dataAbertura}\nDias em aberto: {DiasAbertos()}";
        }
    }
}
