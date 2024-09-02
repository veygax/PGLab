using Il2CppSLZ.VRMK;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace PGLab.Softbody
{
    /// <summary>
    /// Contains patches to modify the butt mesh generation in the game.
    /// </summary>
    internal class ButtPatches
    {
        /// <summary>
        /// Applies the patches to modify the butt mesh generation.
        /// </summary>
        /// <param name="mod">The MelonMod instance.</param>
        public static void ApplyPatches(MelonMod mod)
        {
            var harmony = mod.HarmonyInstance;

            var method1 = typeof(Avatar).GetMethod("GenerateButtMesh");
            var patchMethod = typeof(BreastPatches).GetMethod(nameof(DontRunThis), BindingFlags.Static | BindingFlags.Public);

            if (method1 != null && patchMethod != null)
            {
                harmony.Patch(method1, new HarmonyMethod(patchMethod));
#if DEBUG
                MelonLogger.Msg("Patched Avatar.GenerateButtMesh method.");
#endif
            }
            else
            {
#if DEBUG
                MelonLogger.Error("Failed to patch Avatar.GenerateButtMesh method: method or patchMethod is null.");
#endif
            }
        }

        /// <summary>
        /// Reverts the patches that modify the butt mesh generation.
        /// </summary>
        /// <param name="mod">The MelonMod instance.</param>
        public static void RevertPatches(MelonMod mod)
        {
            var harmony = mod.HarmonyInstance;

            var method1 = typeof(Avatar).GetMethod("GenerateButtMesh");

            if (method1 != null)
            {
                harmony.Unpatch(method1, HarmonyPatchType.Prefix);
#if DEBUG
                MelonLogger.Msg("Unpatched Avatar.GenerateButtMesh method.");
#endif
            }
            else
            {
#if DEBUG
                MelonLogger.Error("Failed to unpatch Avatar.GenerateButtMesh method: method is null.");
#endif
            }
        }

        /// <summary>
        /// Prevents the execution of the original method.
        /// </summary>
        /// <param name="__originalMethod">The original method being patched.</param>
        /// <returns>Always returns false to prevent the original method from running.</returns>
        public static bool DontRunThis(MethodBase __originalMethod)
        {
#if DEBUG
            MelonLogger.Msg($"DontRunThis method called. Preventing execution of {__originalMethod.DeclaringType.Name}.{__originalMethod.Name}.");
#endif
            return false;
        }
    }
}
