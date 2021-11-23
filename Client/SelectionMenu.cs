using LemonUI;
using LemonUI.Menus;
using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgMapEditor.Client {
    //public class SelectionMenu {

    //    public event EventHandler<ObjectHash> Selected;

    //    private readonly NativeMenu menu = new NativeMenu("NG Map Editor");
    //    public SelectionMenu(ObjectPool pool) {
    //        pool.Add(menu);

    //        NativeMenu objMenu = new NativeMenu("Objekt hinzufügen");
    //        foreach(ObjectHash hash in Enum.GetValues(typeof(ObjectHash))) {
    //            NativeItem item = new NativeItem(hash.ToString());
    //            item.Activated += (object sender, EventArgs e) => {
    //                OnObjectCreated.Invoke(this, hash);
    //            };
    //        }
    //        menu.AddSubMenu(objMenu);
            
    //    }

    //    public void Process() {
    //        pool.Process();
    //    }

    //    public void Open() {
    //        menu.Visible = true;
    //    }

    //    public void Close() {
    //        menu.Visible = false;
    //    }

    //    public void Toggle() {
    //        menu.Visible = !menu.Visible;
    //    }

    //}
}
