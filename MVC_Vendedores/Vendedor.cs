using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Vendedores
{
    internal class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double PercComissao { get; set; }
        public Venda[] AsVendas { get; set; }

        public Vendedor(int id, string nome, double percComissao)
        {
            Id = id;
            Nome = nome;
            PercComissao = percComissao;
            AsVendas = new Venda[31];
        }

        public void RegistrarVenda(int dia, Venda venda)
        {
            if (dia < 1 || dia > 31)
            {
                Console.WriteLine("Dia inválido!");
                return;
            }
            AsVendas[dia - 1] = venda;
        }

        public double ValorVendas()
        {
            double total = 0;
            foreach (var venda in AsVendas)
            {
                if (venda != null)
                {
                    total += venda.ValorMedio();
                }
            }
            return total;
        }

        public double ValorComissao()
        {
            return ValorVendas() * PercComissao / 100;
        }
    }
}
