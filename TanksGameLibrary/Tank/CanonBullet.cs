using OpenTK;
using EngineClassLibrary;

namespace TanksGameLibrary
{
    /// <summary>
    /// Класс снаряда пушки.
    /// </summary>
    public class CanonBullet : Bullet
    {
        #region Textures
        /// <summary>
        /// Текстура пули летящей вверх.
        /// </summary>
        internal static Texture spriteBullet_Up = ContentPipe.LoadTexture("CanonBullet_Up.png");
        /// <summary>
        /// Текстура пули летящей вниз.
        /// </summary>
        internal static Texture spriteBullet_Down = ContentPipe.LoadTexture("CanonBullet_Down.png");
        /// <summary>
        /// Текстура пули летящей влево.
        /// </summary>
        internal static Texture spriteBullet_Left = ContentPipe.LoadTexture("CanonBullet_Left.png");
        /// <summary>
        /// Текстура пули летящей вправо.
        /// </summary>
        internal static Texture spriteBullet_Right = ContentPipe.LoadTexture("CanonBullet_Right.png");
        #endregion
        /// <summary>
        /// Конструктор для создания снаряда.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="size"></param>
        /// <param name="texture"></param>
        /// <param name="direction"></param>
        /// <param name="player"></param>
        /// <param name="power"></param>
        public CanonBullet(Vector position, Vector size, Vector direction, bool player, float power)
            : base(position, size, null, direction, player)
        {
            Texture texture;
            if (Direction.X == -1)
                texture = spriteBullet_Right;

            else if (Direction.X == 1)
                texture = spriteBullet_Left;

            else if (Direction.Y == 1)
                texture = spriteBullet_Up;

            else
                texture = spriteBullet_Down;

            Texture = texture;
            Power = power;
            Damage = (int)(10 * Power);
            Speed = 400;
            Tag = ObjType.CanonBullet;
        }

        /// <summary>
        /// Метод передвижения снаряда.
        /// </summary>
        public override void Update()
        {
            Position += Direction * Speed * Time.DeltaTime;
            CheckBorders();
        }
    }
}
