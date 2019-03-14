using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.scripts {
    class weapon {
        public weapon(string n, int dmg) 
        {
            name = n;
            damage = dmg;
        }
        private string name;
        private int damage;

        public int getdmg() { return damage; }
        public string getname() { return name; }

    }
}
