using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Vendedores
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vendedores vendedores = new Vendedores(10);

            while (true)
            {
                Console.WriteLine("\nMenu de Opções:");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Cadastrar vendedor");
                Console.WriteLine("2. Consultar vendedor");
                Console.WriteLine("3. Excluir vendedor");
                Console.WriteLine("4. Registrar venda");
                Console.WriteLine("5. Listar vendedores");
                Console.Write("Escolha uma opção: ");
                int opcao = int.Parse(Console.ReadLine());

                if (opcao == 0)
                    break;

                switch (opcao)
                {
                    case 1:
                        Console.Write("Digite o ID do vendedor: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Digite o nome do vendedor: ");
                        string nome = Console.ReadLine();
                        Console.Write("Digite a porcentagem de comissão: ");
                        double percComissao = double.Parse(Console.ReadLine());
                        Vendedor vendedor = new Vendedor(id, nome, percComissao);
                        if (vendedores.AddVendedor(vendedor))
                            Console.WriteLine("Vendedor cadastrado com sucesso.");
                        else
                            Console.WriteLine("Limite de vendedores atingido.");
                        break;
                    
                    case 2:
                        Console.Write("Digite o ID do vendedor: ");
                        id = int.Parse(Console.ReadLine());
                        vendedor = vendedores.SearchVendedor(id);
                        if (vendedor != null)
                        {
                            Console.WriteLine($"ID: {vendedor.Id}, Nome: {vendedor.Nome}");
                            Console.WriteLine($"Total de vendas: {vendedor.ValorVendas():C}");
                            Console.WriteLine($"Comissão: {vendedor.ValorComissao():C}");
                        }
                        else
                        {
                            Console.WriteLine("Vendedor não encontrado.");
                        }
                        break;
                    
                    case 3:
                        Console.Write("Digite o ID do vendedor para excluir: ");
                        id = int.Parse(Console.ReadLine());
                        if (vendedores.DelVendedor(id))
                            Console.WriteLine("Vendedor excluído com sucesso.");
                        else
                            Console.WriteLine("Erro ao excluir vendedor.");
                        break;
                    
                    case 4:
                        Console.Write("Digite o ID do vendedor: ");
                        id = int.Parse(Console.ReadLine());
                        vendedor = vendedores.SearchVendedor(id);
                        if (vendedor != null)
                        {
                            Console.Write("Digite o dia da venda: ");
                            int dia = int.Parse(Console.ReadLine());
                            Console.Write("Digite a quantidade de itens vendidos: ");
                            int qtde = int.Parse(Console.ReadLine());
                            Console.Write("Digite o valor total da venda: ");
                            double valor = double.Parse(Console.ReadLine());
                            Venda venda = new Venda(qtde, valor);
                            vendedor.RegistrarVenda(dia, venda);
                            Console.WriteLine("Venda registrada com sucesso.");
                        }
                        else
                        {
                            Console.WriteLine("Vendedor não encontrado.");
                        }
                        break;
                    
                    case 5:
                            vendedores.ListarVendedores();
                        break;
                    
                    default:
                            Console.WriteLine("Opção inválida.");
                        break;
                }

            }
        }
    }
}
