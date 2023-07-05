using EngineClassLibrary;
using OpenTK;
using OpenTK.Input;

namespace TanksGameLibrary
{
    /// <summary>
    /// Класс танка.
    /// </summary>
    public class Tank : GameObject
    {
        /// <summary>
        /// Здоровье танка.
        /// </summary>
        public virtual int Health { get; internal set; }

        /// <summary>
        /// Скорость танка.
        /// </summary>
        public virtual int Speed { get; protected set; }

        /// <summary>
        /// Топливо танка.
        /// </summary>
        public virtual float Fuel { get; internal set; }

        /// <summary>
        /// Пушка танка.
        /// </summary>
        public Canon Canon { get; protected set; }

        /// <summary>
        /// Пулемет танка.
        /// </summary>
        public MachineGun MachineGun { get; protected set; }

        /// <summary>
        /// Направление движения танка.
        /// </summary>
        public Vector Direction { get; internal set; }

        public bool IsMove = true;

        public bool controlPlayer;

        #region Textures
        /// <summary>
        /// Текстура первого танка движущегося вверх.
        /// </summary>
        public static Texture spriteTank1_Up = ContentPipe.LoadTexture("Tank1_Up.png");
        /// <summary>
        /// Текстура первого танка движущегося вниз.
        /// </summary>
        public static Texture spriteTank1_Down = ContentPipe.LoadTexture("Tank1_Down.png");
        /// <summary>
        /// Текстура первого танка движущегося влево.
        /// </summary>
        public static Texture spriteTank1_Left = ContentPipe.LoadTexture("Tank1_Left.png");
        /// <summary>
        /// Текстура первого танка движущегося вправо.
        /// </summary>
        public static Texture spriteTank1_Right = ContentPipe.LoadTexture("Tank1_Right.png");
        /// <summary>
        /// Текстура второго танка движущегося вверх.
        /// </summary>
        public static Texture spriteTank2_Up = ContentPipe.LoadTexture("Tank2_Up.png");
        /// <summary>
        /// Текстура второго танка движущегося вниз.
        /// </summary>
        public static Texture spriteTank2_Down = ContentPipe.LoadTexture("Tank2_Down.png");
        /// <summary>
        /// Текстура второго танка движущегося влево.
        /// </summary>
        public static Texture spriteTank2_Left = ContentPipe.LoadTexture("Tank2_Left.png");
        /// <summary>
        /// Текстура второго танка движущегося вправо.
        /// </summary>
        public static Texture spriteTank2_Right = ContentPipe.LoadTexture("Tank2_Right.png");
        #endregion
        /// <summary>
        /// Констурктор танка.
        /// </summary>
        /// <param name="position">Позиция</param>
        /// <param name="scale">Размер</param>
        /// <param name="texture">Текстура</param>
        /// <param name="leftOrRightPlayer">Какой игрок</param>
        public Tank(Vector position, Vector scale, Texture texture, bool leftOrRightPlayer, bool controlPlayer)
            : base(position, scale, texture)
        {
            Direction = Vector.Zero;
            Health = 100;
            Speed = 300;
            Fuel = 80;
            Player = leftOrRightPlayer;
            this.controlPlayer = controlPlayer;
            Canon = new Canon(new Vector(1, 0), position, 20, leftOrRightPlayer, 1.0f);
            MachineGun = new MachineGun(new Vector(1, 0), position, 100, leftOrRightPlayer, 1.0f);
        }

        /// <summary>
        /// Остановка танка.
        /// </summary>
        public void StopTank(Vector dir)
        {
            Position += dir * Speed * Time.DeltaTime;
        }

        /// <summary>
        /// Метод передвижения, обновления кадровы и модификации.
        /// </summary>
        public override void Update()
        {
            if (Direction != Vector.Zero)
                Fuel -= 0.0075f;
 
            if (IsMove && controlPlayer)
                Position += Direction * Speed * Time.DeltaTime;
            CheckBorders();
            if (controlPlayer)
                UpdateKeys(Keyboard.GetState());
            Animation();
        }

        /// <summary>
        /// Анимация танка.
        /// </summary>
        public void Animation()
        {
            if (!Player)
            {
                if (Direction.X == -1)
                    Texture = spriteTank1_Right;

                else if (Direction.X == 1)
                    Texture = spriteTank1_Left;

                else if (Direction.Y == 1)
                    Texture = spriteTank1_Up;

                else if (Direction.Y == -1)
                    Texture = spriteTank1_Down;
            }
            else
            {
                if (Direction.X == -1)
                    Texture = spriteTank2_Right;

                else if (Direction.X == 1)
                    Texture = spriteTank2_Left;

                else if (Direction.Y == 1)
                    Texture = spriteTank2_Up;

                else if (Direction.Y == -1)
                    Texture = spriteTank2_Down;
            }
        }

        /// <summary>
        /// Проверка на столкновение со стенками.
        /// </summary>
        public void CheckBorders()
        {
            int tankWidth = (int)Scale.X * Texture.Width;
            int tankHeight = (int)Scale.Y * Texture.Height;

            if (Position.X <= -800 + tankWidth)
                Position = new Vector(-800 + tankWidth, Position.Y);

            if (Position.X >= 800)
                Position = new Vector(800, Position.Y);

            if (Position.Y <= -450 + tankHeight)
                Position = new Vector(Position.X, -450 + tankHeight);

            if (Position.Y >= 450)
                Position = new Vector(Position.X, 450);
        }

        /// <summary>
        /// Метод нажатия клавиш и управления игроком.
        /// </summary>
        /// <param name="key"></param>
        public void UpdateKeys(KeyboardState key)
        {
            Direction = Vector.Zero;
            // выстрел из пушки
            if (key.IsKeyDown(Key.Space) && !Canon.IsShoot)
            {
                this.Canon.Shoot();
                Canon.IsShoot = true;
            }
            else if (key.IsKeyUp(Key.Space))
                Canon.IsShoot = false;
            // выстрел из пулемета
            if (key.IsKeyDown(Key.ControlRight) && !MachineGun.IsShoot)
            {
                this.MachineGun.Shoot();
                MachineGun.IsShoot = true;
            }
            else if (key.IsKeyUp(Key.ControlRight))
                MachineGun.IsShoot = false;
            // движение
            if (key.IsKeyDown(Key.W))
                Direction = new Vector(0, 1);
            else if (key.IsKeyDown(Key.S))
                Direction = new Vector(0, -1);
            else if (key.IsKeyDown(Key.A))
                Direction = new Vector(1, 0);
            else if (key.IsKeyDown(Key.D))
                Direction = new Vector(-1, 0);
            // следование направления и позиции выстрела
            if (Direction != Vector.Zero)
            {
                Canon.Direction = Direction;
                MachineGun.Direction = Direction;
            }
            Canon.BulletPosition = Position;
            MachineGun.BulletPosition = Position;
        }
    }

    
}
