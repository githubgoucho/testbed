using System;
using System.Collections.Generic;

/*  https://dotnettutorials.net/lesson/singleton-design-pattern/
 * Das Singleton-Entwurfsmuster
 * Nur eine Instanz einer bestimmten Klasse
 * 
 * Globaler Zugriff auf diese Instanz für die gesamte Anwendung.
 * 
 * Nachteile der Verwendung
 * 
 * 1. Komponententests sind sehr schwierig, da sie einen globalen Zustand in eine Anwendung einführen.
 * 
 * 2. Es reduziert das Potenzial für Parallelität innerhalb eines Programms, 
 *    da Sie das Objekt mithilfe von Sperren serialisieren müssen, 
 *    um auf die Singleton-Instanz in einer Umgebung mit mehreren Threads zuzugreifen.
 *    
 * Implementierungsrichtlinien
 * 
 * 1. Sie müssen einen Konstruktor deklarieren, der privat und parameterlos sein sollte. 
 *    Dies ist erforderlich, da die Klasse nicht von außerhalb der Klasse instanziiert werden darf. 
 *    Es wird nur innerhalb der Klasse instanziiert.
 *    
 * 2. Die Klasse sollte als versiegelt deklariert werden, um sicherzustellen, dass sie nicht vererbt werden kann. 
 *    Dies wird nützlich sein, wenn Sie mit der verschachtelten Klasse arbeiten. 
 *    
 * 3. Sie müssen eine private statische Variable erstellen, 
 *    die einen Verweis auf die einzelne erstellte Instanz der Klasse enthält, falls vorhanden.
 *    
 * 4. Sie müssen eine öffentliche statische Eigenschaft/Methode erstellen, 
 *    die die einzeln erstellte Instanz der Singleton-Klasse zurückgibt. 
 *    Diese Methode oder Eigenschaft überprüft zuerst, ob eine Instanz der Singleton-Klasse verfügbar ist oder nicht. 
 *    Wenn die Singleton-Instanz verfügbar ist, wird diese Singleton-Instanz zurückgegeben, 
 *    andernfalls wird eine Instanz erstellt und dann diese Instanz zurückgegeben.
 */

namespace SingletonDemo
{
    //   sealed  Sealed classes are used to restrict the users from inheriting the class.
    public  class Singleton
    {
        private static int counter = 0;
        private static Singleton? instance = null;
        public static Singleton GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new Singleton();
                return instance;
            }
        }

        private Singleton()
        {
            counter++;
            Console.WriteLine("Instanace " + counter.ToString());
        }

        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Singleton fromTeachaer = Singleton.GetInstance;
            fromTeachaer.PrintDetails("first Teacher");

            Singleton fromStudent = Singleton.GetInstance;
            fromStudent.PrintDetails("second Student");

            Console.ReadLine();
        }
    }
}