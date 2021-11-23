using LemonUI;
using LemonUI.Menus;
using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgMapEditor.Client {
    public class EditMenu {

        public event EventHandler<ObjectHash> OnObjectCreated;

        private readonly NativeMenu menu = new NativeMenu("Objekt bearbeiten");
        public EditMenu(ObjectPool pool) {
            pool.Add(menu);

            NativeMenu objMenu = new NativeMenu("Objekt hinzufügen");
            foreach(ObjectHash hash in Enum.GetValues(typeof(ObjectHash))) {
                NativeItem item = new NativeItem(hash.ToString());
                item.Activated += (object sender, EventArgs e) => {
                    OnObjectCreated.Invoke(this, hash);
                };
            }
            menu.AddSubMenu(objMenu);
        }

        public event EventHandler<EditMode> EditModeChanged;

        private Prop prop;

        public void Edit(Prop prop) {
            this.prop = prop;
            menu.Visible = true;
        }

        public void Close() {
            menu.Visible = false;
        }

    }

    public enum EditMode {
        Rotation,
        Position,
    }
}
