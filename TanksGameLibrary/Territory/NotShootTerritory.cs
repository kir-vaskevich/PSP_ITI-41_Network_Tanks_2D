using EngineClassLibrary;
using OpenTK;

namespace TanksGameLibrary
{
    /// <summary>
    /// Класс территории, на которой нельзя стрелять.
    /// </summary>
    public class NotShootTerritory : GameObject, ITerritory
    {
        public bool IsDrive { get; set; }
        /// <summary>
        /// Текстура территории с невозможностью стрельбы.
        /// </summary>
        public static Texture sprite = ContentPipe.LoadTexture("NotShootTerritory.png");
        /// <summary>
        /// Конструктор для создания территории.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="scale"></param>
        /// <param name="texture"></param>
        public NotShootTerritory(Vector position, Vector scale) : base(position, scale, sprite)
        { }
        
        /// <summary>
        /// Метод декорирующий танк.
        /// </summary>
        /// <param name="tank"></param>
        /// <returns></returns>
        public Tank Decorate(Tank tank)
        {
            tank.Canon.IsShoot = true;
            tank.MachineGun.IsShoot = true;
            return tank;
        }

        /// <summary>
        /// Метод проверяющий нахождения танка на территории.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool IsCollided(GameObject obj)
        {
            if (obj is Tank && Collider.IsObjectsCollided(obj, this))
            {
                return true;
            }
            return false;
        }
    }
}
