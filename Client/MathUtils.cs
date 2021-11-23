using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgMapEditor.Client {
    public static class MathUtils {

        public static Vector3 ApplyMatrix3x3(Matrix3x3 mat, Vector3 vec) {
            return new Vector3(mat.M11 * vec.X + mat.M21 * vec.Y + mat.M31 * vec.Z,
                mat.M12 * vec.X + mat.M22 * vec.Y + mat.M32 * vec.Z,
                mat.M13 * vec.X + mat.M23 * vec.Y + mat.M33 * vec.Z);
        }

        public static Vector3 RotateVector3(Vector3 point, Vector3 rotation) {
            return RotateVector3(point, rotation, Vector3.Zero);
        }

        public static Vector3 RotateVector3(Vector3 point, Vector3 rotation, Vector3 offset) {
            Matrix3x3 rotMatX = Matrix3x3.RotationX(rotation.X / 180 * (float)Math.PI);
            Matrix3x3 rotMatY = Matrix3x3.RotationY(rotation.Y / 180 * (float)Math.PI);
            Matrix3x3 rotMatZ = Matrix3x3.RotationZ(rotation.Z / 180 * (float)Math.PI);

            point -= offset;

            point = ApplyMatrix3x3(rotMatX, point);
            point = ApplyMatrix3x3(rotMatY, point);
            point = ApplyMatrix3x3(rotMatZ, point);

            point += offset;

            return point;
        }

        public static float Clamp(float value, float min, float max) {
            return Math.Max(Math.Min(value, max), min);
        }

    }
}
