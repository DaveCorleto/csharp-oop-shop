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
            Console.WriteLine(Product.BasicPrice(guitar.Price));
            Console.WriteLine("Il prezzo ivato della Fender Mustang è: ");
            Console.WriteLine(Product.GeneraPriceIva(guitar.Price,guitar.Iva));
        }
    }

    public class Product
    {
        private int code;
        public int Code { 
            get { return code; }
        }
        //private int velocità;
        //public int Velocità
        //{
        //    get
        //    {
        //        return velocità;
        //    }
        //    set
        //    {
        //        velocità = value;
        //    }
        //}
        public string Name;
        public string Description;
        public decimal Price;
        public int Iva;

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

        public static decimal BasicPrice(decimal Price)
        {
            return Price;
        }
        public static decimal GeneraPriceIva(decimal Price,int Iva)
        {
             decimal PriceIva = (Price / 100) * (100 + Iva);
             return PriceIva;
        }
    }





    //Usate opportunamente i livelli di accesso (public, private), i costruttori, i metodi getter e setter ed eventuali altri metodi di “utilità” per fare in modo che:
    //    Gli altri attributi siano accessibili sia in lettura che in scrittura
    //Il prodotto esponga sia un metodo per avere il prezzo base che uno per avere il prezzo comprensivo di iva
    //Il prodotto esponga un metodo per avere il nome esteso, ottenuto concatenando codice + nome
    //    Testate poi i vostri oggetti Prodotto, istanziandoli e provando ad interargirci per testare tutti i metodi che avete previsto.
    //BONUS:
    //- create un metodo che restituisca il codice con un pad left di 0 per arrivare a 8 caratteri(ad esempio codice 91 diventa 00000091, mentre codice 123445567 resta come è)
    //- Usando un array, dichiarate un elenco dei prodotti di un negozio e inseriteci al suo interno qualche prodotto che vi aspettate di trovare nel negozio.Stampate poi l’elenco dei vostri prodotti che avete previsto nel negozio.
}
