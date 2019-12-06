using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassExercises
{
    class Program
    {
        static void Main(string[] args) {

            Console.WriteLine("Character type:");
            Console.WriteLine("\t1-Wizard");
            Console.WriteLine("\t2-Warrior");
            Console.WriteLine("\t3-Rogue");
            string type = Console.ReadLine();

            Console.WriteLine("Name:");
            string name = Console.ReadLine();

            Character myCharacter = null;
            switch (type) {
                case "1":
                    myCharacter = new Wizard(name);
                    break;

                case "2":
                    myCharacter = new Warrior(name);
                    break;

                case "3":
                    myCharacter = new Rogue(name);
                    break;

                default:
                    Console.WriteLine("No DLC");
                    break;
            }

            if (myCharacter != null)
                myCharacter.ShowActionMenu();


            Console.ReadLine();
        }
    }
}
