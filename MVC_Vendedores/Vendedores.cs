using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Vendedores
{
    internal class Vendedores
    {
        public Vendedor[] OsVendedores { get; set; }
        public int max { get; set; }
        public int qtde { get; set; }

        public Vendedores(int max)
        {
            this.max = max;
            OsVendedores = new Vendedor[max];
            qtde = 0;
        }

        public bool AddVendedor(Vendedor v)
        {
            if (qtde < max)
            {
                OsVendedores[qtde++] = v;
                return true;
            }
            return false;
        }

        public bool DelVendedor(int id)
        {
            for (int i = 0; i < qtde; i++)
            {
                if (OsVendedores[i].Id == id)
                {
                    if (OsVendedores[i].ValorVendas() == 0)
                    {
                        for (int j = i; j < qtde - 1; j++)
                        {
                            OsVendedores[j] = OsVendedores[j + 1];
                        }
                        OsVendedores[--qtde] = null;
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Não é possível excluir um vendedor com vendas registradas.");
                        return false;
                    }
                }
            }
            return false;
        }
        public Vendedor SearchVendedor(int id)
        {
            for (int i = 0; i < qtde; i++)
            {
                if (OsVendedores[i] != null && OsVendedores[i].Id == id)
                {
                    return OsVendedores[i];
                }
            }
            return null;
        }
        public void ListarVendedores()
        {
            double totalVendas = 0;
            double totalComissao = 0;
            Console.WriteLine("Lista de Vendedores:");
            for (int i = 0; i < qtde; i++)
            {
                if (OsVendedores[i] != null)
                {
                    Console.WriteLine($"ID: {OsVendedores[i].Id}, Nome: {OsVendedores[i].Nome}, Valor Total de Vendas: {OsVendedores[i].ValorVendas():C}, Comissão:{OsVendedores[i].ValorComissao():C} ");
                    totalVendas += OsVendedores[i].ValorVendas();
                    totalComissao += OsVendedores[i].ValorComissao();
                }
            }
            Console.WriteLine($"Total de Vendas: {totalVendas:C}");
            Console.WriteLine($"Total de Comissões: {totalComissao:C}");
        }
    }
}
