using OpenTK;
using EngineClassLibrary;

namespace TanksGameLibrary
{
    /// <summary>
    /// Класс пулемета.
    /// </summary>
    public class MachineGun
    {
        /// <summary>
        /// Статическая ссылка на игру для добавления снаряда как объекта в список.
        /// </summary>
        private Game game;
        /// <summary>
        /// Запас патронов.
        /// </summary>
        public int Ammo { get; protected set; }
        /// <summary>
        /// Направление полета пули.
        /// </summary>
        public Vector Direction { get; internal set; }
        /// <summary>
        /// Начальная позиция пули.
        /// </summary>
        public Vector BulletPosition { get; internal set; }
        /// <summary>
        /// Поле, которое показывает попала ли пуля в танк.
        /// </summary>
        public bool IsShoot { get; internal set; }
        /// <summary>
        /// Пуля какого игрока.
        /// </summary>
        private bool _player;
        /// <summary>
        /// Мощность выстрела пулемета.
        /// </summary>
        public float Power { get; internal set; }

        /// <summary>
        /// Конструктор пулемета.
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="tankPosition"></param>
        /// <param name="ammo"></param>
        /// <param name="leftOrRightBullet"></param>
        /// <param name="power"></param>
        public MachineGun(Vector direction, Vector tankPosition, int ammo, bool leftOrRightBullet, float power)
        {
            Direction = direction;
            BulletPosition = tankPosition;
            game = Game.game;
            Ammo = ammo;
            IsShoot = false;
            _player = leftOrRightBullet;
            Power = power;
        }

        /// <summary>
        /// Метод произведения выстрела.
        /// </summary>
        public void Shoot()
        {
            if (Ammo > 0)
            {
                if (Direction.X == -1)
                    BulletPosition = new Vector(BulletPosition.X - 80, BulletPosition.Y - 30);

                else if (Direction.X == 1)
                    BulletPosition = new Vector(BulletPosition.X + 30, BulletPosition.Y - 30);

                else if (Direction.Y == 1)
                    BulletPosition = new Vector(BulletPosition.X - 30, BulletPosition.Y + 30);

                else
                    BulletPosition = new Vector(BulletPosition.X - 30, BulletPosition.Y - 80);

                game.AddToAddObjects(new MachineGunBullet(BulletPosition, new Vector(0.2f, 0.2f), Direction, _player, Power));
                //Ammo--;
            }
        }
    }
}
