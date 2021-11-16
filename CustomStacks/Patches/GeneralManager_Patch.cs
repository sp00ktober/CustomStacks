using HarmonyLib;
using CustomStacks.Managers;
using UltimateSurvival;

namespace CustomStacks.Patches
{
    [HarmonyPatch(typeof(GeneralManager))]
    class GeneralManager_Patch
    {
        private static bool didApplyChanges = false;

        [HarmonyPrefix]
        [HarmonyPatch(typeof(GeneralManager), "Update")]
        public static bool Update_Patch()
        {
            if (didApplyChanges)
            {
                return true;
            }

            ItemDatabase db = MonoSingleton<InventoryController>.Instance.Database;
            int newMax = ConfigManager.generalStackMaxValue.Value;

            if(newMax <= 0)
            {
                didApplyChanges = true;
                return true;
            }

            foreach(ItemCategory category in db.Categories)
            {
                foreach(ItemData data in category.Items)
                {
                    if(data != null && data.StackSize > 1)
                    {
                        AccessTools.Field(typeof(ItemData), "m_StackSize").SetValue(data, newMax);
                    }
                }
            }

            didApplyChanges = true;
            return true;
        }
    }
}
