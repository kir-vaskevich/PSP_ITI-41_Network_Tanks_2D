using EngineClassLibrary;
using OpenTK;

namespace TanksGameLibrary
{
    /// <summary>
    /// Абстрактный класс пули.
    /// </summary>
    public class Bullet : GameObject
    {
        /// <summary>
        /// Урон пули.
        /// </summary>
        public int Damage { get; set; }

        public float Power { get; set; }

        /// <summary>
        /// Скорость пули.
        /// </summary>
        public int Speed { get; set; }

        /// <summary>
        /// Направление движения пули.
        /// </summary>
        public Vector Direction { get; set; }

        /// <summary>
        /// Поле, обозначающее попала ли пуля в танк.
        /// </summary>
        public bool IsHit { get; set; }

        /// <summary>
        /// Консруктор для создания пули.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="scale"></param>
        /// <param name="texture"></param>
        /// <param name="direction"></param>
        /// <param name="player"></param>
        public Bullet(Vector position, Vector scale, Texture texture, Vector direction, bool player)
            : base(position, scale, texture)
        {
            Direction = direction;
            IsHit = false;
            Player = player;
        }

        public Bullet()
        {

        }

        /// <summary>
        /// Проверка на выход пули за пределы карты.
        /// </summary>
        public void CheckBorders()
        {
            if (Position.X <= -800)
                IsHit = true; 

            if (Position.X >= 800)
                IsHit = true; 

            if (Position.Y <= -450)
                IsHit = true; 

            if (Position.Y >= 450)
                IsHit = true; 
        }
    }
}
