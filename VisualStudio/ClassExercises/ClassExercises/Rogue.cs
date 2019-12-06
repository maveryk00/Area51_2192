using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassExercises
{
    class Rogue : Character
    {
        public int stamina;

        public Rogue(string name) : base(name) {
            Console.WriteLine(">Creando Rogue");
        }

        public Rogue(string name, int hp) : base(name, hp) {
        }

        public Rogue(string name, int hp, Stats stats) : base(name, hp, stats) {
        }

        public void Steal() {
            Console.WriteLine("Steal");
        }
    }
}
