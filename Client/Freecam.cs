using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgMapEditor.Client {
    public class Freecam : BaseScript {

        public Freecam() {
            EventHandlers["onResourceStop"] += new Action<string>(OnResourceStop);
            Tick += OnTick;
        }

        private static void OnResourceStop(string resourceName) {
            if(resourceName != API.GetCurrentResourceName()) {
                return;
            }
            SetActive(false);

            Debug.WriteLine("Closed Freecam environemnt");
        }

        public static Camera Camera {
            get;
            private set;
        }

        public static bool IsActive {
            get {
                return Camera != null;
            }
        }

        public static void SetActive(bool active) {
            if(active == IsActive) {
                return;
            }

            if(active) {
                Camera = World.CreateCamera(GameplayCamera.Position, GameplayCamera.Rotation, GameplayCamera.FieldOfView);
            } else {
                Camera.Delete();
            }

            Game.Player.CanControlCharacter = !active;
            API.RenderScriptCams(active, true, 500, false, false);
        }

        private static Task OnTick() {
            Update();
            return Task.FromResult(0);
        }

        private static void Update() {
            if(Camera == null || API.IsPauseMenuActive()) {
                return;
            }


            Vector3 move = new Vector3(0, 0, 0);
            if(Game.IsControlPressed(0, Control.MoveLeftOnly)) {
                move.X--;
            }
            if(Game.IsControlPressed(0, Control.MoveRightOnly)) {
                move.X++;
            }
            if(Game.IsControlPressed(0, Control.MoveUpOnly)) {
                move.Y++;
            }
            if(Game.IsControlPressed(0, Control.MoveDownOnly)) {
                move.Y--;
            }
            if(Game.IsControlPressed(0, Control.Cover)) {
                move.Z--;
            }
            if(Game.IsControlPressed(0, Control.Pickup)) {
                move.Z++;
            }

            int moveSpeed = Game.IsControlPressed(0, Control.Sprint) ? 2 : 1;
            Camera.Position += MathUtils.RotateVector3(move * moveSpeed, Camera.Rotation);


            Vector3 keyRot = new Vector3(0, 0, 0);
            if(Game.IsControlPressed(0, Control.VehicleFlyRollLeftOnly)) {
                Debug.WriteLine("z++");
                keyRot.Z++;
            }
            if(Game.IsControlPressed(0, Control.VehicleFlyRollRightOnly)) {
                Debug.WriteLine("z--");
                keyRot.Z--;
            }
            if(Game.IsControlPressed(0, Control.VehicleFlyPitchDownOnly)) {
                Debug.WriteLine("x--");
                keyRot.X--;
            }
            if(Game.IsControlPressed(0, Control.VehicleFlyPitchUpOnly)) {
                Debug.WriteLine("x++");
                keyRot.X++;
            }
            //if(Game.IsControlPressed(0, Control.VehicleFlyYawLeft)) {
            //    rot.Y--;
            //}
            //if(Game.IsControlPressed(0, Control.VehicleFlyYawRight)) {
            //    rot.Y++;
            //}

            const float keyRotSpeed = 1.0f;

            Vector3 mouseRot = new Vector3(0, 0, 0);
            mouseRot.Z = -Game.GetDisabledControlNormal(0, Control.LookLeftRight);
            mouseRot.X = -Game.GetDisabledControlNormal(0, Control.LookUpDown);

            const float mouseRotSpeed = 3.5f;

            Vector3 newRot = Camera.Rotation + keyRot * keyRotSpeed + mouseRot * mouseRotSpeed;
            newRot.X = MathUtils.Clamp(newRot.X, -89.9f, 89.9f);
            //newRot.Z = MathUtils.Clamp(newRot.Z, -90, 90);

            Camera.Rotation = newRot;

            //camera.Rotation = new Vector3(MathUtils.Clamp(camera.Rotation.X, -90, 90), 0, MathUtils.Clamp(camera.Rotation.Z, -90, 90));

            //Debug.WriteLine(camera.Rotation.X + "/" + camera.Rotation.Y + "/" + camera.Rotation.Z);

            //Debug.WriteLine(camera.Rotation.X.ToString());
            //camera.Rotation = new Vector3(Math.Max(Math.Min(camera.Rotation.X, 360), 0), 0, Math.Max(Math.Min(camera.Rotation.Z, 360), 0));
        }

    }
}
