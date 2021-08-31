using UnityEngine;
using UnityEditor;
using System.IO;
using static System.IO.Directory;
using static System.IO.Path;
using static UnityEngine.Application;
using static UnityEditor.AssetDatabase;

namespace DT
{
    public static class ToolsMenu 
    {
        [MenuItem("Tools/Setup/Create Default Folders")]
        public static void CreateDefaultFolders()
        {
            CreateDirectories("_Project", "Scripts", "Scenes", "Prefabs", "Art");
            Refresh();
        }

        public static void CreateDirectories(string root, params string[] dirs)
        {
            var fullPath = Combine(dataPath, root);

            foreach (string directory in dirs)
                CreateDirectory(Combine(fullPath, directory));
        }
    }
}
