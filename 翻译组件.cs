using HarmonyLib;
using KMod;
using System;
using System.IO;
using System.Reflection;
using TUNING;

namespace 吐泡泡的小鱼的缺氧模组
{
    public static class Utils
    {
        public static Utils.ModInfo modInfo
        {
            get
            {
                if (Utils._modinfo == null)
                {
                    Utils._modinfo = new Utils.ModInfo();
                }
                return Utils._modinfo;
            }
        }
        public static void Localize(Type root)
        {
            ModUtil.RegisterForTranslation(root);
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            string name = executingAssembly.GetName().Name;
            string path = Path.Combine(Path.GetDirectoryName(executingAssembly.Location), "translations");
            Localization.Locale locale = Localization.GetLocale();
            if (locale != null)
            {
                try
                {
                    string text = Path.Combine(path, locale.Code + ".po");
                    Debug.LogWarning(name + " lang file: " + text);
                    if (File.Exists(text))
                    {
                        Debug.Log(name + ": Localize file found " + text);
                        Localization.OverloadStrings(Localization.LoadStringsFile(text, false));
                    }
                }
                catch
                {
                    Debug.LogWarning(name + " Failed to load localization.");
                }
            }
            LocString.CreateLocStringKeys(root, "");
        }
        private static Utils.ModInfo _modinfo;
        public class ModInfo
        {
            public ModInfo()
            {
                Assembly executingAssembly = Assembly.GetExecutingAssembly();
                this.assemblyName = executingAssembly.GetName().Name;
                this.rootDirectory = Path.GetDirectoryName(executingAssembly.Location);
                this.langDirectory = Path.Combine(this.rootDirectory, "translations");
                this.spritesDirectory = Path.Combine(this.rootDirectory, "sprites");
                this.version = executingAssembly.GetName().Version.ToString();
            }
            public readonly string assemblyName;
            public readonly string rootDirectory;
            public readonly string langDirectory;
            public readonly string spritesDirectory;
            public readonly string version;
        }
    }
    //------------------------------------------------------------------------------------------------
}
