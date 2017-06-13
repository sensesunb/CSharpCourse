using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\users\\Cris\\Desktop\\dunkindonuts.txt";
            string[] array = File.ReadAllLines(path);
            string[] clientes = new string[] { "Pedro", "Fabiana", "Cris" } ;
            List<Coffee> listOfCoffees = new List<Coffee>();
            Coffee coffee;

            for (int i = 0; i < array.Length; i++)
            {
                int preco = int.Parse(array[i].Split('$')[1]);
                string nome = array[i].Split(':')[0];
                coffee = new Coffee(preco, nome);
                listOfCoffees.Add(coffee);
            }

            for (int i = 0; i < clientes.Count(); ++i)
            {
                string cliente = clientes[i];
                string caminho = $"C:\\users\\Cris\\Desktop\\{cliente}.txt";
                string[] cafes = File.ReadAllLines(caminho);
                Pedido pedido = new Pedido(listOfCoffees, cafes);
                Console.WriteLine($"{cliente}:");
                pedido.Mostrar();
            }

            Console.ReadLine();
        }
    }

    class Coffee
    {
        public int Preco { get; private set; }
        public string Nome { get; private set; }

        public Coffee(int preco, string nome)
        {
            Nome = nome;
            Preco = preco;
        }
    }

    class Pedido
    {
        public Pedido(List<Coffee> menu, string[] pedido)
        {
            Cafes = pedido;
            for (int i = 0; i < pedido.Length; i++)
            {
                for (int j = 0; j < menu.Count; j++)
                {
                    if (menu[j].Nome == pedido[i])
                    {
                        Total = Total + menu[j].Preco;
                    }
                }
            }
        }

        public void Mostrar()
        {
            for (int i = 0; i < Cafes.Length; ++i)
            {
                Console.WriteLine(Cafes[i]);
            }
            Console.WriteLine($"Valor total: {Total}");
        }

        public int Total { get; private set; } = 0;
        public string[] Cafes { get; private set; }
    }
}
