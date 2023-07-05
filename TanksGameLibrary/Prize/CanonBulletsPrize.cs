using OpenTK;
using EngineClassLibrary;

namespace TanksGameLibrary
{
    /// <summary>
    /// Класс приза патронов.
    /// </summary>
    public class CanonBulletsPrize : Prize
    {
        /// <summary>
        /// Количество патронов в призе.
        /// </summary>
        internal int _ammo;

        /// <summary>
        /// Текстура приза с патронами.
        /// </summary>
        public static Texture sprite = ContentPipe.LoadTexture("CanonBulletsPrize.png");

        /// <summary>
        /// Консруктор создающий приз.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="scale"></param>
        /// <param name="ammo"></param>
        public CanonBulletsPrize(Vector position, Vector scale, int ammo) : base(position, scale, sprite)
        {
            _ammo = ammo;
        }

        /// <summary>
        /// Метод декорирующий танк.
        /// </summary>
        /// <param name="tank"></param>
        /// <returns></returns>
        public override Tank Decorate(Tank tank)
        {
            tank.Canon.Ammo += _ammo;
            return tank;
        }
    }
}
