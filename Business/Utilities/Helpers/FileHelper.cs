using System.IO;

namespace Business.Utilities.Helpers
{
    public static class FileHelper
    {
        public static void RemoveFile(string root, string image, params string[] folders)
        {
            string path = Path.Combine(root, folders[0], folders[1], image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }
    }
}