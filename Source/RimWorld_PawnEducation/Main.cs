using Verse;

namespace PawnEducation.Harmony;

[StaticConstructorOnStartup]
internal static class Main
{
    static Main()
    {
        var message = "pawn.education : ";
        ModSettings.ReadModSettings(ref message);
    }
}