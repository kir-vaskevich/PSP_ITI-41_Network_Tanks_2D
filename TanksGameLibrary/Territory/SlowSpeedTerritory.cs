using OpenTK;
using EngineClassLibrary;


namespace TanksGameLibrary
{
    /// <summary>
    /// Класс территории с замедлением скорости.
    /// </summary>
    public class SlowSpeedTerritory : GameObject, ITerritory
    {
        public bool IsDrive { get; set; }
        /// <summary>
        /// Замедление скорости.
        /// </summary>
        private float _slowSpeed;

        /// <summary>
        /// Текстура территории с замедлением скорости.
        /// </summary>
        public static Texture sprite = ContentPipe.LoadTexture("SlowSpeedTerritory.png");

        /// <summary>
        /// Конструктор для создания территории.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="scale"></param>
        /// <param name="texture"></param>
        /// <param name="slowSpeed"></param>
        public SlowSpeedTerritory(Vector position, Vector scale, float slowSpeed) : base(position, scale, sprite)
        {
            _slowSpeed = slowSpeed;
        }

        /// <summary>
        /// Метод, декорирующий танк.
        /// </summary>
        /// <param name="tank"></param>
        /// <returns></returns>
        public Tank Decorate(Tank tank)
        {
            if (!IsDrive && !(tank is SpeedDecorator))
            {
                IsDrive = true;
                return new SpeedDecorator(tank, _slowSpeed);
            }
            return tank;
        }

        /// <summary>
        /// Метод, определяющий наехал ли танк на территорию.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool IsCollided(GameObject obj)
        {
            if (obj is Tank && Collider.IsObjectsCollided(obj, this))
            {
                return true;
            }
            else
            {
                IsDrive = false;
                return false;
            }
        }
    }
}
