using EngineClassLibrary;
using OpenTK;

namespace TanksGameLibrary
{
    /// <summary>
    /// Абстрактный класс приза.
    /// </summary>
    public abstract class Prize : GameObject
    {
        /// <summary>
        /// Поле, которое показывает подобран ли приз.
        /// </summary>
        public bool IsUse { get; set; }

        /// <summary>
        /// Конструктор для создания приза.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="scale"></param>
        public Prize(Vector position, Vector scale, Texture texture) : base(position, scale, texture)
        {
            IsUse = false;
        }

        public Prize()
        {

        }

        /// <summary>
        /// Метод для модификации и/или отрисовки кадров.
        /// </summary>
        public override void Update()
        { }

        /// <summary>
        /// Абстрактный метод для декорирования танка.
        /// </summary>
        /// <param name="tank"></param>
        /// <returns></returns>
        public abstract Tank Decorate(Tank tank);
    }
}
