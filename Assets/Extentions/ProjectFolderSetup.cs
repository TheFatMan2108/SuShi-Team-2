using UnityEditor;
using UnityEngine;
using System.IO;

public class ProjectFolderSetup : EditorWindow
{
    [MenuItem("Tools/Setup Project Folders")]
    static void CreateFolders()
    {
        string root = "Assets";

        string[] folders = new string[]
        {
            // Tạo thư mục game
            // cấu trúc - Thư mục cha / thư mục con
            "_Game/Animations",
            "_Game/Audio",
            "_Game/Materials",
            "_Game/Models",
            "_Game/Prefabs",
            "_Game/Scenes",
            "_Game/Scripts",
            "_Game/Shaders",
            "_Game/Textures",
            "_Game/UI",

        };

        foreach (string folder in folders)
        {
            string path = Path.Combine(root, folder);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Debug.Log($"📁 Created: {path}");
            }
            else
            {
                Debug.Log($"✅ Already Exists: {path}");
            }
        }

        AssetDatabase.Refresh();
    }
}
