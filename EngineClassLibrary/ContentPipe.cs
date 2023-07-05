using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL;
using System.Windows.Forms;

namespace EngineClassLibrary
{
    /// <summary>
    /// Класс, который загружает текстуру.
    /// </summary>
    public static class ContentPipe
    {
        private static string currDir = Directory.GetCurrentDirectory();
        /// <summary>
        /// Метод для загрузки спрайта.
        /// </summary>
        /// <param name="path">Путь к изображению</param>
        /// <returns></returns>
        public static Texture LoadTexture(string path)
        {
            // D:\Documents\PSP\Tanks\TanksWFA\bin\Debug\Content
            if (!File.Exists(ContentPipe.currDir + @"\Content\" + path))
            {
                throw new FileNotFoundException(@"'D:\Documents\PSP\Tanks\TanksWFA\bin\Debug\Content\" + path + "'");
            }

            int id = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, id);

            Bitmap bmp = new Bitmap(ContentPipe.currDir + @"\Content\" + path);
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            bmp.UnlockBits(data);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)
                TextureWrapMode.Clamp);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)
                TextureWrapMode.Clamp);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)
                TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)
                TextureMagFilter.Linear);

            return new Texture(id, bmp.Width, bmp.Height);
        }

    }
}
