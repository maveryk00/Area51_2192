using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHangManGame
{
    class Player
    {
        int hp = 3;

        public string Life() {
            return "HP = " + hp;
        }

        public string EnterWord() {
            Console.WriteLine("Ingrese una letra:");
            return Console.ReadLine();
        }

        public void Damage() {
            hp--;

            if (hp <= 0)
                hp = 0;
        }

        public bool IsDead() {
            return hp <= 0;
        }
    }
}
