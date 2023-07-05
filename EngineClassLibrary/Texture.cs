namespace EngineClassLibrary
{
    /// <summary>
    /// Класс, который хранит текстуру.
    /// </summary>
    public class Texture
    {
        /// <summary>
        /// Свойство, хранящее идентификатор текстуры.
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Ширина текстуры.
        /// </summary>
        public int Width { get; private set; }
        /// <summary>
        /// Длина текстуры.
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Констуктор создания класса Texture.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Texture(int id, int width, int height)
        {
            Id = id;
            Width = width;
            Height = height;
        }
    }
}
