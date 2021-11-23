using System.Collections.Generic;

namespace EssentialsExtended {
    public static partial class ESX {
        public static partial class UI {
            public class MenuData {
                public dynamic Raw;

                public MenuData(dynamic data) => Raw = data;

                public MenuData() {
                    Raw = new System.Dynamic.ExpandoObject();

                    Raw.title = new System.Dynamic.ExpandoObject();
                    Raw.align = new System.Dynamic.ExpandoObject();
                    Raw.elements = new System.Dynamic.ExpandoObject();
                    Raw.elements.head = new System.Dynamic.ExpandoObject();
                    Raw.elements.rows = new System.Dynamic.ExpandoObject();
                }

                public List<MenuElement> Elements {
                    get {
                        List<MenuElement> temp = new List<MenuElement>();
                        foreach(var i in Raw.elements)
                            temp.Add(new MenuElement(i));

                        return temp;
                    }
                    set => Raw.elements = value;
                }

                public string Title {
                    get => Raw.title;
                    set => Raw.title = value;
                }

                public string Align {
                    get => Raw.align;
                    set => Raw.align = value;
                }

                public string[] Head {
                    get => Raw.elements.head;
                    set => Raw.elements.head = value;
                }

                public dynamic Rows {
                    get => Raw.elements.rows;
                    set => Raw.elements.rows = value;
                }
            }
        }
    }
}