using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace EngineClassLibrary
{
    /// <summary>
    /// Класс отрисовки спрайта.
    /// </summary>
    public class SpriteBatch
    {
        /// <summary>
        /// Метод для отрисовки объекта.
        /// </summary>
        /// <param name="gameObject"></param>
        public static void Draw(GameObject gameObject)
        {
            Texture texture = gameObject.Texture;
            Vector2 position = new Vector2(gameObject.Position.X, gameObject.Position.Y);
            Vector2 size = new Vector2(gameObject.Scale.X, gameObject.Scale.Y);

            Vector2[] vertices = new Vector2[4]
            {
                new Vector2(0, 0),
                new Vector2(1, 0),
                new Vector2(1, 1),
                new Vector2(0, 1)
            };

            GL.BindTexture(TextureTarget.Texture2D, texture.Id);
            GL.Begin(PrimitiveType.Quads);

            for (int i = 0; i < 4; i++)
            {
                GL.TexCoord2(vertices[i]);
                vertices[i].X *= texture.Width;
                vertices[i].Y *= texture.Height;
                vertices[i] *= size;
                vertices[i] -= position;
                GL.Vertex2(vertices[i]);
            }
            GL.End();
        }
    }
}
