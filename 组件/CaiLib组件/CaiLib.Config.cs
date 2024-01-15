using System;
using System.IO;
using CaiLib.Logger;
using KMod;
using Newtonsoft.Json;
//--------------------------------------------------无需更改--------------------------------------------------
namespace CaiLib.Config
{
    public class ConfigManager<T> where T : class, new()
    {
        public T Config { get; set; }
        public ConfigManager(Mod mod, string configFileName = "Config.json")
        {
            this._modPath = mod.ContentPath;
            this._configFileName = configFileName;
        }
        public T ReadConfig(System.Action postReadAction = null)
        {
            this.Config = Activator.CreateInstance<T>();
            string text = Path.Combine(this._modPath, this._configFileName);
            Debug.Log(text);
            T config;
            try
            {
                using (StreamReader streamReader = new StreamReader(text))
                {
                    config = JsonConvert.DeserializeObject<T>(streamReader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                CaiLib.Logger.Logger.Log("Failed to read config file " + this._configFileName + " with exception: " + ex.Message);
                return this.Config;
            }
            this.Config = config;
            bool flag = postReadAction != null;
            if (flag)
            {
                postReadAction();
            }
            return this.Config;
        }
        public bool SaveConfigToFile()
        {
            string directoryName = Path.GetDirectoryName(this._modPath);
            bool flag = directoryName == null;
            bool result;
            if (flag)
            {
                CaiLib.Logger.Logger.Log(string.Concat(new string[]
                {
                    "Failed to read file ",
                    this._configFileName,
                    " - cannot get directory name for executing assembly path ",
                    this._modPath,
                    "."
                }));
                result = false;
            }
            else
            {
                string path = Path.Combine(directoryName, this._configFileName);
                try
                {
                    using (StreamWriter streamWriter = new StreamWriter(path))
                    {
                        string value = JsonConvert.SerializeObject(this.Config, Formatting.Indented);
                        streamWriter.Write(value);
                    }
                }
                catch (Exception ex)
                {
                    CaiLib.Logger.Logger.Log("Failed to write to config file " + this._configFileName + " with exception: " + ex.Message);
                    return false;
                }
                result = true;
            }
            return result;
        }
        private readonly string _modPath;
        private readonly string _configFileName;
    }
}
