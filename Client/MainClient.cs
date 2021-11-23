using CitizenFX.Core;
using CitizenFX.Core.Native;
using LemonUI;
using LemonUI.Menus;
using System;
using System.Drawing;
using System.Threading.Tasks;

namespace NgMapEditor.Client {
    class MainClient : BaseScript {


        public MainClient() {
            Tick += OnTick;

            API.RegisterCommand("mapeditor", new Action(OnMapeditorCommand), false);
        }

        private void OnMapeditorCommand() {
            IsActive = !IsActive;

            Freecam.SetActive(IsActive);
            Game.Player.IsInvincible = IsActive;
        }

        private bool IsActive = false;

        private Task OnTick() {
            if(IsActive) {
                API.EnableCrosshairThisFrame();

                Color color = Color.FromArgb(255, 240, 15, 15);
                RaycastResult result = RaycastCamera(Freecam.Camera, 10000.0f);

                Entity entity = result.HitEntity;
                if(entity != null && API.IsEntityAnObject(entity.Handle)) {
                    Vector3 entityPos = entity.Position;

                    DrawEntityBoundingBox(entity, color);
                    //World.DrawLine(Game.PlayerPed.Position, result.HitPosition, color);
                    //string text = "Entity: " + entity.Handle + " Model: " + entity.Model.Hash + " Coords: " + entityPos.X + "/" + entityPos.Y + "/" + entityPos.Z;
                    //string text = "Entity: " + entity.Handle + " Model: " + entity.Model.Hash + " Rot: " + entity.Rotation.X + "/" + entity.Rotation.Y + "/" + entity.Rotation.Z;

                    //DrawText3Ds(entityPos, text);
                    //DrawText3Ds(entityPos + Vector3.Up * 0.6f, "To delete object press [~g~R~s~]!");

                    if(Game.IsControlJustPressed(0, Control.Reload)) {
                        API.SetEntityAsMissionEntity(entity.Handle, true, true);
                        entity.Delete();
                    }
                } 
                if(result.HitPosition != Vector3.Zero) {
                    //World.DrawLine(Game.PlayerPed.Position, result.HitPosition, color);
                    World.DrawMarker(MarkerType.DebugSphere, result.HitPosition, Vector3.Zero, new Vector3(0, 180, 0), new Vector3(0.1f), color);
                }
            }

            return Task.FromResult(0);
        }

        //private bool IsActive = false;

        //private ObjectPool pool = new ObjectPool();
        //private SelectionMenu selectionMenu;
        //private EditMenu editMenu;

        //public MainClient() {
        //    selectionMenu = new SelectionMenu(pool);
        //    editMenu = new EditMenu(pool);

        //    selectionMenu.Selected += CreateObject;
        //    Tick += OnTick;
        //}

        //private Prop activeProp = null;

        //private async void CreateObject(object sender, ObjectHash hash) {
        //    RaycastResult result = RaycastGameplayCamera(1000.0f);
        //    Vector3 pos = result.DitHit ? result.HitPosition : Game.PlayerPed.Position + 1000.0f * RotationToDirection(GameplayCamera.Rotation);
        //    Model model = new Model((int) hash);
        //    activeProp = await World.CreateProp(model, result.HitPosition, false, false);

        //}

        //private Task OnTick() {
        //    editMenu.Process();

        //    if(API.IsControlJustPressed(0, (int)Control.DropWeapon)) {
        //        IsActive = !IsActive;
        //        Debug.WriteLine("Map Editor now " + (IsActive ? "enabled" : "disabled"));
        //    }

        //    if(IsActive) {
        //        if(API.IsControlJustPressed(0, (int)Control.Pickup)) {
        //            editMenu.Toggle();
        //        }

        //        Color color = Color.FromArgb(255, 240, 15, 15);

        //        RaycastResult result = RaycastGameplayCamera(1000f);
        //        Entity entity = result.HitEntity;
        //        if(entity != null && (API.IsEntityAVehicle(entity.Handle) || API.IsEntityAPed(entity.Handle) || API.IsEntityAnObject(entity.Handle))) {
        //            Vector3 entityPos = entity.Position;

        //            DrawEntityBoundingBox(entity, color);
        //            World.DrawLine(Game.PlayerPed.Position, result.HitPosition, color);
        //            //string text = "Entity: " + entity.Handle + " Model: " + entity.Model.Hash + " Coords: " + entityPos.X + "/" + entityPos.Y + "/" + entityPos.Z;
        //            string text = "Entity: " + entity.Handle + " Model: " + entity.Model.Hash + " Rot: " + entity.Rotation.X + "/" + entity.Rotation.Y + "/" + entity.Rotation.Z;

        //            DrawText3Ds(entityPos, text);
        //            DrawText3Ds(entityPos + Vector3.Up * 0.6f, "To delete object press [~g~E~s~]!");

        //            if(Game.IsControlJustPressed(0, Control.Reload)) {
        //                API.SetEntityAsMissionEntity(entity.Handle, true, true);
        //                entity.Delete();
        //            }

        //        } else if(result.HitPosition.X != 0 && result.HitPosition.Y != 0) {
        //            World.DrawLine(Game.PlayerPed.Position, result.HitPosition, color);
        //            World.DrawMarker(MarkerType.DebugSphere, result.HitPosition, Vector3.Zero, new Vector3(0, 180, 0), new Vector3(0.1f), color);
        //        }
        //    }

        //    return Task.FromResult(1);
        //}

        private void DrawText3Ds(Vector3 pos, string text) {
            API.SetTextScale(0.6f, 0.6f);
            API.SetTextFont(4);
            API.SetTextProportional(false);
            API.SetTextColour(255, 15, 15, 255);
            API.SetTextDropshadow(0, 0, 0, 0, 255);
            API.SetTextOutline();
            API.SetTextEntry("STRING");
            API.SetTextCentre(true);
            API.AddTextComponentString(text);
            API.SetDrawOrigin(pos.X, pos.Y, pos.Z, 0);
            API.DrawText(0.0f, 0.0f);
            API.ClearDrawOrigin();
        }

        private Vector3 ApplyMatrix(Matrix3x3 mat, Vector3 vec) {
            return new Vector3(mat.M11 * vec.X + mat.M21 * vec.Y + mat.M31 * vec.Z,
                mat.M12 * vec.X + mat.M22 * vec.Y + mat.M32 * vec.Z,
                mat.M13 * vec.X + mat.M23 * vec.Y + mat.M33 * vec.Z);
        }

        private Vector3 RotatePoint(Vector3 point, Entity entity) {
            Matrix3x3 rotMatX = Matrix3x3.RotationX(entity.Rotation.X / 180 * (float)Math.PI);
            Matrix3x3 rotMatY = Matrix3x3.RotationY(entity.Rotation.Y / 180 * (float)Math.PI);
            Matrix3x3 rotMatZ = Matrix3x3.RotationZ(entity.Rotation.Z / 180 * (float)Math.PI);

            point -= entity.Position;

            point = ApplyMatrix(rotMatX, point);
            point = ApplyMatrix(rotMatY, point);
            point = ApplyMatrix(rotMatZ, point);

            point += entity.Position;

            return point;
        }

        private void DrawEntityBoundingBox(Entity entity, Color color) {
            Vector3 dim = entity.Model.GetDimensions();

            Vector3 center = entity.Position + Vector3.UnitZ * dim / 2;

            // bottom corners
            Vector3 corner1 = center - dim / 2;
            Vector3 corner2 = corner1 + Vector3.UnitX * dim;
            Vector3 corner3 = corner2 + Vector3.UnitY * dim;
            Vector3 corner4 = corner1 + Vector3.UnitY * dim;

            // bottom edges
            World.DrawLine(RotatePoint(corner1, entity), RotatePoint(corner2, entity), color);
            World.DrawLine(RotatePoint(corner2, entity), RotatePoint(corner3, entity), color);
            World.DrawLine(RotatePoint(corner3, entity), RotatePoint(corner4, entity), color);
            World.DrawLine(RotatePoint(corner4, entity), RotatePoint(corner1, entity), color);

            // top corners
            Vector3 corner5 = corner1 + Vector3.UnitZ * dim;
            Vector3 corner6 = corner2 + Vector3.UnitZ * dim;
            Vector3 corner7 = corner3 + Vector3.UnitZ * dim;
            Vector3 corner8 = corner4 + Vector3.UnitZ * dim;

            // top edges
            World.DrawLine(RotatePoint(corner5, entity), RotatePoint(corner6, entity), color);
            World.DrawLine(RotatePoint(corner6, entity), RotatePoint(corner7, entity), color);
            World.DrawLine(RotatePoint(corner7, entity), RotatePoint(corner8, entity), color);
            World.DrawLine(RotatePoint(corner8, entity), RotatePoint(corner5, entity), color);

            // connecting top and bottom
            World.DrawLine(RotatePoint(corner1, entity), RotatePoint(corner5, entity), color);
            World.DrawLine(RotatePoint(corner2, entity), RotatePoint(corner6, entity), color);
            World.DrawLine(RotatePoint(corner3, entity), RotatePoint(corner7, entity), color);
            World.DrawLine(RotatePoint(corner4, entity), RotatePoint(corner8, entity), color);
        }

        private RaycastResult RaycastCamera(Camera camera, float distance) {
            Vector3 startPos = camera.Position;
            Vector3 direction = RotationToDirection(camera.Rotation);
            Vector3 endPos = startPos + direction * distance;

            RaycastResult result = World.Raycast(startPos, endPos, IntersectOptions.Everything);

            return result;
        }

        //private void DrawText3D(Vector3 pos, string text) {
        //    float screenX = 0;
        //    float screenY = 0;
        //    bool onScreen = API.World3dToScreen2d(pos.X, pos.Y, pos.Z, ref screenX, ref screenY);

        //    API.SetTextScale(0.35f, 0.35f);
        //    API.SetTextFont(4);
        //    API.SetTextProportional(true);
        //    API.SetTextColour(255, 255, 255, 215);
        //    API.SetTextEntry("STRING");
        //    API.SetTextCentre(true);
        //    API.AddTextComponentString(text);
        //    API.DrawText(screenX, screenY);
        //    float factor = text.Length / 370;
        //    API.DrawRect(screenX, screenY + 0.0125f, 0.015f + factor, 0.03f, 41, 11, 41, 68);
        //}

        private void DrawText(Vector2 pos, float width, float height, float scale, string text, Color color) {
            API.SetTextFont(0);
            API.SetTextProportional(false);
            API.SetTextScale(0.25f, 0.25f);
            API.SetTextColour(color.R, color.G, color.B, color.A);
            API.SetTextDropshadow(0, 0, 0, 0, 255);
            API.SetTextEdge(1, 0, 0, 0, 255);
            API.SetTextDropShadow();
            API.SetTextOutline();
            API.SetTextEntry("STRING");
            API.AddTextComponentString(text);
            API.DrawText(pos.X - width / 2, pos.Y - height / 2 + 0.005f);
        }

        private Vector3 RotationToDirection(Vector3 rotation) {
            Vector3 adjustedRotation = rotation * (float) (Math.PI / 180);
            Vector3 direction = new Vector3(
                -(float)Math.Sin(adjustedRotation.Z) * (float)Math.Abs(Math.Cos(adjustedRotation.X)),
                (float)Math.Cos(adjustedRotation.Z) * (float)Math.Abs(Math.Cos(adjustedRotation.X)),
                (float)Math.Sin(adjustedRotation.X));

            return direction;
        }

    }
}
