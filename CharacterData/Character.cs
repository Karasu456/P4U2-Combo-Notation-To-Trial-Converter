namespace P4U2_Combo_Notation_To_Trial_Converter.CharacterData
{
    public interface ICharacter
    {
        Dictionary<string, string> COMMON_ACTIONS { get; set; }
    }
    public class Character : ICharacter
    {
        public Dictionary<string, string> COMMON_ACTIONS { get; set; }

        public Character()
        {
            COMMON_ACTIONS = new Dictionary<string, string>()
            {
                //Base Buttons
                {"5A", "NmlAtk5A\tc"},
                {"5B", "NmlAtk5B\tc"},
                {"5C", "Persona5C\tc"},
                {"5D", "Persona5D\tc"},
                {"5DD", "NmlAtk5D2nd\ti\tc"},
                {"2A", "NmlAtk2A\tc"},
                {"2B", "NmlAtk2B\tc"},
                {"2C", "Persona2C\tc"},
                {"2D", "Persona2D\tc"},
                {"IK", "Ichigeki"},
                {"222CD", "Ichigeki"},

                //Air Buttons
                {"j.A", "NmlAtkAir5A\tc"},
                {"j.2A", "NmlAtkAir2A\tc"},
                {"j.B", "NmlAtkAir5B\tc"},
                {"j.AB", "NmlAtkAirAB\tc"},
                {"j.BB", "NmlAtkAir5B2nd\tc"},
                {"j.2B", "NmlAtkAir2B\tc"},
                {"j.C", "PersonaAir5C\tc"},
                {"j.2C", "PersonaAir2C\tc"},
                {"j.D", "PersonaAir5D\tc"},
                {"j.2D", "PersonaAir2D\tc"},

                //Common Cancels
                {"jc", "CmnActJumpExUpper\ta\tc\tnOnly"},
                {"Jump Cancel", "CmnActJumpExUpper\ta\tc\tnOnly"},
                {"Air Dash", "CmnFAirDash\ti\tc"},
                {"Air Backdash", "CmnBAirDash\ti\tc"},
                {"66","_Dash\t+CmnActFDash\ti\tc"},
                {"Dash Cancel","_Dash\t+CmnActFDash\ti\tc"},
                {"44", "CmnBDash\t+CmnActBDash\ti\tc"},
                {"Backdash", "CmnBDash\t+CmnActBDash\ti\tc"},
                {"IAD", "CmnFAirDash\ti\tc"},
                {"IAD(Back)", "CmnBAirDash\ti\tc"},

                //Common Macros
                {"CD", "NmlAtkThrow\tc"},
                {"Throw", "NmlAtkThrow\tc"},
                {"j.CD", "NmlAtkAirThrow\tc"},
                {"Air Throw", "NmlAtkAirThrow\tc"},
                {"AOA", "Chudan\tc" },
                {"AOA(Launch)", "Chudan\tc\r\nChudanOiuchi\tc\r\nChudanFinish\tc\r\nChudanJump\ta\tc"},
                {"AOA(Blowback)", "Chudan\tc\r\nChudanOiuchi\tc\r\nChudanBlow\tc"},
                {"Guard Cancel", "NmlAtkCounterAssault\tc"},
                {"Guard Cancel Roll", "_GCSurinuke\ta\tc\t+CmnGCSurinuke"},
                {"2AB", "Ashibarai\tc"},
                {"Sweep", "Ashibarai\tc"},
                {"AC", "CmnSurinuke\ti\tc"},
                {"Roll", "CmnSurinuke\ti\tc"},
                {"2AC", "CmnMiniJump\ti\tc"},
                {"Hop", "CmnMiniJump\ti\tc"},
                {"Superjump", "_HighJump\ta\tc\tnOnly"},               
                {"Air Turn", "CmnAirTurn\ti\tc"},
                {"j.AC", "CmnAirTurn\ti\tc"},
                {"BD", "ReversalAction"},
                {"DP", "ReversalAction"},
                {"One More Cancel!", "CmnOneMoreCancel\ti\tc"},
                {"OMC", "CmnOneMoreCancel\ti\tc"},
                {"One More Burst!", "CmnCancelBurst\ti\tc"},
                {"OMB", "CmnCancelBurst\ti\tc"},
                {"Awaken", "_Kakusei\ti\tc"},
                {"Defensive Burst", "CmnDamageBurst\tc\ti" },
            };
        }
    }

    public class PlayableShadow : Character
    {
        public List<string> invalidActions_S = new() { "OMB", "One More Burst!", "IK", "222CD" };
        public Dictionary<string, string> SHADOW_ACTIONS = new()
        {
            {"5AA", "NmlAtk5A2nd\tc"},
            {"5AAA", "NmlAtk5A3rd\tc"},
            {"ACD", "CmnActHeatUp\t+HeatUp\ta\tc"},
            {"Frenzy", "CmnActHeatUp\t+HeatUp\ta\tc"}
        };
    }

    public class YuNarukami : PlayableShadow
    {
        private readonly static Dictionary<string, string> workingDictionary = new()
        {
            //Big Gamble (Air)
            {"j.BD", "ReversalActionAir"},
            {"j.DP", "ReversalActionAir"},

            //Raging Lion
            {"214A", "MidAssaultA"},
            {"214B", "MidAssaultB"},
            {"214AB", "MidAssaultAB"},

            //Raging Lion (Air)
            {"j.214A", "AirMidAssaultA"},
            {"j.214B", "AirMidAssaultB"},

            //Ziocar - Swift Strike
            {"214C", "PersonaLowAssaultC"},
            {"214D", "PersonaLowAssaultD"},
            {"214CD", "PersonaLowAssaultCD"},

            //Ziocar - Swift Strike (CD) ~ Big Gamble
            {"214CD~BD", "PersonaLowAssaultCD\r\nReversalAction\t+ReversalActionAdd"},
            {"214CD~DP", "PersonaLowAssaultCD\r\nReversalAction\t+ReversalActionAdd"},

            //Heroic Bravery
            {"236A", "DashAssaultA"},
            {"236B", "DashAssaultB"},
            {"236AB", "DashAssaultAB"},

            //Zio
            {"236C", "ElectricBall_HontaiC"},
            {"236D", "ElectricBall_HontaiD"},
            {"236CD", "ElectricBall_HontaiCD"},

            //Zio (Air)
            {"j.236C", "ElectricBall_HontaiC"},
            {"j.236D", "ElectricBall_HontaiD"},
            {"j.236CD", "ElectricBall_HontaiCD"},

            //Ziodyne
            {"236236C", "UltimateLaserLandC"},
            {"236236D", "UltimateLaserLandD"},
            {"236236CD", "UltimateLaserLandCD"},

            //Ziodyne (Air)
            {"j.236236C", "UltimateLaserAirC"},
            {"j.236236D", "UltimateLaserAirD"},
            {"j.236236CD", "UltimateLaserAirCD"},

            //Issen - Lightning Flash
            {"236236A", "UltimateAssaultA"},
            {"236236B", "UltimateAssaultB"},
            {"236236AB", "UltimateAssaultAB"},

            //Cross Slash
            {"214214C", "UltimateBladeC"},
            {"214214D", "UltimateBladeD"},
            {"214214CD", "UltimateBladeCD"},

            //Thunder God Dance
            {"Thunder God Dance!", "UltimateWildRush\r\nUltimateWildRush_1st\r\nUltimateWildRush_2nd\r" +
                "\nUltimateWildRush_3rd\r\nUltimateWildRush_4th\r\nUltimateWildRush_5th\r" +
                "\nUltimateWildRush_6th\r\nUltimateWildRush_7th\r\nUltimateWildRush_8th\r" +
                "\nUltimateWildRush_9th\r\nPersonaUltimateWildFinish"},
            {"Thunder God Dance!(nOnly)", "UltimateWildRush\tnOnly\r\nUltimateWildRush_9th\tnOnly\r\nPersonaUltimateWildFinish\tnOnly"}
        };
        private readonly static Dictionary<string, string> workingDictionary_S = new();
        private static bool dictionariesBuilt = false;
        private readonly static List<string> invalidActions = new() { "j.AB", "j.2C", "j.2D" };
        public static Dictionary<string, string> Dictionary
        {
            get { return workingDictionary; }
        }
        public static Dictionary<string, string> Dictionary_S
        {
            get { return workingDictionary_S; }
        }
        public YuNarukami()
        {
            if (!dictionariesBuilt)
            {
                foreach (KeyValuePair<string, string> pair in workingDictionary.ToList())
                {
                    workingDictionary_S.Add(pair.Key, pair.Value);
                }
                //Auto Combo
                workingDictionary.Add("5AA", "NmlAtk5A2nd\tc");
                workingDictionary.Add("5AAA", "NmlAtk5A3rd_P4U2\tc");
                workingDictionary.Add("5AAAA", "AirMidAssaultA\t|MidAssaultA\t+StylishMidAsssault");
                workingDictionary.Add("5AAAAA", "UltimateLaserLandC\t|UltimateLaserAirC\t+StylishLaser");
                //S. dictionary
                workingDictionary_S.Remove("Thunder God Dance!");
                workingDictionary_S.Remove("Thunder God Dance!(nOnly)");
                workingDictionary_S.Add("5AAAA", "PersonaLowAssaultD\t+StylishAsssault");
                workingDictionary_S.Add("5AAAAA", "UltimateLaserLandC\t+StylishLaser");

                foreach (KeyValuePair<string, string> pair in COMMON_ACTIONS.ToList())
                {
                    if (invalidActions.Any(action => pair.Key.Contains(action)))
                    {
                        continue;
                    }

                    if (!workingDictionary.ContainsKey(pair.Key))
                    {
                        workingDictionary.Add(pair.Key, pair.Value);
                    }
                    if (!workingDictionary_S.ContainsKey(pair.Key))
                    {
                        if (invalidActions_S.Any(action => pair.Key.Contains(action)))
                        {
                            continue;
                        }
                        workingDictionary_S.Add(pair.Key, pair.Value);
                    }
                }

                foreach (KeyValuePair<string, string> pair in SHADOW_ACTIONS)
                {
                    workingDictionary_S.Add(pair.Key, pair.Value);
                }

                dictionariesBuilt = true;
            }
        }
    }
    public class YosukeHanamura : PlayableShadow
    {
        private readonly static Dictionary<string, string> workingDictionary = new()
        {
            //j.AA
            {"j.AA", "NmlAtkAir5B\t+NmlAtkAir5A\tc"},

            //Dash Spring
            {"236A", "KakeagariA"},
            {"236B", "KakeagariB"},
            {"236AB", "KakeagariAB"},

            //Moonsault (A)
            {"j.236A", "MoonsaltMoveA"},
            {"j.214A", "MoonsaltMoveA"},
            {"j.6A", "MoonsaltMoveA"},
            {"j.4A", "MoonsaltMoveA"},
            //Moonsault (A) ~ Crescent Slash (A)
            {"j.236A~A", "MoonsaltMoveA\t+MoonsaltMoveHaseiA\ta\tn2miss\r\nMoonsaltSlashA"},
            {"j.214A~A", "MoonsaltMoveA\t+MoonsaltMoveHaseiA\ta\tn2miss\r\nMoonsaltSlashA"},
            {"j.6A~A", "MoonsaltMoveA\t+MoonsaltMoveHaseiA\ta\tn2miss\r\nMoonsaltSlashA"},
            {"j.4A~A", "MoonsaltMoveA\t+MoonsaltMoveHaseiA\ta\tn2miss\r\nMoonsaltSlashA"},
            //Moonsault (A) ~ Crescent Slash (B)
            {"j.236A~B", "MoonsaltMoveA\t+MoonsaltMoveHaseiA\ta\tn2miss\r\nMoonsaltSlashB"},
            {"j.214A~B", "MoonsaltMoveA\t+MoonsaltMoveHaseiA\ta\tn2miss\r\nMoonsaltSlashB"},
            {"j.6A~B", "MoonsaltMoveA\t+MoonsaltMoveHaseiA\ta\tn2miss\r\nMoonsaltSlashB"},
            {"j.4A~B", "MoonsaltMoveA\t+MoonsaltMoveHaseiA\ta\tn2miss\r\nMoonsaltSlashB"},
            //Moonsault (A) ~ Crescent Slash (AB)
            {"j.236A~AB", "MoonsaltMoveA\nMoonsaltMoveAB\t+MoonsaltMoveHaseiAB"},
            {"j.214A~AB", "MoonsaltMoveA\nMoonsaltMoveAB\t+MoonsaltMoveHaseiAB"},
            {"j.6A~AB", "MoonsaltMoveA\nMoonsaltMoveAB\t+MoonsaltMoveHaseiAB"},
            {"j.4A~AB", "MoonsaltMoveA\nMoonsaltMoveAB\t+MoonsaltMoveHaseiAB"},

            //Moonsault (B)
            {"j.236B", "MoonsaltMoveB"},
            {"j.214B", "MoonsaltMoveB"},
            {"j.6B", "MoonsaltMoveB"},
            {"j.4B", "MoonsaltMoveB"},
            //Moonsault (B) ~ Crescent Slash (A)
            {"j.236B~A", "MoonsaltMoveB\t+MoonsaltMoveHaseiB\ta\tn2miss\r\nMoonsaltSlashA"},
            {"j.214B~A", "MoonsaltMoveB\t+MoonsaltMoveHaseiB\ta\tn2miss\r\nMoonsaltSlashA"},
            {"j.6B~A", "MoonsaltMoveB\t+MoonsaltMoveHaseiB\ta\tn2miss\r\nMoonsaltSlashA"},
            {"j.4B~A", "MoonsaltMoveB\t+MoonsaltMoveHaseiB\ta\tn2miss\r\nMoonsaltSlashA"},
            //Moonsault (B) ~ Crescent Slash (B)
            {"j.236B~B", "MoonsaltMoveB\t+MoonsaltMoveHaseiB\ta\tn2miss\r\nMoonsaltSlashB"},
            {"j.214B~B", "MoonsaltMoveB\t+MoonsaltMoveHaseiB\ta\tn2miss\r\nMoonsaltSlashB"},
            {"j.6B~B", "MoonsaltMoveB\t+MoonsaltMoveHaseiB\ta\tn2miss\r\nMoonsaltSlashB"},
            {"j.4B~B", "MoonsaltMoveB\t+MoonsaltMoveHaseiB\ta\tn2miss\r\nMoonsaltSlashB"},
            //Moonsault (B) ~ Crescent Slash (AB)
            {"j.236B~AB", "MoonsaltMoveB\nMoonsaltMoveAB\t+MoonsaltMoveHaseiAB"},
            {"j.214B~AB", "MoonsaltMoveB\nMoonsaltMoveAB\t+MoonsaltMoveHaseiAB"},
            {"j.6B~AB", "MoonsaltMoveB\nMoonsaltMoveAB\t+MoonsaltMoveHaseiAB"},
            {"j.4B~AB", "MoonsaltMoveB\nMoonsaltMoveAB\t+MoonsaltMoveHaseiAB"},

            //Crescent Slash (AB)
            {"j.236AB", "MoonsaltMoveAB"},
            {"j.214AB", "MoonsaltMoveAB"},
            {"j.6AB", "MoonsaltMoveAB"},
            {"j.4AB", "MoonsaltMoveAB"},
            //Moonsault (AB) ~ Crescent Slash (A)
            {"j.236AB~A", "MoonsaltMoveAB\t+MoonsaltMoveHaseiAB\ta\tn2miss\r\nMoonsaltSlashA"},
            {"j.214AB~A", "MoonsaltMoveAB\t+MoonsaltMoveHaseiAB\ta\tn2miss\r\nMoonsaltSlashA"},
            {"j.6AB~A", "MoonsaltMoveAB\t+MoonsaltMoveHaseiAB\ta\tn2miss\r\nMoonsaltSlashA"},
            {"j.4AB~A", "MoonsaltMoveAB\t+MoonsaltMoveHaseiAB\ta\tn2miss\r\nMoonsaltSlashA"},
            //Moonsault (AB) ~ Crescent Slash (B)
            {"j.236AB~B", "MoonsaltMoveAB\t+MoonsaltMoveHaseiAB\ta\tn2miss\r\nMoonsaltSlashB\r\n"},
            {"j.214AB~B", "MoonsaltMoveAB\t+MoonsaltMoveHaseiAB\ta\tn2miss\r\nMoonsaltSlashB\r\n"},
            {"j.6AB~B", "MoonsaltMoveAB\t+MoonsaltMoveHaseiAB\ta\tn2miss\r\nMoonsaltSlashB\r\n"},
            {"j.4AB~B", "MoonsaltMoveAB\t+MoonsaltMoveHaseiAB\ta\tn2miss\r\nMoonsaltSlashB\r\n"},
            //Moonsault (AB) ~ Crescent Slash (AB)
            {"j.236AB~AB", "MoonsaltMoveAB\t+MoonsaltMoveHaseiAB\nMoonsaltMoveAB\t+MoonsaltMoveHaseiAB"},
            {"j.214AB~AB", "MoonsaltMoveAB\t+MoonsaltMoveHaseiAB\nMoonsaltMoveAB\t+MoonsaltMoveHaseiAB"},
            {"j.6AB~AB", "MoonsaltMoveAB\t+MoonsaltMoveHaseiAB\nMoonsaltMoveAB\t+MoonsaltMoveHaseiAB"},
            {"j.4AB~AB", "MoonsaltMoveAB\t+MoonsaltMoveHaseiAB\nMoonsaltMoveAB\t+MoonsaltMoveHaseiAB"},

            //Kunai
            {"j.2A", "KunaiHit_C"},
            {"j.2B", "KunaiHit_D"},
            {"j.2AB", "KunaiHit_CD"},

            //Tentarafoo
            {"236C", "PersonaTentarahuC"},
            {"236D", "PersonaTentarahuD"},
            {"236CD", "PersonaTentarahuCD"},

            //VSlash C
            {"j.236C", "VSlashC\t+VSlashHaseiC"},
            {"j.214C", "VSlashC\t+VSlashHaseiC"},
            {"j.6C", "VSlashC\t+VSlashHaseiC"},
            {"j.4C", "VSlashC\t+VSlashHaseiC"},

            //VSlash D
            {"j.236D", "VSlashD\t+VSlashHaseiD"},
            {"j.214D", "VSlashD\t+VSlashHaseiD"},
            {"j.6D", "VSlashD\t+VSlashHaseiD"},
            {"j.4D", "VSlashD\t+VSlashHaseiD"},

            //VSlash CD
            {"j.236CD", "VSlashCD\t+VSlashHaseiCD"},
            {"j.214CD", "VSlashCD\t+VSlashHaseiCD"},
            {"j.6CD", "VSlashCD\t+VSlashHaseiCD"},
            {"j.4CD", "VSlashCD\t+VSlashHaseiCD"},

            //Mirage Slash
            {"j.2C", "WarpLowSlashC"},
            {"j.2D", "WarpLowSlashD\ta"},
            {"j.2CD", "WarpLowSlashCD\tnOnly"},
            

            //Garudyne
            {"236236C", "Tatsumaki"},
            {"236236D", "TatsumakiD"},
            {"236236CD", "TatsumakiCD"},

            //Garudyne (Air)
            {"j.236236C", "Tatsumaki"},
            {"j.236236D", "TatsumakiD"},
            {"j.236236CD", "TatsumakiCD"},

            //Sukukaja
            {"214214C", "UltimateSukukajaC\ta"},
            {"214214D", "UltimateSukukajaD\ta"},
            {"214214CD", "UltimateSukukajaCD\ta"},

            //Sukukaja Autocombo
            {"5A(Sukukaja)", "Sukukaja5A"},
            {"5AA(Sukukaja)", "Sukukaja5A_2nd"},
            {"5AAA(Sukukaja)", "Sukukaja5A_3rd"},
            {"5AAAA(Sukukaja)", "Sukukaja5A_4th"},
            {"5AAAAA(Sukukaja)", "Sukukaja5A_Finish"},
            {"5AAAAAA(Sukukaja)", "KakeagariA\t+StylishKakeagari"},
            {"5AAAAAAA(Sukukaja)", "UltimateKunaiD\t+StylishUltimateKunai"},
            
            //Shippu - Nagareboshi
            {"214214C(Shippu)", "UltimateKunaiC"},
            {"214214D(Shippu)", "UltimateKunaiD"},
            {"214214CD(Shippu)", "UltimateKunaiCD"},

            //Shippu - Nagareboshi (Air)
            {"j.214214C", "UltimateKunaiC"},
            {"j.214214D", "UltimateKunaiD"},
            {"j.214214CD", "UltimateKunaiCD"},
        };
        private readonly static Dictionary<string, string> workingDictionary_S = new();
        private static bool dictionariesBuilt = false;
        private readonly static List<string> invalidActions = new() { "j.2A", "j.2B", "j.2C", "j.2D" };
        public static Dictionary<string, string> Dictionary
        {
            get { return workingDictionary; }
        }
        public static Dictionary<string, string> Dictionary_S
        {
            get { return workingDictionary_S; }
        }
        public YosukeHanamura()
        {
            if (!dictionariesBuilt)
            {
                foreach (KeyValuePair<string, string> pair in workingDictionary.ToList())
                {
                    workingDictionary_S.Add(pair.Key, pair.Value);
                }

                //Auto Combo
                workingDictionary.Add("5AA", "NmlAtk5A2nd_P4U2\tc");
                workingDictionary.Add("5AAA", "NmlAtk5A3rd_P4U2\tc");
                workingDictionary.Add("5AAAA", "VSlashC\t+StylishVSlash");
                workingDictionary.Add("5AAAAA", "KunaiHit_C\t+StylishKunai");
                workingDictionary.Add("5AAAAAA", "Tatsumaki\t+StylishTatsumaki");
                //S. Auto Combo
                workingDictionary_S.Add("5AAAA", "VSlashC\t+StylishVSlash");
                workingDictionary_S.Add("5AAAAA", "KunaiHit_C\t+StylishKunai");
                workingDictionary_S.Add("5AAAAAA", "Tatsumaki\t+StylishTatsumaki");

                foreach (KeyValuePair<string, string> pair in COMMON_ACTIONS.ToList())
                {
                    if (invalidActions.Any(action => pair.Key.Contains(action)))
                    {
                        continue;
                    }

                    if (!workingDictionary.ContainsKey(pair.Key))
                    {
                        workingDictionary.Add(pair.Key, pair.Value);
                    }
                    if (!workingDictionary_S.ContainsKey(pair.Key))
                    {
                        if (invalidActions_S.Any(action => pair.Key.Contains(action)))
                        {
                            continue;
                        }
                        workingDictionary_S.Add(pair.Key, pair.Value);
                    }
                }

                foreach (KeyValuePair<string, string> pair in SHADOW_ACTIONS)
                {
                    workingDictionary_S.Add(pair.Key, pair.Value);
                }

                dictionariesBuilt = true;
            }
        }
    }
    public class ChieSatonaka : PlayableShadow
    {
        private readonly static Dictionary<string, string> workingDictionary = new()
        {
            //2DD
            {"2DD", "Persona2D2nd\t+NmlAtk5D2nd\tc\tNandodemo"},

            //j.D Variants
            {"j.6D", "PersonaAir5D"},
            {"j.4D", "PersonaAir5D"},
            {"j.2D", "PersonaAir5D"},
            {"j.8D", "PersonaAir8D"},

            //High Counter (Air)
            {"j.BD", "ReversalActionAir"},
            {"j.DP", "ReversalActionAir"},

            //Rampage (A)
            {"236A", "AbaremakuriA"},
            {"j.236A", "AirAbaremakuriA"},
            //Rampage (A) ~ Skull Cracker (A)
            {"236A~236A", "AbaremakuriA\nNoutenotoshiA"},
            {"j.236A~236A", "AirAbaremakuriA\nNoutenotoshiA"},
            //Rampage (A) ~ Skull Cracker (B)
            {"236A~236B", "AbaremakuriA\nNoutenotoshiB"},
            {"j.236A~236B", "AirAbaremakuriA\nNoutenotoshiB"},
            //Rampage (A) ~ Skull Cracker (AB)
            {"236A~236AB", "AbaremakuriA\nNoutenotoshiAB"},
            {"j.236A~236AB", "AirAbaremakuriA\nNoutenotoshiAB"},

            //Rampage (B)
            {"236B", "AbaremakuriB"},
            {"j.236B", "AirAbaremakuriB"},
            //Rampage (B) ~ Skull Cracker (A)
            {"236B~236A", "AbaremakuriB\nNoutenotoshiA"},
            {"j.236B~236A", "AirAbaremakuriB\nNoutenotoshiA"},
            //Rampage (B) ~ Skull Cracker (B)
            {"236B~236B", "AbaremakuriB\nNoutenotoshiB"},
            {"j.236B~236B", "AirAbaremakuriB\nNoutenotoshiB"},
            //Rampage (B) ~ Skull Cracker (AB)
            {"236B~236AB", "AbaremakuriB\nNoutenotoshiAB"},
            {"j.236B~236AB", "AirAbaremakuriB\nNoutenotoshiAB"},

            //Rampage (AB)
            {"236AB", "AbaremakuriAB"},
            {"j.236AB", "AirAbaremakuriAB"},
            //Rampage (AB) ~ Skull Cracker (A)
            {"236AB~236A", "AbaremakuriAB\nNoutenotoshiA"},
            {"j.236AB~236A", "AirAbaremakuriAB\nNoutenotoshiA"},
            //Rampage (AB) ~ Skull Cracker (B)
            {"236AB~236B", "AbaremakuriAB\nNoutenotoshiB"},
            {"j.236AB~236B", "AirAbaremakuriAB\nNoutenotoshiB"},
            //Rampage (AB) ~ Skull Cracker (AB)
            {"236AB~236AB", "AbaremakuriAB\nNoutenotoshiAB"},
            {"j.236AB~236AB", "AirAbaremakuriAB\nNoutenotoshiAB"},

            //Herculean Strike
            {"214A", "100inchPunchA"},
            {"214B", "100inchPunchB"},
            {"214AB", "100inchPunchAB"},

            //Dragon Kick
            {"236C", "DragonKickC"},
            {"236D", "DragonKickD"},
            {"236CD", "DragonKickCD"},

            //Dragon Kick (Air)
            {"j.236C", "AirDragonKickC"},
            {"j.236D", "AirDragonKickD"},
            {"j.236CD", "AirDragonKickCD"},

            //Black Spot
            {"214C", "PersonaKokutengekiC"},
            {"214D", "PersonaKokutengekiD"},
            {"214CD", "PersonaKokutengekiCD"},

            //God's Hand
            {"236236C", "PersonaGodHandC"},
            {"236236D", "PersonaGodHandD"},
            {"236236CD", "PersonaGodHandCD"},

            //Power Charge
            {"236236A", "UltimateChargeA\ta"},
            {"236236B", "UltimateChargeB\ta"},

            //Agneyastra
            {"214214C", "meteoHit_C"},
            {"214214D", "meteoHit_D"},

            //Agneyastra (Air)
            {"j.214214C", "meteoHit_C"},
            {"j.214214D", "meteoHit_D"},
        };
        private readonly static Dictionary<string, string> workingDictionary_S = new();
        private static bool dictionariesBuilt = false;
        private readonly static List<string> invalidActions = new() { "j.2A", "j.2C", "j.2D" };
        public static Dictionary<string, string> Dictionary
        {
            get { return workingDictionary; }
        }
        public static Dictionary<string, string> Dictionary_S
        {
            get { return workingDictionary_S; }
        }
        public ChieSatonaka()
        {
            if (!dictionariesBuilt)
            {
                foreach (KeyValuePair<string, string> pair in workingDictionary.ToList())
                {
                    workingDictionary_S.Add(pair.Key, pair.Value);
                }

                //Auto Combo
                workingDictionary.Add("5AA", "NmlAtk5A2nd_P4U2\tc");
                workingDictionary.Add("5AAA", "NmlAtk5A3rd_P4U2\tc");
                workingDictionary.Add("5AAAA", "100inchPunchA\t+Stylish100inchPunch");
                workingDictionary.Add("5AAAAA", "PersonaGodHandD\t+StylishGodHand");
                //S. Auto Combo
                workingDictionary_S.Add("5AAAA", "AbaremakuriA\t|AirAbaremakuriA\t+StylishAbaremakuri");
                workingDictionary_S.Add("5AAAAA", "NoutenotoshiA\t+StylishNoutenotoshi");
                workingDictionary_S.Add("5AAAAAA", "PersonaGodHandC\t+StylishGodHandC");

                foreach (KeyValuePair<string, string> pair in COMMON_ACTIONS.ToList())
                {
                    if (invalidActions.Any(action => pair.Key.Contains(action)))
                    {
                        continue;
                    }

                    if (!workingDictionary.ContainsKey(pair.Key))
                    {
                        workingDictionary.Add(pair.Key, pair.Value);
                    }
                    if (!workingDictionary_S.ContainsKey(pair.Key))
                    {
                        if (invalidActions_S.Any(action => pair.Key.Contains(action)))
                        {
                            continue;
                        }
                        workingDictionary_S.Add(pair.Key, pair.Value);
                    }
                }

                foreach (KeyValuePair<string, string> pair in SHADOW_ACTIONS)
                {
                    workingDictionary_S.Add(pair.Key, pair.Value);
                }

                dictionariesBuilt = true;
            }
        }
    }
    public class YukikoAmagi : PlayableShadow
    {
        private readonly static Dictionary<string, string> workingDictionary = new()
        {
            //Sensu aka B Normals
            {"5B", "Sensu_5B"},
            {"5BB", "Sensu_5B\nSensu_5B2nd"},
            {"6B", "Sensu_5B"},
            {"6BB", "Sensu_5B\nSensu_5B2nd"},
            {"4B", "Sensu_5B"},
            {"4BB", "Sensu_5B\nSensu_5B2nd"},
            {"2B", "Sensu_2B"},
            {"3B", "Sensu_2B"},
            {"1B", "Sensu_2B"},

            //Sensu (Air)
            {"j.6B", "Sensu_Air5B"},
            {"j.4B", "Sensu_Air5B"},

            //2D Variants
            {"3D", "Persona2D\tc"},
            {"1D", "Persona2D\tc"},

            //j.D Variants
            {"j.6D", "PersonaAir5D\tc"},
            {"j.4D", "PersonaAir5D\tc"},

            //Agi
            {"236A", "LandAgiA"},
            {"236B", "LandAgiB"},
            {"236AB", "LandAgirao"},

            //Agi (Air)
            {"j.236A", "AirAgiA"},
            {"j.236B", "AirAgiB"},
            {"j.236AB", "AirAgirao"},

            //Agi Release
            {"A(Explosion)", "AgishotA"},
            {"B(Explosion)", "AgishotB"},
            {"A(SB - Explosion)", "AgishotAB"},
            {"B(SB - Explosion)", "AgishotAB2nd"},

            //Maragi
            {"236C", "MaharagiC"},
            {"236D", "MaharagiD"},
            {"236CD", "Maharagion"},

            //Fire Boost/Break/Amp
            {"214C", "FireBoosterC\ta"},
            {"214D", "FireBoosterD\ta"},
            {"214CD", "FireBoosterCD\ta"},

            //Flame Dance
            {"214A", "PersonaFireAttackA"},
            {"214B", "PersonaFireAttackB"},
            {"214AB", "PersonaFireAttackAB"},

            //Phoenix Flame Swirl
            {"214214A", "PersonaFireBirdA"},
            {"214214B", "PersonaFireBirdB"},
            {"214214AB", "PersonaFireBirdAB"},

            //Phoenix Flame Swirl (Air)
            {"j.214214A", "PersonaFireBirdA"},
            {"j.214214B", "PersonaFireBirdB"},
            {"j.214214AB", "PersonaFireBirdAB"},

            //Agidyne
            {"236236C", "AgidineC"},
            {"236236D", "AgidineD"},
            {"236236CD", "AgidineCD"},

            //Maragidyne
            {"214214C", "MaharagidineC_Frontfire_col\t|MaharagidineC_Backfire_col"},
            {"214214D", "MaharagidineD_Frontfire_col\t|MaharagidineD_Backfire_col"},
            {"214214CD", "MaharagidineCD_col\t+MaharagidineCD_Frontfire_col"},

            //IK
            {"IK", "PersonaIchigeki"},
        };
        private readonly static Dictionary<string, string> workingDictionary_S = new();
        private static bool dictionariesBuilt = false;
        private readonly static List<string> invalidActions = new() { "j.BB", "j.AB", "j.2A", "j.2B", "j.2C", "j.2D" };
        public static Dictionary<string, string> Dictionary
        {
            get { return workingDictionary; }
        }
        public static Dictionary<string, string> Dictionary_S
        {
            get { return workingDictionary_S; }
        }

        public YukikoAmagi()
        {
            if (!dictionariesBuilt)
            {
                foreach (KeyValuePair<string, string> pair in workingDictionary.ToList())
                {
                    workingDictionary_S.Add(pair.Key, pair.Value);
                }
                
                //Auto Combo
                workingDictionary.Add("5AA", "NmlAtk5A2nd_P4U2\tc");
                workingDictionary.Add("5AAA", "NmlAtk5A3rd_P4U2\tc");
                workingDictionary.Add("5AAAA", "PersonaFireAttackB\t+StylishFire");
                workingDictionary.Add("5AAAAA", "AgidineC\t+StylishAgidine");
                //S. Auto Combo
                workingDictionary_S.Add("5AAAA", "LandAgiA\t+StylishAgi");
                workingDictionary_S.Add("5AAAAA", "AgidineC\t+StylishAgidine");

                foreach (KeyValuePair<string, string> pair in COMMON_ACTIONS.ToList())
                {
                    if (invalidActions.Any(action => pair.Key.Contains(action)))
                    {
                        continue;
                    }

                    if (!workingDictionary.ContainsKey(pair.Key))
                    {
                        workingDictionary.Add(pair.Key, pair.Value);
                    }
                    if (!workingDictionary_S.ContainsKey(pair.Key))
                    {
                        if (invalidActions_S.Any(action => pair.Key.Contains(action)))
                        {
                            continue;
                        }
                        workingDictionary_S.Add(pair.Key, pair.Value);
                    }
                }

                foreach (KeyValuePair<string, string> pair in SHADOW_ACTIONS)
                {
                    workingDictionary_S.Add(pair.Key, pair.Value);
                }

                dictionariesBuilt = true;
            }
        }
    }
    public class KanjiTatsumi : PlayableShadow
    {
        private readonly static Dictionary<string, string> workingDictionary = new()
        {
            //5B
            {"5B", "fukidashi"},

            //5B (Charged)
            {"5[B]", "fukidashi_Tame"},

            //5D Additional
            {"5DD", "Persona5D\tc" },
            {"5DDD", "Persona5D\tc" },
            {"5DDDD", "Persona5D\tc" },

            //j.D Additional
            {"j.DD", "PersonaAir5D\tc" },
            {"j.DDD", "PersonaAir5D\tc" },
            {"j.DDDD", "PersonaAir5D\tc" },

            //Cruel Attack
            {"236A", "BusterAttackA"},
            {"236B", "BusterAttackB"},
            {"236AB", "BusterAttackAB\t|AirBusterAttackAB"},

            //Cruel Attack (Air)
            {"j.236A", "AirBusterAttackA"},
            {"j.236B", "AirBusterAttackB"},
            {"j.236AB", "AirBusterAttackAB\t|BusterAttackAB"},

            //Cruel Attack B ~ Bet Ya Can't Take This!
            {"236B~j.214A", "BusterAttackB\ta\nAirMountA"},
            {"236B~j.214B", "BusterAttackB\ta\nAirMountB"},
            {"236B~j.214AB", "BusterAttackB\ta\nAirMountAB"},

            //Cruel Attack B ~ Bet Ya Can't Take This! ~ Added Cruel Attack (A)
            {"236B~(j.214A)~236A", "BusterAttackB\ta\nAirMountA\nOiuchi\t+OiuchiA"},
            {"236B~(j.214B)~236A", "BusterAttackB\ta\nAirMountB\nOiuchi\t+OiuchiA"},
            {"236B~(j.214AB)~236A", "BusterAttackB\ta\nAirMountAB\nOiuchi\t+OiuchiA"},

            //Cruel Attack B ~ Bet Ya Can't Take This! ~ Added Cruel Attack (B)
            {"236B~(j.214A)~236B", "BusterAttackB\ta\nAirMountA\nOiuchi\t+OiuchiB"},
            {"236B~(j.214B)~236B", "BusterAttackB\ta\nAirMountB\nOiuchi\t+OiuchiB"},
            {"236B~(j.214AB)~236B", "BusterAttackB\ta\nAirMountAB\nOiuchi\t+OiuchiB"},

            //Cruel Attack B ~ Bet Ya Can't Take This! ~ Added Cruel Attack (AB)
            {"236B~(j.214A)~236AB", "BusterAttackB\ta\nAirMountA\nOiuchi\t+OiuchiAB"},
            {"236B~(j.214B)~236AB", "BusterAttackB\ta\nAirMountB\nOiuchi\t+OiuchiAB"},
            {"236B~(j.214AB)~236AB", "BusterAttackB\ta\nAirMountAB\nOiuchi\t+OiuchiAB"},

            //Cruel Attack AB ~ Bet Ya Can't Take This!
            {"236AB~j.214A", "BusterAttackAB\ta\nAirMountA"},
            {"236AB~j.214B", "BusterAttackAB\ta\nAirMountB"},
            {"236AB~j.214AB", "BusterAttackAB\ta\nAirMountAB"},

            //Cruel Attack B ~ Bet Ya Can't Take This! ~ Added Cruel Attack (A)
            {"236AB~(j.214A)~236A", "BusterAttackAB\ta\nAirMountA\nOiuchi\t+OiuchiA"},
            {"236AB~(j.214B)~236A", "BusterAttackAB\ta\nAirMountB\nOiuchi\t+OiuchiA"},
            {"236AB~(j.214AB)~236A", "BusterAttackAB\ta\nAirMountAB\nOiuchi\t+OiuchiA"},

            //Cruel Attack B ~ Bet Ya Can't Take This! ~ Added Cruel Attack (B)
            {"236AB~(j.214A)~236B", "BusterAttackAB\ta\nAirMountA\nOiuchi\t+OiuchiB"},
            {"236AB~(j.214B)~236B", "BusterAttackAB\ta\nAirMountB\nOiuchi\t+OiuchiB"},
            {"236AB~(j.214AB)~236B", "BusterAttackAB\ta\nAirMountAB\nOiuchi\t+OiuchiB"},

            //Cruel Attack B ~ Bet Ya Can't Take This! ~ Added Cruel Attack (AB)
            {"236AB~(j.214A)~236AB", "BusterAttackAB\ta\nAirMountA\nOiuchi\t+OiuchiAB"},
            {"236AB~(j.214B)~236AB", "BusterAttackAB\ta\nAirMountB\nOiuchi\t+OiuchiAB"},
            {"236AB~(j.214AB)~236AB", "BusterAttackAB\ta\nAirMountAB\nOiuchi\t+OiuchiAB"},

            //Throw ~ Added Cruel Attack
            {"CD~236A", "NmlAtkThrow\tc\nOiuchi\t+OiuchiA"},
            {"CD~236B", "NmlAtkThrow\tc\nOiuchi\t+OiuchiB"},
            {"CD~236AB", "NmlAtkThrow\tc\nOiuchi\t+OiuchiAB"},

            {"Throw~236A", "NmlAtkThrow\tc\nOiuchi\t+OiuchiA"},
            {"Throw~236B", "NmlAtkThrow\tc\nOiuchi\t+OiuchiB"},
            {"Throw~236AB", "NmlAtkThrow\tc\nOiuchi\t+OiuchiAB"},

            //Sweep ~ Added Cruel Attack
            {"2AB~236A", "Ashibarai\tc\nOiuchi\t+OiuchiA"},
            {"2AB~236B", "Ashibarai\tc\nOiuchi\t+OiuchiB"},
            {"2AB~236AB", "Ashibarai\tc\nOiuchi\t+OiuchiAB"},

            {"Sweep~236A", "Ashibarai\tc\nOiuchi\t+OiuchiA"},
            {"Sweep~236B", "Ashibarai\tc\nOiuchi\t+OiuchiB"},
            {"Sweep~236AB", "Ashibarai\tc\nOiuchi\t+OiuchiAB"},

            //This'll Hurt!
            {"214C", "PCommandNageC"},
            //{"214D", "PCommandNageD"},
            //{"214CD", "PAntiAirNageCD"},

            //This'll Hurt! ~ Added Cruel Attack
            {"214C~236A", "PCommandNageC\nOiuchi\t+OiuchiA"},
            {"214C~236B", "PCommandNageC\nOiuchi\t+OiuchiB"},
            {"214C~236AB", "PCommandNageC\nOiuchi\t+OiuchiAB"},

            {"214D~236A", "PCommandNageD\nOiuchi\t+OiuchiA"},
            {"214D~236B", "PCommandNageD\nOiuchi\t+OiuchiB"},
            {"214D~236AB", "PCommandNageD\nOiuchi\t+OiuchiAB"},

            {"214CD~236A", "PCommandNageCD\nOiuchi\t+OiuchiA"},
            {"214CD~236B", "PCommandNageCD\nOiuchi\t+OiuchiB"},
            {"214CD~236AB", "PCommandNageCD\nOiuchi\t+OiuchiAB"},

            //Gotcha!
            {"236C", "PersonaAntiAirC"},
            {"236D", "PersonaAntiAirD"},
            {"236CD", "PAntiAirNageCD"},

            //Gotcha! (C) ~ Added Cruel Attack
            {"236C~236A", "PersonaAntiAirC\nOiuchi\t+OiuchiA"},
            {"236C~236B", "PersonaAntiAirC\nOiuchi\t+OiuchiB"},
            {"236C~236AB", "PersonaAntiAirC\nOiuchi\t+OiuchiAB"},

            //Primal Force
            {"[4]6C", "PersonaAssaultC"},
            {"[4]6D", "PersonaAssaultD"},
            {"[4]6CD", "PersonaAssaultCD"},

            //Bet Ya Can't Take This!
            {"j.214A", "AirMountA"},
            {"j.214B", "AirMountB"},
            {"j.214AB", "AirMountAB"},

            //Bet Ya Can't Take This! ~ Added Cruel Attack (A)
            {"j.214A~236A", "AirMountA\nOiuchi\t+OiuchiA"},
            {"j.214B~236A", "AirMountB\nOiuchi\t+OiuchiA"},
            {"j.214AB~236A", "AirMountAB\nOiuchi\t+OiuchiA"},

            //Bet Ya Can't Take This! ~ Added Cruel Attack (B)
            {"j.214A~236B", "AirMountA\nOiuchi\t+OiuchiB"},
            {"j.214B~236B", "AirMountB\nOiuchi\t+OiuchiB"},
            {"j.214AB~236B", "AirMountAB\nOiuchi\t+OiuchiB"},

            //Bet Ya Can't Take This! ~ Added Cruel Attack (AB)
            {"j.214A~236AB", "AirMountA\nOiuchi\t+OiuchiAB"},
            {"j.214B~236AB", "AirMountB\nOiuchi\t+OiuchiAB"},
            {"j.214AB~236AB", "AirMountAB\nOiuchi\t+OiuchiAB"},

            //Ass Whoopin', Tatsumi-Style
            {"236236A", "UltimateCriticalComboA"},
            {"236236B", "UltimateCriticalComboB"},
            {"236236AB", "UltimateCriticalComboAB"},

            //Burn To A Crisp!!
            {"214214C", "UltimateThrow"},
            {"214214D", "UltimateThrowD"},
            {"214214CD", "UltimateThrowCD"},
        };
        private readonly static Dictionary<string, string> workingDictionary_S = new();
        private static bool dictionariesBuilt = false;
        private readonly static List<string> invalidActions = new() { "5DD", "j.BB", "j.AB", "j.2A", "j.2B", "j.2C", "j.2D" };
        public static Dictionary<string, string> Dictionary
        {
            get { return workingDictionary; }
        }
        public static Dictionary<string, string> Dictionary_S
        {
            get { return workingDictionary_S; }
        }

        public KanjiTatsumi()
        {
            if (!dictionariesBuilt)
            {
                foreach (KeyValuePair<string, string> pair in workingDictionary.ToList())
                {
                    workingDictionary_S.Add(pair.Key, pair.Value);
                }

                //Auto Combo
                workingDictionary.Add("5AA", "NmlAtk5A2nd_P4U2\tc");
                workingDictionary.Add("5AAA", "NmlAtk5A3rd_P4U2\tc");
                workingDictionary.Add("5AAAA", "PAirBusterAttackA\t|BusterAttackA\t+StylishAirBusterAttack");
                workingDictionary.Add("5AAAAA", "UltimateCriticalCombo\t+StylishCriticalCombo");
                //S. Auto Combo
                workingDictionary_S.Add("5AAAA", "BusterAttackA\t+StylishBusterAttack");
                workingDictionary_S.Add("5AAAAA", "UltimateCriticalCombo\t+StylishCriticalCombo");

                foreach (KeyValuePair<string, string> pair in COMMON_ACTIONS.ToList())
                {
                    if (invalidActions.Any(action => pair.Key.Contains(action)))
                    {
                        continue;
                    }

                    if (!workingDictionary.ContainsKey(pair.Key))
                    {
                        workingDictionary.Add(pair.Key, pair.Value);
                    }
                    if (!workingDictionary_S.ContainsKey(pair.Key))
                    {
                        if (invalidActions_S.Any(action => pair.Key.Contains(action)))
                        {
                            continue;
                        }
                        workingDictionary_S.Add(pair.Key, pair.Value);
                    }
                }

                foreach (KeyValuePair<string, string> pair in SHADOW_ACTIONS)
                {
                    workingDictionary_S.Add(pair.Key, pair.Value);
                }

                dictionariesBuilt = true;
            }
        }
    }
    public class Teddie : PlayableShadow
    {
        private readonly static Dictionary<string, string> workingDictionary = new()
        {
            //Teddie Decoy
            {"DP", "AtemiSmoke"},
            {"BD", "AtemiSmoke"},

            //AOA (Air)
            {"j.AB", "AirChudan"},

            //Bearscrew
            {"236A", "ScrewDriverA"},
            {"236B", "ScrewDriverB"},
            {"236AB", "ScrewDriverAB"},

            //Bearscrew (Air)
            {"j.236A", "AirScrewDriverA"},
            {"j.236B", "AirScrewDriverB"},
            {"j.236AB", "AirScrewDriverAB"},

            //Puppeteddie
            {"214A", "MoudokuTsumeA"},
            {"214B", "MoudokuTsumeB"},
            {"214AB", "MoudokuTsumeAB"},

            //Puppeteddie (Air)
            {"j.214A", "MoudokuTsumeA"},
            {"j.214B", "MoudokuTsumeB"},
            {"j.214AB", "MoudokuTsumeAB"},
            
            //Teddivision
            {"236C", "TvHit_C"},
            {"236D", "TvHit_D"},
            {"236CD", "Tvwarp\t+TvHit_CD"},

            //Teddivision ~ Teddie Warp
            {"236C~236C", "TvHit_C\nTVWarpC\ta"},
            {"236C~236D", "TvHit_C\nTVWarpD\ta"},
            {"236C~236CD", "TvHit_C\nTVWarpCD\ta"},

            {"236D~236C", "TvHit_D\nTVWarpC\ta"},
            {"236D~236D", "TvHit_D\nTVWarpD\ta"},
            {"236D~236CD", "TvHit_D\nTVWarpCD\ta"},

            {"236CD~236C", "Tvwarp\t+TvHit_CD\nTVWarpC\ta"},
            {"236CD~236D", "Tvwarp\t+TvHit_CD\nTVWarpD\ta"},
            {"236CD~236CD", "Tvwarp\t+TvHit_CD\nTVWarpCD\ta"},

            //Teddivision Held
            {"236[D]", "HoldTv_D"},

            //Teddie Warp Delayed Teleport
            {"236C(Warp)", "TVWarpC\ta"},
            {"236D(Warp)", "TVWarpD\ta"},
            {"236CD(Warp)", "TVWarpCD\ta"},

            //2D Teddie
            {"22A", "TsubureruKumaA\ta"},

            //Tomahawk
            {"236236C", "MissileC"},
            {"236236D", "MissileD"},
            {"236236CD", "MissileCD"},

            //Tomahawk (Held)
            {"236236C(Hold)", "MissileC\nMissileBomb"},
            {"236236D(Hold)", "MissileD\nMissileBomb"},
            {"236236CD(Hold)", "MissileCD\nMissileBomb"},

            //Tomahawk (Air)
            {"j.236236C", "AirMissileC\t|MissileC\t|MissileBomb"},
            {"j.236236D", "AirMissileD\t|MissileD\t|MissileBomb"},
            {"j.236236CD", "AirMissileCD\t|MissileCD\t|MissileBomb"},

            //Tomahawk (Air/Held)
            {"j.236236C(Hold)", "AirMissileC\nMissileBomb"},
            {"j.236236D(Hold)", "AirMissileD\nMissileBomb"},
            {"j.236236CD(Hold)", "AirMissileCD\nMissileBomb"},

            //Tomahawk Explosion
            {"Tomahawk C(Explosion)", "MissileBomb"},
            {"Tomahawk D(Explosion)", "MissileBomb"},

            //Mystery Teddie SP
            {"236236A", "UltimateItemA\t|UltimateItemB\t|AirUltimateItemA\t|AirUltimateItemB\t+UltimateItem\ta"},
            {"236236B", "UltimateItemA\t|UltimateItemB\t|AirUltimateItemA\t|AirUltimateItemB\t+UltimateItem\ta"},
            {"236236AB", "UltimateItemAB\ta"},

            //Mystery Teddie SP (Air)
            {"j.236236A", "UltimateItemA\t|UltimateItemB\t|AirUltimateItemA\t|AirUltimateItemB\t+UltimateItem\ta"},
            {"j.236236B", "UltimateItemA\t|UltimateItemB\t|AirUltimateItemA\t|AirUltimateItemB\t+UltimateItem\ta"},
            {"j.236236AB", "AirUltimateItemABset\ta"},

            //Circus Bear
            {"214214C", "UltimateGorogoroTamaC"},
            {"214214D", "UltimateGorogoroTamaD"},
            {"214214CD", "UltimateGorogoroTamaC\t+UltimateGorogoroTamaCD"},

            //Nihil Hand
            {"214214A", "UltimateNihilA"},
            {"214214B", "UltimateNihilB"},
            {"214214AB", "UltimateNihilAB"},

            {"214214A~A", "UltimateNihilA\nShadowKuma"},
            {"214214B~A", "UltimateNihilB\nShadowKuma"},
            {"214214AB~A", "UltimateNihilAB\nShadowKuma"},

            {"214214A~B", "UltimateNihilA\nShadowKuma"},
            {"214214B~B", "UltimateNihilB\nShadowKuma"},
            {"214214AB~B", "UltimateNihilAB\nShadowKuma"},

            {"214214A~C", "UltimateNihilA\nShadowKuma"},
            {"214214B~C", "UltimateNihilB\nShadowKuma"},
            {"214214AB~C", "UltimateNihilAB\nShadowKuma"},

            {"214214A~D", "UltimateNihilA\nShadowKuma"},
            {"214214B~D", "UltimateNihilB\nShadowKuma"},
            {"214214AB~D", "UltimateNihilAB\nShadowKuma"},

            //Items Lol
            {"5D(Pinwheel)", "Item_kazaguruma"},
            {"5D(Heavy-Armor Agni)", "Item_agni"},
            {"5D(Oil Drum)", "Item_drumkan"},
            {"5D(Dry Ice)", "Item_dryice"},
            {"5D(Mobile Model Varna)", "Item_varunana" },
        };
        private readonly static Dictionary<string, string> workingDictionary_S = new();
        private static bool dictionariesBuilt = false;
        private readonly static List<string> invalidActions = new() { "DP", "BD", "5DD", "j.BB", "j.AB", "j.2A", "j.2B" };
        public static Dictionary<string, string> Dictionary
        {
            get { return workingDictionary; }
        }
        public static Dictionary<string, string> Dictionary_S
        {
            get { return workingDictionary_S; }
        }

        public Teddie()
        {
            if (!dictionariesBuilt)
            {
                foreach (KeyValuePair<string, string> pair in workingDictionary.ToList())
                {
                    workingDictionary_S.Add(pair.Key, pair.Value);
                }

                //Auto Combo
                workingDictionary.Add("5AA", "NmlAtk5A2nd_P4U2\tc");
                workingDictionary.Add("5AAA", "NmlAtk5A3rd_P4U2\tc");
                workingDictionary.Add("5AAAA", "ScrewDriverA\t|AirScrewDriverA\t+StylishDriver");
                workingDictionary.Add("5AAAAA", "MissileC\t|AirMissileC\t|MissileBomb\t+StylishMissile");
                //S. Auto Combo
                workingDictionary_S.Add("5AAAA", "ScrewDriverB\t|AirScrewDriverB\t+StylishDriver");
                workingDictionary_S.Add("5AAAAA", "MissileC\t|AirMissileC\t|MissileBomb\t+StylishMissile");

                foreach (KeyValuePair<string, string> pair in COMMON_ACTIONS.ToList())
                {
                    if (invalidActions.Any(action => pair.Key.Contains(action)))
                    {
                        continue;
                    }

                    if (!workingDictionary.ContainsKey(pair.Key))
                    {
                        workingDictionary.Add(pair.Key, pair.Value);
                    }
                    if (!workingDictionary_S.ContainsKey(pair.Key))
                    {
                        if (invalidActions_S.Any(action => pair.Key.Contains(action)))
                        {
                            continue;
                        }
                        workingDictionary_S.Add(pair.Key, pair.Value);
                    }
                }

                foreach (KeyValuePair<string, string> pair in SHADOW_ACTIONS)
                {
                    workingDictionary_S.Add(pair.Key, pair.Value);
                }

                dictionariesBuilt = true;
            }
        }
    }

    public class NaotoShirogane : PlayableShadow
    {
        private readonly static Dictionary<string, string> workingDictionary = new()
        {
            //2C Hold
            {"2[C]", "Persona2CHold"},

            //Reversal ~ Countershot
            {"BD~A", "ReversalAction\ta\r\nImpactReversal"},
            {"BD~B", "ReversalAction\ta\r\nImpactReversal"},
            {"BD~C", "ReversalAction\ta\r\nImpactReversal"},
            {"BD~D", "ReversalAction\ta\r\nImpactReversal"},

            {"DP~A", "ReversalAction\ta\r\nImpactReversal"},
            {"DP~B", "ReversalAction\ta\r\nImpactReversal"},
            {"DP~C", "ReversalAction\ta\r\nImpactReversal"},
            {"DP~D", "ReversalAction\ta\r\nImpactReversal"},

            //Reversal ~ Safety
            {"BD~4A", "ReversalAction\ta\r\nReversalActionBDash\ta"},
            {"BD~4B", "ReversalAction\ta\r\nReversalActionBDash\ta"},
            {"BD~4C", "ReversalAction\ta\r\nReversalActionBDash\ta"},
            {"BD~4D", "ReversalAction\ta\r\nReversalActionBDash\ta"},

            {"DP~4A", "ReversalAction\ta\r\nReversalActionBDash\ta"},
            {"DP~4B", "ReversalAction\ta\r\nReversalActionBDash\ta"},
            {"DP~4C", "ReversalAction\ta\r\nReversalActionBDash\ta"},
            {"DP~4D", "ReversalAction\ta\r\nReversalActionBDash\ta"},

            //Throw Follow-Up
            {"CD~C", "NmlAtkThrow\tc\nPersonaThrowC"},
            {"CD~D", "NmlAtkThrow\tc\nPersonaThrowC"},

            {"Throw~C", "NmlAtkThrow\tc\nPersonaThrowC"},
            {"Throw~D", "NmlAtkThrow\tc\nPersonaThrowC"},

            //Double Fangs
            {"236A", "BanditRevolverA"},
            {"236B", "BanditRevolverB"},
            {"236AB", "BanditRevolverAB"},

            //Double Fangs (Air)
            {"j.236A", "AirBanditRevolverA"},
            {"j.236B", "AirBanditRevolverB"},
            {"j.236AB", "AirBanditRevolverAB"},

            //Double Fangs ~ Cancel Aim
            {"236A~D", "BanditRevolverA\r\nKamaeCancelD\ta\t|KamaeCancelA\ta\t+ShagekiD"},
            {"236B~D", "BanditRevolverB\r\nKamaeCancelD\ta\t|KamaeCancelA\ta\t+ShagekiD"},
            {"236AB~D", "BanditRevolverAB\r\nKamaeCancelD\ta\t|KamaeCancelA\ta\t+ShagekiD"},

            {"236A~214A", "BanditRevolverA\r\nKamaeCancelD\ta\t|KamaeCancelA\ta\t+ShagekiD"},
            {"236B~214A", "BanditRevolverB\r\nKamaeCancelD\ta\t|KamaeCancelA\ta\t+ShagekiD"},
            {"236AB~214A", "BanditRevolverAB\r\nKamaeCancelD\ta\t|KamaeCancelA\ta\t+ShagekiD"},

            //Double Fangs ~ Snipe (D)
            {"236A~6D", "BanditRevolverA\r\nDanganD"},
            {"236B~6D", "BanditRevolverB\r\nDanganD"},
            {"236AB~6D", "BanditRevolverAB\r\nDanganD"},

            //Double Fangs ~ Snipe (A)
            {"236A~(Ax5)", "BanditRevolverA\r\nDanganLastA"},
            {"236B~(Ax5)", "BanditRevolverB\r\nDanganLastA"},
            {"236AB~(Ax5)", "BanditRevolverAB\r\nDanganLastA"},

            //Double Fangs ~ Snipe (A) ~ Snipe (D)
            {"236A~(Ax5)~6D", "BanditRevolverA\r\nDanganLastA\r\nDanganD"},
            {"236B~(Ax5)~6D", "BanditRevolverB\r\nDanganLastA\r\nDanganD"},
            {"236AB~(Ax5)~6D", "BanditRevolverAB\r\nDanganLastA\r\nDanganD"},

            //Double Fangs ~ Snipe (B)
            {"236A~(Bx5)", "BanditRevolverA\r\nDanganHit_Shita"},
            {"236B~(Bx5)", "BanditRevolverB\r\nDanganHit_Shita"},
            {"236AB~(Bx5)", "BanditRevolverAB\r\nDanganHit_Shita"},

            //Double Fangs ~ Snipe (B) ~ Snipe (D)
            {"236A~(Bx5)~6D", "BanditRevolverA\r\nDanganHit_Shita\r\nDanganD"},
            {"236B~(Bx5)~6D", "BanditRevolverB\r\nDanganHit_Shita\r\nDanganD"},
            {"236AB~(Bx5)~6D", "BanditRevolverAB\r\nDanganHit_Shita\r\nDanganD"},
            
            //Double Fangs ~ Snipe (C)
            {"236A~(Cx5)", "BanditRevolverA\r\nDanganLastB"},
            {"236B~(Cx5)", "BanditRevolverB\r\nDanganLastB"},
            {"236AB~(Cx5)", "BanditRevolverAB\r\nDanganLastB"},

            //Double Fangs ~ Snipe (C) ~ Snipe (D)
            {"236A~(Cx5)~6D", "BanditRevolverA\r\nDanganLastB\r\nDanganD"},
            {"236B~(Cx5)~6D", "BanditRevolverB\r\nDanganLastB\r\nDanganD"},
            {"236AB~(Cx5)~6D", "BanditRevolverAB\r\nDanganLastB\r\nDanganD"},

            //Double Fangs ~ Snipe (AB) ~ Snipe (A)
            {"236A~(AB)~(Ax4)", "BanditRevolverA\r\nDanganLastAB\th#\r\nDanganLastA"},
            {"236B~(AB)~(Ax4)", "BanditRevolverB\r\nDanganLastAB\th#\r\nDanganLastA"},
            {"236AB~(AB)~(Ax4)", "BanditRevolverAB\r\nDanganLastAB\th#\r\nDanganLastA"},

            //Double Fangs ~ Snipe (AB) ~ Snipe (A) ~ Snipe (D)
            {"236A~(AB)~(Ax4)~6D", "BanditRevolverA\r\nDanganLastAB\th#\r\nDanganLastA\r\nDanganD"},
            {"236B~(AB)~(Ax4)~6D", "BanditRevolverB\r\nDanganLastAB\th#\r\nDanganLastA\r\nDanganD"},
            {"236AB~(AB)~(Ax4)~6D", "BanditRevolverAB\r\nDanganLastAB\th#\r\nDanganLastA\r\nDanganD"},

            //Double Fangs ~ Snipe (AB) ~ Snipe (B)
            {"236A~(AB)~(Bx4)", "BanditRevolverA\r\nDanganLastAB\th#\r\nDanganHit_Shita"},
            {"236B~(AB)~(Bx4)", "BanditRevolverB\r\nDanganLastAB\th#\r\nDanganHit_Shita"},
            {"236AB~(AB)~(Bx4)", "BanditRevolverAB\r\nDanganLastAB\th#\r\nDanganHit_Shita"},

            //Double Fangs ~ Snipe (AB) ~ Snipe (B) ~ Snipe (D)
            {"236A~(AB)~(Bx4)~6D", "BanditRevolverA\r\nDanganLastAB\th#\r\nDanganHit_Shita\r\nDanganD"},
            {"236B~(AB)~(Bx4)~6D", "BanditRevolverB\r\nDanganLastAB\th#\r\nDanganHit_Shita\r\nDanganD"},
            {"236AB~(AB)~(Bx4)~6D", "BanditRevolverAB\r\nDanganLastAB\th#\r\nDanganHit_Shita\r\nDanganD"},

            //Double Fangs ~ Snipe (AB) ~ Snipe (C)
            {"236A~(AB)~(Cx4)", "BanditRevolverA\r\nDanganLastAB\th#\r\nDanganLastB"},
            {"236B~(AB)~(Cx4)", "BanditRevolverB\r\nDanganLastAB\th#\r\nDanganLastB"},
            {"236AB~(AB)~(Cx4)", "BanditRevolverAB\r\nDanganLastAB\th#\r\nDanganLastB"},

            //Double Fangs ~ Snipe (AB) ~ Snipe (C) ~ Snipe (D)
            {"236A~(AB)~(Cx4)~6D", "BanditRevolverA\r\nDanganLastAB\th#\r\nDanganLastB\r\nDanganD"},
            {"236B~(AB)~(Cx4)~6D", "BanditRevolverB\r\nDanganLastAB\th#\r\nDanganLastB\r\nDanganD"},
            {"236AB~(AB)~(Cx4)~6D", "BanditRevolverAB\r\nDanganLastAB\th#\r\nDanganLastB\r\nDanganD"},
            
            ///
            ///
            ///

            //Aim
            {"214A", "KamaeA"},
            {"214B", "KamaeB"},
            {"214AB", "KamaeAB"},

            //Aim ~ Cancel Aim
            {"214A~D", "KamaeA\ta\nKamaeCancelD\ta\t|KamaeCancelA\ta\t+ShagekiD"},
            {"214B~D", "KamaeB\ta\nKamaeCancelD\ta\t|KamaeCancelA\ta\t+ShagekiD"},
            {"214AB~D", "KamaeAB\ta\nKamaeCancelD\ta\t|KamaeCancelA\ta\t+ShagekiD"},

            {"214A~214A", "KamaeA\ta\nKamaeCancelD\ta\t|KamaeCancelA\ta\t+ShagekiD"},
            {"214B~214A", "KamaeB\ta\nKamaeCancelD\ta\t|KamaeCancelA\ta\t+ShagekiD"},
            {"214AB~214A", "KamaeAB\ta\nKamaeCancelD\ta\t|KamaeCancelA\ta\t+ShagekiD"},

            //Aim ~ Snipe (D)
            {"214A~6D", "KamaeA\ta\r\nDanganD"},
            {"214B~6D", "KamaeB\ta\r\nDanganD"},
            {"214AB~6D", "KamaeAB\ta\r\nDanganD"},

            //Aim ~ Snipe (A)
            {"214A~(Ax5)", "KamaeA\ta\r\nDanganLastA"},
            {"214B~(Ax5)", "KamaeB\ta\r\nDanganLastA"},
            {"214AB~(Ax5)", "KamaeAB\ta\r\nDanganLastA"},

            //Aim ~ Snipe (A) ~ Snipe (D)
            {"214A~(Ax5)~6D", "KamaeA\ta\r\nDanganLastA\r\nDanganD"},
            {"214B~(Ax5)~6D", "KamaeB\ta\r\nDanganLastA\r\nDanganD"},
            {"214AB~(Ax5)~6D", "KamaeAB\ta\r\nDanganLastA\r\nDanganD"},

            //Aim ~ Snipe (B)
            {"214A~(Bx5)", "KamaeA\ta\r\nDanganHit_Shita"},
            {"214B~(Bx5)", "KamaeB\ta\r\nDanganHit_Shita"},
            {"214AB~(Bx5)", "KamaeAB\ta\r\nDanganHit_Shita"},

            //Aim ~ Snipe (B) ~ Snipe (D)
            {"214A~(Bx5)~6D", "KamaeA\ta\r\nDanganHit_Shita\r\nDanganD"},
            {"214B~(Bx5)~6D", "KamaeB\ta\r\nDanganHit_Shita\r\nDanganD"},
            {"214AB~(Bx5)~6D", "KamaeAB\ta\r\nDanganHit_Shita\r\nDanganD"},

            //Aim ~ Snipe (C)
            {"214A~(Cx5)", "KamaeA\ta\r\nDanganLastB"},
            {"214B~(Cx5)", "KamaeB\ta\r\nDanganLastB"},
            {"214AB~(Cx5)", "KamaeAB\ta\r\nDanganLastB"},

            //Aim ~ Snipe (C) ~ Snipe (D)
            {"214A~(Cx5)~6D", "KamaeA\ta\r\nDanganLastB\r\nDanganD"},
            {"214B~(Cx5)~6D", "KamaeB\ta\r\nDanganLastB\r\nDanganD"},
            {"214AB~(Cx5)~6D", "KamaeAB\ta\r\nDanganLastB\r\nDanganD"},

            //Aim ~ Snipe (6CD)
            {"214A~6CD", "KamaeA\ta\r\nDanganD"},
            {"214B~6CD", "KamaeB\ta\r\nDanganD"},
            {"214AB~6CD", "KamaeAB\ta\r\nDanganD"},

            //Aim ~ Snipe (AB) ~ Snipe (A)
            {"214A~(AB)~(Ax4)", "KamaeA\ta\r\nDanganLastAB\th#\r\nDanganLastA"},
            {"214B~(AB)~(Ax4)", "KamaeB\ta\r\nDanganLastAB\th#\r\nDanganLastA"},
            {"214AB~(AB)~(Ax4)", "KamaeAB\ta\r\nDanganLastAB\th#\r\nDanganLastA"},

            //Aim ~ Snipe (AB) ~ Snipe (A) ~ Snipe (D)
            {"214A~(AB)~(Ax4)~6D", "KamaeA\ta\r\nDanganLastAB\th#\r\nDanganLastA\r\nDanganD"},
            {"214B~(AB)~(Ax4)~6D", "KamaeB\ta\r\nDanganLastAB\th#\r\nDanganLastA\r\nDanganD"},
            {"214AB~(AB)~(Ax4)~6D", "KamaeAB\ta\r\nDanganLastAB\th#\r\nDanganLastA\r\nDanganD"},

            //Aim ~ Snipe (AB) ~ Snipe (B)
            {"214A~(AB)~(Bx4)", "KamaeA\ta\r\nDanganLastAB\th#\r\nDanganHit_Shita"},
            {"214B~(AB)~(Bx4)", "KamaeB\ta\r\nDanganLastAB\th#\r\nDanganHit_Shita"},
            {"214AB~(AB)~(Bx4)", "KamaeAB\ta\r\nDanganLastAB\th#\r\nDanganHit_Shita"},

            //Aim ~ Snipe (AB) ~ Snipe (B) ~ Snipe (D)
            {"214A~(AB)~(Bx4)~6D", "KamaeA\ta\r\nDanganLastAB\th#\r\nDanganHit_Shita\r\nDanganD"},
            {"214B~(AB)~(Bx4)~6D", "KamaeB\ta\r\nDanganLastAB\th#\r\nDanganHit_Shita\r\nDanganD"},
            {"214AB~(AB)~(Bx4)~6D", "KamaeAB\ta\r\nDanganLastAB\th#\r\nDanganHit_Shita\r\nDanganD"},

            //Aim ~ Snipe (AB) ~ Snipe (C)
            {"214A~(AB)~(Cx4)", "KamaeA\ta\r\nDanganLastAB\th#\r\nDanganLastB"},
            {"214B~(AB)~(Cx4)", "KamaeB\ta\r\nDanganLastAB\th#\r\nDanganLastB"},
            {"214AB~(AB)~(Cx4)", "KamaeAB\ta\r\nDanganLastAB\th#\r\nDanganLastB"},

            //Aim ~ Snipe (AB) ~ Snipe (C) ~ Snipe (D)
            {"214A~(AB)~(Cx4)~6D", "KamaeA\ta\r\nDanganLastAB\th#\r\nDanganLastB\r\nDanganD"},
            {"214B~(AB)~(Cx4)~6D", "KamaeB\ta\r\nDanganLastAB\th#\r\nDanganLastB\r\nDanganD"},
            {"214AB~(AB)~(Cx4)~6D", "KamaeAB\ta\r\nDanganLastAB\th#\r\nDanganLastB\r\nDanganD"},

            //Hair-Trigger Megido
            {"214C", "TrapC"},
            {"214D", "TrapD"},
            {"214CD", "TrapCD"},

            //Hair-Trigger Megido (Air)           
            {"j.214CD", "AirTrapCD"},

            //Blight
            {"236C", "PersonaAssaultC"},
            {"236D", "PersonaAssaultD"},
            {"236CD", "PersonaAssaultCD"},

            //Anti-S SP Pistol
            {"236236A", "DanganKakushiA"},
            {"236236B", "DanganKakushiB"},
            {"236236AB", "DanganKakushiAB"},

            //Anti-S SP Pistol (Air)
            {"j.236236A", "DanganKakushiA"},
            {"j.236236B", "DanganKakushiB"},
            {"j.236236AB", "DanganKakushiAB"},

            //Hamaon/Mudoon
            {"236236C", "HamaonKill"},
            {"236236D", "MudoonKill"},
            {"236236CD", "HamaonCDKill"},        

            //Raid (A/B) ~ Raid(Ax3) ~ Critical Shot (C)
            {"214214A~(Ax3)~C", "DanganUltimate\r\nDanganUltimate\t+DanganUltimateTama\r\nDanganUltimate\t+DanganUltimateTama\r\nUltimateWalkingShotKick\t+UltimateWalkingShotKickC"},
            {"214214B~(Ax3)~C", "DanganUltimate\r\nDanganUltimate\t+DanganUltimateTama\r\nDanganUltimate\t+DanganUltimateTama\r\nUltimateWalkingShotKick\t+UltimateWalkingShotKickC"},

            //Raid (A/B) ~ Raid(Ax3) ~ Critical Shot (D)
            {"214214A~(Ax3)~D", "DanganUltimate\r\nDanganUltimate\t+DanganUltimateTama\r\nDanganUltimate\t+DanganUltimateTama\r\nUltimateWalkingShotKick\t+UltimateWalkingShotKickD"},
            {"214214B~(Ax3)~D", "DanganUltimate\r\nDanganUltimate\t+DanganUltimateTama\r\nDanganUltimate\t+DanganUltimateTama\r\nUltimateWalkingShotKick\t+UltimateWalkingShotKickD"},

            //Raid (A/B) ~ Critical Shot (C)
            {"214214A~C", "DanganUltimate\ta\r\nUltimateWalkingShotKick\t+UltimateWalkingShotKickC"},
            {"214214B~C", "DanganUltimate\ta\r\nUltimateWalkingShotKick\t+UltimateWalkingShotKickC"},

            //Raid (A/B) ~ Critical Shot (D)
            {"214214A~D", "DanganUltimate\ta\r\nUltimateWalkingShotKick\t+UltimateWalkingShotKickD"},
            {"214214B~D", "DanganUltimate\ta\r\nUltimateWalkingShotKick\t+UltimateWalkingShotKickD"},

        };
        private readonly static Dictionary<string, string> workingDictionary_S = new();
        private static bool dictionariesBuilt = false;
        private readonly static List<string> invalidActions = new() { "5DD", "j.BB", "j.AB", "j.2A", "j.2B", "j.2C", "j.2D" };
        public static Dictionary<string, string> Dictionary
        {
            get { return workingDictionary; }
        }
        public static Dictionary<string, string> Dictionary_S
        {
            get { return workingDictionary_S; }
        }

        public NaotoShirogane()
        {            
            if (!dictionariesBuilt)
            {
                foreach (KeyValuePair<string, string> pair in workingDictionary.ToList())
                {
                    workingDictionary_S.Add(pair.Key, pair.Value);
                }

                //Auto Combo
                workingDictionary.Add("5AA", "NmlAtk5A2nd_P4U2\tc");
                workingDictionary.Add("5AAA", "NmlAtk5A3rd_P4U2\tc");
                workingDictionary.Add("5AAAA", "BanditRevolverA\t|AirBanditRevolverA\t+StylishBandit");
                workingDictionary.Add("5AAAAA", "DanganD\t+StylishDangan");
                workingDictionary.Add("5AAAAAA", "DanganKakushiA\t+StylishKakushi");
                //S. Auto Combo
                workingDictionary_S.Add("5AAAA", "KamaeB\t+StylishKamaeB\ta");
                workingDictionary_S.Add("5AAAAA", "DanganLastA\t+StylishDangan");
                workingDictionary_S.Add("5AAAAAA", "DanganKakushiA\t+StylishKakushi");

                foreach (KeyValuePair<string, string> pair in COMMON_ACTIONS.ToList())
                {
                    if (invalidActions.Any(action => pair.Key.Contains(action)))
                    {
                        continue;
                    }

                    if (!workingDictionary.ContainsKey(pair.Key))
                    {
                        workingDictionary.Add(pair.Key, pair.Value);
                    }
                    if (!workingDictionary_S.ContainsKey(pair.Key))
                    {
                        if (invalidActions_S.Any(action => pair.Key.Contains(action)))
                        {
                            continue;
                        }
                        workingDictionary_S.Add(pair.Key, pair.Value);
                    }
                }

                foreach (KeyValuePair<string, string> pair in SHADOW_ACTIONS)
                {
                    workingDictionary_S.Add(pair.Key, pair.Value);
                }

                dictionariesBuilt = true;
            }
        }
    }    

    public class MitsuruKirijo : PlayableShadow
    {
        private readonly static Dictionary<string, string> workingDictionary = new()
        {
            //5B (Full Charge)
            {"5[B]", "NmlAtk5Btame"},
            {"4[B]", "NmlAtk5Btame"},
            {"6[B]", "NmlAtk5Btame"},

            //2B (Full Charge)
            {"2[B]", "NmlAtk2Btame"},
            {"3[B]", "NmlAtk2Btame"},
            {"1[B]", "NmlAtk2Btame"},

            //5C (Full Charge)
            {"5[C]", "NmlAtk5Ctame"},

            //2AA and 2AAA
            {"2AA", "NmlAtk2A2nd"},
            {"2AAA", "NmlAtk2A2nd"},

            //5D, 2D, j.D followups
            {"5DD", "5Dhikiyose"},
            {"2DD", "2Dhikiyose"},
            {"j.DD", "Air5Dhikiyose"},

            //Getsu-ei (Air)
            {"j.BD", "ReversalActionAir"},
            {"j.DP", "ReversalActionAir"},

            //Coup Droit
            {"[4]6A", "TosshinA"},
            {"[4]6B", "TosshinB"},
            {"[4]6[B]", "TosshinB"},
            {"[4]6AB", "TosshinAB"},

            {"[1]6A", "TosshinA"},
            {"[1]6B", "TosshinB"},
            {"[1]6[B]", "TosshinB"},
            {"[1]6AB", "TosshinAB"},

            //Bufula
            {"[2]8C", "IceMiller_ShotC"},
            {"[2]8D", "IceMiller_ShotD"},
            {"[2]8CD", "IceMiller_ShotCD"},

            {"[1]8C", "IceMiller_ShotC"},
            {"[1]8D", "IceMiller_ShotD"},
            {"[1]8CD", "IceMiller_ShotCD"},

            //Tentarafoo
            {"[4]6C", "TentarahuC"},
            {"[4]6D", "TentarahuD"},
            {"[4]6CD", "TentarahuCD"},

            {"[1]6C", "TentarahuC\ta"},
            {"[1]6D", "TentarahuD"},
            {"[1]6CD", "TentarahuCD"},

            //Myriad Arrows
            {"236236A", "UltimateRenzokuA"},
            {"236236B", "UltimateRenzokuB"},
            {"236236AB", "UltimateRenzokuAB"},

            //Myriad Arrows (Full Charge)
            {"236236A(Full Charge)", "RenzokufullA\t+Renzokufull\tnOnly\tNandodemo"},
            {"236236B(Full Charge)", "RenzokufullB\t+Renzokufull\tnOnly\tNandodemo"},
            {"236236AB(Full Charge)", "RenzokufullAB\t+Renzokufull\tnOnly\tNandodemo"},

            //Bufudyne
            {"236236C", "aref_431_colC"},
            {"236236D", "aref_431_colD"},
            {"236236CD", "aref_431_colCD"},

            //Mabufudyne
            {"214214C", "UltimateTsuraraThrough\ta"},
            {"214214D", "UltimateTsuraraThrough\ta"},
            {"214214CD", "UltimateTsuraraThroughCD\ta"},

            //Mabufudyne (Ice Shots)
            {"C(Shot)", "Tsurara_ShotC"},
            {"D(Shot)", "Tsurara_ShotD"},

            //Instant Kill
            {"IK","Ichigeki_Whip"},
            {"222CD","Ichigeki_Whip"}
        };
        private readonly static Dictionary<string, string> workingDictionary_S = new();
        private static bool dictionariesBuilt = false;
        private readonly static List<string> invalidActions = new() { "IK", "222CD", "5DD", "j.BB", "j.AB", "j.2A", "j.2B", "j.2C", "j.2D" };
        public static Dictionary<string, string> Dictionary
        {
            get { return workingDictionary; }
        }
        public static Dictionary<string, string> Dictionary_S
        {
            get { return workingDictionary_S; }
        }

        public MitsuruKirijo()
        {
            if (!dictionariesBuilt)
            {
                foreach (KeyValuePair<string, string> pair in workingDictionary.ToList())
                {
                    workingDictionary_S.Add(pair.Key, pair.Value);
                }

                //Auto Combo
                workingDictionary.Add("5AA", "NmlAtk5A2nd_P4U2\tc");
                workingDictionary.Add("5AAA", "NmlAtk5A3rd_P4U2\tc");
                workingDictionary.Add("5AAAA", "TosshinA\t+StylishTosshin");
                workingDictionary.Add("5AAAAA", "UltimateRenzokuA\t+StylishRenzoku");
                //S. Auto Combo
                workingDictionary_S.Add("5AAAA", "NmlAtk5A4th");
                workingDictionary_S.Add("5AAAAA", "NmlAtk5A5th");
                workingDictionary_S.Add("5AAAAAA", "TosshinA\t+StylishTosshin");
                workingDictionary_S.Add("5AAAAAAA", "UltimateRenzokuA\t+StylishRenzoku");

                foreach (KeyValuePair<string, string> pair in COMMON_ACTIONS.ToList())
                {
                    if (invalidActions.Any(action => pair.Key.Contains(action)))
                    {
                        continue;
                    }

                    if (!workingDictionary.ContainsKey(pair.Key))
                    {
                        workingDictionary.Add(pair.Key, pair.Value);
                    }
                    if (!workingDictionary_S.ContainsKey(pair.Key))
                    {
                        if (invalidActions_S.Any(action => pair.Key.Contains(action)))
                        {
                            continue;
                        }
                        workingDictionary_S.Add(pair.Key, pair.Value);
                    }
                }

                foreach (KeyValuePair<string, string> pair in SHADOW_ACTIONS)
                {
                    workingDictionary_S.Add(pair.Key, pair.Value);
                }

                dictionariesBuilt = true;
            }
        }
    }

    public class AkihikoSanada : PlayableShadow
    {
        private readonly static Dictionary<string, string> workingDictionary = new()
        {
            //Kill Rush
            {"236A", "RushA"},
            {"236B", "RushB"},
            {"236AB", "RushAB"},            

            //Dodge Strike
            {"214A", "AtemiSeikoA"},
            {"214AB", "AtemiSeiko"},            

            //Corkscrew
            {"6A", "CorkScrewA"},
            {"6B", "CorkScrewB"},
            {"6AB", "CorkScrewAB"},
            
            //Boomerang Hook
            {"4A", "BodyBlowA"},
            {"4B", "BodyBlowB"},
            {"4AB", "BodyBlowAB"},

            //Sonic Punch
            {"8A", "DashUpperA"},
            {"8B", "DashUpperB"},
            {"8AB", "DashUpperAB"},

            //Duck
            {"236C", "DuckingC\t|HaseiDuckingC\ta"},
            {"236D", "DuckingD\t|HaseiDuckingD\ta"},
            {"236CD", "DuckingCD\t|HaseiDuckingCD\ta"},

            {"6C", "HaseiDuckingC\t|DuckingC\ta"},
            {"6D", "HaseiDuckingD\t|DuckingD\ta"},
            {"6CD", "HaseiDuckingCD\t|DuckingCD\ta"},

            //Weave
            {"214C", "WavingC\t|HaseiWavingC\ta"},
            {"214D", "WavingD\t|HaseiWavingD\ta"},
            {"214CD", "WavingCD\t|HaseiWavingCD\ta"},

            {"4C", "HaseiWavingC\t|WavingC\ta"},
            {"4D", "HaseiWavingD\t|WavingD\ta"},
            {"4CD", "HaseiWavingCD\t|WavingCD\ta"},

            //Assault Dive
            {"j.214A", "AirTosshinA"},
            {"j.214B", "AirTosshinB"},
            {"j.214AB", "AirTosshinAB"},

            //Cyclone Uppercut
            {"236236A", "UltimateUpperA"},
            {"236236B", "UltimateUpperB"},
            {"236236AB", "UltimateUpperAB"},

            //Thunder Fists
            {"236236C", "UltimateKokoroeC\ta"},
            {"236236D", "UltimateKokoroeD\ta"},
            {"236236CD", "UltimateKokoroe_col"},

            //Maziodyne
            {"214214C", "LightningPlasma_col"},
            {"214214CD", "LightningPlasmaCD_col"},

            //Instant Kill
            {"IK", "caef_Ichigeki_globe_col"},
            {"222CD", "caef_Ichigeki_globe_col"}            
        };
        private readonly static Dictionary<string, string> workingDictionary_S = new();
        private static bool dictionariesBuilt = false;
        private readonly static List<string> invalidActions = new() { "IK", "222CD", "5DD", "j.BB", "j.AB", "j.2A", "j.2B", "j.2C", "j.2D" };
        public static Dictionary<string, string> Dictionary
        {
            get { return workingDictionary; }
        }
        public static Dictionary<string, string> Dictionary_S
        {
            get { return workingDictionary_S; }
        }

        public AkihikoSanada()
        {
            if (!dictionariesBuilt)
            {
                foreach (KeyValuePair<string, string> pair in workingDictionary.ToList())
                {
                    workingDictionary_S.Add(pair.Key, pair.Value);
                }

                //Auto Combo
                workingDictionary.Add("5AA", "NmlAtk5A2nd_P4U2\tc");
                workingDictionary.Add("5AAA", "NmlAtk5A3rd_P4U2\tc");
                workingDictionary.Add("5AAAA", "NmlAtk5A3rd_Add");
                workingDictionary.Add("5AAAAA", "NmlAtk5A3rd_Add2");
                workingDictionary.Add("5AAAAAA", "NmlAtk5A3rd_Add3");
                workingDictionary.Add("5AAAAAAA", "AirTosshinA\t+StylishAirTosshin");
                workingDictionary.Add("5AAAAAAAA", "UltimateUpperA\t+StylishUpper");
                //S. Auto Combo
                workingDictionary_S.Add("5AAAA", "BodyBlowA\t+StylishBlow");
                workingDictionary_S.Add("5AAAAA", "CorkScrewA\t+StylishCork");
                workingDictionary_S.Add("5AAAAAA", "LightningPlasma_col\t+StylishLightningPlasma");

                foreach (KeyValuePair<string, string> pair in COMMON_ACTIONS.ToList())
                {
                    if (invalidActions.Any(action => pair.Key.Contains(action)))
                    {
                        continue;
                    }

                    if (!workingDictionary.ContainsKey(pair.Key))
                    {
                        workingDictionary.Add(pair.Key, pair.Value);
                    }
                    if (!workingDictionary_S.ContainsKey(pair.Key))
                    {
                        if (invalidActions_S.Any(action => pair.Key.Contains(action)))
                        {
                            continue;
                        }
                        workingDictionary_S.Add(pair.Key, pair.Value);
                    }
                }

                foreach (KeyValuePair<string, string> pair in SHADOW_ACTIONS)
                {
                    workingDictionary_S.Add(pair.Key, pair.Value);
                }

                dictionariesBuilt = true;
            }
        }
    }

    public class Aigis : PlayableShadow
    {
        private readonly static Dictionary<string, string> workingDictionary = new()
        {
            //5B
            {"5B", "dmy_5B"},

            //2B
            {"2B", "dmy_machinegun2"},

            //j.2B
            {"j.2B", "Air2B_Bom"},
            {"j.1B", "Air2B_Bom"},
            {"j.3B", "Air2B_Bom"},

            //Escape Change
            {"DP", "r_action_land"},
            {"BD", "r_action_land"},

            //Escape Change (Air)
            {"j.DP", "r_action_air"},
            {"j.BD", "r_action_air"},

            //Mode Change
            {"22A", "ModeChangeA\ta\t|ModeChangeB\ta\t+ModeChange"},
            {"22B", "ModeChangeB\ta\t|ModeChangeA\ta\t+ModeChange"},
            {"22AB", "ModeChangeAB\ta"},

            //7th Gen Gatling Blast
            {"236A", "dmy_machinegun_3A"},
            {"236B", "dmy_machinegun_3B"},
            {"236AB", "dmy_machinegun_3AB"},

            //7th Gen Radical Cannon
            {"214A", "dmy_machinegun_9A"},
            {"214B", "dmy_machinegun_9B"},
            {"214AB", "dmy_machinegun_9AB"},

            //7th Gen Radical Cannon (Air)
            {"j.214A", "dmy_machinegun_9A"},
            {"j.214B", "dmy_machinegun_9B"},
            {"j.214AB", "dmy_machinegun_9AB"},

            //7th Gen Vulcan Cannon
            {"j.236A", "dmy_machinegun_4A"},
            {"j.236B", "dmy_machinegun_4B"},
            {"j.236AB", "dmy_machinegun_4AB"},

            //Orgia Boost
            {"66(Orgia)", "OrgiaDash\ta"},
            {"j.66(Orgia)", "OrgiaDash\ta"},
            {"j.[6](Orgia)", "OrgiaDash\ta"},

            //Orgia Back Boost
            {"44(Orgia)", "OrgiaBackDash\ta"},
            {"j.44(Orgia)", "OrgiaBackDash\ta"},

            //Orgia Air Boost
            {"j.AB(Orgia)", "AirSurinuke\ta"},

            //Orgia Hover Boost
            {"j.2AC(Orgia)", "Hovering\ta"},

            //Megido Fire EX 
            {"236C", "RollingC\t|AirRollingC"},
            {"236D", "RollingD\t|AirRollingD"},
            {"236CD", "RollingCD\t|AirRollingCD"},

            //Megido Fire EX (Air)
            {"j.236C", "AirRollingC\t|RollingC"},
            {"j.236D", "AirRollingD\t|RollingD"},
            {"j.236CD", "AirRollingCD\t|RollingCD"},

            //Pandora Missile Launcher
            {"214C", "dmy_machinegun5"},
            {"214CD", "dmy_machinegun_5CD"},

            //Pandora Missile Launcher (Air)
            {"j.214C", "dmy_machinegun5"},
            {"j.214CD", "dmy_machinegun_8CD"},

            //Goddess Shield
            {"236236C", "PersonaAthenaSurfingC\t|PersonaAirAthenaSurfingC\t+AthenaSurfingC"},
            {"236236D", "PersonaAthenaSurfingD\t|PersonaAirAthenaSurfingD\t+AthenaSurfingD"},
            {"236236CD", "PersonaAthenaSurfingCD\t|PersonaAirAthenaSurfingCD\t+AthenaSurfingCD"},

            //Goddess Shield (Air)
            {"j.236236C", "PersonaAthenaSurfingC\t|PersonaAirAthenaSurfingC\t+AthenaSurfingC"},
            {"j.236236D", "PersonaAthenaSurfingD\t|PersonaAirAthenaSurfingD\t+AthenaSurfingD"},
            {"j.236236CD", "PersonaAthenaSurfingCD\t|PersonaAirAthenaSurfingCD\t+AthenaSurfingCD"},

            //Multi-Mounted Machine Gun Orion
            {"j.236236AB", "UltimateAirThrowAB"},

            //Heavenly Spear
            {"214214C", "SpearC"},
            {"214214D", "SpearD"},
            {"214214CD", "SpearCD"},

            //Extreme Orgia Mode (Lol)
            {"214214AB", "UltimateModeChange\ta"},

            //IK
            {"IK", "IchigekiShot"},
            {"222CD", "IchigekiShot"}
        };
        private readonly static Dictionary<string, string> workingDictionary_S = new();
        private static bool dictionariesBuilt = false;
        private readonly static List<string> invalidActions = new() { "5B", "2B", "DP", "BD", "IK", "222CD", "5DD", "j.BB", "j.AB", "j.2A", "j.2B", "j.2D" };
        public static Dictionary<string, string> Dictionary
        {
            get { return workingDictionary; }
        }
        public static Dictionary<string, string> Dictionary_S
        {
            get { return workingDictionary_S; }
        }

        public Aigis()
        {
            if (!dictionariesBuilt)
            {
                foreach (KeyValuePair<string, string> pair in workingDictionary.ToList())
                {
                    workingDictionary_S.Add(pair.Key, pair.Value);
                }

                //Auto Combo
                workingDictionary.Add("5AA", "NmlAtk5A2nd_P4U2\tc");
                workingDictionary.Add("5AAA", "NmlAtk5A3rd_P4U2\tc");
                workingDictionary.Add("5AAAA", "dmy_machinegun10");
                workingDictionary.Add("5AAAAA", "dmy_machinegun_9B\t+StylishCanon");
                workingDictionary.Add("5AAAAAA", "PersonaAthenaSurfingD\t|PersonaAirAthenaSurfingD\t+StylishSurfing\r\n");
                //S. Auto Combo
                workingDictionary_S.Remove("5AA");
                workingDictionary_S.Add("5AA", "dmy_machinegun");
                workingDictionary_S.Add("5AAAA", "dmy_machinegun_9B\t+StylishCanon");
                workingDictionary_S.Add("5AAAAA", "PersonaAthenaSurfingD\t|PersonaAirAthenaSurfingD\t+StylishSurfing");

                foreach (KeyValuePair<string, string> pair in COMMON_ACTIONS.ToList())
                {
                    if (invalidActions.Any(action => pair.Key.Contains(action)))
                    {
                        continue;
                    }

                    if (!workingDictionary.ContainsKey(pair.Key))
                    {
                        workingDictionary.Add(pair.Key, pair.Value);
                    }
                    if (!workingDictionary_S.ContainsKey(pair.Key))
                    {
                        if (invalidActions_S.Any(action => pair.Key.Contains(action)))
                        {
                            continue;
                        }
                        workingDictionary_S.Add(pair.Key, pair.Value);
                    }
                }

                foreach (KeyValuePair<string, string> pair in SHADOW_ACTIONS)
                {
                    if(pair.Key.Equals("5AA"))
                    {
                        continue;
                    }
                    workingDictionary_S.Add(pair.Key, pair.Value);
                }

                dictionariesBuilt = true;
            }
        }
    }

    public class Elizabeth : Character
    {
        private readonly static Dictionary<string, string> workingDictionary = new()
        {
            //Autocombo
            {"5AA", "NmlAtk5A2nd_P4U2\tc"},
            {"5AAA", "dmy_el208"},
            {"5AAAA", "PersonaMahabufudainAB\t+Stylishbufu"},
            {"5AAAAA", "MaharagiHit_CD\t+Stylishragi"},
            {"5AAAAAA", "TatsumakiHit_CD\t+Stylishgaru"},
            {"5AAAAAAA", "PersonaMahajiodainAB\t+Stylishjio"},

            //5B, 5BB, 5BBB
            {"5B", "elef203_CardShot"},
            {"5BB", "NmlAtk5B2nd"},
            {"5BBB", "NmlAtk5B3rd"},

            //2C (Miss)
            {"2C(Miss)", "NmlAtk2Cmiss"},

            //j.B
            {"j.B", "elef251_CardShotAir"},

            //Maziodyne
            {"236A", "PersonaMahajiodainA"},
            {"236B", "PersonaMahajiodainB"},
            {"236AB", "PersonaMahajiodainAB"},

            //Maziodyne (Air)
            {"j.236A", "PersonaMahajiodainA"},
            {"j.236B", "PersonaMahajiodainB"},
            {"j.236AB", "PersonaMahajiodainAB"},

            //Maziodyne (Awakening)
            {"236A(Awakening)", "PersonaMahajiodainKakuseiA"},

            //Maziodyne (Awakening/Air)
            //{"j.236A(Awakening)", "PersonaMahajiodainKakuseiA"},

            //Mabufudyne
            {"214A", "PersonaMahabufudainA"},
            {"214B", "PersonaMahabufudainB"},
            {"214AB", "PersonaMahabufudainAB"},

            //Magarudyne
            {"236C","TatsumakiHit_C"},
            {"236D","TatsumakiHit_D"},
            {"236CD","TatsumakiHit_CD"},

            //Magarudyne (Air)
            {"j.236C","AirTatsumakiHit_C"},

            //Maragidyne
            {"214C", "MaharagiHit_C"},
            {"214D", "MaharagiHit_D"},
            {"214CD", "MaharagiHit_CD"},

            //Debilitate
            {"[2]8A", "Randomizer_col"},
            {"[2]8B", "Randomizer_col"},
            {"[2]8AB", "Randomizer_colCD"},

            //Mind Charge
            {"236236A", "ConcentrateA\ta"},
            {"236236B", "ConcentrateB\ta"},
            {"236236AB", "ConcentrateAB\ta"},

            //Mahamaon & Mamudoon
            {"236236C", "Mahanmaon\ta"},
            {"236236D", "Mahamudo_on\ta"},

            //Diarahan            
            {"214214AB", "DiarahanAB\ta"},

            //Ghastly Wail
            {"214214C", "MoujyaHit_C"},
            {"214214D", "MoujyaHit_D"},
            {"214214CD", "PersonaMoujya_no_NagekiCD\t+MoujyaHit_CD"},
        };
        private static bool dictionariesBuilt = false;
        private readonly static List<string> invalidActions = new() { "DP", "BD", "5DD", "5B", "j.B","j.BB", "j.AB", "j.2A", "j.2C", "j.2D" };
        public static Dictionary<string, string> Dictionary
        {
            get { return workingDictionary; }
        }

        public Elizabeth()
        {
            if (!dictionariesBuilt)
            {
                foreach (KeyValuePair<string, string> pair in COMMON_ACTIONS.ToList())
                {
                    if (invalidActions.Any(action => pair.Key.Contains(action)))
                    {
                        continue;
                    }

                    if (!workingDictionary.ContainsKey(pair.Key))
                    {
                        workingDictionary.Add(pair.Key, pair.Value);
                    }
                }

                dictionariesBuilt = true;
            }
        }
    }

    public class Labrys : PlayableShadow
    {
        private readonly static Dictionary<string, string> workingDictionary = new()
        {
            //5C
            {"5C", "vr_lp204atk"},

            //2C
            {"2C", "vr_lp232atk"},

            //5D & 5DD
            {"5D", "vr_lp205atk"},
            {"5DD", "vr_lp206atk"},

            //j.C
            {"j.C", "vr_lp254atk"},

            //Chain Knuckle
            {"236A", "RocketPunchA"},
            {"236B", "RocketPunchB"},
            {"236AB", "RocketPunchAB"},

            //Chain Knuckle ~ Winch Dash
            {"236A~6", "RocketPunchA\r\nRokepanDash\ta"},
            {"236B~6", "RocketPunchB\r\nRokepanDash\ta"},
            {"236AB~6", "RocketPunchAB\r\nRokepanDash\ta"},

            //Chain Knuckle ~ Winch Dash ~ Extra Attack A
            {"236A~(6)~A", "RocketPunchA\r\nRokepanDash\ta\r\nRokepanHaseiA"},
            {"236B~(6)~A", "RocketPunchB\r\nRokepanDash\ta\r\nRokepanHaseiA"},
            {"236AB~(6)~A", "RocketPunchAB\r\nRokepanDash\ta\r\nRokepanHaseiA"},

            //Chain Knuckle ~ Winch Dash ~ Extra Attack B
            {"236A~(6)~B", "RocketPunchA\r\nRokepanDash\ta\r\nRokepanHaseiB"},
            {"236B~(6)~B", "RocketPunchB\r\nRokepanDash\ta\r\nRokepanHaseiB"},
            {"236AB~(6)~B", "RocketPunchAB\r\nRokepanDash\ta\r\nRokepanHaseiB"},

            //Chain Knuckle ~ Winch Dash ~ Extra Attack AB
            {"236A~(6)~AB", "RocketPunchA\r\nRokepanDash\ta\r\nRokepanHaseiAB"},
            {"236B~(6)~AB", "RocketPunchB\r\nRokepanDash\ta\r\nRokepanHaseiAB"},
            {"236AB~(6)~AB", "RocketPunchAB\r\nRokepanDash\ta\r\nRokepanHaseiAB"},

            //Guillotine Axe
            {"214A", "AxeAttackA"},
            {"214B", "AxeAttackB"},
            {"214AB", "AxeAttackAB"},

            //Guillotine Aerial
            {"j.214A", "AxeAttackAirA"},
            {"j.214B", "AxeAttackAirB"},
            {"j.214AB", "AxeAttackAirAB"},

            //Weaver's Art: Sword (Set)
            {"22A(Set)", "SetupRopeA\ta"},
            {"22B(Set)", "SetupRopeB\ta"},

            //Weaver's Art: Sword (Hit)
            {"22A(Hit)", "YariA\t+Yari\tnOnly"},
            {"22B(Hit)", "YariB\t+Yari\tnOnly"},

            //Weaver's Art: Orb (Set)
            {"236C(Set)", "PShotC\ta"},
            {"236D(Set)", "PShotD\ta"},
            {"236CD(Set)", "PShotCD\ta"},

            //Weaver's Art: Orb (Hit)
            {"236C(Hit)", "407Shot_atk_C\t+407Shot_atk_Hit\tnOnly"},

            //Weaver's Art: Beast
            {"236236C", "UltimateTackleC"},
            {"236236D", "UltimateTackleD"},
            {"236236CD", "UltimateTackleCD"},

            //Weaver's Art: Breaking Wheel
            {"214214C", "Oraora"},
            {"214214D", "Oraora"},
            {"214214CD", "Oraora\t+OraoraCD"},

            //Brutal Impact
            {"214214A", "UltimateFullswingA"},
            {"214214B", "UltimateFullswingB"},
            {"214214AB", "UltimateFullswingAB"}
        };
        private readonly static Dictionary<string, string> workingDictionary_S = new();
        private static bool dictionariesBuilt = false;
        private readonly static List<string> invalidActions = new() { "DP", "BD", "5C", "5D", "5DD", "j.AB", "j.2A", "j.2C", "j.2D" };
        public static Dictionary<string, string> Dictionary
        {
            get { return workingDictionary; }
        }
        public static Dictionary<string, string> Dictionary_S
        {
            get { return workingDictionary_S; }
        }

        public Labrys()
        {
            if (!dictionariesBuilt)
            {
                foreach (KeyValuePair<string, string> pair in workingDictionary.ToList())
                {
                    workingDictionary_S.Add(pair.Key, pair.Value);
                }

                //Auto Combo
                workingDictionary.Add("5AA", "NmlAtk5A2nd_P4U2\tc");
                workingDictionary.Add("5AAA", "NmlAtk5A3rd_P4U2\tc");
                workingDictionary.Add("5AAAA", "AxeAttackA\t+StylishAxeAttack");
                workingDictionary.Add("5AAAAA", "UltimateTackleD\t+StylishTackle");
                //S. Auto Combo
                workingDictionary_S.Add("5AAAA", "AxeAttackA\t+StylishAxeAttack");
                workingDictionary_S.Add("5AAAAA", "UltimateTackleD\t+StylishTackle"); ;

                foreach (KeyValuePair<string, string> pair in COMMON_ACTIONS.ToList())
                {
                    if (invalidActions.Any(action => pair.Key.Contains(action)))
                    {
                        continue;
                    }

                    if (!workingDictionary.ContainsKey(pair.Key))
                    {
                        workingDictionary.Add(pair.Key, pair.Value);
                    }
                    if (!workingDictionary_S.ContainsKey(pair.Key))
                    {
                        if (invalidActions_S.Any(action => pair.Key.Contains(action)))
                        {
                            continue;
                        }
                        workingDictionary_S.Add(pair.Key, pair.Value);
                    }
                }

                foreach (KeyValuePair<string, string> pair in SHADOW_ACTIONS)
                {
                    workingDictionary_S.Add(pair.Key, pair.Value);
                }

                dictionariesBuilt = true;
            }
        }
    }

    public class ShadowLabrys : Character
    {
        private readonly static Dictionary<string, string> workingDictionary = new()
        {
            //Autocombo
            {"5AA", "NmlAtk5A2nd\tc"},
            {"5AAA", "NmlAtk5A3rd\tc"},
            {"5AAAA", "AxeAttackA\t+StylishAxeAttack"},
            {"5AAAAA", "PersonaUltimateTemaeNaguriC\t+StylishNaguri"},

            //8C
            {"8C", "Persona8C"},
            {"j.8C", "Persona8C"},

            //Chain Knuckle
            {"236A", "RocketPunchA"},
            {"236B", "RocketPunchB"},
            {"236AB", "RocketPunchAB"},

            //Guillotine Axe
            {"214A", "AxeAttackA"},
            {"214B", "AxeAttackB"},
            {"214AB", "AxeAttackAB"},

            //Guillotine Aerial
            {"j.214A", "AxeAttackAirA"},
            {"j.214B", "AxeAttackAirB"},
            {"j.214AB", "AxeAttackAirAB"},

            //Flame of Hades
            {"236C", "UshiBeamC"},
            {"236D", "UshiBeamD"},
            {"236CD", "UshiBeamCD"},

            //Flame of Hades (Air)
            {"j.236C", "UshiBeamC"},
            {"j.236D", "UshiBeamD"},
            {"j.236CD", "UshiBeamCD"},

            //Buffalo Hammer
            {"214C", "PersonaUshiTatakiC"},
            {"214D", "PersonaUshiTatakiD"},
            {"214CD", "PersonaUshiTatakiCD"},

            //Buffalo Hammer (Air)
            {"j.214C", "PersonaUshiTatakiC"},
            {"j.214D", "PersonaUshiTatakiD"},
            {"j.214CD", "PersonaUshiTatakiCD"},

            //Massive Slaughter
            {"[4]6C", "PersonaUshiNageC"},
            {"[4]6D", "PersonaUshiNageD"},
            {"[4]6CD", "PersonaUshiNageCD"},

            {"[1]6C", "PersonaUshiNageC"},
            {"[1]6D", "PersonaUshiNageD"},
            {"[1]6CD", "PersonaUshiNageCD"},

            //Massive Slaughter (Air)
            {"j.[4]6C", "PersonaUshiNageC"},
            {"j.[4]6D", "PersonaUshiNageD"},
            {"j.[4]6CD", "PersonaUshiNageCD"},

            //Public Execution
            {"[2]8C", "PersonaUshiAirNageC"},
            {"[2]8D", "PersonaUshiAirNageD"},
            {"[2]8CD", "PersonaUshiAirNageCD"},

            {"[1]8C", "PersonaUshiAirNageC"},
            {"[1]8D", "PersonaUshiAirNageD"},
            {"[1]8CD", "PersonaUshiAirNageCD"},

            //Public Execution (Air)
            {"j.[2]8C", "PersonaUshiAirNageC"},
            {"j.[2]8D", "PersonaUshiAirNageD"},
            {"j.[2]8CD", "PersonaUshiAirNageCD"},

            //Challenge Authority
            {"236236C", "PersonaUltimateTemaeNaguriC"},
            {"236236D", "PersonaUltimateTemaeNaguriD"},
            {"236236CD", "PersonaUltimateTemaeNaguriCD"},

            //Challenge Authority (Air)
            {"j.236236C", "PersonaUltimateTemaeNaguriC"},
            {"j.236236D", "PersonaUltimateTemaeNaguriD"},
            {"j.236236CD", "PersonaUltimateTemaeNaguriCD"},

            //Brutal Impact
            {"214214A", "UltimateFullswingA"},
            {"214214B", "UltimateFullswingB"},
            {"214214AB", "UltimateFullswingAB"},

            //Titanomachia
            {"214214C", "UltimateProgramC\ta"},
            {"214214D", "UltimateProgramD\ta"},
            {"214214CD", "UltimateProgramCD\ta"},

            {"Titanomachia(Finish)", "ProgramFinish\tnOnly"},

            //Titanomachia (Air)
            {"j.214214C", "UltimateProgramC"},
            {"j.214214D", "UltimateProgramD"},
            {"j.214214CD", "UltimateProgramCD"},

            //IK
            {"IK(Set)", "IchigekiJunbi\ta"},
            {"222CD(Set)", "IchigekiJunbi\ta"},
        };
        private static bool dictionariesBuilt = false;
        private readonly static List<string> invalidActions = new() { "5DD", "j.AB", "j.2A", "j.2C", "j.2D" };
        public static Dictionary<string, string> Dictionary
        {
            get { return workingDictionary; }
        }

        public ShadowLabrys()
        {
            if (!dictionariesBuilt)
            {
                foreach (KeyValuePair<string, string> pair in COMMON_ACTIONS.ToList())
                {
                    if (invalidActions.Any(action => pair.Key.Contains(action)))
                    {
                        continue;
                    }

                    if (!workingDictionary.ContainsKey(pair.Key))
                    {
                        workingDictionary.Add(pair.Key, pair.Value);
                    }
                }

                dictionariesBuilt = true;
            }
        }
    }

    public class YukariTakeba : PlayableShadow
    {
        private readonly static Dictionary<string, string> workingDictionary = new()
        {
            //Autocombo
            {"5AA", "NmlAtk5A2nd\tc"},
            {"5AAA", "5A3rd_Atk"},
            {"5AAAA", "MoonsaltJumpC\ta\tn2miss\t+StylishMoonsaltJump"},
            {"5AAAAA", "MoonsaltArrowCharm\t|MoonsaltArrowConfuse\t+StylishMoonsaltArrow"},
            {"5AAAAAA", "AirUltimateArrow_AtkA\t|UltimateArrow_AtkA\t+StylishUltimateArrow"},

            //5B
            {"5B", "5B_Atk"},

            //5B (Charged)
            {"5[B]", "5B_Atk\t+5B_Atk_Charge"},

            //2B
            {"2B", "2B_Atk"},

            //2B (Charged)
            {"2[B]", "2B_Atk\t+2B_Atk_Charge"},

            //j.B
            {"j.B", "Air5B_Atk"},

            //j.B (Charged)
            {"j.[B]", "Air5B_Atk\t+Air5B_Atk_Charge"},

            //j.2B
            {"j.2B", "Air2B_Atk"},

            //j.2B (Charged)
            {"j.2[B]", "Air2B_Atk\t+Air2B_Atk_Charge"},

            //5D
            {"5D", "5D_Atk"},

            //5D (Miss)
            {"5D(Miss)", "5D_Atk_miss"},

            //2D
            {"2D", "2D_Atk"},

            //j.D
            {"j.D", "Air5D_Atk"},

            //Feather Slasher
            {"DP", "ReversalAction_2nd"},
            {"BD", "ReversalAction_2nd"},

            //Feather Arrow
            {"236A", "eff_KuneKuneArrowA"},
            {"236B", "eff_KuneKuneArrowB"},
            {"236AB", "eff_KuneKuneArrowAB"},

            //Feather Arrow (Air)
            {"j.236A", "eff_AirKuneKuneArrowA\t|eff_KuneKuneArrowA"},
            {"j.236B", "eff_AirKuneKuneArrowB\t|eff_KuneKuneArrowB"},
            {"j.236AB", "eff_AirKuneKuneArrowAB\t|eff_KuneKuneArrowAB"},

            //Feather Bomb (Set)
            {"214A", "MatoNageA\ta"},
            {"214B", "MatoNageB\ta"},
            {"214AB", "MatoNageAB\ta"},

            //Feather Bomb (Hit)
            {"Bomb(Explosion)", "eff_MatoNage_Atk"},

            //Magaru
            {"214C", "eff_MahaGaruC_dmy"},
            {"214D", "eff_MahaGaruD_dmy"},
            {"214CD", "eff_MahaGaruCD_dmy"},

            //Magaru (Air)
            {"j.214C", "eff_MahaGaruC_dmy"},
            {"j.214D", "eff_MahaGaruD_dmy"},
            {"j.214CD", "eff_MahaGaruCD_dmy"},

            //Feather Flip ~ Feather Shot A
            {"236C~A", "MoonsaltJumpC\ta\tn2miss\r\nMoonsaltArrowCharm"},
            {"236D~A", "MoonsaltJumpD\ta\tn2miss\r\nMoonsaltArrowCharm"},
            {"236CD~A", "MoonsaltJumpCD\ta\tn2miss\r\nMoonsaltArrowCharm"},

            //Feather Flip ~ Feather Shot B
            {"236C~B", "MoonsaltJumpC\ta\tn2miss\r\nMoonsaltArrowConfuse"},
            {"236D~B", "MoonsaltJumpD\ta\tn2miss\r\nMoonsaltArrowConfuse"},
            {"236CD~B", "MoonsaltJumpCD\ta\tn2miss\r\nMoonsaltArrowConfuse"},

            //Feather Flip ~ Feather Shot C
            {"236C~C", "MoonsaltJumpC\ta\tn2miss\r\nMoonsaltArrowCharm"},
            {"236D~C", "MoonsaltJumpC\ta\tn2miss\r\nMoonsaltArrowCharm"},
            {"236CD~C", "MoonsaltJumpC\ta\tn2miss\r\nMoonsaltArrowCharm"},

            //Feather Flip ~ Feather Shot D
            {"236C~D", "MoonsaltJumpC\ta\tn2miss\r\nMoonsaltArrowConfuse"},
            {"236D~D", "MoonsaltJumpD\ta\tn2miss\r\nMoonsaltArrowConfuse"},
            {"236CD~D", "MoonsaltJumpCD\ta\tn2miss\r\nMoonsaltArrowConfuse"},

            //Feather Flip ~ Feather Shot AB
            {"236C~AB", "MoonsaltJumpC\ta\tn2miss\r\nMoonsaltArrowBoth"},
            {"236D~AB", "MoonsaltJumpD\ta\tn2miss\r\nMoonsaltArrowBoth"},
            {"236CD~AB", "MoonsaltJumpCD\ta\tn2miss\r\nMoonsaltArrowBoth"},

            //Feather Flip ~ Feather Shot CD
            {"236C~CD", "MoonsaltJumpC\ta\tn2miss\r\nMoonsaltArrowBoth"},
            {"236D~CD", "MoonsaltJumpD\ta\tn2miss\r\nMoonsaltArrowBoth"},
            {"236CD~CD", "MoonsaltJumpCD\ta\tn2miss\r\nMoonsaltArrowBoth"},

            //Aerial Feather Flip ~ Feather Shot A
            {"j.236C~A", "MoonsaltJumpC\ta\tn2miss\r\nMoonsaltArrowCharm"},
            {"j.236D~A", "MoonsaltJumpD\ta\tn2miss\r\nMoonsaltArrowCharm"},
            {"j.236CD~A", "MoonsaltJumpCD\ta\tn2miss\r\nMoonsaltArrowCharm"},

            //Aerial Feather Flip ~ Feather Shot B
            {"j.236C~B", "MoonsaltJumpC\ta\tn2miss\r\nMoonsaltArrowConfuse"},
            {"j.236D~B", "MoonsaltJumpD\ta\tn2miss\r\nMoonsaltArrowConfuse"},
            {"j.236CD~B", "MoonsaltJumpCD\ta\tn2miss\r\nMoonsaltArrowConfuse"},

            //Aerial Feather Flip ~ Feather Shot C
            {"j.236C~C", "MoonsaltJumpC\ta\tn2miss\r\nMoonsaltArrowCharm"},
            {"j.236D~C", "MoonsaltJumpC\ta\tn2miss\r\nMoonsaltArrowCharm"},
            {"j.236CD~C", "MoonsaltJumpC\ta\tn2miss\r\nMoonsaltArrowCharm"},

            //Aerial Feather Flip ~ Feather Shot D
            {"j.236C~D", "MoonsaltJumpC\ta\tn2miss\r\nMoonsaltArrowConfuse"},
            {"j.236D~D", "MoonsaltJumpD\ta\tn2miss\r\nMoonsaltArrowConfuse"},
            {"j.236CD~D", "MoonsaltJumpCD\ta\tn2miss\r\nMoonsaltArrowConfuse"},

            //Aerial Feather Flip ~ Feather Shot AB
            {"j.236C~AB", "MoonsaltJumpC\ta\tn2miss\r\nMoonsaltArrowBoth"},
            {"j.236D~AB", "MoonsaltJumpD\ta\tn2miss\r\nMoonsaltArrowBoth"},
            {"j.236CD~AB", "MoonsaltJumpCD\ta\tn2miss\r\nMoonsaltArrowBoth"},

            //Aerial Feather Flip ~ Feather Shot CD
            {"j.236C~CD", "MoonsaltJumpC\ta\tn2miss\r\nMoonsaltArrowBoth"},
            {"j.236D~CD", "MoonsaltJumpD\ta\tn2miss\r\nMoonsaltArrowBoth"},
            {"j.236CD~CD", "MoonsaltJumpCD\ta\tn2miss\r\nMoonsaltArrowBoth"},

            //Hyper Feather Shot
            {"236236A", "UltimateArrow_AtkA"},
            {"236236B", "UltimateArrow_AtkB"},
            {"236236AB", "UltimateArrow_AtkAB"},

            //Hyper Feather Shot (Air)
            {"j.236236A", "AirUltimateArrow_AtkA"},
            {"j.236236B", "AirUltimateArrow_AtkB"},
            {"j.236236AB", "AirUltimateArrow_AtkAB"},

            //Magarula
            {"214214C", "eff_UltimateMahaGaru_Front"},
            {"214214D", "eff_UltimateMahaGaru_Back"},
            {"214214CD(Front)", "eff_UltimateMahaGaru_Front\r\neff_UltimateMahaGaruCD"},
            {"214214CD(Back)", "eff_UltimateMahaGaru_Back\r\neff_UltimateMahaGaruCD"},

            //IK
            {"IK", "IchigekiArrowFinish_Atk"},
            {"222CD", "IchigekiArrowFinish_Atk"},
        };
        private readonly static Dictionary<string, string> workingDictionary_S = new();
        private static bool dictionariesBuilt = false;
        private readonly static List<string> invalidActions = new() { "IK", "222CD", "5B", "2B", "j.B", "5D", "2D", "j.D", "5DD", "j.BB", "j.AB", "j.2A", "j.2C", "j.2D" };
        public static Dictionary<string, string> Dictionary
        {
            get { return workingDictionary; }
        }
        public static Dictionary<string, string> Dictionary_S
        {
            get { return workingDictionary_S; }
        }

        public YukariTakeba()
        {
            if (!dictionariesBuilt)
            {
                foreach (KeyValuePair<string, string> pair in workingDictionary.ToList())
                {
                    workingDictionary_S.Add(pair.Key, pair.Value);
                }

                //Auto Combos - Added in Dictionary :p

                foreach (KeyValuePair<string, string> pair in COMMON_ACTIONS.ToList())
                {
                    if (invalidActions.Any(action => pair.Key.Contains(action)))
                    {
                        continue;
                    }

                    if (!workingDictionary.ContainsKey(pair.Key))
                    {
                        workingDictionary.Add(pair.Key, pair.Value);
                    }
                    if (!workingDictionary_S.ContainsKey(pair.Key))
                    {
                        if (invalidActions_S.Any(action => pair.Key.Contains(action)))
                        {
                            continue;
                        }
                        workingDictionary_S.Add(pair.Key, pair.Value);
                    }
                }

                foreach (KeyValuePair<string, string> pair in SHADOW_ACTIONS)
                {
                    if(pair.Key.Equals("5AA") || pair.Key.Equals("5AAA"))
                    {
                        continue;
                    }
                    workingDictionary_S.Add(pair.Key, pair.Value);
                }

                dictionariesBuilt = true;
            }
        }
    }

    public class JunpeiIori : PlayableShadow
    {
        private readonly static Dictionary<string, string> workingDictionary = new()
        {
            //Autocombo
            {"5AA", "NmlAtk5A2nd\tc"},
            {"5AAA", "NmlAtk5A3rd\tc"},
            {"5AAAA", "AirSpinHomerunA\t|SpinHomerunA\t|AirSpinHomerunAClean\t|SpinHomerunAClean\t+StylishSpin"},
            {"5AAAAA", "UltimateGrandSlamA\ta\t+StylishHomerun"},
            {"5AAAAAA", "UltimateGrandSlamA\t+UltimateGrandSlamABUpper"},

            //5B (Clean)
            {"5B(Clean)", "NmlAtk5BClean"},

            //2B (Clean)
            {"2B(Clean)", "NmlAtk2BClean"},

            //5C
            {"5C", "Dmy_NmlAtk5C_Shot"},

            //j.B (Clean)
            {"j.B(Clean)", "NmlAtkAir5BClean"},

            //Super Flamingo Swing
            {"DP", "ReversalAction\ta\tn2miss\t+ReversalActionKamae"},
            {"BD", "ReversalAction\ta\tn2miss\t+ReversalActionKamae"},

            //Super Flamingo Swing (Hit)
            {"DP(Hit)", "ReversalAction"},
            {"BD(Hit)", "ReversalAction"},

            //Super Flamingo Swing (Clean)
            {"DP(Clean)", "ReversalActionClean"},
            {"BD(Clean)", "ReversalActionClean"},

            //Super Spin Swing
            {"236A", "SpinHomerunA"},
            {"236B", "SpinHomerunB"},
            {"236AB", "SpinHomerunAB"},

            //Super Spin Swing (Clean)
            {"236A(Clean)", "SpinHomerunAClean"},
            {"236B(Clean)", "SpinHomerunBClean"},
            {"236AB(Clean)", "SpinHomerunABClean"},

            //Super Spin Swing (Air)
            {"j.236A", "AirSpinHomerunA"},
            {"j.236B", "AirSpinHomerunB"},
            {"j.236AB", "AirSpinHomerunAB"},

            //Super Spin Swing (Air/Clean)
            {"j.236A(Clean)", "AirSpinHomerunAClean"},
            {"j.236B(Clean)", "AirSpinHomerunBClean"},
            {"j.236AB(Clean)", "AirSpinHomerunABClean"},

            //Full Speed Slide
            {"236C", "HeadSlidingLandC"},
            {"236D", "HeadSlidingLandD"},
            {"236CD", "HeadSlidingLandCD"},
            {"236CD(Hold)", "HeadSlidingLandCDHold"},

            //Full Speed Slide (Air)
            {"j.236C", "HeadSlidingAirC"},
            {"j.236D", "HeadSlidingAirD"},
            {"j.236CD", "HeadSlidingAirCD"},

            //Super Bunt
            {"214A", "PushBuntA"},
            {"214B", "PushBuntB"},
            {"214[B]", "PushBuntB"},
            {"214AB", "PushBuntAB"},

            //Super Bunt (Clean)
            {"214A(Clean)", "PushBuntAClean"},
            {"214B(Clean)", "PushBuntBClean"},
            {"214[B](Clean)", "PushBuntB"},
            {"214AB(Clean)", "PushBuntABClean"},

            //Deathbound
            {"214C", "PersonaDeathBoundC"},
            {"214D", "PersonaDeathBoundD"},
            {"214CD", "PersonaDeathBoundCD"},

            //Deathbound (Air)
            {"j.214C", "PersonaDeathBoundAirC"},
            {"j.214D", "PersonaDeathBoundAirD"},
            {"j.214CD", "PersonaDeathBoundAirCD"},

            //Inferno Homer ~ Additional (A or C)
            {"236236A~A", "UltimateGrandSlamA\ta\r\nUltimateGrandSlamA\t+UltimateGrandSlamABUpper"},
            {"236236B~A", "UltimateGrandSlamB\ta\r\nUltimateGrandSlamA\t+UltimateGrandSlamABUpper\th#"},
            {"236236AB~A", "UltimateGrandSlamAB\ta\r\nUltimateGrandSlamA\t+UltimateGrandSlamABUpper\th#"},

            {"236236A~C", "UltimateGrandSlamA\ta\r\nUltimateGrandSlamA\t+UltimateGrandSlamABUpper"},
            {"236236B~C", "UltimateGrandSlamB\ta\r\nUltimateGrandSlamA\t+UltimateGrandSlamABUpper\th#"},
            {"236236AB~C", "UltimateGrandSlamAB\ta\r\nUltimateGrandSlamA\t+UltimateGrandSlamABUpper\th#"},

            //Inferno Homer ~ Additional (B or D)
            {"236236A~B", "UltimateGrandSlamA\ta\r\nUltimateGrandSlamA\t+UltimateGrandSlamABYoko"},
            {"236236B~B", "UltimateGrandSlamB\ta\r\nUltimateGrandSlamA\t+UltimateGrandSlamABYoko\th#"},
            {"236236AB~B", "UltimateGrandSlamAB\ta\r\nUltimateGrandSlamA\t+UltimateGrandSlamABYoko\th#"},

            {"236236A~D", "UltimateGrandSlamA\ta\r\nUltimateGrandSlamA\t+UltimateGrandSlamABYoko"},
            {"236236B~D", "UltimateGrandSlamB\ta\r\nUltimateGrandSlamA\t+UltimateGrandSlamABYoko\th#"},
            {"236236AB~D", "UltimateGrandSlamAB\ta\r\nUltimateGrandSlamA\t+UltimateGrandSlamABYoko\th#"},

            //Comback Grand Slam ~ Additional (A or C)
            {"236236C~A", "UltimateGrandSlamC\ta\r\nUltimateGrandSlamCDUpper"},
            {"236236D~A", "UltimateGrandSlamD\ta\r\nUltimateGrandSlamCDUpper"},
            {"236236CD~A", "UltimateGrandSlamCD\ta\r\nUltimateGrandSlamCDUpper"},

            {"236236C~C", "UltimateGrandSlamC\ta\r\nUltimateGrandSlamCDUpper"},
            {"236236D~C", "UltimateGrandSlamD\ta\r\nUltimateGrandSlamCDUpper"},
            {"236236CD~C", "UltimateGrandSlamCD\ta\r\nUltimateGrandSlamCDUpper"},

            //Comeback Grand Slam ~ Additional (B or D)
            {"236236C~B", "UltimateGrandSlamA\ta\r\nUltimateGrandSlamCDYoko"},
            {"236236D~B", "UltimateGrandSlamB\ta\r\nUltimateGrandSlamCDYoko"},
            {"236236CD~B", "UltimateGrandSlamAB\ta\r\nUltimateGrandSlamCDYoko"},

            {"236236C~D", "UltimateGrandSlamA\ta\r\nUltimateGrandSlamCDYoko"},
            {"236236D~D", "UltimateGrandSlamB\ta\r\nUltimateGrandSlamCDYoko"},
            {"236236CD~D", "UltimateGrandSlamAB\ta\r\nUltimateGrandSlamCDYoko"},

            //Super Vorpal Bat ~ Additional (A, B, C, D)
            {"214214C~A", "PersonaUltimateSwingShotC\r\nUltimateSwingShotC\t+UltimateSwingShot"},
            {"214214D~A", "PersonaUltimateSwingShotD\r\nUltimateSwingShotD\t+UltimateSwingShot"},
            {"214214CD~A", "PersonaUltimateSwingShotCD\r\nUltimateSwingShotCD\t+UltimateSwingShot"},

            {"214214C~B", "PersonaUltimateSwingShotC\r\nUltimateSwingShotC\t+UltimateSwingShot"},
            {"214214D~B", "PersonaUltimateSwingShotD\r\nUltimateSwingShotD\t+UltimateSwingShot"},
            {"214214CD~B", "PersonaUltimateSwingShotCD\r\nUltimateSwingShotCD\t+UltimateSwingShot"},

            {"214214C~C", "PersonaUltimateSwingShotC\r\nUltimateSwingShotC\t+UltimateSwingShot"},
            {"214214D~C", "PersonaUltimateSwingShotD\r\nUltimateSwingShotD\t+UltimateSwingShot"},
            {"214214CD~C", "PersonaUltimateSwingShotCD\r\nUltimateSwingShotCD\t+UltimateSwingShot"},

            {"214214C~D", "PersonaUltimateSwingShotC\r\nUltimateSwingShotC\t+UltimateSwingShot"},
            {"214214D~D", "PersonaUltimateSwingShotD\r\nUltimateSwingShotD\t+UltimateSwingShot"},
            {"214214CD~D", "PersonaUltimateSwingShotCD\r\nUltimateSwingShotCD\t+UltimateSwingShot"},

            //Victory Cry
            {"Activate Victory Cry", "KachiOta\ta"},
            {"Activate V.C.", "KachiOta\ta"},

            //IK
            {"IK", "Dmy_Ichigeki"},
            {"222CD", "Dmy_Ichigeki"},
        };
        private readonly static Dictionary<string, string> workingDictionary_S = new();
        private static bool dictionariesBuilt = false;
        private readonly static List<string> invalidActions = new() { "IK", "222CD", "5C", "DP", "BD", "5DD", "j.BB", "j.AB", "j.2B", "j.2C" };
        public static Dictionary<string, string> Dictionary
        {
            get { return workingDictionary; }
        }
        public static Dictionary<string, string> Dictionary_S
        {
            get { return workingDictionary_S; }
        }

        public JunpeiIori()
        {
            if (!dictionariesBuilt)
            {
                foreach (KeyValuePair<string, string> pair in workingDictionary.ToList())
                {
                    workingDictionary_S.Add(pair.Key, pair.Value);
                }

                //Auto Combo - Added in Dictionary :p

                foreach (KeyValuePair<string, string> pair in COMMON_ACTIONS.ToList())
                {
                    if (invalidActions.Any(action => pair.Key.Contains(action)))
                    {
                        continue;
                    }

                    if (!workingDictionary.ContainsKey(pair.Key))
                    {
                        workingDictionary.Add(pair.Key, pair.Value);
                    }
                    if (!workingDictionary_S.ContainsKey(pair.Key))
                    {
                        if (invalidActions_S.Any(action => pair.Key.Contains(action)))
                        {
                            continue;
                        }
                        workingDictionary_S.Add(pair.Key, pair.Value);
                    }
                }

                foreach (KeyValuePair<string, string> pair in SHADOW_ACTIONS)
                {
                    if(pair.Key.Equals("5AA") || pair.Key.Equals("5AAA"))
                    {
                        continue;
                    }
                    workingDictionary_S.Add(pair.Key, pair.Value);
                }

                dictionariesBuilt = true;
            }
        }
    }

    public class Minazuki : Character
    {
        private readonly static Dictionary<string, string> workingDictionary = new()
        {
            //Autocombo
            {"5AA", "NmlAtk5A2nd\tc"},
            {"5AAA", "NmlAtk5A3rd\tc"},
            {"5AAAA", "AssaultA_1st\t+Stylish1st"},
            {"5AAAAA", "AssaultA_2nd\t+Stylish2nd"},
            {"5AAAAAA", "nbef_430ShougekihaD\t+StylishShougekiha"},

            //j.[D]
            {"j.[D]", "PersonaAir5D\tc"},

            //Izayoi
            {"DP~DP", "ReversalAction\r\nReversalActionAir"},
            {"DP~BD", "ReversalAction\r\nReversalActionAir"},
            {"BD~BD", "ReversalAction\r\nReversalActionAir"},
            {"BD~DP", "ReversalAction\r\nReversalActionAir"},

            //Ura Izayoi (Air)
            {"j.DP", "ReversalActionAir"},
            {"j.BD", "ReversalActionAir"},

            //Hougetsuzan: Flash Fang
			{"214A", "AssaultA_1st"},
            {"214B", "AssaultB_1st"},
            {"214AB", "AssaultAB_1st"},

            //Hougetsuzan: Flash Fang (A) ~ Soaring Fang (A) ~ Destructive Fang (A)
            {"214A~(4A)~4A", "AssaultA_1st\r\nAssaultA_2nd\r\nAssaultA_3rd"},

            //Hougetsuzan: Flash Fang (A) ~ Soaring Fang (A) ~ Destructive Fang (B)
            {"214A~(4A)~4B", "AssaultA_1st\r\nAssaultA_2nd\r\nAssaultB_3rd"},

            //Hougetsuzan: Flash Fang (A) ~ Soaring Fang (A) ~ Destructive Fang (AB)
            {"214A~(4A)~4AB", "AssaultA_1st\r\nAssaultA_2nd\r\nAssaultAB_3rd"},

            //Hougetsuzan: Flash Fang (A) ~ Soaring Fang (B) ~ Destructive Fang (A)
            {"214A~(4B)~4A", "AssaultA_1st\r\nAssaultB_2nd\r\nAssaultA_3rd"},

            //Hougetsuzan: Flash Fang (A) ~ Soaring Fang (B) ~ Destructive Fang (B)
            {"214A~(4B)~4B", "AssaultA_1st\r\nAssaultB_2nd\r\nAssaultB_3rd"},

            //Hougetsuzan: Flash Fang (A) ~ Soaring Fang (B) ~ Destructive Fang (AB)
            {"214A~(4B)~4AB", "AssaultA_1st\r\nAssaultB_2nd\r\nAssaultAB_3rd"},

            //Hougetsuzan: Flash Fang (A) ~ Soaring Fang (AB) ~ Destructive Fang (A)
            {"214A~(4AB)~4A", "AssaultA_1st\r\nAssaultAB_2nd\r\nAssaultA_3rd"},

            //Hougetsuzan: Flash Fang (A) ~ Soaring Fang (AB) ~ Destructive Fang (B)
            {"214A~(4AB)~4B", "AssaultA_1st\r\nAssaultAB_2nd\r\nAssaultB_3rd"},

            //Hougetsuzan: Flash Fang (A) ~ Soaring Fang (AB) ~ Destructive Fang (AB)
            {"214A~(4AB)~4AB", "AssaultA_1st\r\nAssaultAB_2nd\r\nAssaultAB_3rd"},

            //Hougetsuzan: Flash Fang (B) ~ Soaring Fang (A) ~ Destructive Fang (A)
            {"214B~(4A)~4A", "AssaultB_1st\r\nAssaultA_2nd\r\nAssaultA_3rd"},

            //Hougetsuzan: Flash Fang (B) ~ Soaring Fang (A) ~ Destructive Fang (B)
            {"214B~(4A)~4B", "AssaultB_1st\r\nAssaultA_2nd\r\nAssaultB_3rd"},

            //Hougetsuzan: Flash Fang (B) ~ Soaring Fang (A) ~ Destructive Fang (AB)
            {"214B~(4A)~4AB", "AssaultB_1st\r\nAssaultA_2nd\r\nAssaultAB_3rd"},

            //Hougetsuzan: Flash Fang (B) ~ Soaring Fang (B) ~ Destructive Fang (A)
            {"214B~(4B)~4A", "AssaultB_1st\r\nAssaultB_2nd\r\nAssaultA_3rd"},

            //Hougetsuzan: Flash Fang (B) ~ Soaring Fang (B) ~ Destructive Fang (B)
            {"214B~(4B)~4B", "AssaultB_1st\r\nAssaultB_2nd\r\nAssaultB_3rd"},

            //Hougetsuzan: Flash Fang (B) ~ Soaring Fang (B) ~ Destructive Fang (AB)
            {"214B~(4B)~4AB", "AssaultB_1st\r\nAssaultB_2nd\r\nAssaultAB_3rd"},

            //Hougetsuzan: Flash Fang (B) ~ Soaring Fang (AB) ~ Destructive Fang (A)
            {"214B~(4AB)~4A", "AssaultB_1st\r\nAssaultAB_2nd\r\nAssaultA_3rd"},

            //Hougetsuzan: Flash Fang (B) ~ Soaring Fang (AB) ~ Destructive Fang (B)
            {"214B~(4AB)~4B", "AssaultB_1st\r\nAssaultAB_2nd\r\nAssaultB_3rd"},

            //Hougetsuzan: Flash Fang (B) ~ Soaring Fang (AB) ~ Destructive Fang (AB)
            {"214B~(4AB)~4AB", "AssaultB_1st\r\nAssaultAB_2nd\r\nAssaultAB_3rd"},

            //Hougetsuzan: Flash Fang (AB) ~ Soaring Fang (A) ~ Destructive Fang (A)
            {"214AB~(4A)~4A", "AssaultAB_1st\r\nAssaultA_2nd\r\nAssaultA_3rd"},

            //Hougetsuzan: Flash Fang (AB) ~ Soaring Fang (A) ~ Destructive Fang (B)
            {"214AB~(4A)~4B", "AssaultAB_1st\r\nAssaultA_2nd\r\nAssaultB_3rd"},

            //Hougetsuzan: Flash Fang (AB) ~ Soaring Fang (A) ~ Destructive Fang (AB)
            {"214AB~(4A)~4AB", "AssaultAB_1st\r\nAssaultA_2nd\r\nAssaultAB_3rd"},

            //Hougetsuzan: Flash Fang (AB) ~ Soaring Fang (B) ~ Destructive Fang (A)
            {"214AB~(4B)~4A", "AssaultAB_1st\r\nAssaultB_2nd\r\nAssaultA_3rd"},

            //Hougetsuzan: Flash Fang (AB) ~ Soaring Fang (B) ~ Destructive Fang (B)
            {"214AB~(4B)~4B", "AssaultAB_1st\r\nAssaultB_2nd\r\nAssaultB_3rd"},

            //Hougetsuzan: Flash Fang (AB) ~ Soaring Fang (B) ~ Destructive Fang (AB)
            {"214AB~(4B)~4AB", "AssaultAB_1st\r\nAssaultB_2nd\r\nAssaultAB_3rd"},

            //Hougetsuzan: Flash Fang (AB) ~ Soaring Fang (AB) ~ Destructive Fang (A)
            {"214AB~(4AB)~4A", "AssaultAB_1st\r\nAssaultAB_2nd\r\nAssaultA_3rd"},

            //Hougetsuzan: Flash Fang (AB) ~ Soaring Fang (AB) ~ Destructive Fang (B)
            {"214AB~(4AB)~4B", "AssaultAB_1st\r\nAssaultAB_2nd\r\nAssaultB_3rd"},

            //Hougetsuzan: Flash Fang (AB) ~ Soaring Fang (AB) ~ Destructive Fang (AB)
            {"214AB~(4AB)~4AB", "AssaultAB_1st\r\nAssaultAB_2nd\r\nAssaultAB_3rd"},

            //Survival Knife
            {"236A", "eff_Shot"},
            {"236B", "eff_Shot"},
            {"236AB", "eff_ShotSB\t|effShot"},

            //Tsukiyomi
            {"236C", "PersonaWarpC"},
            {"236D", "PersonaWarpD"},
            {"236CD", "PersonaWarpCD\ta"},

            //Tsukiyomi (Air)
            {"j.236C", "PersonaWarpC"},
            {"j.236D", "PersonaWarpD"},
            {"j.236CD", "PersonaWarpCD\ta"},

            //Spirit/Life Drain
            {"214C", "PersonaThrowC"},
            {"214D", "PersonaThrowD"},
            {"214CD", "PersonaThrowCD"},

            //Wings of Purgatory
            {"236236C", "nbef_430ShougekihaC"},
            {"236236D", "nbef_430ShougekihaD"},
            {"236236CD", "nbef_430ShougekihaCD"},

            //Wings of Purgatory (Air)
            {"j.236236C", "nbef_430ShougekihaC"},
            {"j.236236D", "nbef_430ShougekihaD"},
            {"j.236236CD", "nbef_430ShougekihaCD"},

            //Moon Smasher
            {"214214A", "UltimateTaikuuA"},
            {"214214B", "UltimateTaikuuB"},
            {"214214AB", "UltimateTaikuuAB"},

            //Dream Fog
            {"214214C", "AtemiBlackC_Atk\t|AtemiBlackD_Atk\t+PersonaAtemiBlack\ta"},
            {"214214D", "AtemiBlackC_Atk\t|AtemiBlackD_Atk\t+PersonaAtemiBlack"},
            {"214214CD", "AtemiBlackC_Atk\t|AtemiBlackD_Atk\t+PersonaAtemiBlack\ta"},
        };
        private static bool dictionariesBuilt = false;
        private readonly static List<string> invalidActions = new() { "DP", "BD", "5DD", "j.BB", "j.AB", "j.2A", "j.2B" };
        public static Dictionary<string, string> Dictionary
        {
            get { return workingDictionary; }
        }

        public Minazuki()
        {
            if (!dictionariesBuilt)
            {
                foreach (KeyValuePair<string, string> pair in COMMON_ACTIONS.ToList())
                {
                    if (invalidActions.Any(action => pair.Key.Contains(action)))
                    {
                        continue;
                    }

                    if (!workingDictionary.ContainsKey(pair.Key))
                    {
                        workingDictionary.Add(pair.Key, pair.Value);
                    }
                }

                dictionariesBuilt = true;
            }
        }
    }

    public class Sho : Character
    {
        private readonly static Dictionary<string, string> workingDictionary = new()
        {
            //Autocombo
            {"5AA", "NmlAtk5A2nd\tc"},
            {"5AAA", "NmlAtk5A3rd\tc"},
            {"5AAAA", "AssaultA_1st\t+Stylish1st"},
            {"5AAAAA", "UltimateAssaultA\t+StylishUltimate"},

            //Izayoi
            {"DP~DP", "ReversalAction\r\nReversalActionAir"},
            {"DP~BD", "ReversalAction\r\nReversalActionAir"},
            {"BD~BD", "ReversalAction\r\nReversalActionAir"},
            {"BD~DP", "ReversalAction\r\nReversalActionAir"},

            //Ura Izayoi (Air)
            {"j.DP", "ReversalActionAir"},
            {"j.BD", "ReversalActionAir"},

            //Hougetsuzan: Flash Fang
			{"236A", "AssaultA_1st"},
            {"236B", "AssaultB_1st"},
            {"236AB", "AssaultAB_1st"},
			
			//Hougetsuzan: Soaring Fang
			{"214A", "AssaultA_2nd"},
            {"214B", "AssaultB_2nd"},
            {"214AB", "AssaultAB_2nd"},
			
			//Hougetsuzan: Destructive Fang
			{"j.236A", "AssaultA_3rd"},
            {"j.236B", "AssaultB_3rd"},
            {"j.236AB", "AssaultAB_3rd"},
			
			//High-Speed Movement
			{"236C", "KousokuDashC\t|KousokuDashAirC\ta"},
            {"236D", "KousokuDashD\t|KousokuDashAirD\ta"},
            {"236CD", "KousokuDashCD\t|KousokuDashAirCD\ta"},
			
            //High-Speed Movement (Air)
			{"j.236C", "KousokuDashAirC\t|KousokuDashC\ta"},
            {"j.236D", "KousokuDashAirD\t|KousokuDashD\ta"},
            {"j.236CD", "KousokuDashAirCD\t|KousokuDashCD\ta"},

            //Hougetsuzan: Flash Fang (A) ~ Soaring Fang (A) 
            {"236A~A", "AssaultA_1st\r\nAssaultA_2nd\t+AssaultA_2ndHasei"},

            //Hougetsuzan: Flash Fang (A) ~ Soaring Fang (B) 
            {"236A~B", "AssaultA_1st\r\nAssaultB_2nd\t+AssaultB_2ndHasei"},

            //Hougetsuzan: Flash Fang (A) ~ Soaring Fang (AB) 
            {"236A~AB", "AssaultA_1st\r\nAssaultAB_2nd\t+AssaultAB_2ndHasei"},

            //Hougetsuzan: Flash Fang (B) ~ Soaring Fang (A) 
            {"236B~A", "AssaultB_1st\r\nAssaultA_2nd\t+AssaultA_2ndHasei"},

            //Hougetsuzan: Flash Fang (B) ~ Soaring Fang (B) 
            {"236B~B", "AssaultB_1st\r\nAssaultB_2nd\t+AssaultB_2ndHasei"},

            //Hougetsuzan: Flash Fang (B) ~ Soaring Fang (AB) 
            {"236B~AB", "AssaultB_1st\r\nAssaultAB_2nd\t+AssaultAB_2ndHasei"},

            //Hougetsuzan: Flash Fang (AB) ~ Soaring Fang (A) 
            {"236AB~A", "AssaultAB_1st\r\nAssaultA_2nd\t+AssaultA_2ndHasei"},

            //Hougetsuzan: Flash Fang (AB) ~ Soaring Fang (B) 
            {"236AB~B", "AssaultAB_1st\r\nAssaultB_2nd\t+AssaultB_2ndHasei"},

            //Hougetsuzan: Flash Fang (AB) ~ Soaring Fang (AB) 
            {"236AB~AB", "AssaultAB_1st\r\nAssaultAB_2nd\t+AssaultAB_2ndHasei"},

			//Hougetsuzan: Flash Fang (A) ~ Soaring Fang (A) ~ Destructive Fang (A)
            {"236A~(A)~A", "AssaultA_1st\r\nAssaultA_2nd\t+AssaultA_2ndHasei\r\nAssaultA_3rd\t+AssaultA_3rdHasei"},

            //Hougetsuzan: Flash Fang (A) ~ Soaring Fang (A) ~ Destructive Fang (B)
            {"236A~(A)~B", "AssaultA_1st\r\nAssaultA_2nd\t+AssaultA_2ndHasei\r\nAssaultB_3rd\t+AssaultB_3rdHasei"},

            //Hougetsuzan: Flash Fang (A) ~ Soaring Fang (A) ~ Destructive Fang (AB)
            {"236A~(A)~AB", "AssaultA_1st\r\nAssaultA_2nd\t+AssaultA_2ndHasei\r\nAssaultAB_3rd\t+AssaultAB_3rdHasei"},

            //Hougetsuzan: Flash Fang (A) ~ Soaring Fang (B) ~ Destructive Fang (A)
            {"236A~(B)~A", "AssaultA_1st\r\nAssaultB_2nd\t+AssaultB_2ndHasei\r\nAssaultA_3rd\t+AssaultA_3rdHasei"},

            //Hougetsuzan: Flash Fang (A) ~ Soaring Fang (B) ~ Destructive Fang (B)
            {"236A~(B)~B", "AssaultA_1st\r\nAssaultB_2nd\t+AssaultB_2ndHasei\r\nAssaultB_3rd\t+AssaultB_3rdHasei"},

            //Hougetsuzan: Flash Fang (A) ~ Soaring Fang (B) ~ Destructive Fang (AB)
            {"236A~(B)~AB", "AssaultA_1st\r\nAssaultB_2nd\t+AssaultB_2ndHasei\r\nAssaultAB_3rd\t+AssaultAB_3rdHasei"},

            //Hougetsuzan: Flash Fang (A) ~ Soaring Fang (AB) ~ Destructive Fang (A)
            {"236A~(AB)~A", "AssaultA_1st\r\nAssaultAB_2nd\t+AssaultAB_2ndHasei\r\nAssaultA_3rd\t+AssaultA_3rdHasei"},

            //Hougetsuzan: Flash Fang (A) ~ Soaring Fang (AB) ~ Destructive Fang (B)
            {"236A~(AB)~B", "AssaultA_1st\r\nAssaultAB_2nd\t+AssaultAB_2ndHasei\r\nAssaultB_3rd\t+AssaultB_3rdHasei"},

            //Hougetsuzan: Flash Fang (A) ~ Soaring Fang (AB) ~ Destructive Fang (AB)
            {"236A~(AB)~AB", "AssaultA_1st\r\nAssaultAB_2nd\t+AssaultAB_2ndHasei\r\nAssaultAB_3rd\t+AssaultAB_3rdHasei"},

            //Hougetsuzan: Flash Fang (B) ~ Soaring Fang (A) ~ Destructive Fang (A)
            {"236B~(A)~A", "AssaultB_1st\r\nAssaultA_2nd\t+AssaultA_2ndHasei\r\nAssaultA_3rd\t+AssaultA_3rdHasei"},

            //Hougetsuzan: Flash Fang (B) ~ Soaring Fang (A) ~ Destructive Fang (B)
            {"236B~(A)~B", "AssaultB_1st\r\nAssaultA_2nd\t+AssaultA_2ndHasei\r\nAssaultB_3rd\t+AssaultB_3rdHasei"},

            //Hougetsuzan: Flash Fang (B) ~ Soaring Fang (A) ~ Destructive Fang (AB)
            {"236B~(A)~AB", "AssaultB_1st\r\nAssaultA_2nd\t+AssaultA_2ndHasei\r\nAssaultAB_3rd\t+AssaultAB_3rdHasei"},

            //Hougetsuzan: Flash Fang (B) ~ Soaring Fang (B) ~ Destructive Fang (A)
            {"236B~(B)~A", "AssaultB_1st\r\nAssaultB_2nd\t+AssaultB_2ndHasei\r\nAssaultA_3rd\t+AssaultA_3rdHasei"},

            //Hougetsuzan: Flash Fang (B) ~ Soaring Fang (B) ~ Destructive Fang (B)
            {"236B~(B)~B", "AssaultB_1st\r\nAssaultB_2nd\t+AssaultB_2ndHasei\r\nAssaultB_3rd\t+AssaultB_3rdHasei"},

            //Hougetsuzan: Flash Fang (B) ~ Soaring Fang (B) ~ Destructive Fang (AB)
            {"236B~(B)~AB", "AssaultB_1st\r\nAssaultB_2nd\t+AssaultB_2ndHasei\r\nAssaultAB_3rd\t+AssaultAB_3rdHasei"},

            //Hougetsuzan: Flash Fang (B) ~ Soaring Fang (AB) ~ Destructive Fang (A)
            {"236B~(AB)~A", "AssaultB_1st\r\nAssaultAB_2nd\t+AssaultAB_2ndHasei\r\nAssaultA_3rd\t+AssaultA_3rdHasei"},

            //Hougetsuzan: Flash Fang (B) ~ Soaring Fang (AB) ~ Destructive Fang (B)
            {"236B~(AB)~B", "AssaultB_1st\r\nAssaultAB_2nd\t+AssaultAB_2ndHasei\r\nAssaultB_3rd\t+AssaultB_3rdHasei"},

            //Hougetsuzan: Flash Fang (B) ~ Soaring Fang (AB) ~ Destructive Fang (AB)
            {"236B~(AB)~AB", "AssaultB_1st\r\nAssaultAB_2nd\t+AssaultAB_2ndHasei\r\nAssaultAB_3rd\t+AssaultAB_3rdHasei"},

            //Hougetsuzan: Flash Fang (AB) ~ Soaring Fang (A) ~ Destructive Fang (A)
            {"236AB~(A)~A", "AssaultAB_1st\r\nAssaultA_2nd\t+AssaultA_2ndHasei\r\nAssaultA_3rd\t+AssaultA_3rdHasei"},

            //Hougetsuzan: Flash Fang (AB) ~ Soaring Fang (A) ~ Destructive Fang (B)
            {"236AB~(A)~B", "AssaultAB_1st\r\nAssaultA_2nd\t+AssaultA_2ndHasei\r\nAssaultB_3rd\t+AssaultB_3rdHasei"},

            //Hougetsuzan: Flash Fang (AB) ~ Soaring Fang (A) ~ Destructive Fang (AB)
            {"236AB~(A)~AB", "AssaultAB_1st\r\nAssaultA_2nd\t+AssaultA_2ndHasei\r\nAssaultAB_3rd\t+AssaultAB_3rdHasei"},

            //Hougetsuzan: Flash Fang (AB) ~ Soaring Fang (B) ~ Destructive Fang (A)
            {"236AB~(B)~A", "AssaultAB_1st\r\nAssaultB_2nd\t+AssaultB_2ndHasei\r\nAssaultA_3rd\t+AssaultA_3rdHasei"},

            //Hougetsuzan: Flash Fang (AB) ~ Soaring Fang (B) ~ Destructive Fang (B)
            {"236AB~(B)~B", "AssaultAB_1st\r\nAssaultB_2nd\t+AssaultB_2ndHasei\r\nAssaultB_3rd\t+AssaultB_3rdHasei"},

            //Hougetsuzan: Flash Fang (AB) ~ Soaring Fang (B) ~ Destructive Fang (AB)
            {"236AB~(B)~AB", "AssaultAB_1st\r\nAssaultB_2nd\t+AssaultB_2ndHasei\r\nAssaultAB_3rd\t+AssaultAB_3rdHasei"},

            //Hougetsuzan: Flash Fang (AB) ~ Soaring Fang (AB) ~ Destructive Fang (A)
            {"236AB~(AB)~A", "AssaultAB_1st\r\nAssaultAB_2nd\t+AssaultAB_2ndHasei\r\nAssaultA_3rd\t+AssaultA_3rdHasei"},

            //Hougetsuzan: Flash Fang (AB) ~ Soaring Fang (AB) ~ Destructive Fang (B)
            {"236AB~(AB)~B", "AssaultAB_1st\r\nAssaultAB_2nd\t+AssaultAB_2ndHasei\r\nAssaultB_3rd\t+AssaultB_3rdHasei"},

            //Hougetsuzan: Flash Fang (AB) ~ Soaring Fang (AB) ~ Destructive Fang (AB)
            {"236AB~(AB)~AB", "AssaultAB_1st\r\nAssaultAB_2nd\t+AssaultAB_2ndHasei\r\nAssaultAB_3rd\t+AssaultAB_3rdHasei"},

            //Hougetsuzan: Flash Fang (A) ~ High-Speed Movement (C)
			{"236A~C", "AssaultA_1st\r\nKousokuDashC\t|KousokuDashAirC\ta\tn2miss\t+KousokuDashCHasei"},
			
			//Hougetsuzan: Flash Fang (A) ~ High-Speed Movement (D)
			{"236A~D", "AssaultA_1st\r\nKousokuDashD\t|KousokuDashAirD\ta\tn2miss\t+KousokuDashDHasei"},
			
			//Hougetsuzan: Flash Fang (A) ~ High-Speed Movement (CD)
			{"236A~CD", "AssaultA_1st\r\nKousokuDashCD\t|KousokuDashAirCD\ta\tn2miss\t+KousokuDashCDHasei"},
			
			//Hougetsuzan: Flash Fang (B) ~ High-Speed Movement (C)
			{"236B~C", "AssaultA_1st\r\nKousokuDashC\t|KousokuDashAirC\ta\tn2miss\t+KousokuDashCHasei"},
			
			//Hougetsuzan: Flash Fang (B) ~ High-Speed Movement (D)
			{"236B~D", "AssaultA_1st\r\nKousokuDashD\t|KousokuDashAirD\ta\tn2miss\t+KousokuDashDHasei"},
			
			//Hougetsuzan: Flash Fang (B) ~ High-Speed Movement (CD)
			{"236B~CD", "AssaultA_1st\r\nKousokuDashCD\t|KousokuDashAirCD\ta\tn2miss\t+KousokuDashCDHasei"},
			
			//Hougetsuzan: Flash Fang (AB) ~ High-Speed Movement (C)
			{"236AB~C", "AssaultA_1st\r\nKousokuDashC\t|KousokuDashAirC\ta\tn2miss\t+KousokuDashCHasei"},
			
			//Hougetsuzan: Flash Fang (AB) ~ High-Speed Movement (D)
			{"236AB~D", "AssaultA_1st\r\nKousokuDashD\t|KousokuDashAirD\ta\tn2miss\t+KousokuDashDHasei"},
			
			//Hougetsuzan: Flash Fang (AB) ~ High-Speed Movement (CD)
			{"236AB~CD", "AssaultA_1st\r\nKousokuDashCD\t|KousokuDashAirCD\ta\tn2miss\t+KousokuDashCDHasei"},
						
			//Hougetsuzan: Flash Fang (A) ~ Soaring Fang (A) ~ High-Speed Movement (C)
			{"236A~(A)~C", "AssaultA_1st\r\nAssaultA_2nd\t+AssaultA_2ndHasei\r\nKousokuDashC\t|KousokuDashAirC\ta\tn2miss\t+KousokuDashCHasei"},
			
			//Hougetsuzan: Flash Fang (A) ~ Soaring Fang (A) ~ High-Speed Movement (D)
			{"236A~(A)~D", "AssaultA_1st\r\nAssaultA_2nd\t+AssaultA_2ndHasei\r\nKousokuDashD\t|KousokuDashAirD\ta\tn2miss\t+KousokuDashDHasei"},
			
			//Hougetsuzan: Flash Fang (A) ~ Soaring Fang (A) ~ High-Speed Movement (CD)
			{"236A~(A)~CD", "AssaultA_1st\r\nAssaultA_2nd\t+AssaultA_2ndHasei\r\nKousokuDashCD\t|KousokuDashAirCD\ta\tn2miss\t+KousokuDashCDHasei"},
			
			//Hougetsuzan: Flash Fang (A) ~ Soaring Fang (B) ~ High-Speed Movement (C)
			{"236A~(B)~C", "AssaultA_1st\r\nAssaultB_2nd\t+AssaultB_2ndHasei\r\nKousokuDashC\t|KousokuDashAirC\ta\tn2miss\t+KousokuDashCHasei"},
			
			//Hougetsuzan: Flash Fang (A) ~ Soaring Fang (B) ~ High-Speed Movement (D)
			{"236A~(B)~D", "AssaultA_1st\r\nAssaultB_2nd\t+AssaultB_2ndHasei\r\nKousokuDashD\t|KousokuDashAirD\ta\tn2miss\t+KousokuDashDHasei"},
			
			//Hougetsuzan: Flash Fang (A) ~ Soaring Fang (B) ~ High-Speed Movement (CD)
			{"236A~(B)~CD", "AssaultA_1st\r\nAssaultB_2nd\t+AssaultB_2ndHasei\r\nKousokuDashCD\t|KousokuDashAirCD\ta\tn2miss\t+KousokuDashCDHasei"},
			
			//Hougetsuzan: Flash Fang (A) ~ Soaring Fang (AB) ~ High-Speed Movement (C)
			{"236A~(AB)~C", "AssaultA_1st\r\nAssaultAB_2nd\t+AssaultAB_2ndHasei\r\nKousokuDashC\t|KousokuDashAirC\ta\tn2miss\t+KousokuDashCHasei"},
			
			//Hougetsuzan: Flash Fang (A) ~ Soaring Fang (AB) ~ High-Speed Movement (D)
			{"236A~(AB)~D", "AssaultA_1st\r\nAssaultAB_2nd\t+AssaultAB_2ndHasei\r\nKousokuDashD\t|KousokuDashAirD\ta\tn2miss\t+KousokuDashDHasei"},
			
			//Hougetsuzan: Flash Fang (A) ~ Soaring Fang (AB) ~ High-Speed Movement (CD)
			{"236A~(AB)~CD", "AssaultA_1st\r\nAssaultAB_2nd\t+AssaultAB_2ndHasei\r\nKousokuDashCD\t|KousokuDashAirCD\ta\tn2miss\t+KousokuDashCDHasei"},
						
			//Hougetsuzan: Flash Fang (B) ~ Soaring Fang (A) ~ High-Speed Movement (C)
			{"236B~(A)~C", "AssaultB_1st\r\nAssaultA_2nd\t+AssaultA_2ndHasei\r\nKousokuDashC\t|KousokuDashAirC\ta\tn2miss\t+KousokuDashCHasei"},
			
			//Hougetsuzan: Flash Fang (B) ~ Soaring Fang (A) ~ High-Speed Movement (D)
			{"236B~(A)~D", "AssaultB_1st\r\nAssaultA_2nd\t+AssaultA_2ndHasei\r\nKousokuDashD\t|KousokuDashAirD\ta\tn2miss\t+KousokuDashDHasei"},
			
			//Hougetsuzan: Flash Fang (B) ~ Soaring Fang (A) ~ High-Speed Movement (CD)
			{"236B~(A)~CD", "AssaultB_1st\r\nAssaultA_2nd\t+AssaultA_2ndHasei\r\nKousokuDashCD\t|KousokuDashAirCD\ta\tn2miss\t+KousokuDashCDHasei"},
			
			//Hougetsuzan: Flash Fang (B) ~ Soaring Fang (B) ~ High-Speed Movement (C)
			{"236B~(B)~C", "AssaultB_1st\r\nAssaultB_2nd\t+AssaultB_2ndHasei\r\nKousokuDashC\t|KousokuDashAirC\ta\tn2miss\t+KousokuDashCHasei"},
			
			//Hougetsuzan: Flash Fang (B) ~ Soaring Fang (B) ~ High-Speed Movement (D)
			{"236B~(B)~D", "AssaultB_1st\r\nAssaultB_2nd\t+AssaultB_2ndHasei\r\nKousokuDashD\t|KousokuDashAirD\ta\tn2miss\t+KousokuDashDHasei"},
			
			//Hougetsuzan: Flash Fang (B) ~ Soaring Fang (B) ~ High-Speed Movement (CD)
			{"236B~(B)~CD", "AssaultB_1st\r\nAssaultB_2nd\t+AssaultB_2ndHasei\r\nKousokuDashCD\t|KousokuDashAirCD\ta\tn2miss\t+KousokuDashCDHasei"},
			
			//Hougetsuzan: Flash Fang (B) ~ Soaring Fang (AB) ~ High-Speed Movement (C)
			{"236B~(AB)~C", "AssaultB_1st\r\nAssaultAB_2nd\t+AssaultAB_2ndHasei\r\nKousokuDashC\t|KousokuDashAirC\ta\tn2miss\t+KousokuDashCHasei"},
			
			//Hougetsuzan: Flash Fang (B) ~ Soaring Fang (AB) ~ High-Speed Movement (D)
			{"236B~(AB)~D", "AssaultB_1st\r\nAssaultAB_2nd\t+AssaultAB_2ndHasei\r\nKousokuDashD\t|KousokuDashAirD\ta\tn2miss\t+KousokuDashDHasei"},
			
			//Hougetsuzan: Flash Fang (B) ~ Soaring Fang (AB) ~ High-Speed Movement (CD)
			{"236B~(AB)~CD", "AssaultB_1st\r\nAssaultAB_2nd\t+AssaultAB_2ndHasei\r\nKousokuDashCD\t|KousokuDashAirCD\ta\tn2miss\t+KousokuDashCDHasei"},
						
			//Hougetsuzan: Flash Fang (AB) ~ Soaring Fang (A) ~ High-Speed Movement (C)
			{"236AB~(A)~C", "AssaultAB_1st\r\nAssaultA_2nd\t+AssaultA_2ndHasei\r\nKousokuDashC\t|KousokuDashAirC\ta\tn2miss\t+KousokuDashCHasei"},
			
			//Hougetsuzan: Flash Fang (AB) ~ Soaring Fang (A) ~ High-Speed Movement (D)
			{"236AB~(A)~D", "AssaultAB_1st\r\nAssaultA_2nd\t+AssaultA_2ndHasei\r\nKousokuDashD\t|KousokuDashAirD\ta\tn2miss\t+KousokuDashDHasei"},
			
			//Hougetsuzan: Flash Fang (AB) ~ Soaring Fang (A) ~ High-Speed Movement (CD)
			{"236AB~(A)~CD", "AssaultAB_1st\r\nAssaultA_2nd\t+AssaultA_2ndHasei\r\nKousokuDashCD\t|KousokuDashAirCD\ta\tn2miss\t+KousokuDashCDHasei"},
			
			//Hougetsuzan: Flash Fang (AB) ~ Soaring Fang (B) ~ High-Speed Movement (C)
			{"236AB~(B)~C", "AssaultAB_1st\r\nAssaultB_2nd\t+AssaultB_2ndHasei\r\nKousokuDashC\t|KousokuDashAirC\ta\tn2miss\t+KousokuDashCHasei"},
			
			//Hougetsuzan: Flash Fang (AB) ~ Soaring Fang (B) ~ High-Speed Movement (D)
			{"236AB~(B)~D", "AssaultAB_1st\r\nAssaultB_2nd\t+AssaultB_2ndHasei\r\nKousokuDashD\t|KousokuDashAirD\ta\tn2miss\t+KousokuDashDHasei"},
			
			//Hougetsuzan: Flash Fang (AB) ~ Soaring Fang (B) ~ High-Speed Movement (CD)
			{"236AB~(B)~CD", "AssaultAB_1st\r\nAssaultB_2nd\t+AssaultB_2ndHasei\r\nKousokuDashCD\t|KousokuDashAirCD\ta\tn2miss\t+KousokuDashCDHasei"},
			
			//Hougetsuzan: Flash Fang (AB) ~ Soaring Fang (AB) ~ High-Speed Movement (C)
			{"236AB~(AB)~C", "AssaultAB_1st\r\nAssaultAB_2nd\t+AssaultAB_2ndHasei\r\nKousokuDashC\t|KousokuDashAirC\ta\tn2miss\t+KousokuDashCHasei"},
			
			//Hougetsuzan: Flash Fang (AB) ~ Soaring Fang (AB) ~ High-Speed Movement (D)
			{"236AB~(AB)~D", "AssaultAB_1st\r\nAssaultAB_2nd\t+AssaultAB_2ndHasei\r\nKousokuDashD\t|KousokuDashAirD\ta\tn2miss\t+KousokuDashDHasei"},
			
			//Hougetsuzan: Flash Fang (AB) ~ Soaring Fang (AB) ~ High-Speed Movement (CD)
			{"236AB~(AB)~CD", "AssaultAB_1st\r\nAssaultAB_2nd\t+AssaultAB_2ndHasei\r\nKousokuDashCD\t|KousokuDashAirCD\ta\tn2miss\t+KousokuDashCDHasei"},

            //Hougetsuzan: Soaring Fang (A) ~ Destructive Fang (A)
            {"214A~A", "AssaultA_2nd\t+AssaultA_2ndHasei\r\nAssaultA_3rd\t+AssaultA_3rdHasei"},

            //Hougetsuzan: Soaring Fang (A) ~ Destructive Fang (B)
            {"214A~B", "AssaultA_2nd\t+AssaultA_2ndHasei\r\nAssaultB_3rd\t+AssaultB_3rdHasei"},

            //Hougetsuzan: Soaring Fang (A) ~ Destructive Fang (AB)
            {"214A~AB", "AssaultA_2nd\t+AssaultA_2ndHasei\r\nAssaultAB_3rd\t+AssaultAB_3rdHasei"},

            //Hougetsuzan: Soaring Fang (B) ~ Destructive Fang (A)
            {"214B~A", "AssaultB_2nd\t+AssaultB_2ndHasei\r\nAssaultA_3rd\t+AssaultA_3rdHasei"},

            //Hougetsuzan: Soaring Fang (B) ~ Destructive Fang (B)
            {"214B~B", "AssaultB_2nd\t+AssaultB_2ndHasei\r\nAssaultB_3rd\t+AssaultB_3rdHasei"},

            //Hougetsuzan: Soaring Fang (B) ~ Destructive Fang (AB)
            {"214B~AB", "AssaultB_2nd\t+AssaultB_2ndHasei\r\nAssaultAB_3rd\t+AssaultAB_3rdHasei"},

            //Hougetsuzan: Soaring Fang (AB) ~ Destructive Fang (A)
            {"214AB~A", "AssaultAB_2nd\t+AssaultAB_2ndHasei\r\nAssaultA_3rd\t+AssaultA_3rdHasei"},

            //Hougetsuzan: Soaring Fang (AB) ~ Destructive Fang (B)
            {"214AB~B", "AssaultAB_2nd\t+AssaultAB_2ndHasei\r\nAssaultB_3rd\t+AssaultB_3rdHasei"},

            //Hougetsuzan: Soaring Fang (AB) ~ Destructive Fang (AB)
            {"214AB~AB", "AssaultAB_2nd\t+AssaultAB_2ndHasei\r\nAssaultAB_3rd\t+AssaultAB_3rdHasei"},

            //Hougetsuzan: Soaring Fang (A) ~ High-Speed Movement (C)
			{"214A~C", "AssaultA_2nd\t+AssaultA_2ndHasei\r\nKousokuDashC\t|KousokuDashAirC\ta\tn2miss\t+KousokuDashCHasei"},
			
			//Hougetsuzan: Soaring Fang (A) ~ High-Speed Movement (D)
			{"214A~D", "AssaultA_2nd\t+AssaultA_2ndHasei\r\nKousokuDashD\t|KousokuDashAirD\ta\tn2miss\t+KousokuDashDHasei"},
			
			//Hougetsuzan: Soaring Fang (A) ~ High-Speed Movement (CD)
			{"214A~CD", "AssaultA_2nd\t+AssaultA_2ndHasei\r\nKousokuDashCD\t|KousokuDashAirCD\ta\tn2miss\t+KousokuDashCDHasei"},
			
			//Hougetsuzan: Soaring Fang (B) ~ High-Speed Movement (C)
			{"214B~C", "AssaultB_2nd\t+AssaultB_2ndHasei\r\nKousokuDashC\t|KousokuDashAirC\ta\tn2miss\t+KousokuDashCHasei"},
			
			//Hougetsuzan: Soaring Fang (B) ~ High-Speed Movement (D)
			{"214B~D", "AssaultB_2nd\t+AssaultB_2ndHasei\r\nKousokuDashD\t|KousokuDashAirD\ta\tn2miss\t+KousokuDashDHasei"},
			
			//Hougetsuzan: Soaring Fang (B) ~ High-Speed Movement (CD)
			{"214B~CD", "AssaultB_2nd\t+AssaultB_2ndHasei\r\nKousokuDashCD\t|KousokuDashAirCD\ta\tn2miss\t+KousokuDashCDHasei"},
			
			//Hougetsuzan: Soaring Fang (AB) ~ High-Speed Movement (C)
			{"214AB~C", "AssaultAB_2nd\t+AssaultAB_2ndHasei\r\nKousokuDashC\t|KousokuDashAirC\ta\tn2miss\t+KousokuDashCHasei"},
			
			//Hougetsuzan: Soaring Fang (AB) ~ High-Speed Movement (D)
			{"214AB~D", "AssaultAB_2nd\t+AssaultAB_2ndHasei\r\nKousokuDashD\t|KousokuDashAirD\ta\tn2miss\t+KousokuDashDHasei"},
			
			//Hougetsuzan: Soaring Fang (AB) ~ High-Speed Movement (CD)
			{"214AB~CD", "AssaultAB_2nd\t+AssaultAB_2ndHasei\r\nKousokuDashCD\t|KousokuDashAirCD\ta\tn2miss\t+KousokuDashCDHasei"},

            //Survival Knife
            {"[4]6A", "eff_Shot"},
            {"[1]6A", "eff_Shot"},
            {"[4]6B", "eff_Shot"},
            {"[1]6B", "eff_Shot"},
            {"[4]6C", "eff_Shot"},
            {"[1]6C", "eff_Shot"},
            {"[4]6D", "eff_Shot"},
            {"[1]6D", "eff_Shot"},
            {"[4]6AB", "eff_ShotSB"},
            {"[1]6AB", "eff_ShotSB"},
            {"[4]6CD", "eff_ShotSB"},
            {"[1]6CD", "eff_ShotSB"},

            //Blazing Moon Barrage
            {"236236A", "UltimateAssaultA"},
            {"236236B", "UltimateAssaultB"},
            {"236236AB", "UltimateAssaultAB"},

            //Moon Smasher
            {"214214A", "UltimateTaikuuA"},
            {"214214B", "UltimateTaikuuB"},
            {"214214AB", "UltimateTaikuuAB"},
        };
        private static bool dictionariesBuilt = false;
        private readonly static List<string> invalidActions = new() { "DP", "BD", "5DD", "j.BB", "j.AB", "j.2A", "j.2B" };
        public static Dictionary<string, string> Dictionary
        {
            get { return workingDictionary; }
        }

        public Sho()
        {
            if (!dictionariesBuilt)
            {
                foreach (KeyValuePair<string, string> pair in COMMON_ACTIONS.ToList())
                {
                    if (invalidActions.Any(action => pair.Key.Contains(action)))
                    {
                        continue;
                    }

                    if (!workingDictionary.ContainsKey(pair.Key))
                    {
                        workingDictionary.Add(pair.Key, pair.Value);
                    }
                }

                dictionariesBuilt = true;
            }
        }
    }

    public class RiseKujikawa : PlayableShadow
    {
        private readonly static Dictionary<string, string> workingDictionary = new()
        {
            //Autocombo
            {"5AA", "NmlAtk5A2nd\tc"},
            {"5AAA", "NmlAtk5A3rd\tc"},
            {"5AAAA", "OnpuShot_Atk\t+OnpuShot_Atk_stylish"},
            {"5AAAAA", "UltimateHysterieBintaA\t+BintaA_Stylish"},

            //Reflective Bit
            {"DP", "rp400_atk_col"},
            {"BD", "rp400_atk_col"},

            //ROCK YOU!
            {"236A", "OnpuShot_Atk"},
            {"236B", "OnpuShotb_Atk"},
            {"236AB", "OnpuShotab_Atk"},

            //No Touching!
            {"214A", "AssaultA"},
            {"214B", "AssaultB"},
            {"214AB", "AssaultAB"},

            //Platinum Disc
            {"236C", "rp403_atkc_col"},
            {"236D", "rp403_atkd_col"},
            {"236CD", "rp403_atkcd_col"},

            //Platinum Disc (Air)
            {"j.236C", "rp403_atkc_col"},
            {"j.236D", "rp403_atkd_col"},
            {"j.236CD", "rp403_atkcd_col"},

            //Tetrakarn/Makarakarn
            {"214C", "TetraKhanC\ta"},
            {"214D", "TetraKhanD\ta"},
            {"214CD", "TetraKhanCD\ta"},

            //Arrow Rain
            {"22A", "rp406_atka_col"},
            {"22B", "rp406_atkb_col"},
            {"22AB", "rp406_atkab_col"},

            //Hysterical Slap
            {"236236A", "UltimateHysterieBintaA"},
            {"236236B", "UltimateHysterieBintaB"},
            {"236236AB", "UltimateHysterieBintaAB"},

            //Risette Field
            {"236236C", "UltimateBitFunnelC\ta"},
            {"236236D", "UltimateBitFunnelD\ta"},
            {"236236CD", "UltimateBitFunnelCD\ta"},

            //Risette Field (Air)
            {"j.236236C", "UltimateBitFunnelC\ta"},
            {"j.236236D", "UltimateBitFunnelD\ta"},
            {"j.236236CD", "UltimateBitFunnelCD\ta"},

            //Risette Field (Detonate)
            {"C(Explosion)", "rpef_431_BombAtk"},
            {"D(Explosion)", "rpef_431_BombAtk"},

            //Risette: Live on Stage
            {"214214C", "UltimateRiseMusicGameC\r\nRiseMusicGame_Atk\tnOnly"},
            {"214214D", "UltimateRiseMusicGameD\r\nRiseMusicGame_Atk\tnOnly"},
            {"214214CD", "UltimateRiseMusicGameCD\r\nRiseMusicGame_Atk\tnOnly"},

            //IK
            {"IK", "rief450_atk"},
            {"222CD", "rief450_atk"},
        };
        private readonly static Dictionary<string, string> workingDictionary_S = new();
        private static bool dictionariesBuilt = false;
        private readonly static List<string> invalidActions = new() { "DP", "BD", "IK", "222CD", "5DD", "j.BB", "j.AB", "j.2A", "j.2C" };
        public static Dictionary<string, string> Dictionary
        {
            get { return workingDictionary; }
        }
        public static Dictionary<string, string> Dictionary_S
        {
            get { return workingDictionary_S; }
        }

        public RiseKujikawa()
        {
            if (!dictionariesBuilt)
            {
                foreach (KeyValuePair<string, string> pair in workingDictionary.ToList())
                {
                    workingDictionary_S.Add(pair.Key, pair.Value);
                }

                //Auto Combo - Added in dictionary :p

                foreach (KeyValuePair<string, string> pair in COMMON_ACTIONS.ToList())
                {
                    if (invalidActions.Any(action => pair.Key.Contains(action)))
                    {
                        continue;
                    }

                    if (!workingDictionary.ContainsKey(pair.Key))
                    {
                        workingDictionary.Add(pair.Key, pair.Value);
                    }
                    if (!workingDictionary_S.ContainsKey(pair.Key))
                    {
                        if (invalidActions_S.Any(action => pair.Key.Contains(action)))
                        {
                            continue;
                        }
                        workingDictionary_S.Add(pair.Key, pair.Value);
                    }
                }

                foreach (KeyValuePair<string, string> pair in SHADOW_ACTIONS)
                {
                    if (pair.Key.Equals("5AA") || pair.Key.Equals("5AAA"))
                    {
                        continue;
                    }
                    workingDictionary_S.Add(pair.Key, pair.Value);
                }

                dictionariesBuilt = true;
            }
        }
    }

    public class KenAmada : PlayableShadow
    {
        private readonly static Dictionary<string, string> workingDictionary = new()
        {
            //Autocombo
            {"5AA", "NmlAtk5A2nd\tc"},
            {"5AAA", "NmlAtk5A3rd\tc\r\nKoromaru5C\tnOnly"},
            {"5AAAA", "NyoisoA\t+NyoisoA_Stylish"},
            {"5AAAAA", "PersonaRaigekisouA"},
            {"5AAAAAA", "am431_FireatkC\t|FireBlessC\t+Fire_Stylish"},

            //5C
            {"5C", "Koromaru5C"},

            //2C
            {"2C", "Koromaru2C"},

            //j.C
            {"j.C", "Koromaru5C"},

            //j.2C
            {"j.2C", "Koromaru2C"},

            //Charge Thrust
            {"236A", "NyoisoA"},
            {"236B", "NyoisoB"},
            {"236AB", "NyoisoAB"},

            //Charge Thrust ~ Gigantic Impact
            {"236A~A", "NyoisoA\r\nPersonaRaigekisouA"},
            {"236B~A", "NyoisoB\r\nPersonaRaigekisouA"},
            {"236AB~A", "NyoisoAB\r\nPersonaRaigekisouA"},

            {"236A~B", "NyoisoA\r\nPersonaRaigekisouB"},
            {"236B~B", "NyoisoB\r\nPersonaRaigekisouB"},
            {"236AB~B", "NyoisoAB\r\nPersonaRaigekisouB"},

            {"236A~AB", "NyoisoA\r\nPersonaRaigekisouAB"},
            {"236B~AB", "NyoisoB\r\nPersonaRaigekisouAB"},
            {"236AB~AB", "NyoisoAB\r\nPersonaRaigekisouAB"},

            //Mediarama
            {"214A", "DiaA\ta"},
            {"214B", "DiaB\ta"},
            {"214AB", "DiaAB\ta"},

            //Zan - Hakurou Battouga
            {"236C", "KoromaruAssaultC"},
            {"236D", "KoromaruAssaultD"},
            {"236CD", "KoromaruAssaultCD"},

            //Zan - Hakurou Battouga (Air)
            {"j.236C", "KoromaruAssaultC"},
            {"j.236D", "KoromaruAssaultD"},
            {"j.236CD", "KoromaruAssaultCD"},

            //Zetsu - Hakurou Battouga
            {"214C", "KoromaruAirAssaultC"},
            {"214D", "KoromaruAirAssaultD"},
            {"214CD", "KoromaruAirAssaultCD"},

            //Zetsu - Hakurou Battouga (Air)
            {"j.214C", "KoromaruAirAssaultC"},
            {"j.214D", "KoromaruAirAssaultD"},
            {"j.214CD", "KoromaruAirAssaultCD"},

            //Thunder Reign
            {"236236A", "UltimateSenpukonA"},
            {"236236B", "UltimateSenpukonB"},
            {"236236AB", "UltimateSenpukonAB"},

            //Fire Breath
            {"236236C", "am431_FireatkC\t|FireBlessC"},
            {"236236D", "am431_FireatkD\t|FireBlessCD"},
            {"236236CD", "am431_FireatkCD\t|FireBlessCD"},

            //Fire Breath (Air)
            {"j.236236C", "am431_FireatkC\t|FireBlessC"},
            {"j.236236D", "am431_FireatkD\t|FireBlessCD"},
            {"j.236236CD", "am431_FireatkCD\t|FireBlessCD"},

            //Super Gattai! Ultimate Cross
            {"214214A", "UltimateXAttackA"},
            {"214214B", "UltimateXAttackB"},
            {"214214AB", "UltimateXAttackAB"},

            //IK
            {"IK", "KoromaruIchigeki"},
            {"222CD", "KoromaruIchigeki"},
        };
        private readonly static Dictionary<string, string> workingDictionary_S = new();
        private static bool dictionariesBuilt = false;
        private readonly static List<string> invalidActions = new() { "5C", "2C", "j.C", "j.2C", "IK", "222CD", "5DD", "j.BB", "j.AB", "j.2A", "j.2D" };
        public static Dictionary<string, string> Dictionary
        {
            get { return workingDictionary; }
        }
        public static Dictionary<string, string> Dictionary_S
        {
            get { return workingDictionary_S; }
        }

        public KenAmada()
        {
            if (!dictionariesBuilt)
            {
                foreach (KeyValuePair<string, string> pair in workingDictionary.ToList())
                {
                    workingDictionary_S.Add(pair.Key, pair.Value);
                }

                //Auto Combo - Added in Dictionary :p

                foreach (KeyValuePair<string, string> pair in COMMON_ACTIONS.ToList())
                {
                    if (invalidActions.Any(action => pair.Key.Contains(action)))
                    {
                        continue;
                    }

                    if (!workingDictionary.ContainsKey(pair.Key))
                    {
                        workingDictionary.Add(pair.Key, pair.Value);
                    }
                    if (!workingDictionary_S.ContainsKey(pair.Key))
                    {
                        if (invalidActions_S.Any(action => pair.Key.Contains(action)))
                        {
                            continue;
                        }
                        workingDictionary_S.Add(pair.Key, pair.Value);
                    }
                }

                foreach (KeyValuePair<string, string> pair in SHADOW_ACTIONS)
                {
                    if (pair.Key.Equals("5AA") || pair.Key.Equals("5AAA"))
                    {
                        continue;
                    }
                    workingDictionary_S.Add(pair.Key, pair.Value);
                }

                dictionariesBuilt = true;
            }
        }
    }

    public class TohruAdachi : Character
    {
        private readonly static Dictionary<string, string> workingDictionary = new()
        {
            //Autocombo
            {"5AA", "NmlAtk5A2nd\tc"},
            {"5AAA", "NmlAtk5A3rd\tc"},
            {"5AAAA", "DashAssaultA\t+StylishDashAssault"},
            {"5AAAAA", "UltimateAirAssaultC_atk\t+StylishSPSkill"},

            //Calm Down!
            {"236A", "SpecialWalkA\ta"},
            {"236B", "SpecialWalkB\ta"},
            {"236AB", "SpecialWalkAB\ta"},

            //Calm Down! ~ Pain in the Ass!!
            {"236A~A", "SpecialWalkA\ta\r\nDashAssaultA"},
            {"236B~A", "SpecialWalkB\ta\r\nDashAssaultB"},
            {"236AB~A", "SpecialWalkAB\ta\r\nDashAssaultAB"},

            {"236A~B", "SpecialWalkA\ta\r\nDashAssaultA"},
            {"236B~B", "SpecialWalkB\ta\r\nDashAssaultB"},
            {"236AB~B", "SpecialWalkAB\ta\r\nDashAssaultAB"},

            //Scared?
            {"214A", "dmy_LowShotA_Atk"},
            {"214B", "dmy_LowShotB_Atk"},
            {"214AB", "dmy_LowShotSB_Atk"},

            //Megidola
            {"214C", "MegiDoraC"},
            {"214D", "MegiDoraD"},
            {"214CD", "MegiDoraCD"},

            //Evil Smile
            {"236C", "DevilSmileC\ta"},
            {"236D", "DevilSmileD\ta"},
            {"236CD", "DevilSmileCD\ta"},

            //Atom Smasher
            {"236236C", "UltimateAirAssaultC_atk"},
            {"236236D", "UltimateAirAssaultD_atk"},
            {"236236CD", "UltimateAirAssaultCD_atk"},

            //Atom Smasher (Air)
            {"j.236236C", "UltimateAirAssaultC_atk"},
            {"j.236236D", "UltimateAirAssaultD_atk"},
            {"j.236236CD", "UltimateAirAssaultCD_atk"},

            //Heat Riser
            {"236236A", "PersonaUltimateHeatRiserA"},
            {"236236B", "PersonaUltimateHeatRiserB"},
            {"236236AB", "PersonaUltimateHeatRiserAB"},

            //Ghastly Wail
            {"214214C", "PersonaMoujaNoNagekiC"},
            {"214214D", "PersonaMoujaNoNagekiD"},
            {"214214CD", "PersonaMoujaNoNagekiCD"},

            //Magatsu Mandala
            {"214214A", "PersonaYodonda_KuukiA"},
            {"214214B", "PersonaYodonda_KuukiB"},
            {"214214AB", "PersonaYodonda_KuukiAB"},

            //IK
            {"IK", "Ichigeki_Atk"},
            {"222CD", "Ichigeki_Atk"},
        };
        private static bool dictionariesBuilt = false;
        private readonly static List<string> invalidActions = new() { "5DD", "IK", "222CD", "j.BB", "j.AB", "j.2A", "j.2B" };
        public static Dictionary<string, string> Dictionary
        {
            get { return workingDictionary; }
        }

        public TohruAdachi()
        {
            if (!dictionariesBuilt)
            {
                foreach (KeyValuePair<string, string> pair in COMMON_ACTIONS.ToList())
                {
                    if (invalidActions.Any(action => pair.Key.Contains(action)))
                    {
                        continue;
                    }

                    if (!workingDictionary.ContainsKey(pair.Key))
                    {
                        workingDictionary.Add(pair.Key, pair.Value);
                    }
                }

                dictionariesBuilt = true;
            }
        }
    }

    public class Marie : Character
    {
        private readonly static Dictionary<string, string> workingDictionary = new()
        {
            //Autocombo
            {"5AA", "NmlAtk5A2nd\tc"},
            {"5AAA", "NmlAtk5A3rd\tc"},
            {"5AAAA", "AssaultA\t+AssaultA_Stylish"},
            {"5AAAAA", "mr430B_Atk\t+SPSkill_Stylish"},

            //5BB
            {"5BB", "NmlAtk5B2nd"},

            //Hot Lightning
            {"BD", "mr400_Atk"},
            {"DP", "mr400_Atk"},

            //Hot Lightning (Air)
            {"j.BD", "mr400_Atk"},
            {"j.DP", "mr400_Atk"},

            //Run Amok
            {"236A", "AssaultA"},
            {"236B", "AssaultB"},
            {"236AB", "AssaultAB"},

            //Run Amok (Air)
            {"j.236A", "AirAssaultA"},
            {"j.236B", "AirAssaultB"},
            {"j.236AB", "AirAssaultAB"},

            //Dance, Fallen Angels
            {"214A~A", "mr403_Atk"},
            {"214A~B", "mr403_Atk"},

            //Memories of Grief
            {"214B~A", "mr404_Atk"},
            {"214B~B", "mr404_Atk"},

            //Memories of Grief (Okizeme)
            {"214B(Okizeme)", "PresentForYouA\t+214BSkill\ta"},

            //It's All Yours
            {"214A", "mr403_Atk\ta"},
            {"214B", "mr404_Atk\ta"},
            {"214AB", "PresentForYouSB\ta"},

            //It's All Yours ~ Her Name is "Hope (Pandora)"
            {"214A~C", "mr403_Atk\ta\r\nmr405SB_Atk"},
            {"214B~C", "mr404_Atk\ta\r\nmr405SB_Atk"},
            {"214AB~C", "PresentForYouSB\ta\r\nmr405SB_Atk"},

            //It's All Yours ~ Stance Cancel
            {"214A~D", "mr403_Atk\ta\r\nKamaeCancel\ta"},
            {"214B~D", "mr404_Atk\ta\r\nKamaeCancel\ta"},
            {"214AB~D", "PresentForYouSB\ta\r\nKamaeCancel\ta"},

            //Stigma of Condemnation
            {"236C", "mr406c_Atk"},
            {"236D", "mr406d_Atk"},
            {"236CD", "mr406sb_Atk"},

            //Abysmal Evil Eye
            {"214C", "mr407c_Atk"},
            {"214D", "mr407d_Atk"},
            {"214CD", "mr407sb_Atk"},

            //Shell of Denial
            {"236236A", "mr430_Atk"},
            {"236236B", "mr430B_Atk"},
            {"236236AB", "mr430SB_Atk"},

            //ShutupIhateyouyoustupidjerk ~ (Hold A)
            {"236236C~[A]", "mr432_CardAtk\r\nmr432San_Atk"},
            {"236236D~[A]", "mr432_CardAtk\t+mr432d_CardAtk\r\nmr432San_Atk"},
            {"236236CD~[A]", "mr432_CardAtk\t+mr432cd_CardAtk\r\nmr432San_Atk"},

            //ShutupIhateyouyoustupidjerk ~ B
            {"236236C~[B]", "mr432_CardAtk\r\nmr432Cloud_Atk"},
            {"236236D~[B]", "mr432_CardAtk\t+mr432d_CardAtk\r\nmr432Cloud_Atk"},
            {"236236CD~[B]", "mr432_CardAtk\t+mr432cd_CardAtk\r\nmr432Cloud_Atk"},

            //ShutupIhateyouyoustupidjerk ~ C
            {"236236C~[C]", "mr432_CardAtk\r\nmr432Rain_Atk"},
            {"236236D~[C]", "mr432_CardAtk\t+mr432d_CardAtk\r\nmr432Rain_Atk"},
            {"236236CD~[C]", "mr432_CardAtk\t+mr432cd_CardAtk\r\nmr432Rain_Atk"},

            //ShutupIhateyouyoustupidjerk ~ D
            {"236236C~[D]", "mr432_CardAtk\r\nmr432Snow_Atk"},
            {"236236D~[D]", "mr432_CardAtk\t+mr432d_CardAtk\r\nmr432Snow_Atk"},
            {"236236CD~[D]", "mr432_CardAtk\t+mr432cd_CardAtk\r\nmr432Snow_Atk"},

            //Shining Arrows
            {"214214C", "UltimateWindC\ta"},
            {"214214D", "UltimateWindC\t+UltimateWindD\ta"},
            {"214214CD", "UltimateWindC\t+UltimateWindCD\ta"},

            //Shining Arrows (Air)
            {"j.214214C", "UltimateWindC\ta"},
            {"j.214214D", "UltimateWindC\t+UltimateWindD\ta"},
            {"j.214214CD", "UltimateWindC\t+UltimateWindCD\ta"},

            //Shining Arrows Followups
            {"C(Shot)", "mp431_ExWindShot"},
            {"D(Shot)", "mp431_ExWindShotD\t|mp431_ExWindShotC"},

            //IK
            {"IK", "Ichigeki_Atk"},
            {"222CD", "Ichigeki_Atk"},
        };
        private static bool dictionariesBuilt = false;
        private readonly static List<string> invalidActions = new() { "DP", "BD", "IK", "222CD", "5DD", "j.BB", "j.AB", "j.2A", "j.2C", "j.2D" };
        public static Dictionary<string, string> Dictionary
        {
            get { return workingDictionary; }
        }

        public Marie()
        {
            if (!dictionariesBuilt)
            {

                foreach (KeyValuePair<string, string> pair in COMMON_ACTIONS.ToList())
                {
                    if (invalidActions.Any(action => pair.Key.Contains(action)))
                    {
                        continue;
                    }

                    if (!workingDictionary.ContainsKey(pair.Key))
                    {
                        workingDictionary.Add(pair.Key, pair.Value);
                    }
                }

                dictionariesBuilt = true;
            }
        }
    }

    public class Margaret : Character
    {
        private readonly static Dictionary<string, string> workingDictionary = new()
        {
            //Autocombo
            {"5A", "ArenBeam\t+NmlAtk5A\tc"},
            {"5AA", "ArenBeam2nd\t+NmlAtk5A2nd\tc"},
            {"5AAA", "ArenBeam3rd\t+NmlAtk5A3rd\tc"},
            {"5AAAA", "ArenBeam3rd\t+NmlAtk5A3rd\tc"},
            {"5AAAAA", "ArenBeam3rd\t+NmlAtk5A3rd\tc"},
            {"5AAAAAA", "Shinkuha_YarinageC\t+StylishShinkuha"},
            {"5AAAAAAA", "PersonaChargeSlashA\t+StylishSPSkill"},

            //Ultra Suplex (Air)
            {"j.DP", "ReversalAction"},
            {"j.BD", "ReversalAction"},

            //j.22C
            {"j.22C", "NmlAtkAir22C\ta"},

            //j.22D
            {"j.22D", "NmlAtkAir22D\ta"},

            //Divine Vacuum
            {"236C", "Shinkuha_YarinageC\t|Shinkuha_TatsumakiC"},
            {"236D", "Shinkuha_TatsumakiD"},
            {"236CD", "Shinkuha_TatsumakiCD"},

            //Divine Vacuum (Air)
            {"j.236C", "Shinkuha_YarinageC\t|Shinkuha_TatsumakiC"},
            {"j.236D", "Shinkuha_TatsumakiD"},
            {"j.236CD", "Shinkuha_TatsumakiCD"},

            //Gale Slash
            {"214A", "PersonaGaleSlashA"},
            {"214B", "PersonaGaleSlashB"},
            {"214AB", "PersonaGaleSlashAB"},

            //Gale Slash (Air)
            {"j.214A", "PersonaGaleSlashA_Air"},
            {"j.214B", "PersonaGaleSlashB_Air"},
            {"j.214AB", "PersonaGaleSlashAB_Air"},

            //God's Hand
            {"214C", "PersonaGodHandC_Atk"},
            {"214D", "PersonaGodHandD_Atk"},
            {"214CD", "PersonaGodHandCD_Atk"},

            //Power Slash
            {"236236A", "PersonaChargeSlashA"},
            {"236236B", "PersonaChargeSlashB"},
            {"236236AB", "PersonaChargeSlashAB"},

            //Power Slash ~ Power Slash
            {"236236A~236236A", "UltimateChargeSlashA\t+PersonaChargeSlashA\ta\r\nUltimateChargeSlashA\t+PersonaChargeSlashA"},
            {"236236B~236236A", "UltimateChargeSlashB\t+PersonaChargeSlashB\ta\r\nUltimateChargeSlashA\t+PersonaChargeSlashA"},
            {"236236AB~236236A", "UltimateChargeSlashAB\t+PersonaChargeSlashAB\ta\r\nUltimateChargeSlashA\t+PersonaChargeSlashA"},

            {"236236A~236236B", "UltimateChargeSlashA\t+PersonaChargeSlashA\ta\r\nUltimateChargeSlashB\t+PersonaChargeSlashB"},
            {"236236B~236236B", "UltimateChargeSlashB\t+PersonaChargeSlashB\ta\r\nUltimateChargeSlashB\t+PersonaChargeSlashB"},
            {"236236AB~236236B", "UltimateChargeSlashAB\t+PersonaChargeSlashAB\ta\r\nUltimateChargeSlashB\t+PersonaChargeSlashB"},

            {"236236A~236236AB", "UltimateChargeSlashA\t+PersonaChargeSlashA\ta\r\nUltimateChargeSlashAB\t+PersonaChargeSlashAB"},
            {"236236B~236236AB", "UltimateChargeSlashB\t+PersonaChargeSlashB\ta\r\nUltimateChargeSlashAB\t+PersonaChargeSlashAB"},
            {"236236AB~236236AB", "UltimateChargeSlashAB\t+PersonaChargeSlashAB\ta\r\nUltimateChargeSlashAB\t+PersonaChargeSlashAB"},

            //Power Slash ~ Hassou Tobi
            {"236236A~214214A", "UltimateChargeSlashA\t+PersonaChargeSlashA\ta\r\nPersonaHassouJumpA"},
            {"236236B~214214A", "UltimateChargeSlashB\t+PersonaChargeSlashB\ta\r\nPersonaHassouJumpA"},
            {"236236AB~214214A", "UltimateChargeSlashAB\t+PersonaChargeSlashAB\ta\r\nPersonaHassouJumpA"},

            {"236236A~214214B", "UltimateChargeSlashA\t+PersonaChargeSlashA\ta\r\nPersonaHassouJumpB"},
            {"236236B~214214B", "UltimateChargeSlashB\t+PersonaChargeSlashB\ta\r\nPersonaHassouJumpB"},
            {"236236AB~214214B", "UltimateChargeSlashAB\t+PersonaChargeSlashAB\ta\r\nPersonaHassouJumpB"},

            {"236236A~214214AB", "UltimateChargeSlashA\t+PersonaChargeSlashA\ta\r\nPersonaHassouJumpAB"},
            {"236236B~214214AB", "UltimateChargeSlashB\t+PersonaChargeSlashB\ta\r\nPersonaHassouJumpAB"},
            {"236236AB~214214AB", "UltimateChargeSlashAB\t+PersonaChargeSlashAB\ta\r\nPersonaHassouJumpAB"},

            //Phanta Rhei
            {"236236C", "Ryuten_atk"},
            {"236236D", "Ryuten_atkD"},
            {"236236CD", "Ryuten_atkCD"},

            //Phanta Rhei (Air)
            {"j.236236C", "Ryuten_atk"},
            {"j.236236D", "Ryuten_atkD"},
            {"j.236236CD", "Ryuten_atkCD"},

            //Mediarahan
            {"214214C", "UltimateMediarahanC\ta"},
            {"214214D", "UltimateMediarahanD\ta"},
            {"214214CD", "UltimateMediarahanCD\ta"},

            //Hassou Tobi
            {"214214A", "PersonaHassouJumpA"},
            {"214214B", "PersonaHassouJumpB"},
            {"214214AB", "PersonaHassouJumpAB"},

            //IK
            {"IK", "Ichigeki_Atk"},
            {"222CD", "Ichigeki_Atk"},
        };
        private static bool dictionariesBuilt = false;
        private readonly static List<string> invalidActions = new() {"IK", "222CD", "5DD", "j.BB", "j.AB", "j.2A" };
        public static Dictionary<string, string> Dictionary
        {
            get { return workingDictionary; }
        }

        public Margaret()
        {
            if (!dictionariesBuilt)
            {
                foreach (KeyValuePair<string, string> pair in COMMON_ACTIONS.ToList())
                {
                    if (invalidActions.Any(action => pair.Key.Contains(action)))
                    {
                        continue;
                    }

                    if (!workingDictionary.ContainsKey(pair.Key))
                    {
                        workingDictionary.Add(pair.Key, pair.Value);
                    }
                }

                dictionariesBuilt = true;
            }
        }
    }
}
