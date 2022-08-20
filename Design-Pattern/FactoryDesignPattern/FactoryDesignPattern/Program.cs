using System;
using System.Collections.Generic;

namespace FactoryDesignPattern
{
/*
    Kein guter Code ist es den genauen Klassennamen 
    beim Erstellen der Objekte durch den Client anzugeben, 
    was zu einer engen Kopplung zwischen dem Client und dem Produkt führt. 
    
    Um dieses Problem zu lösen, müssen wir das Factory Design Pattern verwenden. 
    
    Factory Design Pattern wenn

    1. Das Class-Objekt  mit Sub-Classes erweitert werden muss
       
    2. Klassen wissen nicht, welche Unterklassen sie erstellen müssen.
   
    3. Die Produktimplementierung wird sich im Laufe der Zeit ändern und der Client bleibt unverändert
*/

    class Program
    {
        static void Main(string[] args)
        {
            // let the factory do the job
            CreditCard? cardDetails = CreditCardFactory.GetCreditCard("MasterCard");

            if (cardDetails != null)
            {
                Console.WriteLine("CardType : " + cardDetails.GetCardType());
                Console.WriteLine("CreditLimit : " + cardDetails.GetCreditLimit());
                Console.WriteLine("AnnualCharge :" + cardDetails.GetAnnualCharge());
            }
            else
            {
                Console.Write("Invalid Card Type");
            }
            Console.ReadLine();
        }
    }

    class CreditCardFactory
    {
        public static CreditCard? GetCreditCard(string cardType)
        {
            CreditCard? cardDetails = null;
            if (cardType == "AmericanExpress")
            {
                cardDetails = new AmericanExpress();
            }
            else if (cardType == "MasterCard")
            {
                cardDetails = new MasterCard();
            }
            else if (cardType == "Visa")
            {
                cardDetails = new Visa();
            }
            return cardDetails;
        }
    }

    /// <summary>
    /// Product Interface
    /// </summary>
    public interface CreditCard
    {
        string GetCardType();
        int GetCreditLimit();
        int GetAnnualCharge();
    }

    /// <summary>
    /// Product Classe AmericanExpress
    /// </summary>
    class AmericanExpress : CreditCard
    {
        public string GetCardType()
        {
            return "AmericanExpress";
        }
        public int GetCreditLimit()
        {
            return 15000;
        }
        public int GetAnnualCharge()
        {
            return 500;
        }
    }
    /// <summary>
    /// Product Classe Master
    /// </summary>
    public class MasterCard : CreditCard
    {
        public string GetCardType()
        {
            return "MasterCard";
        }
        public int GetCreditLimit()
        {
            return 25000;
        }
        public int GetAnnualCharge()
        {
            return 1500;
        }
    }

    /// <summary>
    /// Product Classe Visa
    /// </summary>
    public class Visa : CreditCard
    {
        public string GetCardType()
        {
            return "Visa";
        }
        public int GetCreditLimit()
        {
            return 35000;
        }
        public int GetAnnualCharge()
        {
            return 2000;
        }
    }
}