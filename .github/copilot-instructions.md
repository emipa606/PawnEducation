# GitHub Copilot Instructions for RimWorld Modding - Pawn Education (Continued)

## Mod Overview and Purpose
Pawn Education (Continued) is an updated version of Tyler's original mod that allows pawns to educate each other within the RimWorld game. The mod introduces a system where pawns can engage in educational interactions, sharing knowledge and skills based on their passion levels. This interaction enhances the social dynamics and learning opportunities within the RimWorld world.

## Key Features and Systems
- **Educational Interactions**: Pawns can discuss and share skills with each other if the teacher is passionate about the subject, the skill level difference is 2, and the skill is enabled for both.
- **Experience Gain**: The teacher and student gain experience based on their skill levels and passion. The teacher gains more experience than the student.
- **Master Lessons**: When the teacher is a master (skill level 20), there is a 5% chance to give a master lesson, which automatically increases the student's skill level by 2.
- **Thoughts and Moods**: Interactions related to passionate skills or learning from a master can affect pawns' thoughts and moods positively.
- **Configuration File**: The mod generates a configuration file where users can adjust parameters for the interaction algorithms.

## Coding Patterns and Conventions
- **C# Code Structure**: The mod is primarily written in C# with a focus on object-oriented programming principles.
- **Naming Conventions**: Use clear and descriptive variable and method names. Follow the convention of using PascalCase for class names and camelCase for method and variable names.
- **Comments**: Write meaningful comments in your code to explain complex logic or important decisions.
- **Error Handling**: Implement error handling to manage exceptions and unexpected situations gracefully.
- **Mod Settings**: Use the `ModSettings` class to handle configuration settings, as shown in the `ModSettings.cs` file.

## XML Integration
- **Def Files**: The mod uses XML files to define various game elements such as interactions, thoughts, and rules. These files are located in the `Source\TranslationTemplate` directory.
- **Patches**: The mod includes XML patches to modify existing game behavior, as seen in the `Patches` directory.

## Harmony Patching
- **Harmony**: The mod utilizes Harmony to patch existing game methods to add new functionality or modify existing behavior.
- **PatchLoader**: The `PatchLoader.cs` file is responsible for loading and applying Harmony patches.
- **Debug Actions**: The `Dialog_DebugOptionListLister_DoListingItems.cs` file includes debug actions to clear craft thoughts and write mod settings.

## Suggestions for Copilot
- **Generate XML Defs**: Request Copilot to generate XML definitions for new game elements such as interactions, thoughts, and rules.
- **Implement Harmony Patches**: Ask Copilot to assist in implementing Harmony patches to modify existing game methods.
- **Debug Actions**: Request Copilot to help create debug actions for testing and troubleshooting the mod.
- **Mod Settings**: Use Copilot to assist in creating and managing mod settings using the `ModSettings` class.
- **Error Handling**: Ask Copilot to generate error handling code to manage exceptions and unexpected situations.

By following these guidelines, you can effectively use GitHub Copilot to enhance your work on the Pawn Education (Continued) mod, ensuring that your code is clean, efficient, and well-documented.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

