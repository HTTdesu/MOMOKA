using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace MOMOKA.Common
{
    public static class MMKUtils
    {
        public static string MakeValidFullPath(string path, string extension = null)
        {
            string fullPath = Path.GetFullPath(path).Replace('\\', '/');
            string directory = Path.GetDirectoryName(fullPath);
            if (!directory.StartsWith(Application.dataPath + "/"))
            {
                fullPath = Path.GetFullPath("Assets/" + path);
                directory = Path.GetDirectoryName(fullPath);
            }

            if (!string.IsNullOrEmpty(extension))
            {
                Path.ChangeExtension(fullPath, extension);
            }

            return fullPath;
        }
    }
}
