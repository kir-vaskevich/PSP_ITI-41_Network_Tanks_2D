using OpenTK;
using EngineClassLibrary;

namespace TanksGameLibrary
{
    /// <summary>
    /// Класс территории через которую нельзя проехать.
    /// </summary>
    public class NotDriveTerritory : GameObject, ITerritory
    {
        public bool IsDrive { get; set; }

        /// <summary>
        /// Текстура территории с невозможность проезжать через нее.
        /// </summary>
        public static Texture sprite = ContentPipe.LoadTexture("NotDriveTerritory.png");
        /// <summary>
        /// Конструктор для создания территории.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="scale"></param>
        /// <param name="texture"></param>
        public NotDriveTerritory(Vector position, Vector scale) : base(position, scale, sprite)
        { }

        /// <summary>
        /// Метод декорирующий танк.
        /// </summary>
        /// <param name="tank"></param>
        /// <returns></returns>
        public Tank Decorate(Tank tank)
        {
            //tank.Direction = Vector.Zero;
            Vector dir = Vector.Zero;
            if (this.Position.X > tank.Position.X && tank.Direction == new Vector(1, 0))
                dir = new Vector(-1, 0);
            if (this.Position.X < tank.Position.X && tank.Direction == new Vector(-1, 0))
                dir = new Vector(1, 0);
            if (this.Position.Y > tank.Position.Y && tank.Direction == new Vector(0, 1))
                dir = new Vector(0, -1);
            if (this.Position.Y < tank.Position.Y && tank.Direction == new Vector(0, -1))
                dir = new Vector(0, 1);
            tank.StopTank(dir);
            return tank;
        }

        /// <summary>
        /// Метод для проверки сталкивания танка с территорией.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool IsCollided(GameObject obj)
        {
            if (obj is Tank && Collider.IsObjectsTouched(obj, this))
            {
                //tankDirection = (obj as Tank).Direction;
                //(obj as Tank).IsMove = false;
                return true;
            }
            else
            {
                //(obj as Tank).IsMove = true;
            }
            return false;
        }
    }
}
