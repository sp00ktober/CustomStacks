using BepInEx;
using BepInEx.Configuration;
//using System.Collections.Generic;

namespace CustomStacks.Managers
{
    public class ConfigManager
    {
        public static ConfigFile confFile { get; set; }
        public static ConfigEntry<int> generalStackMaxValue { get; set; }
        //public static ConfigEntry<Dictionary<int, int>> specificStackMaxValue { get; set; }

        public static void InitConfigSettings()
        {
            confFile = new ConfigFile(Paths.ConfigPath + "\\CustomStacks.cfg", true);

            generalStackMaxValue = confFile.Bind<int>(
                "generalStackMaxValue",
                "generalStackMaxValue",
                99,
                "Sets the max stack size for every item. 0 defaults to vanilla values, as well as negative values.");
            /*
            specificStackMaxValue = confFile.Bind<Dictionary<int, int>>(
                "generalStackMaxValue",
                "generalStackMaxValue",
                null,
                "Sets the max stack size for specific items by matching their item id. if not set defaults to generalStackMaxValue.");
            */
        }
    }
}
