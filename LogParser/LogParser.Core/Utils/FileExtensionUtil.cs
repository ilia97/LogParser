namespace LogParser.Core.Utils
{
    public class FileExtensionUtil
    {
        private static string[] pictureExtensions = new string[] { "jpeg", "jpg", "tiff", "gif", "bmp", "png", "bat", "bpg" };

        private static string[] cssExtensions = new string[] { "css", "scss" };

        private static string[] scriptExtensions = new string[] { "js", "cgi" };

        public static bool IsPicture(string fileName)
        {
            return IsFileOfType(fileName, pictureExtensions);
        }

        public static bool IsCssFile(string fileName)
        {
            return IsFileOfType(fileName, cssExtensions);
        }

        public static bool IsScriptFile(string fileName)
        {
            return IsFileOfType(fileName, scriptExtensions);
        }

        private static bool IsFileOfType(string fileName, string[] extensions)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                foreach (var extension in extensions)
                {
                    if (fileName.EndsWith($".{extension}"))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
