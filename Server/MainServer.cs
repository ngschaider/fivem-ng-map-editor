using CitizenFX.Core;
using EssentialsExtended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NgMapEditor.Server {
    class MainServer : BaseScript {

        public MainServer() {
            Tick += OnTick;
        }

        private Task OnTick() {
            return Task.FromResult(1);
        }
    }
}
