using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCadastro
{
    class Pedido
    {
        int ID_pedido;
        int produto;
        string cliente;
        int valor;

        public int ID_pedido1 { get => ID_pedido; set => ID_pedido = value; }
        public int Produto { get => produto; set => produto = value; }
        public string Cliente { get => cliente; set => cliente = value; }
        public int Valor { get => valor; set => valor = value; }
    }
}
