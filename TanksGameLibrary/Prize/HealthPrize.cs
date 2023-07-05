using OpenTK;
using EngineClassLibrary;

namespace TanksGameLibrary
{
    /// <summary>
    /// Класс приза здоровья.
    /// </summary>
    public class HealthPrize : Prize
    {
        /// <summary>
        /// Здоровье, которое дает приз.
        /// </summary>
        private int _health;
        /// <summary>
        /// Максимально здоровье танка.
        /// </summary>
        private int _maxHealth = 100;

        /// <summary>
        /// Текстура приза здоровья.
        /// </summary>
        public static Texture sprite = ContentPipe.LoadTexture("HealthPrize.png");

        /// <summary>
        /// Конструктор создающий приз.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="scale"></param>
        /// <param name="health"></param>
        public HealthPrize(Vector position, Vector scale, int health) : base(position, scale, sprite)
        {
            _health = health;
        }

        /// <summary>
        /// Метод для лечения танка.
        /// </summary>
        /// <param name="tank"></param>
        /// <returns></returns>
        public override Tank Decorate(Tank tank)
        {
            if (tank.Health + _health > _maxHealth)
                tank.Health = _maxHealth;
            else
                tank.Health += _health;
            return tank;
        }
    }
}
