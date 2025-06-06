﻿using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace DBToggler.Core
{
    [BepInPlugin(GUID, NAME, VERSION)]
    [BepInProcess("CharaStudio")]
    public class Init : BaseUnityPlugin
    {
        private bool liveedit = true;
        private const string GUID = "fox.dbtoggler";
        private const string NAME = "Dynamic Bone Toggler";
        private const string VERSION = "1.0";
        internal static ConfigEntry<KeyboardShortcut> EnableDynamicBonesKey;
        internal static ConfigEntry<KeyboardShortcut> DisableDynamicBonesKey;
        public static ManualLogSource _logger;
        private static GameObject bepinex;
        private static Harmony harmony;

        private void Awake()
        {
            EnableDynamicBonesKey = Config.Bind("Bones", "Enable", new KeyboardShortcut(KeyCode.G), "Partial support");
            DisableDynamicBonesKey =
                Config.Bind("Bones", "Disable", new KeyboardShortcut(KeyCode.H), "Partial support");
            _logger = Logger;
            bepinex = gameObject;
            harmony = Harmony.CreateAndPatchAll(GetType());
        }

        private void OnDestroy()
        {
            harmony?.UnpatchSelf();
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(StudioScene), nameof(StudioScene.Start))]
        private static void StudioEntry()
        {
            bepinex.GetOrAddComponent<ToggleDynamicBones>();
        }
    }
}