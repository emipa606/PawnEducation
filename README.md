# PawnEducation

![Image](https://i.imgur.com/WAEzk68.png)

Update of Tylers mod
https://steamcommunity.com/sharedfiles/filedetails/?id=1729795429

- Added russian translation, via Reiquard

![Image](https://i.imgur.com/7Gzt3Rg.png)


[table]
    [tr]
        [td]https://invite.gg/Mlie]![Image](https://i.imgur.com/zdzzBrc.png)
[/td]
        [td]https://github.com/emipa606/PawnEducation]![Image](https://i.imgur.com/kTkpTOE.png)
[/td]
    [/tr]
[/table]
	
![Image](https://i.imgur.com/NOW7jU1.png)

A mod that allows pawns to educate each other. 

# Description

A mod that allows pawns to educate each other. The higher the passion for the subject, the higher the odds of discussion and the more experience is shared.
When the teacher has skill level 20, something special may happen... :)
  
Savegame compatible. 

Should not conflict with any mods

I did not spend a ton of time testing the balance (activation odds, exp gain). Please let me know your opinions on the balance of activation odds and exp gain, or if you notice any spelling errors in the log.

This mod has one of my other mods built in (Empty Play Log) in order to allow uninstalling. If you are subscribed to this one, you don&apos;t need Empty Play Log. Subscribing to both will cause the button to show up twice, but shouldn&apos;t cause any other problems. 

# Functionality Specifics

[spoiler]Interaction will only activate for skills that
1. The teacher is passionate in
2. The difference between teacher/student skill is = 2
3. Skill is enabled for both teacher/student (not disabled by traits or lack of body parts)

Activation rate is affected by combined passion of teacher and student, from a min-weight = 0.2 to a max-weight = 0.8. For comparison, the default activation weight of the &apos;chat&apos; interaction, provided necessary circumstances are met, is 0.8.

Teacher xp gain = 2 * (20/ {difference in skill})
Student xp gain = 2 * {difference in skill} * 3

Teacher gets a 2x xp multiplier for burning passion
Student gets a 4x xp multiplier for burning passion, and a 2x xp multiplier for regular passion
Student gets a 8x xp multiplier if the teacher is a master (Skill = 20). This is not combined with other xp modifiers for the student.
If the teacher is a master (Skill=20), there is a 5% chance he/she will give a &apos;master lesson&apos;. This is an automatic 2 level increase to the skill for the student. If this activates, the student does not get other skill gains listed above. The teacher gets the same xp bonus regardless.

[u]Thoughts/moods[/u]
Check the ThoughtsDef file for specifics on how social/opinions are affected

Teaching/learning a passionate skill gives a +1 mood buff, lasting 3 days, stacking up to 5 times
Teaching/learning a burning passionate skill gives a +3 mood buff, lasting 3 days, stacking up to 5 times, with a 0.67x multiplier on each additional stack
Learning from a master gives a +10 mood buff, lasting 3 days, stacking up to 5 times, with a 0.5x multiplier on each addtional stack

Pawns with the &apos;Psychopath&apos; trait do not get social or mood boosts because they are Psychopaths. Pawns with the &apos;Too Smart&apos; trait also do not get social or mood boosts.
[/spoiler]


# Configuration

Upon loading the mod the first time, a file should get generated at C:\Users\{USER}\AppData\LocalLow\Ludeon Studios\RimWorld by Ludeon Studios\Config\PawnEducation.config . The values in this file can be edited/saved to change the parameters of the interaction algorithms. Setting values too high might cause errors. Some values are explicitly capped due to game engine limitations.

To edit opinion/mood gains from interactions, modify the Def files at :
{STEAM_INSTALL_LOCATION}\steamapps\workshop\content\294100\1729795429\Defs

Where {STEAM_INSTALL_LOCATION} is the location of the Steam partition containing RimWorld


# Uninstalling

1. Load your existing save
2. Put the game into &apos;pause&apos; mode
3. Click the debug action &apos;Clear Play Log&apos; under &apos;Mods - Misc&apos;
4. Make a new save
5. Exit to menu
6. Disable/unsubcribe from Pawn Education
7. Load new save (ignore warnings)

# Dependencies

None

# Synergy

works well with Orion&apos;s Hospitality mod - https://steamcommunity.com/sharedfiles/filedetails/?id=753498552

# Honourable Mentions

pardeike/Harmony - https://github.com/pardeike/Harmony/
Mlie, for updating the mod for 1.1

# Future Enhancements

Translations
Incorporating Insult/Social fight chances into the mix

![Image](https://i.imgur.com/Rs6T6cr.png)



-  See if the the error persists if you just have this mod and its requirements active.
-  If not, try adding your other mods until it happens again.
-  Post your error-log using https://steamcommunity.com/workshop/filedetails/?id=818773962]HugsLib and command Ctrl+F12
-  For best support, please use the Discord-channel for error-reporting.
-  Do not report errors by making a discussion-thread, I get no notification of that.
-  If you have the solution for a problem, please post it to the GitHub repository.



