using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace EngineClassLibrary
{
    /// <summary>
    /// Класс для проверки столкновения объектов.
    /// </summary>
    public static class Collider
    {
        /// <summary>
        /// Метод, проверяющий столкновение центра первого объекта со вторым.
        /// </summary>
        /// <param name="obj1">Первый объект</param>
        /// <param name="obj2">Второй объект</param>
        /// <returns></returns>
        public static bool IsObjectsCollided(GameObject obj1, GameObject obj2)
        {
            Vector obj1Center = new Vector(
                obj1.Position.X - ((float)obj1.Texture.Width * obj1.Scale.X) / 2f,
                obj1.Position.Y - ((float)obj1.Texture.Height * obj1.Scale.Y) / 2f
                );
            Vector obj2Coords = new Vector(
                obj2.Position.X - obj2.Texture.Width * obj2.Scale.X,
                obj2.Position.Y - obj2.Texture.Height * obj2.Scale.Y
                );
            if (obj1Center.X <= obj2.Position.X && obj1Center.X >= obj2Coords.X)
            {
                if (obj1Center.Y <= obj2.Position.Y && obj1Center.Y >= obj2Coords.Y)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Метод проверяющий прикосновение объектов.
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns></returns>
        public static bool IsObjectsTouched(GameObject obj1, GameObject obj2)
        {
            //Rectangle rec1 = new Rectangle((int)obj1.Position.X, (int)obj1.Position.Y, obj1.Texture.Width, obj1.Texture.Height);
            //Rectangle rec2 = new Rectangle((int)obj2.Position.X, (int)obj2.Position.Y, obj2.Texture.Width, obj2.Texture.Height);
            //if (rec1.Contains(rec2.X, rec2.Y) || rec1.Contains(rec2.X - rec2.Width, rec2.Y) || rec1.Contains(rec2.X - rec2.Width, rec2.Y - rec2.Height) || rec1.Contains(rec2.X, rec2.Y - rec2.Height))
            //    return true;
            //return false;

            Vector[] obj1Coords = new Vector[] {
                obj1.Position,
                new Vector(obj1.Position.X - obj1.Texture.Width * obj1.Scale.X, obj1.Position.Y),
                new Vector(obj1.Position.X - obj1.Texture.Width * obj1.Scale.X, obj1.Position.Y - obj1.Texture.Height * obj1.Scale.Y),
                new Vector(obj1.Position.X, obj1.Position.Y - obj1.Texture.Height * obj1.Scale.Y)
                };
            Vector obj2Coords = new Vector(
                obj2.Position.X - obj2.Texture.Width * obj2.Scale.X,
                obj2.Position.Y - obj2.Texture.Height * obj2.Scale.Y
                );
            foreach (Vector vector in obj1Coords)
            {
                if (vector.X <= obj2.Position.X && vector.X >= obj2Coords.X)
                {
                    if (vector.Y <= obj2.Position.Y && vector.Y >= obj2Coords.Y)
                        return true;
                }
            }
            return false;
        }
    }
}
