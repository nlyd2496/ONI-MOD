using System;
using KMod;
//--------------------------------------------------无需更改--------------------------------------------------
namespace CaiLib.Logger
{
    public static class Logger
    {
        public static void LogInit(Mod mod)
        {
            Logger._mod = mod;
            string[] array = new string[5];
            array[0] = Logger.Timestamp();
            array[1] = " <<-- CaiLib -->> Loaded [ ";
            array[2] = ((mod != null) ? mod.title : null);
            array[3] = " ] with version ";
            int num = 4;
            bool flag = mod == null;
            string text;
            if (flag)
            {
                text = null;
            }
            else
            {
                Mod.PackagedModInfo packagedModInfo = mod.packagedModInfo;
                text = ((packagedModInfo != null) ? packagedModInfo.version : null);
            }
            array[num] = text;
            Console.WriteLine(string.Concat(array));
        }
        public static void Log(string message)
        {
            bool flag = Logger._mod == null;
            if (flag)
            {
                Console.WriteLine(Logger.Timestamp() + " <<-- CaiLib -->> Looks like you have not called LogInit! Please do that before using CaiLib.Log()");
            }
            string[] array = new string[5];
            array[0] = Logger.Timestamp();
            array[1] = " <<-- ";
            int num = 2;
            Mod mod = Logger._mod;
            array[num] = ((mod != null) ? mod.title : null);
            array[3] = " -->> ";
            array[4] = message;
            Console.WriteLine(string.Concat(array));
        }
        private static string Timestamp()
        {
            return System.DateTime.UtcNow.ToString("[HH:mm:ss.fff]");
        }
        private static Mod _mod;
    }
}
