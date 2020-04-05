using System;
using System.Xml.Serialization;
using Verse;
using System.IO;
using System.Xml;

namespace PawnEducation
{
    [Serializable]
    public class ModSettings
    {
        public static ModSettings instance = new ModSettings();

        public static void Init(ModSettings settings)
        {
            instance.baseInteractionWeight = settings.baseInteractionWeight;
            instance.interactionAdjustMultiplier = settings.interactionAdjustMultiplier;
            instance.baseInteractionExp = settings.baseInteractionExp;
            instance.baseInteractionRecipientExpMultiplier = settings.baseInteractionRecipientExpMultiplier;
            instance.interactionInitiatorMajorPassionExpMultiplier = settings.interactionInitiatorMajorPassionExpMultiplier;
            instance.interactionRecipientMinorPassionExpMultiplier = settings.interactionRecipientMinorPassionExpMultiplier;
            instance.interactionRecipientMasterEducationExpMultiplier = settings.interactionRecipientMasterEducationExpMultiplier;
            instance.interactionRecipientMasterLessonLevelGain = Math.Min(settings.interactionRecipientMasterLessonLevelGain, (byte)20);
            instance.interactionRecipientMasterLessonChance = Math.Min(settings.interactionRecipientMasterLessonChance, 1);
            instance.interactionInitiatorMasterLessionLevelRequirement = Math.Min(settings.interactionInitiatorMasterLessionLevelRequirement, (byte)20);
        }

        public static void ReadModSettings(ref string message)
        {
            string path = $"{GenFilePaths.ConfigFolderPath}\\PawnEducation.config";

            if (File.Exists(path))
            {
                XmlSerializer xml = new XmlSerializer(typeof(ModSettings));
                FileStream file = new FileStream(path, FileMode.Open);

                if (file.CanRead)
                {
                    ModSettings.Init((ModSettings)xml.Deserialize(file));
                    message += ", loaded settings";
                }

                file.Flush();
                file.Close();
                file.Dispose();
                xml = null;
                file = null;
            }
            else
            {
                ModSettings.instance = new ModSettings();
                WriteModSettings();
                message += ", generated settings file";
            }
        }

        public static void WriteModSettings()
        {
            string path = $"{GenFilePaths.ConfigFolderPath}\\PawnEducation.config";

            XmlSerializer xml = new XmlSerializer(typeof(ModSettings));
            TextWriter file = new StreamWriter(path);
            xml.Serialize(file, ModSettings.instance);

            file.Flush();
            file.Close();
            file.Dispose();
            xml = null;
            file = null;
        }

        //[XmlAnyElement("baseInteractionWeightComment", Order =0)]
        public XmlComment baseInteractionWeightComment = new XmlDocument().CreateComment("Controls how often the education interaction activates. Default value is 0.2");        
        public float baseInteractionWeight = 0.2f;

        //[XmlAnyElement("interactionAdjustMultiplierComment")]
        public XmlComment interactionAdjustMultiplierComment = new XmlDocument().CreateComment("An adjustment multiplier to how often the education interaction activates. Default value is 1");
        public byte interactionAdjustMultiplier = 1;

        //[XmlAnyElement("baseInteractionExpComment")]
        public XmlComment baseInteractionExpComment = new XmlDocument().CreateComment("Base exp value gained by initiator/recipient. Default value is 2");
        public byte baseInteractionExp = 2;

       // [XmlAnyElement("baseInteractionIntiatorDividendComment")]
        public XmlComment baseInteractionIntiatorDividendComment = new XmlDocument().CreateComment("Dividend in initiator exp gain function. Increase to increase the amount of exp the initiator gets. Default value is 20");
        public byte baseInteractionIntiatorDividend = 20;

        //[XmlAnyElement("baseInteractionRecipientExpMultiplierComment")]
        public XmlComment baseInteractionRecipientExpMultiplierComment = new XmlDocument().CreateComment("Multiplier in recipient exp gain function. Increase to increase the amount of exp the recipient gets. Default value is 3");
        public byte baseInteractionRecipientExpMultiplier = 3;

       // [XmlAnyElement("interactionInitiatorMajorPassionExpMultiplierComment")]
        public XmlComment interactionInitiatorMajorPassionExpMultiplierComment = new XmlDocument().CreateComment("Multiplier in initiator exp gain function, for major passions. Increase to increase the amount of exp the initiator gets. Default value is 2");
        public byte interactionInitiatorMajorPassionExpMultiplier = 2;

        //[XmlAnyElement("interactionRecipientMajorPassionExpMultiplierComment")]
        public XmlComment interactionRecipientMajorPassionExpMultiplierComment = new XmlDocument().CreateComment("Multiplier in recipient exp gain function, for major passions. Increase to increase the amount of exp the recipient gets. Default value is 4");
        public byte interactionRecipientMajorPassionExpMultiplier = 4;

        //[XmlAnyElement("interactionRecipientMinorPassionExpMultiplierComment")]
        public XmlComment interactionRecipientMinorPassionExpMultiplierComment = new XmlDocument().CreateComment("Multiplier in recipient exp gain function, for minor passions. Increase to increase the amount of exp the recipient gets. Default value is 2");
        public byte interactionRecipientMinorPassionExpMultiplier = 2;

        //[XmlAnyElement("interactionRecipientMasterEducationExpMultiplierComment")]
        public XmlComment interactionRecipientMasterEducationExpMultiplierComment = new XmlDocument().CreateComment("Multiplier in recipient exp gain function, for master education. Increase to increase the amount of exp the recipient gets. Default value is 8");
        public byte interactionRecipientMasterEducationExpMultiplier = 8;

        //[XmlAnyElement("interactionRecipientMasterLessonLevelGainComment")]
        public XmlComment interactionRecipientMasterLessonLevelGainComment = new XmlDocument().CreateComment("Static level increases for recipient during master lessons. Increase to increase the amount of levels the recipient gets. Max value is 20. Default value is 2");
        public byte interactionRecipientMasterLessonLevelGain = 2;

        //[XmlAnyElement("interactionRecipientMasterLessonChanceComment")]
        public XmlComment interactionRecipientMasterLessonChanceComment = new XmlDocument().CreateComment("Chance of master lesson activation. Max value is 1. Default value is 0.05");
        public float interactionRecipientMasterLessonChance = 0.05f;

        //[XmlAnyElement("interactionInitiatorMasterLessionLevelRequirementComment")]
        public XmlComment interactionInitiatorMasterLessionLevelRequirementComment = new XmlDocument().CreateComment("Static level requirement for initiator for master lessons to activate. Max value is 20. Default value is 20");
        public byte interactionInitiatorMasterLessionLevelRequirement = 20;
    }
}

