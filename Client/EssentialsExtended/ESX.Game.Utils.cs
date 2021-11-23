using CitizenFX.Core;

namespace EssentialsExtended {
    public static partial class ESX {
        public static partial class Game {
            public static class Utils {
                public static dynamic Raw => ESX.Raw.Game.Utils;

                public static void DrawText3D(Vector3 coords, string text, double size, dynamic font) => Raw.DrawText3D(coords, text, size, font);
            }
        }
    }
}