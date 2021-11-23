using System.Collections.Generic;
using CitizenFX.Core;

namespace EssentialsExtended {
    public class PlayerData {
        public dynamic Raw;

        public PlayerData() {
        }

        public PlayerData(dynamic data) => Raw = data;

        public Job Job => new Job(Raw.job);

        public Vector3 Coords => new Vector3((float)Raw.coords.x, (float)Raw.coords.y, (float)Raw.coords.z);

        public double Heading => Raw.coords.heading;

        public double MaxWeight => Raw.maxWeight;

        public List<Weapon> Loadout {
            get {
                List<Weapon> temp = new List<Weapon>();
                var loadout = Raw.loadout;

                foreach(var i in loadout) {
                    temp.Add(new Weapon(i));
                }

                return temp;
            }
        }

        public Account[] Accounts {
            get {
                Account[] accounts = new Account[3];
                var raw = Raw.accounts;
                for(int i = 0; i < 3; i++)
                    accounts[i] = new Account(raw[i]);

                return accounts;
            }
        }

        public List<InventoryItem> Inventory {
            get {
                List<InventoryItem> inventory = new List<InventoryItem>();
                var rawdata = Raw.inventory;
                foreach(var i in rawdata) {
                    inventory.Add(new InventoryItem(i));
                }

                return inventory;
            }
        }
    }
}