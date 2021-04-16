using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEquip.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Equipamento[] equipamentos = new Equipamento[100];
            Chamado[] chamados = new Chamado[100];
            int numeroChamados = 1;
            int numeroEquipamentos = 1;
            while (true)
            {
                Console.Clear();
                MenuPrincipal();
                string op = Console.ReadLine();
                if (op == "1")
                {
                    while (true)
                    {
                        Console.Clear();
                        MenuEquipamento();
                        op = Console.ReadLine();
                        if (op == "1") { 
                            CriarEquipamento(equipamentos, numeroEquipamentos); 
                            numeroEquipamentos++;
                            continue;
                        }
                        else if (op == "2") { VisualizarEquipamentos(equipamentos); continue; }
                        else if (op == "3") { EditarEquipamento(equipamentos, numeroEquipamentos); continue; }
                        else if (op == "4") { RemoverEquipamento(equipamentos, numeroEquipamentos); continue; }
                        else { break; }
                    }
                }
                else if (op == "2")
                {
                    while (true)
                    {
                        Console.Clear();
                        MenuChamadas();
                        op = Console.ReadLine();
                        if (op == "1")
                        {
                            CriarChamado(chamados, numeroChamados, equipamentos);
                            numeroChamados++;
                            continue;
                        }
                        else if (op == "2") { VisualizarChamados(chamados); continue; }
                        else if (op == "3") { EditarChamado(chamados, numeroChamados, equipamentos); continue; }
                        else if (op == "4") { RemoverChamado(chamados, numeroChamados); continue; }
                        else { break; }
                    }
                }
                else { break; }

            }

        }
        private static void EditarChamado(Chamado[] chamados, int numeroChamados, Equipamento[] equipamentos)
        {
            Console.WriteLine("Digite o número do chamado que deseja editar: ");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n > numeroChamados || n < 1 || chamados[n] == null)
            {
                Console.WriteLine("Digite um número existente.");
            }
            else
            {
                CriarChamado(chamados, n, equipamentos);
            }
        }

        private static void RemoverChamado(Chamado[] chamados, int numeroChamados)
        {
            Console.WriteLine("Digite o número do chamado que deseja remover: ");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n > numeroChamados || n < 1 || chamados[n] == null)
            {
                Console.WriteLine("Digite um número existente.");
            }
            else { chamados[n] = null; }
        }
        private static void VisualizarChamados(Chamado[] chamados)
        {
            int i = 0;
            foreach (Chamado chamado in chamados)
            {
                if (!(chamado == null))
                {
                    Console.WriteLine($"Número do chamado: {i}");
                    Console.WriteLine(chamado);
                    Console.WriteLine();
                }
                i++;
            }
            Console.ReadLine();
        }

        private static void CriarChamado(Chamado[] chamados, int numeroChamados, Equipamento[] equipamentos)
        {
            Equipamento equipamento;
            Console.WriteLine("Digite o título do chamado: ");
            string titulo = Console.ReadLine();
            Console.WriteLine("Digite a descrição do chamado: ");
            string descricao = Console.ReadLine();
            while (true)
            {
                Console.WriteLine("Digite o número do equipamento: ");
                int n = Convert.ToInt32(Console.ReadLine());
                if (equipamentos[n] == null) {
                    Console.WriteLine("Não existe equipamento com esse número");
                    continue;
                }
                else { equipamento = equipamentos[n]; break; }
            }
            DateTime dataAbertura = DateTime.Now;
            Chamado chamado = new Chamado(titulo, descricao, equipamento, dataAbertura);
            chamados[numeroChamados] = chamado;
            Console.WriteLine("Chamado criado com sucesso!");
            Console.ReadLine();
        }

        private static void MenuChamadas()
        {
            Console.WriteLine("Controle de Chamados de Manutenção");
            Console.WriteLine("Digite 1 para registrar um novo chamado");
            Console.WriteLine("Digite 2 para visualizar todos os chamados registrados");
            Console.WriteLine("Digite 3 para editar um chamado");
            Console.WriteLine("Digite 4 para excluir um chamado do registro");
            Console.WriteLine("Digite qualquer outra tecla para voltar ao menu principal");
        }

        private static void RemoverEquipamento(Equipamento[] equipamentos, int numeroEquipamentos)
        {
            Console.WriteLine("Digite o número do equipamento que deseja remover: ");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n > numeroEquipamentos || n < 1 || equipamentos[n] == null)
            {
                Console.WriteLine("Digite um número existente.");
            }
            else { equipamentos[n] = null; }
        }

        private static void EditarEquipamento(Equipamento[] equipamentos, int numeroEquipamentos)
        {
            Console.WriteLine("Digite o número do equipamento que deseja editar: ");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n > numeroEquipamentos || n < 1 || equipamentos[n]==null)
            {
                Console.WriteLine("Digite um número existente.");
            }
            else
            {
                CriarEquipamento(equipamentos, n);
            }
        }

        private static void VisualizarEquipamentos(Equipamento[] equipamentos)
        {
            int i=0;
            foreach (Equipamento equip in equipamentos)
            {
                if(!(equip==null))
                {
                    Console.WriteLine($"Número do equipamento: {i}");
                    Console.WriteLine(equip);
                    Console.WriteLine();
                }
                i++;
            }
            Console.ReadLine();
        }

        private static void CriarEquipamento(Equipamento[] equipamentos, int numeroEquipamentos)
        {
            string nome;
            while (true)
            {
                Console.WriteLine("Digite o nome do equipamento: ");
                nome = Console.ReadLine();
                if (nome.Length < 6)
                {
                    Console.WriteLine("Nome inválido. No mínimo 6 caracteres");
                    continue;
                }
                else { break; }
            }
            Console.WriteLine("Digite o preço do equipamento: ");
            double preco = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Digite o número de série: ");
            int nSerie = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite a data de fabricação(formato DD/MM/YYYY): ");
            DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Digite o fabricante do equipamento: ");
            string fabricante = Console.ReadLine();
            Equipamento equipamento = new Equipamento(nome, preco, nSerie, dataFabricacao, fabricante);
            equipamentos[numeroEquipamentos] = equipamento;
            Console.WriteLine("Equipamento criado com sucesso!");
            Console.ReadLine();
        }

        private static void MenuEquipamento()
        {
            Console.WriteLine("Controle de Equipamentos");
            Console.WriteLine("Digite 1 para registrar um novo equipamento");
            Console.WriteLine("Digite 2 para visualizar todos os equipamentos registrados");
            Console.WriteLine("Digite 3 para editar um equipamento");
            Console.WriteLine("Digite 4 para excluir um equipamento do registro");
            Console.WriteLine("Digite qualquer outra tecla para voltar ao menu principal");
        }

        private static void MenuPrincipal()
        {
            Console.WriteLine("Gestão de Equipamentos");
            Console.WriteLine("Digite 1 para o Controle de Equipamentos");
            Console.WriteLine("Digite 2 para o Controle de Chamados");
            Console.WriteLine("Digite alguma tecla além de 1 e 2 para sair do programa");
        }
    }
}
