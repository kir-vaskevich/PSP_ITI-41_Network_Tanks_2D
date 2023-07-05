using System;

namespace EngineClassLibrary
{
    public class Vector
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static Vector Zero { get => new Vector(0f, 0f); }

        public static Vector operator *(Vector vector, float digit)
        {
            return new Vector(vector.X * digit, vector.Y * digit);
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y);
        }

        public override bool Equals(object obj)
        {
            if (obj == null && !this.GetType().Equals(obj.GetType()))
                return false;

            Vector vector = (Vector) obj;
            if ((X == vector.X) && (Y == vector.Y))
                return true;
            return false;
        }

        public static bool operator ==(Vector v1, Vector v2)
        {
            if (v1.X == v2.X && v1.Y == v2.Y)
                return true;
            return false;
        }

        public static bool operator !=(Vector v1, Vector v2)
        {
            if (v1.X != v2.X || v1.Y != v2.Y)
                return true;
            return false;
        }
    }
}
