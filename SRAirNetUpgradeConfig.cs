using System;
using UModFramework.API;

namespace SRAirNetUpgrade
{
    internal class SRAirNetUpgradeConfig
    {
        private static readonly string configVersion = "1.0";

        //Add your config vars here.

        internal void Load()
        {
            SRAirNetUpgrade.Log("Loading settings.");
            try
            {
                using (UMFConfig cfg = new UMFConfig())
                {
                    string cfgVer = cfg.Read("ConfigVersion", new UMFConfigString());
                    if (cfgVer != string.Empty && cfgVer != configVersion)
                    {
                        cfg.DeleteConfig(false);
                        SRAirNetUpgrade.Log("The config file was outdated and has been deleted. A new config will be generated.");
                    }

                    //cfg.Write("SupportsHotLoading", new UMFConfigBool(false)); //Uncomment if your mod can't be loaded once the game has started.
                    cfg.Read("LoadPriority", new UMFConfigString("Normal"));
                    cfg.Write("MinVersion", new UMFConfigString("0.52"));
                    //cfg.Write("MaxVersion", new UMFConfigString("0.54.99999.99999")); //Uncomment if you think your mod may break with the next major UMF release.
                    cfg.Write("UpdateURL", new UMFConfigString(""));
                    cfg.Write("ConfigVersion", new UMFConfigString(configVersion));

                    SRAirNetUpgrade.Log("Finished UMF Settings.");

                    //Add your settings here

                    SRAirNetUpgrade.Log("Finished loading settings.");
                }
            }
            catch (Exception e)
            {
                SRAirNetUpgrade.Log("Error loading mod settings: " + e.Message + "(" + e.InnerException?.Message + ")");
            }
        }

        public static SRAirNetUpgradeConfig Instance { get; } = new SRAirNetUpgradeConfig();
    }
}