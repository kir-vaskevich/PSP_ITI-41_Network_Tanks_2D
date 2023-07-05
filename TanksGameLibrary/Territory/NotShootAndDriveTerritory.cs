using EngineClassLibrary;
using OpenTK;

namespace TanksGameLibrary
{
    /// <summary>
    /// Класс территории, через которую нельзя передвигаться и стрелять.
    /// </summary>
    public class NotShootAndDriveTerritory : GameObject, ITerritory
    {
        public bool IsDrive { get; set; }

        /// <summary>
        /// Направление движения танка.
        /// </summary>
        private Vector tankDirection;

        /// <summary>
        /// Текстура территории через которую нельзя проезжать и стрелять.
        /// </summary>
        public static Texture sprite = ContentPipe.LoadTexture("NotShootAndDriveTerritory.png");

        /// <summary>
        /// Конструктор для создания территории.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="scale"></param>
        /// <param name="texture"></param>
        public NotShootAndDriveTerritory(Vector position, Vector scale) : base(position, scale, sprite)
        {
            
        }

        /// <summary>
        /// Метод декорирующий танк.
        /// </summary>
        /// <param name="tank"></param>
        /// <returns></returns>
        public Tank Decorate(Tank tank)
        {
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
                return true;
            }
            else if (obj is Bullet && Collider.IsObjectsCollided(obj, this))
            {
                return true;
            }
            return false;
        }
    }
}
