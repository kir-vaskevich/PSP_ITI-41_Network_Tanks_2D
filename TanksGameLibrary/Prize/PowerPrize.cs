using OpenTK;
using EngineClassLibrary;

namespace TanksGameLibrary
{
    /// <summary>
    /// Класс приза мощности.
    /// </summary>
    public class PowerPrize : Prize
    {
        /// <summary>
        /// Коэфициент мощности.
        /// </summary>
        private float _power;

        /// <summary>
        /// Текстура приза мощности вооружения.
        /// </summary>
        public static Texture sprite = ContentPipe.LoadTexture("PowerPrize.png");

        /// <summary>
        /// Конструктор создающий приз.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="scale"></param>
        /// <param name="power"></param>
        public PowerPrize(Vector position, Vector scale, float power) : base(position, scale, sprite)
        {
            _power = power;
        }

        /// <summary>
        /// Метод для декорации танка.
        /// </summary>
        /// <param name="tank"></param>
        /// <returns></returns>
        public override Tank Decorate(Tank tank)
        {
            return new PowerDecorator(tank, _power);
        }
    }
}
