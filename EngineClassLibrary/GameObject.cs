using OpenTK;
using System.Text.Json.Serialization;

namespace EngineClassLibrary
{
    /// <summary>
    /// Класс игрового объекта.
    /// </summary>
    public class GameObject
    {
        /// <summary>
        /// Автосвойство текстуры.
        /// </summary>
        public Texture Texture { get; set; }
        /// <summary>
        /// Автосвойсво позиции объекта.
        /// </summary>
        public Vector Position { get; set; }
        
        /// <summary>
        /// Автосвойство размера объекта.
        /// </summary>
        /// 
        public Vector Scale { get; set; }

        /// <summary>
        /// Консруктор для создания объекта.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="scale"></param>
        /// <param name="texture"></param>
        public GameObject(Vector position, Vector scale, Texture texture)
        {
            Position = position;
            Scale = scale;
            Texture = texture;
        }

        public GameObject()
        {

        }

        public ObjType Tag { get; set; }

        /// <summary>
        /// Если значение true, то игрок правый, иначе левый.
        /// </summary>
        [JsonIgnore]
        public bool Player { get; set; }

        /// <summary>
        /// Абстрактный метод для модификации и/или отрисовки кадров.
        /// </summary>
        public virtual void Update()
        {

        }
    }
}
