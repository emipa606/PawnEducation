using LudeonTK;
using RimWorld;
using Verse;

namespace PawnEducation;

public static class DebugPawnEduction
{
    [DebugAction("Pawn Education", "Clear Play Log", actionType = DebugActionType.Action,
        allowedGameStates = AllowedGameStates.Playing)]
    private static void DebugAction_ClearCraftThoughts()
    {
        Find.PlayLog.AllEntries.Clear();
        Messages.Message("Play log cleared, it is now safe to uninstall Pawn Education.",
            MessageTypeDefOf.NeutralEvent);
    }
}