using EngineClassLibrary;
using OpenTK;

namespace TanksGameLibrary
{
    /// <summary>
    /// Класс заднего фона игры.
    /// </summary>
    public class Background : GameObject
    {
        private static Texture sprite = ContentPipe.LoadTexture("Background.png");
        /// <summary>
        /// Консруктор для создания объекта заднего фона игры.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="scale"></param>
        /// <param name="texture"></param>
        public Background(Vector position, Vector scale) : base(position, scale, sprite)
        { }
        /// <summary>
        /// Метод передвижения, обновления кадровы и модификации.
        /// </summary>
        public override void Update()
        { }
    }
}
