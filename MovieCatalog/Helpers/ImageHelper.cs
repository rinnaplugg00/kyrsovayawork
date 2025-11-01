using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MovieCatalog.Helpers
{
    public static class ImageHelper
    {
        public static string CopyPosterToFolder(string sourcePath)
        {
            if (string.IsNullOrEmpty(sourcePath) || !File.Exists(sourcePath))
                return "";

            var postersDir = Path.Combine(Application.StartupPath, "Resources", "Posters");
            Directory.CreateDirectory(postersDir);

            var fileName = Path.GetFileName(sourcePath);
            var destPath = Path.Combine(postersDir, fileName);
            File.Copy(sourcePath, destPath, true);

            return destPath;
        }

        public static Image LoadPoster(string path, int width = 150, int height = 200)
        {
            if (!File.Exists(path)) return null;

            var img = Image.FromFile(path);
            return new Bitmap(img, new Size(width, height));
        }
    }
}
