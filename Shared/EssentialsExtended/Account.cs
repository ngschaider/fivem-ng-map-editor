using System;

namespace EssentialsExtended {
    public class Account {

        public enum AccountType : int {
            Cash = 0,
            Bank = 1,
            Black = 2
        }

        public dynamic Raw;
        public string Name => Raw.name;
        public int Money => Convert.ToInt32(Raw.money);
        public string Label => Raw.label;

        public Account() {
        }

        public Account(dynamic data) => Raw = data;

    }
}
