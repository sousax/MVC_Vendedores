using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Vendedores
{
    internal class Venda
    {
        private int qtde;
        private double valor;

        public Venda(int qtde, double valor)
        {
            this.qtde = qtde;
            this.valor = valor;
        }

        public double ValorMedio()
        {
            return qtde > 0 ? valor / qtde : 0;
        }
    }
}
