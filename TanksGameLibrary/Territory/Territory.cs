using EngineClassLibrary;
using OpenTK;

namespace TanksGameLibrary
{
    /// <summary>
    /// Абстрактный класс территории.
    /// </summary>
    public abstract class Territory : GameObject
    {
        /// <summary>
        /// Поле, определяющее находится ли танк на территории.
        /// </summary>
        public bool IsDrive { get; protected set; }

        /// <summary>
        /// Конструктор территории.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="scale"></param>
        /// <param name="texture"></param>
        public Territory(Vector position, Vector scale, Texture texture) : base(position, scale, texture)
        {
            IsDrive = false;
        }

        /// <summary>
        /// Абстрактный метод для определения наезда/соприкосновения танка на/с территор(ию)/(ей)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public abstract bool IsCollided(GameObject obj);

        /// <summary>
        /// Абстрактный метод декорирования танка.
        /// </summary>
        /// <param name="tank"></param>
        /// <returns></returns>
        public abstract Tank Decorate(Tank tank);

        /// <summary>
        /// Метод передвижения, обновления кадров и модификации.
        /// </summary>
        public override void Update()
        {

        }
    }
}