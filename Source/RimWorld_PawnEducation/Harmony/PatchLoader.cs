using HarmonyLib;
using System.Reflection;
using Verse;

namespace PawnEducation.Harmony
{
    [StaticConstructorOnStartup]
    internal class PatchLoader
    {
        static PatchLoader()
        {
            var instance = new HarmonyLib.Harmony("pawn.education");
            instance.PatchAll(Assembly.GetExecutingAssembly());
            string message = "pawn.education : patched DoListingItems";

            ModSettings.ReadModSettings(ref message);
            Log.Message(message, false);
        }
    }
}
