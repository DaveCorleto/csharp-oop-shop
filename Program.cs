using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System;

namespace csharp_oop_shop
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // Creazione di istanze di Product
            Product book = new Product("La Nave di Teseo", "Bellissimo libro", 17.99m, 22);
            Product guitar = new Product("Fender Mustang", "La chitarra di Kurt", 1345, 23);
            Product headphones = new Product("Beyerdynamic DT770PRO", "Cuffie da studio", 139, 20);

            Console.WriteLine(book.Code);
            Console.WriteLine(guitar.Code);
            Console.WriteLine(headphones.Code);

            Console.WriteLine("Il prezzo base della Fender Mustang è: ");
            Console.WriteLine(guitar.BasicPrice());

            Console.WriteLine("Il prezzo ivato della Fender Mustang è: ");
            Console.WriteLine(guitar.GeneraPriceIva(guitar.Price, guitar.Iva));

            Console.WriteLine("Proviamo la Funzione Nome esteso: ");
            Console.WriteLine(guitar.GeneraNomeEsteso(guitar.Code, guitar.Name));
            Console.WriteLine(book.GeneraNomeEsteso(book.Code, book.Name));
            Console.WriteLine(headphones.GeneraNomeEsteso(headphones.Code, headphones.Name));


            Console.WriteLine("Proviamo il metodo per avere il padding a 8 caratteri:");
            Console.WriteLine(guitar.GetPaddedCode());

            // Bonus: Elenco dei prodotti del negozio
            Product[] products = new Product[]
            {
            book,
            guitar,
            headphones
            };

            Console.WriteLine("Elenco dei prodotti nel negozio:");
            foreach (var product in products)
            {
                Console.WriteLine($"Codice: {product.GetPaddedCode()}, Nome: {product.Name}, Prezzo: {product.Price}, IVA: {product.Iva}");
            }
        }
    }

    public class Product
    {
        private int code;
        public int Code { get { return code; } }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private decimal price;
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        private int iva;
        public int Iva
        {
            get { return iva; }
            set { iva = value; }
        }

        public Product(string name, string description, decimal price, int iva)
        {
            this.code = GeneraCodeRandom();
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Iva = iva;
        }

        public static int GeneraCodeRandom()
        {
            Random random = new Random();
            return random.Next(100000, 999999);
        }

        public decimal BasicPrice()
        {
            return Price;
        }

        public decimal GeneraPriceIva(decimal price, int iva)
        {
            decimal priceIva = (price / 100) * (100 + iva);
            return priceIva;
        }

        public string GeneraNomeEsteso(int code, string name)
        {
            string codeString = Convert.ToString(code);
            string extendedName = $"{codeString} - {name}";
            return extendedName;
        }
        public string GetPaddedCode()
        {
            return code.ToString().PadLeft(8, '0');
        }
    }
}




    //BONUS:
    //- create un metodo che restituisca il codice con un pad left di 0 per arrivare a 8 caratteri(ad esempio codice 91 diventa 00000091, mentre codice 123445567 resta come è)
    //- Usando un array, dichiarate un elenco dei prodotti di un negozio e inseriteci al suo interno qualche prodotto che vi aspettate di trovare nel negozio.Stampate poi l’elenco dei vostri prodotti che avete previsto nel negozio.

