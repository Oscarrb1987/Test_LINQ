using System;
using System.Collections.Generic;
using System.Linq;


namespace Test_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Ej 1
             */
            int[] numeros = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var pares = from n in numeros
                        where (n % 2 == 0)
                        select n;
            
            Console.WriteLine("Números pares: ");
            foreach (int n in pares)
            {
                Console.Write($"{n} ");
            }

            Console.WriteLine();
            Console.WriteLine();
            
            /*
             * Ej 2
             */
           
            int[] numeros2 = { 1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14 };

            var numerosRango = from n in numeros2
                               where (n > 1) && (n < 12)
                               select n;
            Console.WriteLine("Números entre 1 y 12: ");
            foreach (int n in numerosRango)
            {
                Console.Write($"{n} ");
            }

            Console.WriteLine();
            Console.WriteLine();
            
            /*
             * Ej 3
             */
            
            int[] numeros3 = { 3, 9, 2, 8, 6, 5 };
            var cuadrados = from n in numeros3
                            select (n * n);
            foreach (int n in cuadrados)
            {
                Console.WriteLine($"Número: {Math.Sqrt(n)}. Cuadrado: {n}");
            }

            Console.WriteLine();
            
            /*
             * Ej 4
             */
            
            int[] numeros4 = { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2 };
            var frecuencias = from n in numeros4
                              group n by n into veces
                              select new
                              {
                                  numero = veces.Key,
                                  numVeces = veces.Count()
                              };
            foreach (var n in frecuencias)
            {
                Console.WriteLine($"El número {n.numero} aparece {n.numVeces} veces.");
            }

            Console.WriteLine();
            
            /*
             * Ej 5
             */
            
            string[] ciudades = { "ROMA", "LONDRES", "ZARAGOZA", "A CORUÑA", "ZURICH", "BERLIN", "AMSTERDAM", "AMBERES", "PARIS" };
            var ciudadBuscada = from c in ciudades
                                where c.StartsWith("A") && c.EndsWith("M")
                                select c;
            foreach (var c in ciudadBuscada)
            {
                Console.WriteLine($"La ciudad buscada es {c}");
            }

            Console.WriteLine();
            
            /*
             * Ej 6
             */
            
            int[] numeros6 = { 5, 7, 13, 9, 55, 4, 16 };
            int cantidad;
            Console.WriteLine("Introducir la cantidad de números más altos: ");
            cantidad = int.Parse(Console.ReadLine());
            var numerosAltos = (from n in numeros6
                                orderby n descending
                                select n).Take(cantidad);
            Console.WriteLine($"Los {cantidad} números más altos son: ");
            foreach (var n in numerosAltos)
            {
                Console.Write($"{n} ");
            }

            Console.WriteLine();
            Console.WriteLine();
            
            /*
             * Ej 7
             */
            
            string palabra;
            char[] letras;
            char[] letrasResultado;
            char letraEliminar;
            Console.WriteLine("Introducir una palabra: ");
            palabra = Console.ReadLine();
            letras = palabra.ToCharArray();
            foreach (char letra in letras)
            {
                Console.WriteLine($"Carácter: {letra}");
            }
            Console.WriteLine("Elige la letra a eliminar: ");
            letraEliminar = char.Parse(Console.ReadLine());

            char[] Remove(char[] palabraInicio, char letra)
            {
                var palabraDevuelta = palabraInicio.Where(x => x != letra).ToArray();
                return palabraDevuelta;
            }

            letrasResultado = Remove(letras, letraEliminar);
            foreach (char l in letrasResultado)
            {
                Console.WriteLine($"Carácter: {l}");
            }

            Console.WriteLine();
            
            /*
             * Ej 8
             */
            
            char[] conjuntoLetras = { 'a', 'b', 'c' };
            int[] conjuntoNumeros = { 1, 2, 3 };
            var productoCartesiano = from l in conjuntoLetras
                                     from n in conjuntoNumeros
                                     select new
                                     {
                                         LetraPC = l,
                                         NumeroPC = n
                                     };
            Console.WriteLine("Resultado del producto cartesiano: ");
            foreach (var elemento in productoCartesiano)
            {
                Console.Write($"({elemento.LetraPC}, {elemento.NumeroPC}), ");
            }

            Console.WriteLine();
            Console.WriteLine();
            
            /*
             * Ej 9
             */
            
            List<List<int>> numeros9 = new List<List<int>>()
            {
                new List<int>() {1, 2, 3, 4},
                new List<int>() {5, 6, 7, 8},
                new List<int>() {9, 10, 11, 12},
                new List<int>() {13, 14, 15, 16}
            };

            var result = numeros9
                .SelectMany(inner => inner.Select((item, index) => new { item, index }))
                .GroupBy(i => i.index, i => i.item)
                .Select(g => g.ToList())
                .ToList();

            foreach (List<int> listInt in result)
            {
                foreach (int e in listInt)
                {
                    Console.Write($"{e} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            
            /*
             * Ej 10
             */
            
            var daysNames = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>();
            foreach (var day in daysNames)
            {
                Console.WriteLine($"{day}");
            }

            Console.WriteLine();
            
            /*
             * Ej 11
             */
            
            List<Customer> customers = new List<Customer>() {
                new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };
            var millonarios = from c in customers
                              where c.Balance > 1000000
                              group c by c.Bank into numeroMillonarios
                              select new
                              {
                                  Banco = numeroMillonarios.Key,
                                  NumMillonarios = numeroMillonarios.Count()
                              };
            foreach (var millonario in millonarios)
            {
                Console.WriteLine($"El banco {millonario.Banco} tiene {millonario.NumMillonarios} millonarios.");
            }

            Console.ReadKey();
        }

    }

    internal class Customer
    {
        public string Name { get; internal set; }
        public double Balance { get; internal set; }
        public string Bank { get; internal set; }
    }
}