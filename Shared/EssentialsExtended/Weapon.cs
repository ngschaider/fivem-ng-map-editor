using System.Collections.Generic;

namespace EssentialsExtended {
    public class Weapon {

        public dynamic Raw;
        public string Name => Raw.name;
        public int Ammo => Raw.ammo;
        public string Label => Raw.label;
        public int TintIndex => Raw.tintIndex;

        public List<string> Components {
            get {
                List<string> temp = new List<string>();
                foreach(var i in Raw.components) {
                    temp.Add(i);
                }

                return temp;
            }
        }

        public Weapon() {
        }

        public Weapon(dynamic data) => Raw = data;

    }
}