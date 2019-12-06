using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassExercises
{
    class Wizard : Character
    {
        public int mp;

        public Wizard(string name) : base(name) {
            Console.WriteLine(">Creando Wizard");
        }

        public Wizard(string name, int hp, int mp) : base(name, hp) {
            this.mp = mp;
        }

        public Wizard(string name, int hp, int mp, Stats stats) : base(name, hp, stats) {
        }

        public void Cast() {
            Console.WriteLine("Cast");
        }


        public override void ShowActionMenu() {
            base.ShowActionMenu();
            Console.WriteLine("4 - cast");

            string action = Console.ReadLine();
            switch (action) {
                case "1":
                    Walk();
                    break;

                case "2":
                    Jump();
                    break;

                case "3":
                    Attack();
                    break;

                case "4":
                    Cast();
                    break;
            }

            ShowActionMenu();
        }



    }
}
