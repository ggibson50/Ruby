using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ruby.ViewModels
{
    public class Constants
    {
        public const string SERVER_IMAGE_PATH = "~/Content/ServerImages/";
        public const string USER_IMAGE_PATH = "~/Content/UserImages/";

        public const string THUMBNAILS = "Thumbnails/";

        public const int MAX_FILE_SIZE = 5 * 1024 * 1024;


        public static readonly string[] FILE_EXTENSIONS = new string[]
        {
            ".jpg", ".jpeg.", ".gif", ".png"
        };
    }
}