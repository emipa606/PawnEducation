﻿using Verse;
using RimWorld;
using System.Collections.Generic;
using System.Linq;

namespace PawnEducation
{
    public class InteractionWorker_Education : InteractionWorker
    {
        private SkillRecord taggedInitiatorSkill = null;

        public override float RandomSelectionWeight(Pawn initiator, Pawn recipient)
        {
            if (initiator == null || recipient == null) return 0f;

            int weightMult = 0;

            taggedInitiatorSkill = RandomSkillToDiscuss(initiator, recipient);

            //no passion, recipient is more educated in relevant skills than initiator, or passionate skills are disabled on initiator or recipient :(
            if (taggedInitiatorSkill == null) return 0f;

            SkillRecord recipientSkill = recipient.skills.GetSkill(taggedInitiatorSkill.def);

            //baseWeight.min = 0.20, baseWeight.max = 0.80
            weightMult += (int)recipientSkill.passion + (int)taggedInitiatorSkill.passion;

            return ModSettings.instance.baseInteractionWeight * weightMult * ModSettings.instance.interactionAdjustMultiplier;
        }

        public override void Interacted(Pawn initiator, Pawn recipient, List<RulePackDef> extraSentencePacks, out string letterText, out string letterLabel, out LetterDef letterDef, out LookTargets lookTargets)
        {
            letterText = null;
            letterDef = null;
            letterLabel = null;
            lookTargets = null;

            int baseExp = ModSettings.instance.baseInteractionExp;
            SkillRecord recipientSkill = recipient.skills.GetSkill(taggedInitiatorSkill.def);

            //the higher the difference in skill between the two, the more experience the recipient gets/the less the initiator gets reciprocated
            //the world's shittiest algorithm right here, probably make it better at some point
            int skillDiff = taggedInitiatorSkill.Level - recipientSkill.Level;
            int initiatorExp = baseExp * (ModSettings.instance.baseInteractionIntiatorDividend / skillDiff);
            int recipientExp = baseExp * skillDiff * ModSettings.instance.baseInteractionRecipientExpMultiplier;

            //load log sentences based on which skill was discussed
            LoadSkillBasedSentences(extraSentencePacks);
            InitiatorLearn(initiator, recipient, initiatorExp);
            RecipientLearn(initiator, recipient, recipientSkill, recipientExp, extraSentencePacks);
        }

        private void InitiatorLearn(Pawn initiator, Pawn recipient, int initiatorExp)
        {
            //bonus to exp based on passion, and set thoughts
            switch (taggedInitiatorSkill.passion)
            {
                case Passion.Major:
                    initiatorExp *= ModSettings.instance.interactionInitiatorMajorPassionExpMultiplier;
                    ApplyThought(initiator, recipient, "PawnEducation_BurningPassionTeach");
                    break;
                case Passion.Minor:
                    ApplyThought(initiator, recipient, "PawnEducation_PassionTeach");
                    break;
            }

            taggedInitiatorSkill.Learn(initiatorExp);
        }

        private void RecipientLearn(Pawn initiator, Pawn recipient, SkillRecord recipientSkill, int recipientExp, List<RulePackDef> extraSentencePacks)
        {
            bool recipientSpecialLearn = false;

            if (taggedInitiatorSkill.Level == ModSettings.instance.interactionInitiatorMasterLessionLevelRequirement)
            {
                //learned from the master
                if (Rand.Value < ModSettings.instance.interactionRecipientMasterLessonChance)
                {
                    //master lesson
                    recipientSpecialLearn = true;
                    recipientSkill.Level += ModSettings.instance.interactionRecipientMasterLessonLevelGain;
                    Messages.Message("MasterLesson".Translate(recipient.LabelShort, recipientSkill.def.label, initiator.LabelShort,
                            recipient.Named("RECIPIENT"), recipientSkill.def.Named("SKILL"), initiator.Named("INITIATOR")), MessageTypeDefOf.PositiveEvent);
                }
                else
                {
                    //regular lesson from master
                    recipientExp *= ModSettings.instance.interactionRecipientMasterEducationExpMultiplier;
                }
                ApplyInteractionAndThought(recipient, initiator, "PawnEducation_MasterLearn", extraSentencePacks);
            }
            else
            {
                //bonus to exp based on passion, and set thoughts
                switch (recipientSkill.passion)
                {
                    case Passion.Major:
                        recipientExp *= ModSettings.instance.interactionRecipientMajorPassionExpMultiplier;
                        ApplyInteractionAndThought(recipient, initiator, "PawnEducation_BurningPassionLearn", extraSentencePacks);
                        break;
                    case Passion.Minor:
                        recipientExp *= ModSettings.instance.interactionRecipientMinorPassionExpMultiplier;
                        ApplyInteractionAndThought(recipient, initiator, "PawnEducation_PassionLearn", extraSentencePacks);
                        break;
                    default:
                        ApplyInteractionAndThought(recipient, initiator, "PawnEducation_NoPassionLearn", extraSentencePacks);
                        break;
                }
            }

            if (!recipientSpecialLearn) recipientSkill.Learn(recipientExp);
        }

        private SkillRecord RandomSkillToDiscuss(Pawn initiator, Pawn recipient)
        {
            return (from SkillRecord iSkill in initiator.skills.skills
                    join SkillRecord rSkill in recipient.skills.skills on iSkill.def equals rSkill.def into rS
                    from rSkill in rS
                    where rSkill != null && iSkill.passion != Passion.None && !iSkill.TotallyDisabled && !rSkill.TotallyDisabled && (iSkill.Level - rSkill.Level) >= 2
                    select iSkill).DefaultIfEmpty(null).RandomElement<SkillRecord>();
        }

        private void LoadSkillBasedSentences(List<RulePackDef> extraSentencePacks)
        {
            extraSentencePacks.Add(RulePackDef.Named($"PawnEducation_{taggedInitiatorSkill.def.defName}"));
        }

        private void ApplyInteractionAndThought(Pawn thoughtReceiver, Pawn thoughtTarget, string defName, List<RulePackDef> extraSentencePacks)
        {
            RulePackDef rulePack = RulePackDef.Named(defName);
            extraSentencePacks.Add(rulePack);

            if (!defName.Contains("NoPassion")) ApplyThought(thoughtReceiver, thoughtTarget, defName);
        }

        private void ApplyThought(Pawn thoughtReceiver, Pawn thoughtTarget, string defName)
        {
            ThoughtDef thought = ThoughtDef.Named(defName);
            if (ThoughtUtility.CanGetThought(thoughtReceiver, thought)) thoughtReceiver.needs.mood.thoughts.memories.TryGainMemory((Thought_Memory)ThoughtMaker.MakeThought(thought), thoughtTarget);
        }
    }
}
