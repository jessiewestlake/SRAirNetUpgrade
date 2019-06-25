using UnityEngine;
using HarmonyLib;

namespace SRAirNetUpgrade.Patches
{
    [HarmonyPatch(typeof(AirNet))]
    [HarmonyPatch("OnCollisionEnter")]
    static class Patch_AirNetStrength
    {
        static bool Prefix(AirNet __instance, float ___netStrength)
        {
            ___netStrength = 1f;
            __instance.brokenColor = Color.blue;
            __instance.fullColor = Color.blue;
            return false;
        }
    }
}