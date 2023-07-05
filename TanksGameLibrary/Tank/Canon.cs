using OpenTK;
using EngineClassLibrary;

namespace TanksGameLibrary
{
    /// <summary>
    /// Класс пушки танка.
    /// </summary>
    public class Canon
    {
        /// <summary>
        /// Ссылка на игру.
        /// </summary>
        private Game game;

        /// <summary>
        /// Количество патронов пушки.
        /// </summary>
        public int Ammo { get; internal set; }

        /// <summary>
        /// Направление выстрела патрона пушкой.
        /// </summary>
        public Vector Direction { get; internal set; }

        /// <summary>
        /// Начальная позиция пули.
        /// </summary>
        public Vector BulletPosition { get; internal set; }

        /// <summary>
        /// Поле, обозначающее выстрелила ли пушка.
        /// </summary>
        public bool IsShoot { get; internal set; }

        /// <summary>
        /// Поле, определяющее пулю определенного игрока.
        /// </summary>
        private bool _player;

        /// <summary>
        /// Мощность выстрела.
        /// </summary>
        public virtual float Power { get; internal set; }

        /// <summary>
        /// Конструктор для создания пушки.
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="tankPosition"></param>
        /// <param name="ammo"></param>
        /// <param name="leftOrRightBuller"></param>
        /// <param name="power"></param>
        public Canon(Vector direction, Vector tankPosition, int ammo, bool leftOrRightBuller, float power)
        {
            Direction = direction;
            BulletPosition = tankPosition;
            game = Game.game;
            Ammo = ammo;
            IsShoot = false;
            _player = leftOrRightBuller;
            Power = power;
        }

        /// <summary>
        /// Метод стрельбы патроном.
        /// </summary>
        public void Shoot()
        {
            if (Ammo > 0)
            {
                if (Direction.X == -1)
                    BulletPosition = new Vector(BulletPosition.X - 80, BulletPosition.Y - 20);

                else if (Direction.X == 1)
                    BulletPosition = new Vector(BulletPosition.X + 30, BulletPosition.Y - 20);

                else if (Direction.Y == 1)
                    BulletPosition = new Vector(BulletPosition.X - 20, BulletPosition.Y + 30);

                else
                    BulletPosition = new Vector(BulletPosition.X - 20, BulletPosition.Y - 80);

                game.AddToAddObjects(new CanonBullet(BulletPosition, new Vector(0.10f, 0.10f), Direction, _player, Power));
                Ammo--;
            }
        }
    }
}
