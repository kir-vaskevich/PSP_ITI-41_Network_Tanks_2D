using OpenTK;
using EngineClassLibrary;

namespace TanksGameLibrary
{
    /// <summary>
    /// Класс приза скорости.
    /// </summary>
    public class BoostSpeedPrize : Prize
    {
        /// <summary>
        /// Ускорение.
        /// </summary>
        internal float _speedBoost;

        /// <summary>
        /// Текстура приза с ускорением.
        /// </summary>
        public static Texture sprite = ContentPipe.LoadTexture("BoostSpeedPrize.png");

        /// <summary>
        /// Конструктор, создающий приз.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="scale"></param>
        /// <param name="speedBoost"></param>
        public BoostSpeedPrize(Vector position, Vector scale, float speedBoost) : base(position, scale, sprite)
        {
            _speedBoost = speedBoost;
        }

        /// <summary>
        /// Метод декорирующий танк.
        /// </summary>
        /// <param name="tank"></param>
        /// <returns></returns>
        public override Tank Decorate(Tank tank)
        {
            return new SpeedDecorator(tank, _speedBoost);
        }
    }
}
