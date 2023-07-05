using OpenTK;
using EngineClassLibrary;

namespace TanksGameLibrary
{
    /// <summary>
    /// Класс приза топлива.
    /// </summary>
    public class FuelPrize : Prize
    {
        /// <summary>
        /// Топлива в призе.
        /// </summary>
        private float _fuel;

        /// <summary>
        /// Максимальный запас топлива танка.
        /// </summary>
        private float _maxFuel = 80f;

        /// <summary>
        /// Текстура приза топлива.
        /// </summary>
        public static Texture sprite = ContentPipe.LoadTexture("FuelPrize.png");

        /// <summary>
        /// Конструктор для создания приза.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="scale"></param>
        /// <param name="fuel"></param>
        public FuelPrize(Vector position, Vector scale, float fuel) : base(position, scale, sprite)
        {
            _fuel = fuel;
        }

        /// <summary>
        /// Метод, добавляющий топливо в танк.
        /// </summary>
        /// <param name="tank"></param>
        /// <returns></returns>
        public override Tank Decorate(Tank tank)
        {
            if (tank.Fuel + _fuel > _maxFuel)
                tank.Fuel = _maxFuel;
            else
                tank.Fuel += _fuel;
            return tank;
        }
    }
}
