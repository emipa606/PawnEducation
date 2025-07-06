using System.Reflection;
using Verse;

namespace PawnEducation.Harmony;

[StaticConstructorOnStartup]
internal class PatchLoader
{
    static PatchLoader()
    {
        new HarmonyLib.Harmony("pawn.education").PatchAll(Assembly.GetExecutingAssembly());
        var message = "pawn.education : patched DoListingItems";

        ModSettings.ReadModSettings(ref message);
    }
}