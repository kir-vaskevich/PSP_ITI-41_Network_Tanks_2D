using EngineClassLibrary;
using OpenTK;

namespace TanksGameLibrary
{
    /// <summary>
    /// Класс пули пулемета танка.
    /// </summary>
    public class MachineGunBullet : Bullet
    {
        /// <summary>
        /// Текстура пули.
        /// </summary>
        internal static Texture spriteBullet = ContentPipe.LoadTexture("MachineGunBullet.png");

        /// <summary>
        /// Конструктор для создания пули.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="size"></param>
        /// <param name="texture"></param>
        /// <param name="direction"></param>
        /// <param name="player"></param>
        /// <param name="power"></param>
        public MachineGunBullet(Vector position, Vector size, Vector direction, bool player, float power)
            : base(position, size, spriteBullet, direction, player)
        {
            Power = power;
            Damage = (int)(2 * Power);
            Speed = 400;
            Tag = ObjType.MachineGunBullet;
        }

        /// <summary>
        /// Метод передвижения пули.
        /// </summary>
        public override void Update()
        {
            Position += Direction * Speed * Time.DeltaTime;
            CheckBorders();
        }
    }
}
