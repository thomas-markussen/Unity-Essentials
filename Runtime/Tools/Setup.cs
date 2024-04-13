using UnityEngine;
using UnityEditor;
using static System.IO.Directory;
using static System.IO.Path;
using static UnityEditor.AssetDatabase;
using UnityEditor.PackageManager;

public static class Setup
{
    [MenuItem("Tools/Setup/Create Default Folders")]
    public static void CreateDefaultFolders()
    {
        Folders.CreateDefault("_Project", "Animation", "Art", "Materials", "Prefabs", "ScriptableObjects", "_Scripts", "Settings");
        Refresh();
    }

    [MenuItem("Tools/Setup/Import Basics")]
    public static void ImportBasicAssets()
    {
        Debug.Log("Importing Assets...");

        // Git
        Client.Add("git+https://github.com/starikcetin/Eflatun.SceneReference.git#4.0.0");
        Client.Add("git+https://github.com/KyleBanks/scene-ref-attribute.git");
        Client.Add("git+https://github.com/mob-sakai/UIEffect.git");
        Client.Add("git+https://github.com/mob-sakai/SoftMaskForUGUI.git");
        Client.Add("git+https://github.com/thomas-markussen/Unity-Bootstrapper.git");

        //Asset Store
        Assets.ImportAsset("DOTween Pro.unitypackage", "Demigiant/Editor ExtensionsVisual Scripting");
        Assets.ImportAsset("Cartoon FX Remaster.unitypackage", "Jean Moreno/Particle Systems");
    }



    static class Folders
    {
        public static void CreateDefault(string root, params string[] folders)
        {
            var fullpath = Combine(Application.dataPath, root);
            foreach (var folder in folders)
            {
                var path = Combine(fullpath, folder);
                if (!Exists(path)) CreateDirectory(path);
            }
        }
    }

    static class Assets
    {
        public static void ImportAsset(string asset, string subfolder, string folder = "C:/Users/Thomas/AppData/Roaming/Unity/Asset Store-5.x")
        {
            ImportPackage(Combine(folder, subfolder, asset), false);
        }
    }
}
