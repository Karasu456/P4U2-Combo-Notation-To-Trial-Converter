using System.Text.RegularExpressions;
using P4U2_Combo_Notation_To_Trial_Converter.CharacterData;
using ComboBox = System.Windows.Forms.ComboBox;
using ToolTip = System.Windows.Forms.ToolTip;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace P4U2_Combo_Notation_To_Trial_Converter
{
    public partial class Form1 : Form
    {
        private readonly Dictionary<string, Type> characterCrossReference = new()
        {
            {"Yu Narukami", typeof(YuNarukami)},
            {"Yosuke Hanamura", typeof(YosukeHanamura)},
            {"Chie Satonaka", typeof(ChieSatonaka)},
            {"Yukiko Amagi", typeof(YukikoAmagi)},
            {"Kanji Tatsumi", typeof(KanjiTatsumi)},
            {"Teddie", typeof(Teddie)},
            {"Naoto Shirogane", typeof(NaotoShirogane)},
            {"Aigis", typeof(Aigis)},
            {"Akihiko Sanada", typeof(AkihikoSanada)},
            {"Mitsuru Kirijo", typeof(MitsuruKirijo)},
            {"Elizabeth", typeof(Elizabeth)},
            {"Labrys", typeof(Labrys)},
            {"Shadow Labrys", typeof(ShadowLabrys)},
            {"Yukari Takeba", typeof(YukariTakeba)},
            {"Junpei Iori", typeof(JunpeiIori)},
            {"Sho", typeof(Sho)},
            {"Minazuki", typeof(Minazuki)},
            {"Rise Kujikawa", typeof(RiseKujikawa)},
            {"Ken Amada", typeof(KenAmada)},
            {"Tohru Adachi", typeof(TohruAdachi)},
            {"Marie", typeof(Marie)},
            {"Margaret", typeof(Margaret)}
        };

        private Dictionary<string, string>? currentDictionary;
#pragma warning disable IDE0044 // Add readonly modifier
        private List<string> trialSettings = new();
#pragma warning restore IDE0044 // Add readonly modifier
        private readonly Dictionary<string, string> trialDescriptions = new()
        {
            {"Burst\t100", "Burst Ready"},
            {"SP\t150", "Full SP - Awakening"},
            {"SP\t100", "Full SP"},            
            {"Kakusei", "Awakening"},
            {"Ichigeki", "Instant Kill Ready"},
            {"HPRecovery", "HP Recovery"},
            {"HPRecoveryEnemyOnly", "E-HP Recovery"},
            {"Konran", "Player Panic"},
            {"Kanden", "Player Shock"},
            {"PersonaBreak", "Persona Broken"},
            {"EnemyKyofu", "Enemy Fear"},
            {"NoMiss", "No Miss"},
            {"Junhudo", "Use Every Attack"},
            {"HeatUpForever", "Infinite Frenzy"}
        };
        private int percentSP;
        private string? strPercentSP;
        private int percentHP;
        private string? strPercentHP;
        private int juPoints;
        private int agBullets;
        private bool juFullCount;

        private readonly List<string> chiesItems = new() { "Default", "Level 1", "Level 2", "Level 3"};
        private readonly List<string> yukikosItems = new() { "Default", "Level 1", "Level 2", "Level 3", "Level 4", "Level 5", "Level 6", "Level 7", "Level 8", "Level 9"};
        private readonly List<string> teddiesItems = new() { "Default", "MF-06S Brahman", "Dr. Salt NEO", "Heavy-Armor Agni", "Mystery Food X", "Smart Bomb", "Turbo Recon Dyaus", "Oil Drum", "Motorcycle Key", "Firecracker", "Dry Ice", "Vanish Ball", "Mobile Model Varna", "Muscle Drink", "Pinwheel", "D-Type Prithvi", "Ball Lightning", "Amagiya Bucket"};
        private readonly List<string> teddiesItems2 = new() { "Default", "Firecracker", "Dry Ice", "Vanish Ball", "Mobile Model Varna", "Muscle Drink", "Pinwheel", "D-Type Prithvi", "Ball Lightning", "Amagi Inn Bucket", "MF-06S Brahman", "Dr. Salt NEO", "Heavy-Armor Agni", "Mystery Food X", "Smart Bomb", "Turbo Recon Dyaus", "Oil Drum", "Motorcycle Key"};
        private readonly List<string> labrysItems = new() { "Default", "Level 1", "Level 2", "Level 3", "Level 4", "Level 5"};
        private readonly List<string> naotosItems = new() { "Default", "Fixed at Zero", "Fixed at MAX"};
        private readonly List<string> mariesItems = new() { "Sunny Weather", "Cloudy Weather", "Rainy Weather", "Snowy Weather"};

        public Form1()
        {
            InitializeComponent();
            SetComboBoxDefaults(characterSelectComboBox, "Yu Narukami", "This is to set the character for the combo.");
            SetComboBoxDefaults(stagePositionComboBox, "Default", "This is to set the position of the stage.");
            SetComboBoxDefaults(enemyBehaviorComboBox, "Standing", "This is to set the behavior of the enemy dummy.");
            SetComboBoxDefaults(counterComboBox, "Regular Hit", "This is to set whether or not the combo is a counter hit.");
        }
                
        /// <summary>
        /// Sets the default selected item and tooltip for a ComboBox.
        /// </summary>
        private static void SetComboBoxDefaults(ComboBox box, string selectedText, string toolTip)
        {
            box.SelectedItem = selectedText;
            ToolTip tip = new();
            tip.SetToolTip(box, toolTip);
        }

        /// <summary>
        /// Handles the TextChanged event for the percentHPTextBox control.
        /// Validates the input to ensure that it is a number between 1 and 100, inclusive.
        /// </summary>
        private void PercentHPTextBox_TextChanged(object sender, EventArgs e)
        {
            string input = percentHPTextBox.Text;
            string pattern = @"^([1-9][0-9]?|100)?$";
            if (int.TryParse(input, out int number))
            {
                if (number >= 100 || number < 1)
                {
                    percentHPTextBox.Text = "";
                }
            }
            else if (!Regex.IsMatch(input, pattern))
            {
                // Find the first invalid character in the input string
                int invalidIndex = input.Length;
                for (int i = 0; i < input.Length; i++)
                {
                    if (!char.IsDigit(input[i]))
                    {
                        invalidIndex = i;
                        break;
                    }
                }

                // Remove all characters after the first invalid character
                percentHPTextBox.Text = input.Remove(invalidIndex);
                percentHPTextBox.Select(invalidIndex, percentHPTextBox.TextLength - invalidIndex);
            }

            if (percentHPTextBox.Text.Length > 0)
            {
                trialSettings.Remove($"HP\t{strPercentHP}");

                percentHP = int.Parse(percentHPTextBox.Text);
                strPercentHP = percentHP.ToString();

                trialSettings.Add($"HP\t{strPercentHP}");
            }
            else if (percentHPTextBox.Text.Length == 0)
            {
                trialSettings.Remove($"HP\t{strPercentHP}");
            }

            RefreshTrialSettingsDataGridView(trialSettings);
        }

        /// <summary>
        /// Handles the TextChanged event for the percentSPTextBox control.
        /// Validates the input to ensure that it is a number between 0 and 150, inclusive.
        /// </summary>
        private void PercentSPTextBox_TextChanged(object sender, EventArgs e)
        {
            string input = percentSPTextBox.Text;
            string pattern = @"^(1[0-4][0-9]|[1-9]?[0-9]|150)$";            

            if (int.TryParse(input, out int number))
            {
                if(awakeningCheckBox.Checked)
                {
                    if (number >= 150)
                    {
                        fullSPCheckBox.Checked = true;
                        percentSPTextBox.Text = "";
                        percentSPTextBox.Enabled = false;
                    }
                    else if (number < 1)
                    {
                        percentSPTextBox.Text = "";
                    }
                }
                else
                {
                    if (number >= 100)
                    {
                        fullSPCheckBox.Checked = true;
                        percentSPTextBox.Text = "";
                        percentSPTextBox.Enabled = false;
                    }
                    else if (number < 1)
                    {
                        percentSPTextBox.Text = "";
                    }
                }
            }
            else if (!Regex.IsMatch(input, pattern))
            {
                // Find the first invalid character in the input string
                int invalidIndex = input.Length;
                for (int i = 0; i < input.Length; i++)
                {
                    if (!char.IsDigit(input[i]))
                    {
                        invalidIndex = i;
                        break;
                    }
                }

                // Remove all characters after the first invalid character
                percentSPTextBox.Text = input.Remove(invalidIndex);
                percentSPTextBox.Select(invalidIndex, percentSPTextBox.TextLength - invalidIndex);
            }
            
            if (percentSPTextBox.Text.Length > 0)
            {
                trialSettings.Remove("SP\t150");
                trialSettings.Remove("SP\t100");
                trialSettings.Remove($"SP\t{strPercentSP}");

                percentSP = int.Parse(percentSPTextBox.Text);
                strPercentSP = percentSP.ToString();

                trialSettings.Add($"SP\t{strPercentSP}");                
            }
            else if (percentSPTextBox.Text.Length == 0 )
            {
                trialSettings.Remove($"SP\t{strPercentSP}");
            }

            RefreshTrialSettingsDataGridView(trialSettings);
        }

        private void ComboInputTextBox_TextChanged(object sender, EventArgs e)
        {
            CompileTrialData();
        }

        private void CompileTrialData()
        {
            var segmentStrings = comboInputTextBox.Text.Split(new[] { " > " }, StringSplitOptions.None);
            var errorSegments = new List<int>();

            trialDataGridView.Rows.Clear();

            int index = 0;
            foreach (string segment in segmentStrings)
            {
                if (segment.Trim().Length == 0)
                {
                    continue;
                }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (currentDictionary.TryGetValue(segment, out string? nullSegment))
                {
                    trialDataGridView.Rows.Add(segment, currentDictionary[segment]);
                    trialDataGridView.Rows[^1].DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    errorSegments.Add(index);
                    trialDataGridView.Rows.Add(segment, "INVALID INPUT");
                    trialDataGridView.Rows[^1].DefaultCellStyle.BackColor = Color.Red;
                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                index++;
            }            
        }

        private void UpdateCurrentDictionary()
        {
            Type classTypeSelected;
            object? instancedClass;

            if (characterSelectComboBox.SelectedItem.ToString() != null)
            {
#pragma warning disable CS8604 // Possible null reference argument.
                classTypeSelected = characterCrossReference[characterSelectComboBox.SelectedItem.ToString()];
#pragma warning restore CS8604 // Possible null reference argument.
            }
            else
            {
                classTypeSelected = typeof(YuNarukami);
            }
            instancedClass = Activator.CreateInstance(classTypeSelected);

            if (shadowCheckBox.Checked)
            {
                PropertyInfo? dictionaryProperty = classTypeSelected.GetProperty("Dictionary_S", BindingFlags.Public | BindingFlags.Static);

                if (dictionaryProperty != null && dictionaryProperty.PropertyType == typeof(Dictionary<string, string>))
                {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    currentDictionary = (Dictionary<string, string>)dictionaryProperty.GetValue(instancedClass, null);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                }
                else
                {
                    currentDictionary = YuNarukami.Dictionary_S;
                }                
            }
            else
            {
                PropertyInfo? dictionaryProperty = classTypeSelected.GetProperty("Dictionary", BindingFlags.Public | BindingFlags.Static);

                if (dictionaryProperty != null && dictionaryProperty.PropertyType == typeof(Dictionary<string, string>))
                {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    currentDictionary = (Dictionary<string, string>)dictionaryProperty.GetValue(instancedClass, null);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                }
                else
                {
                    currentDictionary = YuNarukami.Dictionary;
                }
            }

            if (instancedClass is PlayableShadow)
            {
                shadowCheckBox.Enabled = true;
            }
            else
            {
                shadowCheckBox.Checked = false;
                shadowCheckBox.Enabled = false;
                infiniteFrenzyCheckBox.Checked = false;
                infiniteFrenzyCheckBox.Enabled = false;
            }

            if (instancedClass is Sho)
            {
                ichigekiReadyCheckBox.Checked = false;
                ichigekiReadyCheckBox.Enabled = false;
            }
            else
            {   
                if(shadowCheckBox.Checked == false)
                {
                    ichigekiReadyCheckBox.Enabled = true;
                }                
            }
        }
        
        private void CharacterSelectComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateCurrentDictionary();
            //comboInputTextBox.Text = "";
            CompileTrialData();
            ClearCharacterSpecificSettings();
            CreateCharacterSettings();            

        }

        private static void CheckBoxChanged(System.Windows.Forms.CheckBox checkBox, string item, List<string> itemList)
        {
            if (checkBox.Checked)
            {
                if (!itemList.Contains(item))
                {
                    itemList.Add(item);
                }
            }
            else
            {
                if (itemList.Contains(item))
                {
                    itemList.Remove(item);
                }
            }
        }

        private void RefreshTrialSettingsDataGridView(List<string> itemList)
        {
            trialSettingsDataGridView.Rows.Clear();
            foreach(string trialText in itemList)
            {
                ///
                /// Specific Settings for Everyone :skull:
                ///
                if (trialText == $"HP\t{strPercentHP}")
                {
                    trialSettingsDataGridView.Rows.Add("% HP", $"HP\t{percentHPTextBox.Text}");
                }
                else if (trialText == $"SP\t{strPercentSP}")
                {
                    trialSettingsDataGridView.Rows.Add("% SP", $"SP\t{percentSPTextBox.Text}");
                }
                else if(trialText == "Tooi")
                {
                    trialSettingsDataGridView.Rows.Add("Far Apart", "Tooi");
                }
                else if (trialText == "Hashi")
                {
                    trialSettingsDataGridView.Rows.Add("Near Corner", "Hashi");
                }
                else if (trialText == "HashiEx")
                {
                    trialSettingsDataGridView.Rows.Add("At Corner", "HashiEx");
                }
                else if (trialText == "Jump")
                {
                    trialSettingsDataGridView.Rows.Add("Enemy Behavior", "Jump");
                }
                else if (trialText == "Crouch")
                {
                    trialSettingsDataGridView.Rows.Add("Enemy Behavior", "Crouch");
                }
                else if (trialText == "Attack")
                {
                    trialSettingsDataGridView.Rows.Add("Enemy Behavior", "Attack");
                }
                else if (trialText == "Counter Hit")
                {
                    trialSettingsDataGridView.Rows.Add("Counter Hit", "Counter");
                }
                else if (trialText == "Counter Hit(ND)")
                {
                    trialSettingsDataGridView.Rows.Add("Counter Hit", "CounterND");
                }
                else if (trialText == "Fake Fatal :)")
                {
                    trialSettingsDataGridView.Rows.Add("Counter Hit", "Counter");
                }
                ///
                /// Character Specific CheckBox Settings
                ///
                else if (trialText == "Infinite Sukukaja")
                {
                    trialSettingsDataGridView.Rows.Add("Yosuke", "YosukesSukukaja\t1");
                }
                else if (trialText == "Fire Break Fast Recovery")
                {
                    trialSettingsDataGridView.Rows.Add("Yukiko", "YukikosFireGuardKill\t1");
                }
                else if (trialText == "Fix Item 1")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItemFix\t1");
                }
                else if (trialText == "Fix Item 2")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItemFix2\t1");
                }
                else if (trialText == "Mystery Teddie SP Fast Recovery")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasSPItemFastRecovery\t1");
                }
                else if (trialText == "Orgia Fast Recovery")
                {
                    trialSettingsDataGridView.Rows.Add("Aigis", "AegissOrgia\t1");
                }
                else if (trialText == "Ammo Fast Recovery")
                {
                    trialSettingsDataGridView.Rows.Add("Aigis", "AegissBulletsRecover\t1");
                }
                else if (trialText == "Thunder Fists Always On")
                {
                    trialSettingsDataGridView.Rows.Add("Akihiko", "AkihikosThunder\t1");
                }
                else if (trialText == "Titanomachia Fast Recovery")
                {
                    trialSettingsDataGridView.Rows.Add("S. Labrys", "ShadowLabryssProgramFastRecover\t1");
                }
                else if (trialText == "Full Run Count")
                {                    
                    trialSettingsDataGridView.Rows.Add("Junpei", "JunpeisFullCount\t1");
                }
                else if (trialText == "Never Activate Victory Cry")
                {
                    trialSettingsDataGridView.Rows.Add("Junpei", "JunpeisOtakebi\t1");
                }
                else if (trialText == "Analyze Always On")
                {
                    trialSettingsDataGridView.Rows.Add("Rise", "RisesMarking\t1");
                }
                else if (trialText == "Tetrakarn Fast Recovery")
                {
                    trialSettingsDataGridView.Rows.Add("Rise", "RisesTetraFastRecover\t1");
                }
                else if (trialText == "Risette Field Fast Recovery")
                {
                    trialSettingsDataGridView.Rows.Add("Rise", "RisesBitFastRecover\t1");
                }
                else if (trialText == "Koromaru Fast Recovery")
                {
                    trialSettingsDataGridView.Rows.Add("Ken", "KorosHP\t1");
                }
                else if (trialText == "Heat Riser Always On")
                {
                    trialSettingsDataGridView.Rows.Add("Adachi", "AdachisHeat\t1");
                }
                else if (trialText == "Magatsu Mandala Always On")
                {
                    trialSettingsDataGridView.Rows.Add("Adachi", "AdachisYodomi\t1");
                }
                ///
                /// Character Specific ComboBox Settings
                ///
                else if (trialText == "Chie Charge Level 0")
                {
                    //Empty clause because ComboBoxes are silly :p
                }
                else if (trialText == "Chie Charge Level 1")
                {
                    trialSettingsDataGridView.Rows.Add("Chie", "ChiesCharge\t1");
                }
                else if (trialText == "Chie Charge Level 2")
                {
                    trialSettingsDataGridView.Rows.Add("Chie", "ChiesCharge\t2");
                }
                else if (trialText == "Chie Charge Level 3")
                {
                    trialSettingsDataGridView.Rows.Add("Chie", "ChiesCharge\t3");
                }
                else if (trialText == "Yukiko Charge Level 0")
                {
                    //Empty clause because ComboBoxes are silly :p
                }
                else if (trialText == "Yukiko Charge Level 1")
                {
                    trialSettingsDataGridView.Rows.Add("Yukiko", "YukikosFireBooster\t1");
                }
                else if (trialText == "Yukiko Charge Level 2")
                {
                    trialSettingsDataGridView.Rows.Add("Yukiko", "YukikosFireBooster\t2");
                }
                else if (trialText == "Yukiko Charge Level 3")
                {
                    trialSettingsDataGridView.Rows.Add("Yukiko", "YukikosFireBooster\t3");
                }
                else if (trialText == "Yukiko Charge Level 4")
                {
                    trialSettingsDataGridView.Rows.Add("Yukiko", "YukikosFireBooster\t4");
                }
                else if (trialText == "Yukiko Charge Level 5")
                {
                    trialSettingsDataGridView.Rows.Add("Yukiko", "YukikosFireBooster\t5");
                }
                else if (trialText == "Yukiko Charge Level 6")
                {
                    trialSettingsDataGridView.Rows.Add("Yukiko", "YukikosFireBooster\t6");
                }
                else if (trialText == "Yukiko Charge Level 7")
                {
                    trialSettingsDataGridView.Rows.Add("Yukiko", "YukikosFireBooster\t7");
                }
                else if (trialText == "Yukiko Charge Level 8")
                {
                    trialSettingsDataGridView.Rows.Add("Yukiko", "YukikosFireBooster\t8");
                }
                else if (trialText == "Yukiko Charge Level 9")
                {
                    trialSettingsDataGridView.Rows.Add("Yukiko", "YukikosFireBooster\t9");
                }
                else if (trialText == "Teddie Item 0")
                {
                    //Empty clause because ComboBoxes are silly :p
                }
                else if (trialText == "Teddie Item MF-06S Brahman")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem\t1");
                }
                else if (trialText == "Teddie Item Dr. Salt NEO")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem\t2");
                }
                else if (trialText == "Teddie Item Heavy-Armor Agni")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem\t3");
                }
                else if (trialText == "Teddie Item Mystery Food X")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem\t4");
                }
                else if (trialText == "Teddie Item Smart Bomb")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem\t5");
                }
                else if (trialText == "Teddie Item Turbo Recon Dyaus")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem\t6");
                }
                else if (trialText == "Teddie Item Oil Drum")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem\t7");
                }
                else if (trialText == "Teddie Item Motorcycle Key")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem\t8");
                }
                else if (trialText == "Teddie Item Firecracker")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem\t9");
                }
                else if (trialText == "Teddie Item Dry Ice")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem\t10");
                }
                else if (trialText == "Teddie Item Vanish Ball")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem\t11");
                }
                else if (trialText == "Teddie Item Mobile Model Varna")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem\t12");
                }
                else if (trialText == "Teddie Item Muscle Drink")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem\t13");
                }
                else if (trialText == "Teddie Item Pinwheel")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem\t14");
                }
                else if (trialText == "Teddie Item D-Type Prithvi")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem\t15");
                }
                else if (trialText == "Teddie Item Ball Lightning")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem\t16");
                }
                else if (trialText == "Teddie Item Amagiya Bucket")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem\t17");
                }
                else if (trialText == "Teddie Item2 0")
                {
                    //Empty clause because ComboBoxes are silly :p
                }
                else if (trialText == "Teddie Item2 Firecracker")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem2\t1");
                }
                else if (trialText == "Teddie Item2 Dry Ice")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem2\t2");
                }
                else if (trialText == "Teddie Item2 Vanish Ball")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem2\t3");
                }
                else if (trialText == "Teddie Item2 Mobile Model Varna")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem2\t4");
                }
                else if (trialText == "Teddie Item2 Muscle Drink")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem2\t5");
                }
                else if (trialText == "Teddie Item2 Pinwheel")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem2\t6");
                }
                else if (trialText == "Teddie Item2 D-Type Prithvi")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem2\t7");
                }
                else if (trialText == "Teddie Item2 Ball Lightning")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem2\t8");
                }
                else if (trialText == "Teddie Item2 Amagi Inn Bucket")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem2\t9");
                }
                else if (trialText == "Teddie Item2 MF-06S Brahman")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem2\t10");
                }
                else if (trialText == "Teddie Item2 Dr. Salt NEO")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem2\t11");
                }
                else if (trialText == "Teddie Item2 Heavy-Armor Agni")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem2\t12");
                }
                else if (trialText == "Teddie Item2 Mystery Food X")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem2\t13");
                }
                else if (trialText == "Teddie Item2 Smart Bomb")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem2\t14");
                }
                else if (trialText == "Teddie Item2 Turbo Recon Dyaus")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem2\t15");
                }
                else if (trialText == "Teddie Item2 Oil Drum")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem2\t16");
                }
                else if (trialText == "Teddie Item2 Motorcycle Key")
                {
                    trialSettingsDataGridView.Rows.Add("Teddie", "KumasItem2\t17");
                }
                else if (trialText == $"Aigis Max Bullets: {agBullets}")
                {
                    trialSettingsDataGridView.Rows.Add("Aigis", $"AegissBulletsMax\t{agBullets}");
                }
                else if (trialText == "Labrys Initial Axe Level 0")
                {
                    //Empty clause because ComboBoxes are silly :p
                }
                else if (trialText == "Labrys Initial Axe Level 1")
                {
                    trialSettingsDataGridView.Rows.Add("Labrys", "LabryssAxInitial\t1");
                }
                else if (trialText == "Labrys Initial Axe Level 2")
                {
                    trialSettingsDataGridView.Rows.Add("Labrys", "LabryssAxInitial\t2");
                }
                else if (trialText == "Labrys Initial Axe Level 3")
                {
                    trialSettingsDataGridView.Rows.Add("Labrys", "LabryssAxInitial\t3");
                }
                else if (trialText == "Labrys Initial Axe Level 4")
                {
                    trialSettingsDataGridView.Rows.Add("Labrys", "LabryssAxInitial\t4");
                }
                else if (trialText == "Labrys Initial Axe Level 5")
                {
                    trialSettingsDataGridView.Rows.Add("Labrys", "LabryssAxInitial\t5");
                }
                else if (trialText == "Default Fate")
                {
                    //Empty clause because ComboBoxes are silly :p
                }
                else if (trialText == "Fixed at Zero")
                {
                    trialSettingsDataGridView.Rows.Add("Naoto", "NaotosFate\t1");
                }
                else if (trialText == "Fixed at MAX")
                {
                    trialSettingsDataGridView.Rows.Add("Naoto", "NaotosFate\t2");
                }                
                else if (trialText == $"Junpei Score: {juPoints}")
                {
                    trialSettingsDataGridView.Rows.Add("Junpei", $"JunpeisPoint\t{juPoints}");
                }
                else if (trialText == "Sunny Weather")
                {
                    trialSettingsDataGridView.Rows.Add("Marie", "MariesOtenki\t1");
                }
                else if (trialText == "Cloudy Weather")
                {
                    trialSettingsDataGridView.Rows.Add("Marie", "MariesOtenki\t2");
                }
                else if (trialText == "Rainy Weather")
                {
                    trialSettingsDataGridView.Rows.Add("Marie", "MariesOtenki\t3");
                }
                else if (trialText == "Snowy Weather")
                {
                    trialSettingsDataGridView.Rows.Add("Marie", "MariesOtenki\t4");
                }
                ///
                /// Basic Settings
                ///
                else
                {
                    trialSettingsDataGridView.Rows.Add(trialDescriptions[trialText], trialText);
                }                
            }
        }

        private void BurstReadyCheckBox_CheckedChangedsListBox(object sender, EventArgs e)
        {
            CheckBoxChanged(burstReadyCheckBox, "Burst\t100", trialSettings);
            RefreshTrialSettingsDataGridView(trialSettings);
        }

        private void FullSPCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(fullSPCheckBox.Checked)
            {                
                percentSPTextBox.Text = "";
                percentSPTextBox.Enabled= false;
            }
            else
            {
                percentSPTextBox.Enabled= true;
            }

            if (awakeningCheckBox.Checked)
            {               
                CheckBoxChanged(fullSPCheckBox, "SP\t150", trialSettings);
            }
            else
            {
                CheckBoxChanged(fullSPCheckBox, "SP\t100", trialSettings);
            }
            RefreshTrialSettingsDataGridView(trialSettings);
        }

        private void AwakeningCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxChanged(awakeningCheckBox, "Kakusei", trialSettings);
            RefreshTrialSettingsDataGridView(trialSettings);

            if (awakeningCheckBox.Checked)
            {
                shadowCheckBox.Checked = false;
                shadowCheckBox.Enabled = false;
                infiniteFrenzyCheckBox.Checked = false;
                infiniteFrenzyCheckBox.Enabled = false;
                ichigekiReadyCheckBox.Enabled = true;
                if (trialSettings.Contains("SP\t100"))
                {
                    trialSettings.Remove("SP\t100");
                    CheckBoxChanged(fullSPCheckBox, "SP\t150", trialSettings);
                    RefreshTrialSettingsDataGridView(trialSettings);
                }
            }
            else
            {
#pragma warning disable CS8604 // Possible null reference argument.
                if (characterCrossReference[characterSelectComboBox.SelectedItem.ToString()].IsSubclassOf(typeof(PlayableShadow)))
                {
                    shadowCheckBox.Enabled = true;
                }
#pragma warning restore CS8604 // Possible null reference argument.
                if (trialSettings.Contains("SP\t150"))
                {
                    trialSettings.Remove("SP\t150");
                    CheckBoxChanged(fullSPCheckBox, "SP\t100", trialSettings);
                    RefreshTrialSettingsDataGridView(trialSettings);
                }
            }            
        }

        private void IchigekiReadyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ichigekiReadyCheckBox.Checked)
            {
                shadowCheckBox.Enabled = false;                
            }
            else
            {
                shadowCheckBox.Enabled = true;
            }
            CheckBoxChanged(ichigekiReadyCheckBox, "Ichigeki", trialSettings);
            RefreshTrialSettingsDataGridView(trialSettings);
        }

        private void PlayerHPRecoveryCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxChanged(playerHPRecoveryCheckBox, "HPRecovery", trialSettings);
            RefreshTrialSettingsDataGridView(trialSettings);
        }

        private void EnemyHPRecoveryCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxChanged(enemyHPRecoveryCheckBox, "HPRecoveryEnemyOnly", trialSettings);
            RefreshTrialSettingsDataGridView(trialSettings);
        }

        private void PlayerPanicCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxChanged(playerPanicCheckBox, "Konran", trialSettings);
            RefreshTrialSettingsDataGridView(trialSettings);
        }

        private void PlayerShockCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxChanged(playerShockCheckBox, "Kanden", trialSettings);
            RefreshTrialSettingsDataGridView(trialSettings);
        }

        private void PersonaBrokenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxChanged(personaBrokenCheckBox, "PersonaBreak", trialSettings);
            RefreshTrialSettingsDataGridView(trialSettings);
        }

        private void EnemyFearCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (counterComboBox.SelectedIndex == 1 && enemyFearCheckBox.Checked)
            {
                counterComboBox.SelectedIndex = 3;
            }
            else
            {
                CheckBoxChanged(enemyFearCheckBox, "EnemyKyofu", trialSettings);
                RefreshTrialSettingsDataGridView(trialSettings);
            }            
        }

        private void NoMissCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxChanged(noMissCheckBox, "NoMiss", trialSettings);
            RefreshTrialSettingsDataGridView(trialSettings);
        }

        private void JunhudoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxChanged(junhudoCheckBox, "Junhudo", trialSettings);
            RefreshTrialSettingsDataGridView(trialSettings);
        }

        private void ShadowCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (shadowCheckBox.Checked)
            {
                awakeningCheckBox.Checked = false;
                awakeningCheckBox.Enabled = false;
                ichigekiReadyCheckBox.Checked = false;
                ichigekiReadyCheckBox.Enabled= false;
                infiniteFrenzyCheckBox.Enabled = true;
            }
            else
            {
                awakeningCheckBox.Enabled = true;
                ichigekiReadyCheckBox.Enabled = true;
                infiniteFrenzyCheckBox.Checked = false;
                infiniteFrenzyCheckBox.Enabled = false;
            }

            UpdateCurrentDictionary();
            CompileTrialData();
        }

        private void InfiniteFrenzyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(infiniteFrenzyCheckBox.Checked)
            {
                shadowCheckBox.Enabled = false;
            }
            else
            {
                shadowCheckBox.Enabled = true;
            }
            CheckBoxChanged(infiniteFrenzyCheckBox, "HeatUpForever", trialSettings);
            RefreshTrialSettingsDataGridView(trialSettings);
        }

        private void StagePositionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            trialSettings.Remove("Tooi");
            trialSettings.Remove("Hashi");
            trialSettings.Remove("HashiEx");

            switch (stagePositionComboBox.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    trialSettings.Add("Tooi");
                    break;
                case 2:
                    trialSettings.Add("Hashi");
                    break;
                case 3:
                    trialSettings.Add("HashiEx");
                    break;
            }
            RefreshTrialSettingsDataGridView(trialSettings);
        }

        private void EnemyBehaviorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            trialSettings.Remove("Jump");
            trialSettings.Remove("Crouch");
            trialSettings.Remove("Attack");

            switch (enemyBehaviorComboBox.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    trialSettings.Add("Jump");
                    break;
                case 2:
                    trialSettings.Add("Crouch");
                    break;
                case 3:
                    trialSettings.Add("Attack");
                    break;
            }
            RefreshTrialSettingsDataGridView(trialSettings);
        }

        private void CounterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            trialSettings.Remove("Counter Hit");
            trialSettings.Remove("Counter Hit(ND)");
            trialSettings.Remove("Fake Fatal :)");
            enemyFearCheckBox.Checked= false;
            enemyFearCheckBox.Enabled= true;

            switch (counterComboBox.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    trialSettings.Add("Counter Hit");
                    break;
                case 2:
                    trialSettings.Add("Counter Hit(ND)");
                    break;
                case 3:
                    trialSettings.Add("Fake Fatal :)");
                    enemyFearCheckBox.Checked= true;
                    enemyFearCheckBox.Enabled= false;
                    break;
            }
            RefreshTrialSettingsDataGridView(trialSettings);
        }

        private void BtnClearCombo_Click(object sender, EventArgs e)
        {
            //Clear Output
            trialSettings.Clear();
            comboInputTextBox.Clear();
            trialDataGridView.Rows.Clear();
            trialSettingsDataGridView.Rows.Clear();

            //Reset Combo Boxes
            stagePositionComboBox.SelectedIndex = 0;
            enemyBehaviorComboBox.SelectedIndex = 0;
            counterComboBox.SelectedIndex = 0;

            //Reset Settings
            percentHPTextBox.Text = "";
            percentSPTextBox.Text = "";
            burstReadyCheckBox.Checked = false;
            fullSPCheckBox.Checked = false;            
            if (infiniteFrenzyCheckBox.Enabled)
            {
                infiniteFrenzyCheckBox.Checked = false;
                infiniteFrenzyCheckBox.Enabled = false;
                shadowCheckBox.Enabled = true;
            }
            shadowCheckBox.Checked = false;
            awakeningCheckBox.Checked = false;
            playerHPRecoveryCheckBox.Checked = false;
            enemyHPRecoveryCheckBox.Checked = false;
            playerPanicCheckBox.Checked = false;
            playerShockCheckBox.Checked = false;
            personaBrokenCheckBox.Checked = false;
            enemyFearCheckBox.Checked = false;
            noMissCheckBox.Checked = false;
            junhudoCheckBox.Checked = false;

            if (characterSpecificSettingsPanel.Controls.Count > 0)
            {
                foreach (Control activeControl in characterSpecificSettingsPanel.Controls)
                {
                    switch (activeControl)
                    {
                        case System.Windows.Forms.CheckBox checkBox:
                            // Access properties of checkBox
                            checkBox.Checked = false;
                            break;
                        case ComboBox comboBox:
                            // Access properties of comboBox
                            comboBox.SelectedIndex = 0;
                            break;
                        case NumericUpDown numericUpDown:
                            // Access properties of numericUpDown
                            numericUpDown.Value = 0;
                            break;
                    }
                }
            }
        }

        private void UpdateCharacterSettings()
        {
            if(characterSpecificSettingsPanel.Controls.Count > 0)
            {
                foreach (Control activeControl in characterSpecificSettingsPanel.Controls)
                {
                    switch (activeControl)
                    {
                        case System.Windows.Forms.CheckBox checkBox:
                            switch (checkBox.Text)
                            {
                                case "Infinite Sukukaja?":
                                    if (checkBox.Checked == true)
                                    {
                                        if(!(trialSettings.Contains("Infinite Sukukaja")))
                                        {
                                            trialSettings.Add("Infinite Sukukaja");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }                                        
                                    }
                                    else
                                    {
                                        if (trialSettings.Contains("Infinite Sukukaja"))
                                        {
                                            trialSettings.Remove("Infinite Sukukaja");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                    }
                                    break;
                                case "Fire Break Fast Recovery?":
                                    if (checkBox.Checked == true)
                                    {
                                        if (!(trialSettings.Contains("Fire Break Fast Recovery")))
                                        {
                                            trialSettings.Add("Fire Break Fast Recovery");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                    }
                                    else
                                    {
                                        if (trialSettings.Contains("Fire Break Fast Recovery"))
                                        {
                                            trialSettings.Remove("Fire Break Fast Recovery");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                    }
                                    break;
                                case "Fix Item 1?":
                                    if (checkBox.Checked == true)
                                    {
                                        if (!(trialSettings.Contains("Fix Item 1")))
                                        {
                                            trialSettings.Add("Fix Item 1");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                    }
                                    else
                                    {
                                        if (trialSettings.Contains("Fix Item 1"))
                                        {
                                            trialSettings.Remove("Fix Item 1");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                    }
                                    break;
                                case "Fix Item 2?":
                                    if (checkBox.Checked == true)
                                    {
                                        if (!(trialSettings.Contains("Fix Item 2")))
                                        {
                                            trialSettings.Add("Fix Item 2");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                    }
                                    else
                                    {
                                        if (trialSettings.Contains("Fix Item 2"))
                                        {
                                            trialSettings.Remove("Fix Item 2");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                    }
                                    break;
                                case "Mystery Teddie SP Fast Recovery?":
                                    if (checkBox.Checked == true)
                                    {
                                        if (!(trialSettings.Contains("Mystery Teddie SP Fast Recovery")))
                                        {
                                            trialSettings.Add("Mystery Teddie SP Fast Recovery");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                    }
                                    else
                                    {
                                        if (trialSettings.Contains("Mystery Teddie SP Fast Recovery"))
                                        {
                                            trialSettings.Remove("Mystery Teddie SP Fast Recovery");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                    }
                                    break;
                                case "Orgia Fast Recovery?":
                                    if (checkBox.Checked == true)
                                    {
                                        if (!(trialSettings.Contains("Orgia Fast Recovery")))
                                        {
                                            trialSettings.Add("Orgia Fast Recovery");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                    }
                                    else
                                    {
                                        if (trialSettings.Contains("Orgia Fast Recovery"))
                                        {
                                            trialSettings.Remove("Orgia Fast Recovery");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                    }
                                    break;
                                case "Ammo Fast Recovery?":
                                    if (checkBox.Checked == true)
                                    {
                                        if (!(trialSettings.Contains("Ammo Fast Recovery")))
                                        {
                                            trialSettings.Add("Ammo Fast Recovery");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                    }
                                    else
                                    {
                                        if (trialSettings.Contains("Ammo Fast Recovery"))
                                        {
                                            trialSettings.Remove("Ammo Fast Recovery");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                    }
                                    break;
                                case "Thunder Fists Always On?":
                                    if (checkBox.Checked == true)
                                    {
                                        if (!(trialSettings.Contains("Thunder Fists Always On")))
                                        {
                                            trialSettings.Add("Thunder Fists Always On");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                    }
                                    else
                                    {
                                        if (trialSettings.Contains("Thunder Fists Always On"))
                                        {
                                            trialSettings.Remove("Thunder Fists Always On");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                    }
                                    break;
                                case "Titanomachia Fast Recovery?":
                                    if (checkBox.Checked == true)
                                    {
                                        if (!(trialSettings.Contains("Titanomachia Fast Recovery")))
                                        {
                                            trialSettings.Add("Titanomachia Fast Recovery");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                    }
                                    else
                                    {
                                        if (trialSettings.Contains("Titanomachia Fast Recovery"))
                                        {
                                            trialSettings.Remove("Titanomachia Fast Recovery");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                    }
                                    break;
                                case "Full Run Count?":                                                                        

                                    if (juPoints == 55)
                                    {
                                        juFullCount = true;
                                        checkBox.Checked = true;
                                    }
                                    else if (juPoints < 55)
                                    {
                                        if (checkBox.Enabled != true)
                                        {
                                            checkBox.Enabled = true;
                                        }
                                        
                                        juFullCount = false;

                                        if (checkBox.Checked)
                                        {
                                            juFullCount = true;
                                        }
                                    }

                                    if (juFullCount)
                                    {
                                        if (!(trialSettings.Contains("Full Run Count")))
                                        {
                                            trialSettings.Add("Full Run Count");
                                            trialSettings.Remove($"Junpei Score: {juPoints}");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                    }
                                    else
                                    {
                                        if (trialSettings.Contains("Full Run Count"))
                                        {
                                            trialSettings.Remove("Full Run Count");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }                                        
                                    }

                                    break;
                                case "Never Activate Victory Cry?":                                    
                                    if (checkBox.Checked == true)
                                    {
                                        if (!(trialSettings.Contains("Never Activate Victory Cry")))
                                        {
                                            trialSettings.Add("Never Activate Victory Cry");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                    }
                                    else
                                    {
                                        if (trialSettings.Contains("Never Activate Victory Cry"))
                                        {
                                            trialSettings.Remove("Never Activate Victory Cry");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                    }
                                    break;
                                case "Analyze Always On?":
                                    if (checkBox.Checked == true)
                                    {
                                        if (!(trialSettings.Contains("Analyze Always On")))
                                        {
                                            trialSettings.Add("Analyze Always On");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                    }
                                    else
                                    {
                                        if (trialSettings.Contains("Analyze Always On"))
                                        {
                                            trialSettings.Remove("Analyze Always On");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                    }
                                    break;
                                case "Tetrakarn Fast Recovery?":
                                    if (checkBox.Checked == true)
                                    {
                                        if (!(trialSettings.Contains("Tetrakarn Fast Recovery")))
                                        {
                                            trialSettings.Add("Tetrakarn Fast Recovery");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                    }
                                    else
                                    {
                                        if (trialSettings.Contains("Tetrakarn Fast Recovery"))
                                        {
                                            trialSettings.Remove("Tetrakarn Fast Recovery");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                    }
                                    break;
                                case "Risette Field Fast Recovery?":
                                    if (checkBox.Checked == true)
                                    {
                                        if (!(trialSettings.Contains("Risette Field Fast Recovery")))
                                        {
                                            trialSettings.Add("Risette Field Fast Recovery");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                    }
                                    else
                                    {
                                        if (trialSettings.Contains("Risette Field Fast Recovery"))
                                        {
                                            trialSettings.Remove("Risette Field Fast Recovery");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                    }
                                    break;
                                case "Koromaru Fast Recovery?":
                                    if (checkBox.Checked == true)
                                    {
                                        if (!(trialSettings.Contains("Koromaru Fast Recovery")))
                                        {
                                            trialSettings.Add("Koromaru Fast Recovery");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                    }
                                    else
                                    {
                                        if (trialSettings.Contains("Koromaru Fast Recovery"))
                                        {
                                            trialSettings.Remove("Koromaru Fast Recovery");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                    }
                                    break;
                                case "Heat Riser Always On?":
                                    if (checkBox.Checked == true)
                                    {
                                        if (!(trialSettings.Contains("Heat Riser Always On")))
                                        {
                                            trialSettings.Add("Heat Riser Always On");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                    }
                                    else
                                    {
                                        if (trialSettings.Contains("Heat Riser Always On"))
                                        {
                                            trialSettings.Remove("Heat Riser Always On");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                    }
                                    break;
                                case "Magatsu Mandala Always On?":
                                    if (checkBox.Checked == true)
                                    {
                                        if (!(trialSettings.Contains("Magatsu Mandala Always On")))
                                        {
                                            trialSettings.Add("Magatsu Mandala Always On");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                    }
                                    else
                                    {
                                        if (trialSettings.Contains("Magatsu Mandala Always On"))
                                        {
                                            trialSettings.Remove("Magatsu Mandala Always On");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                    }
                                    break;
                            }
                            break;
                        case ComboBox comboBox:

                            List<string> comboBoxItems = new();

                            foreach (string item in comboBox.Items)
                            {
                                comboBoxItems.Add(item.ToString());
                            }

                            if (comboBoxItems.SequenceEqual(chiesItems))
                            {
                                switch (comboBox.SelectedItem)
                                {
                                    case "Default":
                                        trialSettings.Remove("Chie Charge Level 1");
                                        trialSettings.Remove("Chie Charge Level 2");
                                        trialSettings.Remove("Chie Charge Level 3");

                                        if (!(trialSettings.Contains("Chie Charge Level 0")))
                                        {
                                            trialSettings.Add("Chie Charge Level 0");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Level 1":
                                        trialSettings.Remove("Chie Charge Level 0");
                                        trialSettings.Remove("Chie Charge Level 2");
                                        trialSettings.Remove("Chie Charge Level 3");

                                        if(!(trialSettings.Contains("Chie Charge Level 1")))
                                        {
                                            trialSettings.Add("Chie Charge Level 1");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }                                                                                
                                        break;
                                    case "Level 2":
                                        trialSettings.Remove("Chie Charge Level 0");
                                        trialSettings.Remove("Chie Charge Level 1");
                                        trialSettings.Remove("Chie Charge Level 3");

                                        if (!(trialSettings.Contains("Chie Charge Level 2")))
                                        {
                                            trialSettings.Add("Chie Charge Level 2");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Level 3":
                                        trialSettings.Remove("Chie Charge Level 0");
                                        trialSettings.Remove("Chie Charge Level 1");
                                        trialSettings.Remove("Chie Charge Level 2");

                                        if (!(trialSettings.Contains("Chie Charge Level 3")))
                                        {
                                            trialSettings.Add("Chie Charge Level 3");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                }
                            }
                            else if (comboBoxItems.SequenceEqual(yukikosItems))
                            {
                                switch (comboBox.SelectedItem)
                                {
                                    case "Default":
                                        trialSettings.Remove("Yukiko Charge Level 1");
                                        trialSettings.Remove("Yukiko Charge Level 2");
                                        trialSettings.Remove("Yukiko Charge Level 3");
                                        
                                        trialSettings.Remove("Yukiko Charge Level 4");
                                        trialSettings.Remove("Yukiko Charge Level 5");
                                        trialSettings.Remove("Yukiko Charge Level 6");

                                        trialSettings.Remove("Yukiko Charge Level 7");
                                        trialSettings.Remove("Yukiko Charge Level 8");
                                        trialSettings.Remove("Yukiko Charge Level 9");

                                        if (!(trialSettings.Contains("Yukiko Charge Level 0")))
                                        {
                                            trialSettings.Add("Yukiko Charge Level 0");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Level 1":
                                        trialSettings.Remove("Yukiko Charge Level 0");
                                        trialSettings.Remove("Yukiko Charge Level 2");
                                        trialSettings.Remove("Yukiko Charge Level 3");

                                        trialSettings.Remove("Yukiko Charge Level 4");
                                        trialSettings.Remove("Yukiko Charge Level 5");
                                        trialSettings.Remove("Yukiko Charge Level 6");

                                        trialSettings.Remove("Yukiko Charge Level 7");
                                        trialSettings.Remove("Yukiko Charge Level 8");
                                        trialSettings.Remove("Yukiko Charge Level 9");

                                        if (!(trialSettings.Contains("Yukiko Charge Level 1")))
                                        {
                                            trialSettings.Add("Yukiko Charge Level 1");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Level 2":
                                        trialSettings.Remove("Yukiko Charge Level 0");
                                        trialSettings.Remove("Yukiko Charge Level 1");
                                        trialSettings.Remove("Yukiko Charge Level 3");

                                        trialSettings.Remove("Yukiko Charge Level 4");
                                        trialSettings.Remove("Yukiko Charge Level 5");
                                        trialSettings.Remove("Yukiko Charge Level 6");

                                        trialSettings.Remove("Yukiko Charge Level 7");
                                        trialSettings.Remove("Yukiko Charge Level 8");
                                        trialSettings.Remove("Yukiko Charge Level 9");

                                        if (!(trialSettings.Contains("Yukiko Charge Level 2")))
                                        {
                                            trialSettings.Add("Yukiko Charge Level 2");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Level 3":
                                        trialSettings.Remove("Yukiko Charge Level 0");
                                        trialSettings.Remove("Yukiko Charge Level 1");
                                        trialSettings.Remove("Yukiko Charge Level 2");

                                        trialSettings.Remove("Yukiko Charge Level 4");
                                        trialSettings.Remove("Yukiko Charge Level 5");
                                        trialSettings.Remove("Yukiko Charge Level 6");

                                        trialSettings.Remove("Yukiko Charge Level 7");
                                        trialSettings.Remove("Yukiko Charge Level 8");
                                        trialSettings.Remove("Yukiko Charge Level 9");

                                        if (!(trialSettings.Contains("Yukiko Charge Level 3")))
                                        {
                                            trialSettings.Add("Yukiko Charge Level 3");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Level 4":
                                        trialSettings.Remove("Yukiko Charge Level 0");
                                        trialSettings.Remove("Yukiko Charge Level 1");
                                        trialSettings.Remove("Yukiko Charge Level 2");

                                        trialSettings.Remove("Yukiko Charge Level 3");
                                        trialSettings.Remove("Yukiko Charge Level 5");
                                        trialSettings.Remove("Yukiko Charge Level 6");

                                        trialSettings.Remove("Yukiko Charge Level 7");
                                        trialSettings.Remove("Yukiko Charge Level 8");
                                        trialSettings.Remove("Yukiko Charge Level 9");

                                        if (!(trialSettings.Contains("Yukiko Charge Level 4")))
                                        {
                                            trialSettings.Add("Yukiko Charge Level 4");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Level 5":
                                        trialSettings.Remove("Yukiko Charge Level 0");
                                        trialSettings.Remove("Yukiko Charge Level 1");
                                        trialSettings.Remove("Yukiko Charge Level 2");

                                        trialSettings.Remove("Yukiko Charge Level 3");
                                        trialSettings.Remove("Yukiko Charge Level 4");
                                        trialSettings.Remove("Yukiko Charge Level 6");

                                        trialSettings.Remove("Yukiko Charge Level 7");
                                        trialSettings.Remove("Yukiko Charge Level 8");
                                        trialSettings.Remove("Yukiko Charge Level 9");

                                        if (!(trialSettings.Contains("Yukiko Charge Level 5")))
                                        {
                                            trialSettings.Add("Yukiko Charge Level 5");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Level 6":
                                        trialSettings.Remove("Yukiko Charge Level 0");
                                        trialSettings.Remove("Yukiko Charge Level 1");
                                        trialSettings.Remove("Yukiko Charge Level 2");

                                        trialSettings.Remove("Yukiko Charge Level 3");
                                        trialSettings.Remove("Yukiko Charge Level 4");
                                        trialSettings.Remove("Yukiko Charge Level 5");

                                        trialSettings.Remove("Yukiko Charge Level 7");
                                        trialSettings.Remove("Yukiko Charge Level 8");
                                        trialSettings.Remove("Yukiko Charge Level 9");

                                        if (!(trialSettings.Contains("Yukiko Charge Level 6")))
                                        {
                                            trialSettings.Add("Yukiko Charge Level 6");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Level 7":
                                        trialSettings.Remove("Yukiko Charge Level 0");
                                        trialSettings.Remove("Yukiko Charge Level 1");
                                        trialSettings.Remove("Yukiko Charge Level 2");

                                        trialSettings.Remove("Yukiko Charge Level 3");
                                        trialSettings.Remove("Yukiko Charge Level 4");
                                        trialSettings.Remove("Yukiko Charge Level 5");

                                        trialSettings.Remove("Yukiko Charge Level 6");
                                        trialSettings.Remove("Yukiko Charge Level 8");
                                        trialSettings.Remove("Yukiko Charge Level 9");

                                        if (!(trialSettings.Contains("Yukiko Charge Level 7")))
                                        {
                                            trialSettings.Add("Yukiko Charge Level 7");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Level 8":
                                        trialSettings.Remove("Yukiko Charge Level 0");
                                        trialSettings.Remove("Yukiko Charge Level 1");
                                        trialSettings.Remove("Yukiko Charge Level 2");

                                        trialSettings.Remove("Yukiko Charge Level 3");
                                        trialSettings.Remove("Yukiko Charge Level 4");
                                        trialSettings.Remove("Yukiko Charge Level 5");

                                        trialSettings.Remove("Yukiko Charge Level 6");
                                        trialSettings.Remove("Yukiko Charge Level 7");
                                        trialSettings.Remove("Yukiko Charge Level 9");

                                        if (!(trialSettings.Contains("Yukiko Charge Level 8")))
                                        {
                                            trialSettings.Add("Yukiko Charge Level 8");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Level 9":
                                        trialSettings.Remove("Yukiko Charge Level 0");
                                        trialSettings.Remove("Yukiko Charge Level 1");
                                        trialSettings.Remove("Yukiko Charge Level 2");

                                        trialSettings.Remove("Yukiko Charge Level 3");
                                        trialSettings.Remove("Yukiko Charge Level 4");
                                        trialSettings.Remove("Yukiko Charge Level 5");

                                        trialSettings.Remove("Yukiko Charge Level 6");
                                        trialSettings.Remove("Yukiko Charge Level 7");
                                        trialSettings.Remove("Yukiko Charge Level 8");

                                        if (!(trialSettings.Contains("Yukiko Charge Level 9")))
                                        {
                                            trialSettings.Add("Yukiko Charge Level 9");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                }
                            }
                            else if (comboBoxItems.SequenceEqual(teddiesItems))
                            {
                                switch (comboBox.SelectedItem)
                                {
                                    case "Default":
                                        trialSettings.Remove("Teddie Item MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item Dr. Salt NEO");
                                        trialSettings.Remove("Teddie Item Heavy-Armor Agni");

                                        trialSettings.Remove("Teddie Item Mystery Food X");
                                        trialSettings.Remove("Teddie Item Smart Bomb");
                                        trialSettings.Remove("Teddie Item Turbo Recon Dyaus");

                                        trialSettings.Remove("Teddie Item Oil Drum");
                                        trialSettings.Remove("Teddie Item Motorcycle Key");
                                        trialSettings.Remove("Teddie Item Firecracker");

                                        trialSettings.Remove("Teddie Item Dry Ice");
                                        trialSettings.Remove("Teddie Item Vanish Ball");
                                        trialSettings.Remove("Teddie Item Mobile Model Varna");

                                        trialSettings.Remove("Teddie Item Muscle Drink");
                                        trialSettings.Remove("Teddie Item Pinwheel");
                                        trialSettings.Remove("Teddie Item D-Type Prithvi");

                                        trialSettings.Remove("Teddie Item Ball Lightning");
                                        trialSettings.Remove("Teddie Item Amagiya Bucket");

                                        if (!(trialSettings.Contains("Teddie Item 0")))
                                        {
                                            trialSettings.Add("Teddie Item 0");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "MF-06S Brahman":
                                        trialSettings.Remove("Teddie Item 0");
                                        trialSettings.Remove("Teddie Item Dr. Salt NEO");
                                        trialSettings.Remove("Teddie Item Heavy-Armor Agni");

                                        trialSettings.Remove("Teddie Item Mystery Food X");
                                        trialSettings.Remove("Teddie Item Smart Bomb");
                                        trialSettings.Remove("Teddie Item Turbo Recon Dyaus");

                                        trialSettings.Remove("Teddie Item Oil Drum");
                                        trialSettings.Remove("Teddie Item Motorcycle Key");
                                        trialSettings.Remove("Teddie Item Firecracker");

                                        trialSettings.Remove("Teddie Item Dry Ice");
                                        trialSettings.Remove("Teddie Item Vanish Ball");
                                        trialSettings.Remove("Teddie Item Mobile Model Varna");

                                        trialSettings.Remove("Teddie Item Muscle Drink");
                                        trialSettings.Remove("Teddie Item Pinwheel");
                                        trialSettings.Remove("Teddie Item D-Type Prithvi");

                                        trialSettings.Remove("Teddie Item Ball Lightning");
                                        trialSettings.Remove("Teddie Item Amagiya Bucket");

                                        if (!(trialSettings.Contains("Teddie Item MF-06S Brahman")))
                                        {
                                            trialSettings.Add("Teddie Item MF-06S Brahman");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Dr. Salt Neo":
                                        trialSettings.Remove("Teddie Item 0");
                                        trialSettings.Remove("Teddie Item MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item Heavy-Armor Agni");

                                        trialSettings.Remove("Teddie Item Mystery Food X");
                                        trialSettings.Remove("Teddie Item Smart Bomb");
                                        trialSettings.Remove("Teddie Item Turbo Recon Dyaus");

                                        trialSettings.Remove("Teddie Item Oil Drum");
                                        trialSettings.Remove("Teddie Item Motorcycle Key");
                                        trialSettings.Remove("Teddie Item Firecracker");

                                        trialSettings.Remove("Teddie Item Dry Ice");
                                        trialSettings.Remove("Teddie Item Vanish Ball");
                                        trialSettings.Remove("Teddie Item Mobile Model Varna");

                                        trialSettings.Remove("Teddie Item Muscle Drink");
                                        trialSettings.Remove("Teddie Item Pinwheel");
                                        trialSettings.Remove("Teddie Item D-Type Prithvi");

                                        trialSettings.Remove("Teddie Item Ball Lightning");
                                        trialSettings.Remove("Teddie Item Amagiya Bucket");

                                        if (!(trialSettings.Contains("Teddie Item Dr. Salt NEO")))
                                        {
                                            trialSettings.Add("Teddie Item Dr. Salt NEO");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Heavy-Armor Agni":
                                        trialSettings.Remove("Teddie Item 0");
                                        trialSettings.Remove("Teddie Item MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item Dr. Salt NEO");

                                        trialSettings.Remove("Teddie Item Mystery Food X");
                                        trialSettings.Remove("Teddie Item Smart Bomb");
                                        trialSettings.Remove("Teddie Item Turbo Recon Dyaus");

                                        trialSettings.Remove("Teddie Item Oil Drum");
                                        trialSettings.Remove("Teddie Item Motorcycle Key");
                                        trialSettings.Remove("Teddie Item Firecracker");

                                        trialSettings.Remove("Teddie Item Dry Ice");
                                        trialSettings.Remove("Teddie Item Vanish Ball");
                                        trialSettings.Remove("Teddie Item Mobile Model Varna");

                                        trialSettings.Remove("Teddie Item Muscle Drink");
                                        trialSettings.Remove("Teddie Item Pinwheel");
                                        trialSettings.Remove("Teddie Item D-Type Prithvi");

                                        trialSettings.Remove("Teddie Item Ball Lightning");
                                        trialSettings.Remove("Teddie Item Amagiya Bucket");

                                        if (!(trialSettings.Contains("Teddie Item Heavy-Armor Agni")))
                                        {
                                            trialSettings.Add("Teddie Item Heavy-Armor Agni");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Mystery Food X":
                                        trialSettings.Remove("Teddie Item 0");
                                        trialSettings.Remove("Teddie Item MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item Dr. Salt NEO");

                                        trialSettings.Remove("Teddie Item Heavy-Armor Agni");
                                        trialSettings.Remove("Teddie Item Smart Bomb");
                                        trialSettings.Remove("Teddie Item Turbo Recon Dyaus");

                                        trialSettings.Remove("Teddie Item Oil Drum");
                                        trialSettings.Remove("Teddie Item Motorcycle Key");
                                        trialSettings.Remove("Teddie Item Firecracker");

                                        trialSettings.Remove("Teddie Item Dry Ice");
                                        trialSettings.Remove("Teddie Item Vanish Ball");
                                        trialSettings.Remove("Teddie Item Mobile Model Varna");

                                        trialSettings.Remove("Teddie Item Muscle Drink");
                                        trialSettings.Remove("Teddie Item Pinwheel");
                                        trialSettings.Remove("Teddie Item D-Type Prithvi");

                                        trialSettings.Remove("Teddie Item Ball Lightning");
                                        trialSettings.Remove("Teddie Item Amagiya Bucket");

                                        if (!(trialSettings.Contains("Teddie Item Mystery Food X")))
                                        {
                                            trialSettings.Add("Teddie Item Mystery Food X");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Smart Bomb":
                                        trialSettings.Remove("Teddie Item 0");
                                        trialSettings.Remove("Teddie Item MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item Dr. Salt NEO");

                                        trialSettings.Remove("Teddie Item Heavy-Armor Agni");
                                        trialSettings.Remove("Teddie Item Mystery Food X");
                                        trialSettings.Remove("Teddie Item Turbo Recon Dyaus");

                                        trialSettings.Remove("Teddie Item Oil Drum");
                                        trialSettings.Remove("Teddie Item Motorcycle Key");
                                        trialSettings.Remove("Teddie Item Firecracker");

                                        trialSettings.Remove("Teddie Item Dry Ice");
                                        trialSettings.Remove("Teddie Item Vanish Ball");
                                        trialSettings.Remove("Teddie Item Mobile Model Varna");

                                        trialSettings.Remove("Teddie Item Muscle Drink");
                                        trialSettings.Remove("Teddie Item Pinwheel");
                                        trialSettings.Remove("Teddie Item D-Type Prithvi");

                                        trialSettings.Remove("Teddie Item Ball Lightning");
                                        trialSettings.Remove("Teddie Item Amagiya Bucket");

                                        if (!(trialSettings.Contains("Teddie Item Smart Bomb")))
                                        {
                                            trialSettings.Add("Teddie Item Smart Bomb");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Turbo Recon Dyaus":
                                        trialSettings.Remove("Teddie Item 0");
                                        trialSettings.Remove("Teddie Item MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item Dr. Salt NEO");

                                        trialSettings.Remove("Teddie Item Heavy-Armor Agni");
                                        trialSettings.Remove("Teddie Item Mystery Food X");
                                        trialSettings.Remove("Teddie Item Smart Bomb");

                                        trialSettings.Remove("Teddie Item Oil Drum");
                                        trialSettings.Remove("Teddie Item Motorcycle Key");
                                        trialSettings.Remove("Teddie Item Firecracker");

                                        trialSettings.Remove("Teddie Item Dry Ice");
                                        trialSettings.Remove("Teddie Item Vanish Ball");
                                        trialSettings.Remove("Teddie Item Mobile Model Varna");

                                        trialSettings.Remove("Teddie Item Muscle Drink");
                                        trialSettings.Remove("Teddie Item Pinwheel");
                                        trialSettings.Remove("Teddie Item D-Type Prithvi");

                                        trialSettings.Remove("Teddie Item Ball Lightning");
                                        trialSettings.Remove("Teddie Item Amagiya Bucket");

                                        if (!(trialSettings.Contains("Teddie Item Turbo Recon Dyaus")))
                                        {
                                            trialSettings.Add("Teddie Item Turbo Recon Dyaus");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Oil Drum":
                                        trialSettings.Remove("Teddie Item 0");
                                        trialSettings.Remove("Teddie Item MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item Dr. Salt NEO");

                                        trialSettings.Remove("Teddie Item Heavy-Armor Agni");
                                        trialSettings.Remove("Teddie Item Mystery Food X");
                                        trialSettings.Remove("Teddie Item Smart Bomb");

                                        trialSettings.Remove("Teddie Item Turbo Recon Dyaus");
                                        trialSettings.Remove("Teddie Item Motorcycle Key");
                                        trialSettings.Remove("Teddie Item Firecracker");

                                        trialSettings.Remove("Teddie Item Dry Ice");
                                        trialSettings.Remove("Teddie Item Vanish Ball");
                                        trialSettings.Remove("Teddie Item Mobile Model Varna");

                                        trialSettings.Remove("Teddie Item Muscle Drink");
                                        trialSettings.Remove("Teddie Item Pinwheel");
                                        trialSettings.Remove("Teddie Item D-Type Prithvi");

                                        trialSettings.Remove("Teddie Item Ball Lightning");
                                        trialSettings.Remove("Teddie Item Amagiya Bucket");

                                        if (!(trialSettings.Contains("Teddie Item Oil Drum")))
                                        {
                                            trialSettings.Add("Teddie Item Oil Drum");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Motorcycle Key":
                                        trialSettings.Remove("Teddie Item 0");
                                        trialSettings.Remove("Teddie Item MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item Dr. Salt NEO");

                                        trialSettings.Remove("Teddie Item Heavy-Armor Agni");
                                        trialSettings.Remove("Teddie Item Mystery Food X");
                                        trialSettings.Remove("Teddie Item Smart Bomb");

                                        trialSettings.Remove("Teddie Item Turbo Recon Dyaus");
                                        trialSettings.Remove("Teddie Item Oil Drum");
                                        trialSettings.Remove("Teddie Item Firecracker");

                                        trialSettings.Remove("Teddie Item Dry Ice");
                                        trialSettings.Remove("Teddie Item Vanish Ball");
                                        trialSettings.Remove("Teddie Item Mobile Model Varna");

                                        trialSettings.Remove("Teddie Item Muscle Drink");
                                        trialSettings.Remove("Teddie Item Pinwheel");
                                        trialSettings.Remove("Teddie Item D-Type Prithvi");

                                        trialSettings.Remove("Teddie Item Ball Lightning");
                                        trialSettings.Remove("Teddie Item Amagiya Bucket");

                                        if (!(trialSettings.Contains("Teddie Item Motorcycle Key")))
                                        {
                                            trialSettings.Add("Teddie Item Motorcycle Key");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Firecracker":
                                        trialSettings.Remove("Teddie Item 0");
                                        trialSettings.Remove("Teddie Item MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item Dr. Salt NEO");

                                        trialSettings.Remove("Teddie Item Heavy-Armor Agni");
                                        trialSettings.Remove("Teddie Item Mystery Food X");
                                        trialSettings.Remove("Teddie Item Smart Bomb");

                                        trialSettings.Remove("Teddie Item Turbo Recon Dyaus");
                                        trialSettings.Remove("Teddie Item Oil Drum");
                                        trialSettings.Remove("Teddie Item Motorcycle Key");

                                        trialSettings.Remove("Teddie Item Dry Ice");
                                        trialSettings.Remove("Teddie Item Vanish Ball");
                                        trialSettings.Remove("Teddie Item Mobile Model Varna");

                                        trialSettings.Remove("Teddie Item Muscle Drink");
                                        trialSettings.Remove("Teddie Item Pinwheel");
                                        trialSettings.Remove("Teddie Item D-Type Prithvi");

                                        trialSettings.Remove("Teddie Item Ball Lightning");
                                        trialSettings.Remove("Teddie Item Amagiya Bucket");

                                        if (!(trialSettings.Contains("Teddie Item Firecracker")))
                                        {
                                            trialSettings.Add("Teddie Item Firecracker");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;

                                    case "Dry Ice":
                                        trialSettings.Remove("Teddie Item 0");
                                        trialSettings.Remove("Teddie Item MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item Dr. Salt NEO");

                                        trialSettings.Remove("Teddie Item Heavy-Armor Agni");
                                        trialSettings.Remove("Teddie Item Mystery Food X");
                                        trialSettings.Remove("Teddie Item Smart Bomb");

                                        trialSettings.Remove("Teddie Item Turbo Recon Dyaus");
                                        trialSettings.Remove("Teddie Item Oil Drum");
                                        trialSettings.Remove("Teddie Item Motorcycle Key");

                                        trialSettings.Remove("Teddie Item Firecracker");
                                        trialSettings.Remove("Teddie Item Vanish Ball");
                                        trialSettings.Remove("Teddie Item Mobile Model Varna");

                                        trialSettings.Remove("Teddie Item Muscle Drink");
                                        trialSettings.Remove("Teddie Item Pinwheel");
                                        trialSettings.Remove("Teddie Item D-Type Prithvi");

                                        trialSettings.Remove("Teddie Item Ball Lightning");
                                        trialSettings.Remove("Teddie Item Amagiya Bucket");

                                        if (!(trialSettings.Contains("Teddie Item Dry Ice")))
                                        {
                                            trialSettings.Add("Teddie Item Dry Ice");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;

                                    case "Vanish Ball":
                                        trialSettings.Remove("Teddie Item 0");
                                        trialSettings.Remove("Teddie Item MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item Dr. Salt NEO");

                                        trialSettings.Remove("Teddie Item Heavy-Armor Agni");
                                        trialSettings.Remove("Teddie Item Mystery Food X");
                                        trialSettings.Remove("Teddie Item Smart Bomb");

                                        trialSettings.Remove("Teddie Item Turbo Recon Dyaus");
                                        trialSettings.Remove("Teddie Item Oil Drum");
                                        trialSettings.Remove("Teddie Item Motorcycle Key");

                                        trialSettings.Remove("Teddie Item Firecracker");
                                        trialSettings.Remove("Teddie Item Dry Ice");
                                        trialSettings.Remove("Teddie Item Mobile Model Varna");

                                        trialSettings.Remove("Teddie Item Muscle Drink");
                                        trialSettings.Remove("Teddie Item Pinwheel");
                                        trialSettings.Remove("Teddie Item D-Type Prithvi");

                                        trialSettings.Remove("Teddie Item Ball Lightning");
                                        trialSettings.Remove("Teddie Item Amagiya Bucket");

                                        if (!(trialSettings.Contains("Teddie Item Vanish Ball")))
                                        {
                                            trialSettings.Add("Teddie Item Vanish Ball");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;

                                    case "Mobile Model Varna":
                                        trialSettings.Remove("Teddie Item 0");
                                        trialSettings.Remove("Teddie Item MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item Dr. Salt NEO");

                                        trialSettings.Remove("Teddie Item Heavy-Armor Agni");
                                        trialSettings.Remove("Teddie Item Mystery Food X");
                                        trialSettings.Remove("Teddie Item Smart Bomb");

                                        trialSettings.Remove("Teddie Item Turbo Recon Dyaus");
                                        trialSettings.Remove("Teddie Item Oil Drum");
                                        trialSettings.Remove("Teddie Item Motorcycle Key");

                                        trialSettings.Remove("Teddie Item Firecracker");
                                        trialSettings.Remove("Teddie Item Dry Ice");
                                        trialSettings.Remove("Teddie Item Vanish Ball");

                                        trialSettings.Remove("Teddie Item Muscle Drink");
                                        trialSettings.Remove("Teddie Item Pinwheel");
                                        trialSettings.Remove("Teddie Item D-Type Prithvi");

                                        trialSettings.Remove("Teddie Item Ball Lightning");
                                        trialSettings.Remove("Teddie Item Amagiya Bucket");

                                        if (!(trialSettings.Contains("Teddie Item Mobile Model Varna")))
                                        {
                                            trialSettings.Add("Teddie Item Mobile Model Varna");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;

                                    case "Muscle Drink":
                                        trialSettings.Remove("Teddie Item 0");
                                        trialSettings.Remove("Teddie Item MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item Dr. Salt NEO");

                                        trialSettings.Remove("Teddie Item Heavy-Armor Agni");
                                        trialSettings.Remove("Teddie Item Mystery Food X");
                                        trialSettings.Remove("Teddie Item Smart Bomb");

                                        trialSettings.Remove("Teddie Item Turbo Recon Dyaus");
                                        trialSettings.Remove("Teddie Item Oil Drum");
                                        trialSettings.Remove("Teddie Item Motorcycle Key");

                                        trialSettings.Remove("Teddie Item Firecracker");
                                        trialSettings.Remove("Teddie Item Dry Ice");
                                        trialSettings.Remove("Teddie Item Vanish Ball");

                                        trialSettings.Remove("Teddie Item Mobile Model Varna");
                                        trialSettings.Remove("Teddie Item Pinwheel");
                                        trialSettings.Remove("Teddie Item D-Type Prithvi");

                                        trialSettings.Remove("Teddie Item Ball Lightning");
                                        trialSettings.Remove("Teddie Item Amagiya Bucket");

                                        if (!(trialSettings.Contains("Teddie Item Muscle Drink")))
                                        {
                                            trialSettings.Add("Teddie Item Muscle Drink");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;

                                    case "Pinwheel":
                                        trialSettings.Remove("Teddie Item 0");
                                        trialSettings.Remove("Teddie Item MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item Dr. Salt NEO");

                                        trialSettings.Remove("Teddie Item Heavy-Armor Agni");
                                        trialSettings.Remove("Teddie Item Mystery Food X");
                                        trialSettings.Remove("Teddie Item Smart Bomb");

                                        trialSettings.Remove("Teddie Item Turbo Recon Dyaus");
                                        trialSettings.Remove("Teddie Item Oil Drum");
                                        trialSettings.Remove("Teddie Item Motorcycle Key");

                                        trialSettings.Remove("Teddie Item Firecracker");
                                        trialSettings.Remove("Teddie Item Dry Ice");
                                        trialSettings.Remove("Teddie Item Vanish Ball");

                                        trialSettings.Remove("Teddie Item Mobile Model Varna");
                                        trialSettings.Remove("Teddie Item Muscle Drink");
                                        trialSettings.Remove("Teddie Item D-Type Prithvi");

                                        trialSettings.Remove("Teddie Item Ball Lightning");
                                        trialSettings.Remove("Teddie Item Amagiya Bucket");

                                        if (!(trialSettings.Contains("Teddie Item Pinwheel")))
                                        {
                                            trialSettings.Add("Teddie Item Pinwheel");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;

                                    case "D-Type Prithvi":
                                        trialSettings.Remove("Teddie Item 0");
                                        trialSettings.Remove("Teddie Item MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item Dr. Salt NEO");

                                        trialSettings.Remove("Teddie Item Heavy-Armor Agni");
                                        trialSettings.Remove("Teddie Item Mystery Food X");
                                        trialSettings.Remove("Teddie Item Smart Bomb");

                                        trialSettings.Remove("Teddie Item Turbo Recon Dyaus");
                                        trialSettings.Remove("Teddie Item Oil Drum");
                                        trialSettings.Remove("Teddie Item Motorcycle Key");

                                        trialSettings.Remove("Teddie Item Firecracker");
                                        trialSettings.Remove("Teddie Item Dry Ice");
                                        trialSettings.Remove("Teddie Item Vanish Ball");

                                        trialSettings.Remove("Teddie Item Mobile Model Varna");
                                        trialSettings.Remove("Teddie Item Muscle Drink");
                                        trialSettings.Remove("Teddie Item Pinwheel");

                                        trialSettings.Remove("Teddie Item Ball Lightning");
                                        trialSettings.Remove("Teddie Item Amagiya Bucket");

                                        if (!(trialSettings.Contains("Teddie Item D-Type Prithvi")))
                                        {
                                            trialSettings.Add("Teddie Item D-Type Prithvi");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;

                                    case "Ball Lightning":
                                        trialSettings.Remove("Teddie Item 0");
                                        trialSettings.Remove("Teddie Item MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item Dr. Salt NEO");

                                        trialSettings.Remove("Teddie Item Heavy-Armor Agni");
                                        trialSettings.Remove("Teddie Item Mystery Food X");
                                        trialSettings.Remove("Teddie Item Smart Bomb");

                                        trialSettings.Remove("Teddie Item Turbo Recon Dyaus");
                                        trialSettings.Remove("Teddie Item Oil Drum");
                                        trialSettings.Remove("Teddie Item Motorcycle Key");

                                        trialSettings.Remove("Teddie Item Firecracker");
                                        trialSettings.Remove("Teddie Item Dry Ice");
                                        trialSettings.Remove("Teddie Item Vanish Ball");

                                        trialSettings.Remove("Teddie Item Mobile Model Varna");
                                        trialSettings.Remove("Teddie Item Muscle Drink");
                                        trialSettings.Remove("Teddie Item Pinwheel");

                                        trialSettings.Remove("Teddie Item D-Type Prithvi");
                                        trialSettings.Remove("Teddie Item Amagiya Bucket");

                                        if (!(trialSettings.Contains("Teddie Item Ball Lightning")))
                                        {
                                            trialSettings.Add("Teddie Item Ball Lightning");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;

                                    case "Amagiya Bucket":
                                        trialSettings.Remove("Teddie Item 0");
                                        trialSettings.Remove("Teddie Item MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item Dr. Salt NEO");

                                        trialSettings.Remove("Teddie Item Heavy-Armor Agni");
                                        trialSettings.Remove("Teddie Item Mystery Food X");
                                        trialSettings.Remove("Teddie Item Smart Bomb");

                                        trialSettings.Remove("Teddie Item Turbo Recon Dyaus");
                                        trialSettings.Remove("Teddie Item Oil Drum");
                                        trialSettings.Remove("Teddie Item Motorcycle Key");

                                        trialSettings.Remove("Teddie Item Firecracker");
                                        trialSettings.Remove("Teddie Item Dry Ice");
                                        trialSettings.Remove("Teddie Item Vanish Ball");

                                        trialSettings.Remove("Teddie Item Mobile Model Varna");
                                        trialSettings.Remove("Teddie Item Muscle Drink");
                                        trialSettings.Remove("Teddie Item Pinwheel");

                                        trialSettings.Remove("Teddie Item D-Type Prithvi");
                                        trialSettings.Remove("Teddie Item Ball Lightning");

                                        if (!(trialSettings.Contains("Teddie Item Amagiya Bucket")))
                                        {
                                            trialSettings.Add("Teddie Item Amagiya Bucket");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                }
                            }
                            else if (comboBoxItems.SequenceEqual(teddiesItems2))
                            {
                                switch (comboBox.SelectedItem)
                                {
                                    case "Default":
                                        trialSettings.Remove("Teddie Item2 Firecracker");
                                        trialSettings.Remove("Teddie Item2 Dry Ice");
                                        trialSettings.Remove("Teddie Item2 Vanish Ball");

                                        trialSettings.Remove("Teddie Item2 Mobile Model Varna");
                                        trialSettings.Remove("Teddie Item2 Muscle Drink");
                                        trialSettings.Remove("Teddie Item2 Pinwheel");

                                        trialSettings.Remove("Teddie Item2 D-Type Prithvi");
                                        trialSettings.Remove("Teddie Item2 Ball Lightning");
                                        trialSettings.Remove("Teddie Item2 Amagi Inn Bucket");

                                        trialSettings.Remove("Teddie Item2 MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item2 Dr. Salt NEO");
                                        trialSettings.Remove("Teddie Item2 Heavy-Armor Agni");

                                        trialSettings.Remove("Teddie Item2 Mystery Food X");
                                        trialSettings.Remove("Teddie Item2 Smart Bomb");
                                        trialSettings.Remove("Teddie Item2 Turbo Recon Dyaus");

                                        trialSettings.Remove("Teddie Item2 Oil Drum");
                                        trialSettings.Remove("Teddie Item2 Motorcycle Key");

                                        if (!(trialSettings.Contains("Teddie Item2 0")))
                                        {
                                            trialSettings.Add("Teddie Item2 0");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Firecracker":
                                        trialSettings.Remove("Teddie Item2 0");
                                        trialSettings.Remove("Teddie Item2 Dry Ice");
                                        trialSettings.Remove("Teddie Item2 Vanish Ball");

                                        trialSettings.Remove("Teddie Item2 Mobile Model Varna");
                                        trialSettings.Remove("Teddie Item2 Muscle Drink");
                                        trialSettings.Remove("Teddie Item2 Pinwheel");

                                        trialSettings.Remove("Teddie Item2 D-Type Prithvi");
                                        trialSettings.Remove("Teddie Item2 Ball Lightning");
                                        trialSettings.Remove("Teddie Item2 Amagi Inn Bucket");

                                        trialSettings.Remove("Teddie Item2 MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item2 Dr. Salt NEO");
                                        trialSettings.Remove("Teddie Item2 Heavy-Armor Agni");

                                        trialSettings.Remove("Teddie Item2 Mystery Food X");
                                        trialSettings.Remove("Teddie Item2 Smart Bomb");
                                        trialSettings.Remove("Teddie Item2 Turbo Recon Dyaus");

                                        trialSettings.Remove("Teddie Item2 Oil Drum");
                                        trialSettings.Remove("Teddie Item2 Motorcycle Key");

                                        if (!(trialSettings.Contains("Teddie Item2 Firecracker")))
                                        {
                                            trialSettings.Add("Teddie Item2 Firecracker");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Dry Ice":
                                        trialSettings.Remove("Teddie Item2 0");
                                        trialSettings.Remove("Teddie Item2 Firecracker");
                                        trialSettings.Remove("Teddie Item2 Vanish Ball");

                                        trialSettings.Remove("Teddie Item2 Mobile Model Varna");
                                        trialSettings.Remove("Teddie Item2 Muscle Drink");
                                        trialSettings.Remove("Teddie Item2 Pinwheel");

                                        trialSettings.Remove("Teddie Item2 D-Type Prithvi");
                                        trialSettings.Remove("Teddie Item2 Ball Lightning");
                                        trialSettings.Remove("Teddie Item2 Amagi Inn Bucket");

                                        trialSettings.Remove("Teddie Item2 MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item2 Dr. Salt NEO");
                                        trialSettings.Remove("Teddie Item2 Heavy-Armor Agni");

                                        trialSettings.Remove("Teddie Item2 Mystery Food X");
                                        trialSettings.Remove("Teddie Item2 Smart Bomb");
                                        trialSettings.Remove("Teddie Item2 Turbo Recon Dyaus");

                                        trialSettings.Remove("Teddie Item2 Oil Drum");
                                        trialSettings.Remove("Teddie Item2 Motorcycle Key");

                                        if (!(trialSettings.Contains("Teddie Item2 Dry Ice")))
                                        {
                                            trialSettings.Add("Teddie Item2 Dry Ice");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Vanish Ball":
                                        trialSettings.Remove("Teddie Item2 0");
                                        trialSettings.Remove("Teddie Item2 Firecracker");
                                        trialSettings.Remove("Teddie Item2 Dry Ice");

                                        trialSettings.Remove("Teddie Item2 Mobile Model Varna");
                                        trialSettings.Remove("Teddie Item2 Muscle Drink");
                                        trialSettings.Remove("Teddie Item2 Pinwheel");

                                        trialSettings.Remove("Teddie Item2 D-Type Prithvi");
                                        trialSettings.Remove("Teddie Item2 Ball Lightning");
                                        trialSettings.Remove("Teddie Item2 Amagi Inn Bucket");

                                        trialSettings.Remove("Teddie Item2 MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item2 Dr. Salt NEO");
                                        trialSettings.Remove("Teddie Item2 Heavy-Armor Agni");

                                        trialSettings.Remove("Teddie Item2 Mystery Food X");
                                        trialSettings.Remove("Teddie Item2 Smart Bomb");
                                        trialSettings.Remove("Teddie Item2 Turbo Recon Dyaus");

                                        trialSettings.Remove("Teddie Item2 Oil Drum");
                                        trialSettings.Remove("Teddie Item2 Motorcycle Key");

                                        if (!(trialSettings.Contains("Teddie Item2 Vanish Ball")))
                                        {
                                            trialSettings.Add("Teddie Item2 Vanish Ball");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Mobile Model Varna":
                                        trialSettings.Remove("Teddie Item2 0");
                                        trialSettings.Remove("Teddie Item2 Firecracker");
                                        trialSettings.Remove("Teddie Item2 Dry Ice");

                                        trialSettings.Remove("Teddie Item2 Vanish Ball");
                                        trialSettings.Remove("Teddie Item2 Muscle Drink");
                                        trialSettings.Remove("Teddie Item2 Pinwheel");

                                        trialSettings.Remove("Teddie Item2 D-Type Prithvi");
                                        trialSettings.Remove("Teddie Item2 Ball Lightning");
                                        trialSettings.Remove("Teddie Item2 Amagi Inn Bucket");

                                        trialSettings.Remove("Teddie Item2 MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item2 Dr. Salt NEO");
                                        trialSettings.Remove("Teddie Item2 Heavy-Armor Agni");

                                        trialSettings.Remove("Teddie Item2 Mystery Food X");
                                        trialSettings.Remove("Teddie Item2 Smart Bomb");
                                        trialSettings.Remove("Teddie Item2 Turbo Recon Dyaus");

                                        trialSettings.Remove("Teddie Item2 Oil Drum");
                                        trialSettings.Remove("Teddie Item2 Motorcycle Key");

                                        if (!(trialSettings.Contains("Teddie Item2 Mobile Model Varna")))
                                        {
                                            trialSettings.Add("Teddie Item2 Mobile Model Varna");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Muscle Drink":
                                        trialSettings.Remove("Teddie Item2 0");
                                        trialSettings.Remove("Teddie Item2 Firecracker");
                                        trialSettings.Remove("Teddie Item2 Dry Ice");

                                        trialSettings.Remove("Teddie Item2 Vanish Ball");
                                        trialSettings.Remove("Teddie Item2 Mobile Model Varna");
                                        trialSettings.Remove("Teddie Item2 Pinwheel");

                                        trialSettings.Remove("Teddie Item2 D-Type Prithvi");
                                        trialSettings.Remove("Teddie Item2 Ball Lightning");
                                        trialSettings.Remove("Teddie Item2 Amagi Inn Bucket");

                                        trialSettings.Remove("Teddie Item2 MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item2 Dr. Salt NEO");
                                        trialSettings.Remove("Teddie Item2 Heavy-Armor Agni");

                                        trialSettings.Remove("Teddie Item2 Mystery Food X");
                                        trialSettings.Remove("Teddie Item2 Smart Bomb");
                                        trialSettings.Remove("Teddie Item2 Turbo Recon Dyaus");

                                        trialSettings.Remove("Teddie Item2 Oil Drum");
                                        trialSettings.Remove("Teddie Item2 Motorcycle Key");

                                        if (!(trialSettings.Contains("Teddie Item2 Muscle Drink")))
                                        {
                                            trialSettings.Add("Teddie Item2 Muscle Drink");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Pinwheel":
                                        trialSettings.Remove("Teddie Item2 0");
                                        trialSettings.Remove("Teddie Item2 Firecracker");
                                        trialSettings.Remove("Teddie Item2 Dry Ice");

                                        trialSettings.Remove("Teddie Item2 Vanish Ball");
                                        trialSettings.Remove("Teddie Item2 Mobile Model Varna");
                                        trialSettings.Remove("Teddie Item2 Muscle Drink");

                                        trialSettings.Remove("Teddie Item2 D-Type Prithvi");
                                        trialSettings.Remove("Teddie Item2 Ball Lightning");
                                        trialSettings.Remove("Teddie Item2 Amagi Inn Bucket");

                                        trialSettings.Remove("Teddie Item2 MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item2 Dr. Salt NEO");
                                        trialSettings.Remove("Teddie Item2 Heavy-Armor Agni");

                                        trialSettings.Remove("Teddie Item2 Mystery Food X");
                                        trialSettings.Remove("Teddie Item2 Smart Bomb");
                                        trialSettings.Remove("Teddie Item2 Turbo Recon Dyaus");

                                        trialSettings.Remove("Teddie Item2 Oil Drum");
                                        trialSettings.Remove("Teddie Item2 Motorcycle Key");

                                        if (!(trialSettings.Contains("Teddie Item2 Pinwheel")))
                                        {
                                            trialSettings.Add("Teddie Item2 Pinwheel");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "D-Type Prithvi":
                                        trialSettings.Remove("Teddie Item2 0");
                                        trialSettings.Remove("Teddie Item2 Firecracker");
                                        trialSettings.Remove("Teddie Item2 Dry Ice");

                                        trialSettings.Remove("Teddie Item2 Vanish Ball");
                                        trialSettings.Remove("Teddie Item2 Mobile Model Varna");
                                        trialSettings.Remove("Teddie Item2 Muscle Drink");

                                        trialSettings.Remove("Teddie Item2 Pinwheel");
                                        trialSettings.Remove("Teddie Item2 Ball Lightning");
                                        trialSettings.Remove("Teddie Item2 Amagi Inn Bucket");

                                        trialSettings.Remove("Teddie Item2 MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item2 Dr. Salt NEO");
                                        trialSettings.Remove("Teddie Item2 Heavy-Armor Agni");

                                        trialSettings.Remove("Teddie Item2 Mystery Food X");
                                        trialSettings.Remove("Teddie Item2 Smart Bomb");
                                        trialSettings.Remove("Teddie Item2 Turbo Recon Dyaus");

                                        trialSettings.Remove("Teddie Item2 Oil Drum");
                                        trialSettings.Remove("Teddie Item2 Motorcycle Key");

                                        if (!(trialSettings.Contains("Teddie Item2 D-Type Prithvi")))
                                        {
                                            trialSettings.Add("Teddie Item2 D-Type Prithvi");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Ball Lightning":
                                        trialSettings.Remove("Teddie Item2 0");
                                        trialSettings.Remove("Teddie Item2 Firecracker");
                                        trialSettings.Remove("Teddie Item2 Dry Ice");

                                        trialSettings.Remove("Teddie Item2 Vanish Ball");
                                        trialSettings.Remove("Teddie Item2 Mobile Model Varna");
                                        trialSettings.Remove("Teddie Item2 Muscle Drink");

                                        trialSettings.Remove("Teddie Item2 Pinwheel");
                                        trialSettings.Remove("Teddie Item2 D-Type Prithvi");
                                        trialSettings.Remove("Teddie Item2 Amagi Inn Bucket");

                                        trialSettings.Remove("Teddie Item2 MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item2 Dr. Salt NEO");
                                        trialSettings.Remove("Teddie Item2 Heavy-Armor Agni");

                                        trialSettings.Remove("Teddie Item2 Mystery Food X");
                                        trialSettings.Remove("Teddie Item2 Smart Bomb");
                                        trialSettings.Remove("Teddie Item2 Turbo Recon Dyaus");

                                        trialSettings.Remove("Teddie Item2 Oil Drum");
                                        trialSettings.Remove("Teddie Item2 Motorcycle Key");

                                        if (!(trialSettings.Contains("Teddie Item2 Ball Lightning")))
                                        {
                                            trialSettings.Add("Teddie Item2 Ball Lightning");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Amagi Inn Bucket":
                                        trialSettings.Remove("Teddie Item2 0");
                                        trialSettings.Remove("Teddie Item2 Firecracker");
                                        trialSettings.Remove("Teddie Item2 Dry Ice");

                                        trialSettings.Remove("Teddie Item2 Vanish Ball");
                                        trialSettings.Remove("Teddie Item2 Mobile Model Varna");
                                        trialSettings.Remove("Teddie Item2 Muscle Drink");

                                        trialSettings.Remove("Teddie Item2 Pinwheel");
                                        trialSettings.Remove("Teddie Item2 D-Type Prithvi");
                                        trialSettings.Remove("Teddie Item2 Ball Lightning");

                                        trialSettings.Remove("Teddie Item2 MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item2 Dr. Salt NEO");
                                        trialSettings.Remove("Teddie Item2 Heavy-Armor Agni");

                                        trialSettings.Remove("Teddie Item2 Mystery Food X");
                                        trialSettings.Remove("Teddie Item2 Smart Bomb");
                                        trialSettings.Remove("Teddie Item2 Turbo Recon Dyaus");

                                        trialSettings.Remove("Teddie Item2 Oil Drum");
                                        trialSettings.Remove("Teddie Item2 Motorcycle Key");

                                        if (!(trialSettings.Contains("Teddie Item2 Amagi Inn Bucket")))
                                        {
                                            trialSettings.Add("Teddie Item2 Amagi Inn Bucket");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;

                                    case "MF-06S Brahman":
                                        trialSettings.Remove("Teddie Item2 0");
                                        trialSettings.Remove("Teddie Item2 Firecracker");
                                        trialSettings.Remove("Teddie Item2 Dry Ice");

                                        trialSettings.Remove("Teddie Item2 Vanish Ball");
                                        trialSettings.Remove("Teddie Item2 Mobile Model Varna");
                                        trialSettings.Remove("Teddie Item2 Muscle Drink");

                                        trialSettings.Remove("Teddie Item2 Pinwheel");
                                        trialSettings.Remove("Teddie Item2 D-Type Prithvi");
                                        trialSettings.Remove("Teddie Item2 Ball Lightning");

                                        trialSettings.Remove("Teddie Item2 Amagi Inn Bucket");
                                        trialSettings.Remove("Teddie Item2 Dr. Salt NEO");
                                        trialSettings.Remove("Teddie Item2 Heavy-Armor Agni");

                                        trialSettings.Remove("Teddie Item2 Mystery Food X");
                                        trialSettings.Remove("Teddie Item2 Smart Bomb");
                                        trialSettings.Remove("Teddie Item2 Turbo Recon Dyaus");

                                        trialSettings.Remove("Teddie Item2 Oil Drum");
                                        trialSettings.Remove("Teddie Item2 Motorcycle Key");

                                        if (!(trialSettings.Contains("Teddie Item2 MF-06S Brahman")))
                                        {
                                            trialSettings.Add("Teddie Item2 MF-06S Brahman");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;

                                    case "Dr. Salt NEO":
                                        trialSettings.Remove("Teddie Item2 0");
                                        trialSettings.Remove("Teddie Item2 Firecracker");
                                        trialSettings.Remove("Teddie Item2 Dry Ice");

                                        trialSettings.Remove("Teddie Item2 Vanish Ball");
                                        trialSettings.Remove("Teddie Item2 Mobile Model Varna");
                                        trialSettings.Remove("Teddie Item2 Muscle Drink");

                                        trialSettings.Remove("Teddie Item2 Pinwheel");
                                        trialSettings.Remove("Teddie Item2 D-Type Prithvi");
                                        trialSettings.Remove("Teddie Item2 Ball Lightning");

                                        trialSettings.Remove("Teddie Item2 Amagi Inn Bucket");
                                        trialSettings.Remove("Teddie Item2 MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item2 Heavy-Armor Agni");

                                        trialSettings.Remove("Teddie Item2 Mystery Food X");
                                        trialSettings.Remove("Teddie Item2 Smart Bomb");
                                        trialSettings.Remove("Teddie Item2 Turbo Recon Dyaus");

                                        trialSettings.Remove("Teddie Item2 Oil Drum");
                                        trialSettings.Remove("Teddie Item2 Motorcycle Key");

                                        if (!(trialSettings.Contains("Teddie Item2 Dr. Salt NEO")))
                                        {
                                            trialSettings.Add("Teddie Item2 Dr. Salt NEO");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;

                                    case "Heavy-Armor Agni":
                                        trialSettings.Remove("Teddie Item2 0");
                                        trialSettings.Remove("Teddie Item2 Firecracker");
                                        trialSettings.Remove("Teddie Item2 Dry Ice");

                                        trialSettings.Remove("Teddie Item2 Vanish Ball");
                                        trialSettings.Remove("Teddie Item2 Mobile Model Varna");
                                        trialSettings.Remove("Teddie Item2 Muscle Drink");

                                        trialSettings.Remove("Teddie Item2 Pinwheel");
                                        trialSettings.Remove("Teddie Item2 D-Type Prithvi");
                                        trialSettings.Remove("Teddie Item2 Ball Lightning");

                                        trialSettings.Remove("Teddie Item2 Amagi Inn Bucket");
                                        trialSettings.Remove("Teddie Item2 MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item2 Dr. Salt NEO");

                                        trialSettings.Remove("Teddie Item2 Mystery Food X");
                                        trialSettings.Remove("Teddie Item2 Smart Bomb");
                                        trialSettings.Remove("Teddie Item2 Turbo Recon Dyaus");

                                        trialSettings.Remove("Teddie Item2 Oil Drum");
                                        trialSettings.Remove("Teddie Item2 Motorcycle Key");

                                        if (!(trialSettings.Contains("Teddie Item2 Heavy-Armor Agni")))
                                        {
                                            trialSettings.Add("Teddie Item2 Heavy-Armor Agni");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;

                                    case "Mystery Food X":
                                        trialSettings.Remove("Teddie Item2 0");
                                        trialSettings.Remove("Teddie Item2 Firecracker");
                                        trialSettings.Remove("Teddie Item2 Dry Ice");

                                        trialSettings.Remove("Teddie Item2 Vanish Ball");
                                        trialSettings.Remove("Teddie Item2 Mobile Model Varna");
                                        trialSettings.Remove("Teddie Item2 Muscle Drink");

                                        trialSettings.Remove("Teddie Item2 Pinwheel");
                                        trialSettings.Remove("Teddie Item2 D-Type Prithvi");
                                        trialSettings.Remove("Teddie Item2 Ball Lightning");

                                        trialSettings.Remove("Teddie Item2 Amagi Inn Bucket");
                                        trialSettings.Remove("Teddie Item2 MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item2 Dr. Salt NEO");

                                        trialSettings.Remove("Teddie Item2 Heavy-Armor Agni");
                                        trialSettings.Remove("Teddie Item2 Smart Bomb");
                                        trialSettings.Remove("Teddie Item2 Turbo Recon Dyaus");

                                        trialSettings.Remove("Teddie Item2 Oil Drum");
                                        trialSettings.Remove("Teddie Item2 Motorcycle Key");

                                        if (!(trialSettings.Contains("Teddie Item2 Mystery Food X")))
                                        {
                                            trialSettings.Add("Teddie Item2 Mystery Food X");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;

                                    case "Smart Bomb":
                                        trialSettings.Remove("Teddie Item2 0");
                                        trialSettings.Remove("Teddie Item2 Firecracker");
                                        trialSettings.Remove("Teddie Item2 Dry Ice");

                                        trialSettings.Remove("Teddie Item2 Vanish Ball");
                                        trialSettings.Remove("Teddie Item2 Mobile Model Varna");
                                        trialSettings.Remove("Teddie Item2 Muscle Drink");

                                        trialSettings.Remove("Teddie Item2 Pinwheel");
                                        trialSettings.Remove("Teddie Item2 D-Type Prithvi");
                                        trialSettings.Remove("Teddie Item2 Ball Lightning");

                                        trialSettings.Remove("Teddie Item2 Amagi Inn Bucket");
                                        trialSettings.Remove("Teddie Item2 MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item2 Dr. Salt NEO");

                                        trialSettings.Remove("Teddie Item2 Heavy-Armor Agni");
                                        trialSettings.Remove("Teddie Item2 Mystery Food X");
                                        trialSettings.Remove("Teddie Item2 Turbo Recon Dyaus");

                                        trialSettings.Remove("Teddie Item2 Oil Drum");
                                        trialSettings.Remove("Teddie Item2 Motorcycle Key");

                                        if (!(trialSettings.Contains("Teddie Item2 Smart Bomb")))
                                        {
                                            trialSettings.Add("Teddie Item2 Smart Bomb");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;

                                    case "Turbo Recon Dyaus":
                                        trialSettings.Remove("Teddie Item2 0");
                                        trialSettings.Remove("Teddie Item2 Firecracker");
                                        trialSettings.Remove("Teddie Item2 Dry Ice");

                                        trialSettings.Remove("Teddie Item2 Vanish Ball");
                                        trialSettings.Remove("Teddie Item2 Mobile Model Varna");
                                        trialSettings.Remove("Teddie Item2 Muscle Drink");

                                        trialSettings.Remove("Teddie Item2 Pinwheel");
                                        trialSettings.Remove("Teddie Item2 D-Type Prithvi");
                                        trialSettings.Remove("Teddie Item2 Ball Lightning");

                                        trialSettings.Remove("Teddie Item2 Amagi Inn Bucket");
                                        trialSettings.Remove("Teddie Item2 MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item2 Dr. Salt NEO");

                                        trialSettings.Remove("Teddie Item2 Heavy-Armor Agni");
                                        trialSettings.Remove("Teddie Item2 Mystery Food X");
                                        trialSettings.Remove("Teddie Item2 Smart Bomb");

                                        trialSettings.Remove("Teddie Item2 Oil Drum");
                                        trialSettings.Remove("Teddie Item2 Motorcycle Key");

                                        if (!(trialSettings.Contains("Teddie Item2 Turbo Recon Dyaus")))
                                        {
                                            trialSettings.Add("Teddie Item2 Turbo Recon Dyaus");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;

                                    case "Oil Drum":
                                        trialSettings.Remove("Teddie Item2 0");
                                        trialSettings.Remove("Teddie Item2 Firecracker");
                                        trialSettings.Remove("Teddie Item2 Dry Ice");

                                        trialSettings.Remove("Teddie Item2 Vanish Ball");
                                        trialSettings.Remove("Teddie Item2 Mobile Model Varna");
                                        trialSettings.Remove("Teddie Item2 Muscle Drink");

                                        trialSettings.Remove("Teddie Item2 Pinwheel");
                                        trialSettings.Remove("Teddie Item2 D-Type Prithvi");
                                        trialSettings.Remove("Teddie Item2 Ball Lightning");

                                        trialSettings.Remove("Teddie Item2 Amagi Inn Bucket");
                                        trialSettings.Remove("Teddie Item2 MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item2 Dr. Salt NEO");

                                        trialSettings.Remove("Teddie Item2 Heavy-Armor Agni");
                                        trialSettings.Remove("Teddie Item2 Mystery Food X");
                                        trialSettings.Remove("Teddie Item2 Smart Bomb");

                                        trialSettings.Remove("Teddie Item2 Turbo Recon Dyaus");
                                        trialSettings.Remove("Teddie Item2 Motorcycle Key");

                                        if (!(trialSettings.Contains("Teddie Item2 Oil Drum")))
                                        {
                                            trialSettings.Add("Teddie Item2 Oil Drum");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;

                                    case "Motorcycle Key":
                                        trialSettings.Remove("Teddie Item2 0");
                                        trialSettings.Remove("Teddie Item2 Firecracker");
                                        trialSettings.Remove("Teddie Item2 Dry Ice");

                                        trialSettings.Remove("Teddie Item2 Vanish Ball");
                                        trialSettings.Remove("Teddie Item2 Mobile Model Varna");
                                        trialSettings.Remove("Teddie Item2 Muscle Drink");

                                        trialSettings.Remove("Teddie Item2 Pinwheel");
                                        trialSettings.Remove("Teddie Item2 D-Type Prithvi");
                                        trialSettings.Remove("Teddie Item2 Ball Lightning");

                                        trialSettings.Remove("Teddie Item2 Amagi Inn Bucket");
                                        trialSettings.Remove("Teddie Item2 MF-06S Brahman");
                                        trialSettings.Remove("Teddie Item2 Dr. Salt NEO");

                                        trialSettings.Remove("Teddie Item2 Heavy-Armor Agni");
                                        trialSettings.Remove("Teddie Item2 Mystery Food X");
                                        trialSettings.Remove("Teddie Item2 Smart Bomb");

                                        trialSettings.Remove("Teddie Item2 Turbo Recon Dyaus");
                                        trialSettings.Remove("Teddie Item2 Oil Drum");

                                        if (!(trialSettings.Contains("Teddie Item2 Motorcycle Key")))
                                        {
                                            trialSettings.Add("Teddie Item2 Motorcycle Key");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                }
                            }
                            else if (comboBoxItems.SequenceEqual(labrysItems))
                            {
                                switch (comboBox.SelectedItem)
                                {
                                    case "Default":
                                        trialSettings.Remove("Labrys Initial Axe Level 1");
                                        trialSettings.Remove("Labrys Initial Axe Level 2");
                                        trialSettings.Remove("Labrys Initial Axe Level 3");

                                        trialSettings.Remove("Labrys Initial Axe Level 4");
                                        trialSettings.Remove("Labrys Initial Axe Level 5");

                                        if (!(trialSettings.Contains("Labrys Initial Axe Level 0")))
                                        {
                                            trialSettings.Add("Labrys Initial Axe Level 0");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Level 1":
                                        trialSettings.Remove("Labrys Initial Axe Level 0");
                                        trialSettings.Remove("Labrys Initial Axe Level 2");
                                        trialSettings.Remove("Labrys Initial Axe Level 3");

                                        trialSettings.Remove("Labrys Initial Axe Level 4");
                                        trialSettings.Remove("Labrys Initial Axe Level 5");

                                        if (!(trialSettings.Contains("Labrys Initial Axe Level 1")))
                                        {
                                            trialSettings.Add("Labrys Initial Axe Level 1");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Level 2":
                                        trialSettings.Remove("Labrys Initial Axe Level 0");
                                        trialSettings.Remove("Labrys Initial Axe Level 1");
                                        trialSettings.Remove("Labrys Initial Axe Level 3");

                                        trialSettings.Remove("Labrys Initial Axe Level 4");
                                        trialSettings.Remove("Labrys Initial Axe Level 5");

                                        if (!(trialSettings.Contains("Labrys Initial Axe Level 2")))
                                        {
                                            trialSettings.Add("Labrys Initial Axe Level 2");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Level 3":
                                        trialSettings.Remove("Labrys Initial Axe Level 0");
                                        trialSettings.Remove("Labrys Initial Axe Level 1");
                                        trialSettings.Remove("Labrys Initial Axe Level 2");

                                        trialSettings.Remove("Labrys Initial Axe Level 4");
                                        trialSettings.Remove("Labrys Initial Axe Level 5");

                                        if (!(trialSettings.Contains("Labrys Initial Axe Level 3")))
                                        {
                                            trialSettings.Add("Labrys Initial Axe Level 3");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Level 4":
                                        trialSettings.Remove("Labrys Initial Axe Level 0");
                                        trialSettings.Remove("Labrys Initial Axe Level 1");
                                        trialSettings.Remove("Labrys Initial Axe Level 2");

                                        trialSettings.Remove("Labrys Initial Axe Level 3");
                                        trialSettings.Remove("Labrys Initial Axe Level 5");

                                        if (!(trialSettings.Contains("Labrys Initial Axe Level 4")))
                                        {
                                            trialSettings.Add("Labrys Initial Axe Level 4");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Level 5":
                                        trialSettings.Remove("Labrys Initial Axe Level 0");
                                        trialSettings.Remove("Labrys Initial Axe Level 1");
                                        trialSettings.Remove("Labrys Initial Axe Level 2");

                                        trialSettings.Remove("Labrys Initial Axe Level 3");
                                        trialSettings.Remove("Labrys Initial Axe Level 4");

                                        if (!(trialSettings.Contains("Labrys Initial Axe Level 5")))
                                        {
                                            trialSettings.Add("Labrys Initial Axe Level 5");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                }
                            }
                            else if (comboBoxItems.SequenceEqual(naotosItems))
                            {
                                switch (comboBox.SelectedItem)
                                {
                                    case "Default":
                                        trialSettings.Remove("Fixed at Zero");
                                        trialSettings.Remove("Fixed at MAX");

                                        if (!(trialSettings.Contains("Default Fate")))
                                        {
                                            trialSettings.Add("Default Fate");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Fixed at Zero":
                                        trialSettings.Remove("Default Fate");
                                        trialSettings.Remove("Fixed at MAX");

                                        if (!(trialSettings.Contains("Fixed at Zero")))
                                        {
                                            trialSettings.Add("Fixed at Zero");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Fixed at MAX":
                                        trialSettings.Remove("Default Fate");
                                        trialSettings.Remove("Fixed at Zero");

                                        if (!(trialSettings.Contains("Fixed at MAX")))
                                        {
                                            trialSettings.Add("Fixed at MAX");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                }
                            }
                            else if (comboBoxItems.SequenceEqual(mariesItems))
                            {
                                switch (comboBox.SelectedItem)
                                {
                                    case "Sunny Weather":
                                        trialSettings.Remove("Cloudy Weather");
                                        trialSettings.Remove("Rainy Weather");
                                        trialSettings.Remove("Snowy Weather");

                                        if (!(trialSettings.Contains("Sunny Weather")))
                                        {
                                            trialSettings.Add("Sunny Weather");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Cloudy Weather":
                                        trialSettings.Remove("Sunny Weather");
                                        trialSettings.Remove("Rainy Weather");
                                        trialSettings.Remove("Snowy Weather");

                                        if (!(trialSettings.Contains("Cloudy Weather")))
                                        {
                                            trialSettings.Add("Cloudy Weather");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Rainy Weather":
                                        trialSettings.Remove("Cloudy Weather");
                                        trialSettings.Remove("Sunny Weather");
                                        trialSettings.Remove("Snowy Weather");

                                        if (!(trialSettings.Contains("Rainy Weather")))
                                        {
                                            trialSettings.Add("Rainy Weather");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                    case "Snowy Weather":
                                        trialSettings.Remove("Cloudy Weather");
                                        trialSettings.Remove("Rainy Weather");
                                        trialSettings.Remove("Sunny Weather");

                                        if (!(trialSettings.Contains("Snowy Weather")))
                                        {
                                            trialSettings.Add("Snowy Weather");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        break;
                                }
                            }
                            break;
                        case NumericUpDown numericUpDown:

                            switch (numericUpDown.Maximum) 
                            {
                                case 120: //Aigis
                                    if (numericUpDown.Value == 0)
                                    {                                        
                                        if(trialSettings.Contains($"Aigis Max Bullets: {agBullets}"))
                                        {
                                            trialSettings.Remove($"Aigis Max Bullets: {agBullets}");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                        agBullets = (int) numericUpDown.Value;
                                    }
                                    else if (numericUpDown.Value == agBullets)
                                    {
                                        if (!(trialSettings.Contains($"Aigis Max Bullets: {agBullets}")))
                                        {
                                            trialSettings.Add($"Aigis Max Bullets: {agBullets}");
                                            RefreshTrialSettingsDataGridView(trialSettings);
                                        }
                                    }
                                    else
                                    {                                      
                                        if (trialSettings.Contains($"Aigis Max Bullets: {agBullets}"))
                                        {
                                            trialSettings.Remove($"Aigis Max Bullets: {agBullets}");
                                        }

                                        agBullets = (int)numericUpDown.Value;
                                    }
                                    break;

                                case 55: //Junpei
                                    if (!(juFullCount))
                                    {
                                        if (numericUpDown.Value == 55)
                                        {
                                            if (trialSettings.Contains($"Junpei Score: {juPoints}"))
                                            {
                                                trialSettings.Remove($"Junpei Score: {juPoints}");
                                                RefreshTrialSettingsDataGridView(trialSettings);
                                            }
                                        }
                                        else if (numericUpDown.Value < 55 && numericUpDown.Value == juPoints)
                                        {
                                            if (!(trialSettings.Contains($"Junpei Score: {juPoints}")))
                                            {
                                                trialSettings.Remove("Full Run Count");
                                                trialSettings.Add($"Junpei Score: {juPoints}");
                                                RefreshTrialSettingsDataGridView(trialSettings);
                                            }
                                        }
                                        else if (numericUpDown.Value < 55 && numericUpDown.Value != juPoints)
                                        {
                                            if (trialSettings.Contains($"Junpei Score: {juPoints}"))
                                            {
                                                trialSettings.Remove($"Junpei Score: {juPoints}");
                                            }
                                            juPoints = (int)numericUpDown.Value;
                                        }
                                    }
                                                                        
                                    juPoints = (int)numericUpDown.Value;

                                    break;
                            }

                            break;
                    }
                }
            }
        }



        private void ClearCharacterSpecificSettings()
        {
            List<string> characterSpecificSettings = new()
                {
                    //Yosuke Sukukaja Setting
                    "Infinite Sukukaja",
                    //Chie Power Charge Settings
                    "Chie Charge Level 0",
                    "Chie Charge Level 1",
                    "Chie Charge Level 2",
                    "Chie Charge Level 3",
                    //Yukiko Initial Fire Level Settings
                    "Yukiko Charge Level 0",
                    "Yukiko Charge Level 1",
                    "Yukiko Charge Level 2",
                    "Yukiko Charge Level 3",
                    "Yukiko Charge Level 4",
                    "Yukiko Charge Level 5",
                    "Yukiko Charge Level 6",
                    "Yukiko Charge Level 7",
                    "Yukiko Charge Level 8",
                    "Yukiko Charge Level 9",
                    //Yukiko Fire Break Fast Recovery Setting
                    "Fire Break Fast Recovery",
                    //Teddie Item 1 Settings
                    "Teddie Item 0",
                    "Teddie Item MF-06S Brahman",
                    "Teddie Item Dr. Salt NEO",
                    "Teddie Item Heavy-Armor Agni",
                    "Teddie Item Mystery Food X",
                    "Teddie Item Smart Bomb",
                    "Teddie Item Turbo Recon Dyaus",
                    "Teddie Item Oil Drum",
                    "Teddie Item Motorcycle Key",
                    "Teddie Item Firecracker",
                    "Teddie Item Dry Ice",
                    "Teddie Item Vanish Ball",
                    "Teddie Item Mobile Model Varna",
                    "Teddie Item Muscle Drink",
                    "Teddie Item Pinwheel",
                    "Teddie Item D-Type Prithvi",
                    "Teddie Item Ball Lightning",
                    "Teddie Item Amagiya Bucket",                
                    //Teddie Item 2 Settings
                    "Teddie Item2 0",
                    "Teddie Item2 Firecracker",
                    "Teddie Item2 Dry Ice",
                    "Teddie Item2 Vanish Ball",
                    "Teddie Item2 Mobile Model Varna",
                    "Teddie Item2 Muscle Drink",
                    "Teddie Item2 Pinwheel",
                    "Teddie Item2 D-Type Prithvi",
                    "Teddie Item2 Ball Lightning",
                    "Teddie Item2 Amagi Inn Bucket",
                    "Teddie Item2 MF-06S Brahman",
                    "Teddie Item2 Dr. Salt NEO",
                    "Teddie Item2 Heavy-Armor Agni",
                    "Teddie Item2 Mystery Food X",
                    "Teddie Item2 Smart Bomb",
                    "Teddie Item2 Turbo Recon Dyaus",
                    "Teddie Item2 Oil Drum",
                    "Teddie Item2 Motorcycle Key",
                    //Teddie Fix Item 1 Setting
                    "Fix Item 1",
                    //Teddie Fix Item 2 Setting
                    "Fix Item 2",
                    //Teddie Mystery Teddie SP Fast Recovery Setting
                    "Mystery Teddie SP Fast Recovery",
                    //Naoto Fate Settings
                    "Default Fate",
                    "Fixed at Zero",
                    "Fixed at MAX",
                    //Akihiko Thunder Fists Always On Setting
                    "Thunder Fists Always On",
                    //Aigis Max Bullet Count
                    $"Aigis Max Bullets: {agBullets}",
                    //Aigis Orgia Fast Recovery Setting
                    "Orgia Fast Recovery",
                    //Aigis Ammo Fast Recovery Setting
                    "Ammo Fast Recovery",
                    //Labrys Initial Axe Level Setting
                    "Labrys Initial Axe Level 0",
                    "Labrys Initial Axe Level 1",
                    "Labrys Initial Axe Level 2",
                    "Labrys Initial Axe Level 3",
                    "Labrys Initial Axe Level 4",
                    "Labrys Initial Axe Level 5",
                    //S. Labrys Titanomachia Fast Recovery Setting
                    "Titanomachia Fast Recovery",   
                    //Junpei Score Count Setting
                    $"Junpei Score: {juPoints}",
                    //Junpei Full Run Count Setting
                    "Full Run Count",
                    //Junpei Never Activate Victory Cry Setting
                    "Never Activate Victory Cry",
                    //Rise Analyze Always On Setting
                    "Analyze Always On",
                    //Rise Tetrakarn/Makarakarn Fast Recovery Setting
                    "Tetrakarn Fast Recovery",
                    //Rise Risette Field Fast Recovery Setting
                    "Risette Field Fast Recovery",
                    //Ken Koromaru HP Fast Recovery Setting
                    "Koromaru Fast Recovery",
                    //Adachi Heat Riser Always On Setting
                    "Heat Riser Always On",
                    //Adachi Magatsu Mandala Always On Setting
                    "Magatsu Mandala Always On",
                    //Marie Weather Settings
                    "Sunny Weather",
                    "Cloudy Weather",
                    "Rainy Weather",
                    "Snowy Weather",
                };

            foreach (string setting in characterSpecificSettings)
            {
                if (trialSettings.Contains(setting))
                {
                    trialSettings.Remove(setting.ToString());
                }
            }

        }

        private void CreateCharacterSettings()
        {
            characterSpecificSettingsPanel.Controls.Clear();
            //trialSettings.Clear();
            RefreshTrialSettingsDataGridView(trialSettings);

            List<Control> controlList = new();

            switch (characterSelectComboBox.SelectedIndex)
            {
                case 1: //Yosuke Hanamura
                    System.Windows.Forms.CheckBox yoSukukajaCheckBox = new()
                    {
                        Text = "Infinite Sukukaja?",
                        Font = awakeningCheckBox.Font,
                        AutoSize = true
                    };

                    controlList.Add(yoSukukajaCheckBox);
                    break;
                case 2: //Chie Satonaka
                    Label ceChargeLabel = new()
                    {
                        Text = "Charge Level:",
                        Font = awakeningCheckBox.Font
                    };

                    ComboBox ceChargeComboBox = new()
                    {
                        DropDownStyle = ComboBoxStyle.DropDownList
                    };

                    ceChargeComboBox.Items.Add("Default"); //N/A
                    ceChargeComboBox.Items.Add("Level 1"); //ChiesCharge 1
                    ceChargeComboBox.Items.Add("Level 2"); //ChiesCharge 2
                    ceChargeComboBox.Items.Add("Level 3"); //ChiesCharge 3
                    ceChargeComboBox.SelectedIndex = 0;

                    controlList.Add(ceChargeLabel);
                    controlList.Add(ceChargeComboBox);
                    break;
                case 3: //Yukiko Amagi
                    Label yuLevelLabel = new()
                    {
                        Text = "Initial Fire Level:",
                        Font = awakeningCheckBox.Font
                    };

                    ComboBox yuLevelComboBox = new()
                    {
                        DropDownStyle = ComboBoxStyle.DropDownList
                    };

                    yuLevelComboBox.Items.Add("Default"); //N/A
                    yuLevelComboBox.Items.Add("Level 1"); //YukikosFireBooster 1
                    yuLevelComboBox.Items.Add("Level 2"); //YukikosFireBooster 2
                    yuLevelComboBox.Items.Add("Level 3"); //YukikosFireBooster 3
                    yuLevelComboBox.Items.Add("Level 4"); //YukikosFireBooster 4
                    yuLevelComboBox.Items.Add("Level 5"); //YukikosFireBooster 5
                    yuLevelComboBox.Items.Add("Level 6"); //YukikosFireBooster 6
                    yuLevelComboBox.Items.Add("Level 7"); //YukikosFireBooster 7
                    yuLevelComboBox.Items.Add("Level 8"); //YukikosFireBooster 8
                    yuLevelComboBox.Items.Add("Level 9"); //YukikosFireBooster 9
                    yuLevelComboBox.SelectedIndex = 0;

                    System.Windows.Forms.CheckBox yuBreakCheckBox = new()
                    {
                        Text = "Fire Break Fast Recovery?",
                        Font = awakeningCheckBox.Font,
                        AutoSize = true
                    };

                    controlList.Add(yuLevelLabel);
                    controlList.Add(yuLevelComboBox);
                    controlList.Add(yuBreakCheckBox);

                    break;
                case 5: //Teddie
                    Label kuItem1Label = new()
                    {
                        Text = "Initial Item 1:",
                        Font = awakeningCheckBox.Font
                    };

                    ComboBox kuItem1ComboBox = new()
                    {
                        DropDownStyle = ComboBoxStyle.DropDownList
                    };

                    kuItem1ComboBox.Items.Add("Default"); //N/A
                    kuItem1ComboBox.Items.Add("MF-06S Brahman"); //KumasItem 1
                    kuItem1ComboBox.Items.Add("Dr. Salt NEO"); //KumasItem 2
                    kuItem1ComboBox.Items.Add("Heavy-Armor Agni"); //KumasItem 3
                    kuItem1ComboBox.Items.Add("Mystery Food X"); //KumasItem 4
                    kuItem1ComboBox.Items.Add("Smart Bomb"); //KumasItem 5
                    kuItem1ComboBox.Items.Add("Turbo Recon Dyaus"); //KumasItem 6
                    kuItem1ComboBox.Items.Add("Oil Drum"); //KumasItem 7
                    kuItem1ComboBox.Items.Add("Motorcycle Key"); //KumasItem 8
                    kuItem1ComboBox.Items.Add("Firecracker"); //KumasItem 9
                    kuItem1ComboBox.Items.Add("Dry Ice"); //KumasItem 10
                    kuItem1ComboBox.Items.Add("Vanish Ball"); //KumasItem 11
                    kuItem1ComboBox.Items.Add("Mobile Model Varna"); //KumasItem 12
                    kuItem1ComboBox.Items.Add("Muscle Drink"); //KumasItem 13
                    kuItem1ComboBox.Items.Add("Pinwheel"); //KumasItem 14
                    kuItem1ComboBox.Items.Add("D-Type Prithvi"); //KumasItem 15
                    kuItem1ComboBox.Items.Add("Ball Lightning"); //KumasItem 16
                    kuItem1ComboBox.Items.Add("Amagiya Bucket"); //KumasItem 17
                    kuItem1ComboBox.SelectedIndex = 0;

                    System.Windows.Forms.CheckBox kuFixedItem1CheckBox = new()
                    {
                        Text = "Fix Item 1?",
                        Font = awakeningCheckBox.Font,
                        AutoSize = true
                    };

                    Label kuItem2Label = new()
                    {
                        Text = "Initial Item 2:",
                        Font = awakeningCheckBox.Font
                    };

                    ComboBox kuItem2ComboBox = new()
                    {
                        DropDownStyle = ComboBoxStyle.DropDownList
                    };

                    kuItem2ComboBox.Items.Add("Default"); //N/A
                    kuItem2ComboBox.Items.Add("Firecracker"); //KumasItem2 1
                    kuItem2ComboBox.Items.Add("Dry Ice"); //KumasItem2 2
                    kuItem2ComboBox.Items.Add("Vanish Ball"); //KumasItem2 3
                    kuItem2ComboBox.Items.Add("Mobile Model Varna"); //KumasItem2 4
                    kuItem2ComboBox.Items.Add("Muscle Drink"); //KumasItem2 5
                    kuItem2ComboBox.Items.Add("Pinwheel"); //KumasItem2 6
                    kuItem2ComboBox.Items.Add("D-Type Prithvi"); //KumasItem2 7
                    kuItem2ComboBox.Items.Add("Ball Lightning"); //KumasItem2 8
                    kuItem2ComboBox.Items.Add("Amagi Inn Bucket"); //KumasItem2 9
                    kuItem2ComboBox.Items.Add("MF-06S Brahman"); //KumasItem2 10
                    kuItem2ComboBox.Items.Add("Dr. Salt NEO"); //KumasItem2 11
                    kuItem2ComboBox.Items.Add("Heavy-Armor Agni"); //KumasItem2 12
                    kuItem2ComboBox.Items.Add("Mystery Food X"); //KumasItem2 13
                    kuItem2ComboBox.Items.Add("Smart Bomb"); //KumasItem2 14
                    kuItem2ComboBox.Items.Add("Turbo Recon Dyaus"); //KumasItem2 15
                    kuItem2ComboBox.Items.Add("Oil Drum"); //KumasItem2 16
                    kuItem2ComboBox.Items.Add("Motorcycle Key"); //KumasItem2 17
                    kuItem2ComboBox.SelectedIndex = 0;

                    System.Windows.Forms.CheckBox kuFixedItem2CheckBox = new()
                    {
                        Text = "Fix Item 2?",
                        Font = awakeningCheckBox.Font,
                        AutoSize = true
                    };

                    System.Windows.Forms.CheckBox kuCheckBoxRecovery = new()
                    {
                        Text = "Mystery Teddie SP Fast Recovery?",
                        Font = awakeningCheckBox.Font,
                        AutoSize = true
                    };

                    controlList.Add(kuItem1Label);
                    controlList.Add(kuItem1ComboBox);
                    controlList.Add(kuItem2Label);
                    controlList.Add(kuItem2ComboBox);
                    controlList.Add(kuFixedItem1CheckBox);
                    controlList.Add(kuFixedItem2CheckBox);
                    controlList.Add(kuCheckBoxRecovery);
                    break;
                case 6: //Naoto Shirogane
                    Label naFateLabel = new()
                    {
                        Text = "Fate Setting:",
                        Font = awakeningCheckBox.Font
                    };

                    ComboBox naFateComboBox = new()
                    {
                        DropDownStyle = ComboBoxStyle.DropDownList
                    };

                    naFateComboBox.Items.Add("Default");
                    naFateComboBox.Items.Add("Fixed at Zero"); //NaotosFate 1
                    naFateComboBox.Items.Add("Fixed at MAX"); //NaotosFate 2
                    naFateComboBox.SelectedIndex= 0;

                    controlList.Add(naFateLabel);
                    controlList.Add(naFateComboBox);
                    break;                
                case 8: //Akihiko Sanada
                    System.Windows.Forms.CheckBox akFistsCheckBox = new()
                    {
                        Text = "Thunder Fists Always On?",
                        Font = awakeningCheckBox.Font,
                        AutoSize = true
                    };

                    controlList.Add(akFistsCheckBox);
                    break;
                case 11: //Labrys
                    Label laLevelLabel = new()
                    {
                        Text = "Initial Axe Level:",
                        Font = awakeningCheckBox.Font
                    };

                    ComboBox laLevelComboBox = new()
                    {
                        DropDownStyle = ComboBoxStyle.DropDownList
                    };

                    laLevelComboBox.Items.Add("Default"); //N/A
                    laLevelComboBox.Items.Add("Level 1"); //LabryssAxInitial 1
                    laLevelComboBox.Items.Add("Level 2"); //LabryssAxInitial 2
                    laLevelComboBox.Items.Add("Level 3"); //LabryssAxInitial 3
                    laLevelComboBox.Items.Add("Level 4"); //LabryssAxInitial 4
                    laLevelComboBox.Items.Add("Level 5"); //LabryssAxInitial 5
                    laLevelComboBox.SelectedIndex = 0;

                    controlList.Add(laLevelLabel);
                    controlList.Add(laLevelComboBox);
                    break;
                case 9: //Aigis
                    Label agBulletLabel = new()
                    {
                        Text = "Max Ammo:",
                        Font = awakeningCheckBox.Font,
                        AutoSize = true
                    };

                    NumericUpDown agMaxBulletNumericUpDown = new()
                    {
                        Minimum = 0,
                        Maximum = 120,
                        Size = new System.Drawing.Size(51, 23),
                        TextAlign = HorizontalAlignment.Center
                    };

                    System.Windows.Forms.CheckBox agOrgiaCheckBox = new()
                    {
                        Text = "Orgia Fast Recovery?",
                        Font = awakeningCheckBox.Font,
                        AutoSize = true
                    };

                    System.Windows.Forms.CheckBox agAmmoCheckBox = new()
                    {
                        Text = "Ammo Fast Recovery?",
                        Font = awakeningCheckBox.Font,
                        AutoSize = true
                    };
                    controlList.Add(agBulletLabel);
                    controlList.Add(agMaxBulletNumericUpDown);
                    controlList.Add(agOrgiaCheckBox);
                    controlList.Add(agAmmoCheckBox);
                    break;
                case 12: //Shadow Labrys
                    System.Windows.Forms.CheckBox lsTitanoCheckBox = new()
                    {
                        Text = "Titanomachia Fast Recovery?",
                        Font = awakeningCheckBox.Font,
                        AutoSize = true
                    };

                    controlList.Add(lsTitanoCheckBox);
                    break;
                case 14: //Junpei Iori
                    Label juScoreLabel = new()
                    {
                        Text = "Score:",
                        Font = awakeningCheckBox.Font,
                        AutoSize = true
                    };

                    NumericUpDown juScoreNumericUpDown = new()
                    {
                        Minimum = 0,
                        Maximum = 55,
                        Size = new System.Drawing.Size(51, 23),
                        TextAlign = HorizontalAlignment.Center
                    };

                    System.Windows.Forms.CheckBox juFullCountCheckBox = new()
                    {
                        Text = "Full Run Count?",
                        Font = awakeningCheckBox.Font,
                        AutoSize = true
                    };

                    System.Windows.Forms.CheckBox juVictoryCheckBox = new()
                    {
                        Text = "Never Activate Victory Cry?",
                        Font = awakeningCheckBox.Font,
                        AutoSize = true
                    };
                    controlList.Add(juScoreLabel);
                    controlList.Add(juScoreNumericUpDown);
                    controlList.Add(juFullCountCheckBox);
                    controlList.Add(juVictoryCheckBox);
                    break;
                case 17: //Rise Kujikawa
                    System.Windows.Forms.CheckBox riAnalyzeCheckBox = new()
                    {
                        Text = "Analyze Always On?",
                        Font = awakeningCheckBox.Font,
                        AutoSize = true
                    };

                    System.Windows.Forms.CheckBox riTetrakarnCheckBox = new()
                    {
                        Text = "Tetrakarn Fast Recovery?",
                        Font = awakeningCheckBox.Font,
                        AutoSize = true
                    };

                    System.Windows.Forms.CheckBox riFieldCheckBox = new()
                    {
                        Text = "Risette Field Fast Recovery?",
                        Font = awakeningCheckBox.Font,
                        AutoSize = true
                    };

                    controlList.Add(riAnalyzeCheckBox);
                    controlList.Add(riTetrakarnCheckBox);
                    controlList.Add(riFieldCheckBox);                    
                    break;
                case 18: //Ken Amada
                    System.Windows.Forms.CheckBox amFastRecoveryCheckBox = new()
                    {
                        Text = "Koromaru HP Fast Recovery?",
                        Font = awakeningCheckBox.Font,
                        AutoSize = true
                    };

                    controlList.Add(amFastRecoveryCheckBox);
                    break;
                case 19: //Tohru Adachi
                    System.Windows.Forms.CheckBox adHeatCheckBox = new()
                    {
                        Text = "Heat Riser Always On?",
                        Font = awakeningCheckBox.Font,
                        AutoSize = true
                    };

                    System.Windows.Forms.CheckBox adMagatsuCheckBox = new()
                    {
                        Text = "Magatsu Mandala Always On?",
                        Font = awakeningCheckBox.Font,
                        AutoSize = true
                    };

                    controlList.Add(adHeatCheckBox);
                    controlList.Add(adMagatsuCheckBox);
                    break;
                case 20: //Marie
                    Label mrWeatherLabel = new()
                    {
                        Text = "Weather Forecast:",
                        Font = awakeningCheckBox.Font,
                        
                    };

                    ComboBox mrWeatherComboBox = new()
                    {
                        DropDownStyle = ComboBoxStyle.DropDownList
                    }; ;
                    mrWeatherComboBox.Items.Add("Sunny Weather");  //MariesOtenki 1
                    mrWeatherComboBox.Items.Add("Cloudy Weather"); //MariesOtenki 2
                    mrWeatherComboBox.Items.Add("Rainy Weather");  //MariesOtenki 3
                    mrWeatherComboBox.Items.Add("Snowy Weather");  //MariesOtenki 4
                    mrWeatherComboBox.SelectedIndex= 0;

                    controlList.Add(mrWeatherLabel);
                    controlList.Add(mrWeatherComboBox);
                    break;
            }

            int y = 3;
            Control? previousControl = null;  // Variable to keep track of the previous control
            foreach (Control listItem in controlList)
            {
#pragma warning disable CS8604 // Possible null reference argument.
                if (characterCrossReference[characterSelectComboBox.SelectedItem.ToString()] != null && characterCrossReference[characterSelectComboBox.SelectedItem.ToString()].Equals(typeof(RiseKujikawa))) 
                {
                    listItem.Location = new Point(3, y);
                    y += 25;
                    listItem.TabStop = false;
                    characterSpecificSettingsPanel.Controls.Add(listItem);
                    previousControl = listItem;
                }
#pragma warning restore CS8604 // Possible null reference argument.
                else
                {
                    if (previousControl != null && previousControl is Label && (!(listItem.GetType().Equals(typeof(Label)))))
                    {
                        // Shift the next control's location if the previous control was a Label
                        listItem.Location = new Point(129, y - 3);
                    }
                    else if (previousControl != null && previousControl is System.Windows.Forms.CheckBox && listItem.GetType().Equals(typeof(System.Windows.Forms.CheckBox)) && listItem != controlList.Last())
                    {
                        // Shift the checkbox location if the previous control was also a checkbox
                        Point lastCheckBoxLocation = previousControl.Location;
                        if (lastCheckBoxLocation.X == 3)
                        {
                            listItem.Location = new Point(129, y);
                        }
                        else
                        {
                            listItem.Location = new Point(3, y + 25);
                        }
                    }
                    else if (listItem != controlList[0])
                    {
                        // Use the default location if none of the above conditions are met
                        y += 25;
                        listItem.Location = new Point(3, y);
                    }
                    else
                    {
                        listItem.Location = new Point(3, y);
                    }

                    listItem.TabStop = false;
                    characterSpecificSettingsPanel.Controls.Add(listItem);
                    previousControl = listItem;
                }
                
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.About myForm = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };            
            myForm.ShowDialog();
        }

        private void DocumentationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string target = "https://github.com/Karasu456/P4U2-Combo-Notation-To-Trial-Converter/wiki";
            try
            {
                System.Diagnostics.Process.Start("cmd", "/c start " + target);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void SaveToTextFile()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            List<string> currentProperties = new()
            {                
                characterSelectComboBox.SelectedItem.ToString(),
                comboInputTextBox.Text.ToString(),
                stagePositionComboBox.SelectedItem.ToString(),
                enemyBehaviorComboBox.SelectedItem.ToString(),
                counterComboBox.SelectedItem.ToString(),
                percentHPTextBox.Text,
                percentSPTextBox.Text,
                burstReadyCheckBox.CheckState.ToString(),
                fullSPCheckBox.CheckState.ToString(),
                awakeningCheckBox.CheckState.ToString(),
                ichigekiReadyCheckBox.CheckState.ToString(),
                playerHPRecoveryCheckBox.CheckState.ToString(),
                enemyHPRecoveryCheckBox.CheckState.ToString(),
                playerPanicCheckBox.CheckState.ToString(),
                playerShockCheckBox.CheckState.ToString(),
                personaBrokenCheckBox.CheckState.ToString(),
                enemyFearCheckBox.CheckState.ToString(),
                noMissCheckBox.CheckState.ToString(),
                junhudoCheckBox.CheckState.ToString(),
                shadowCheckBox.CheckState.ToString(),
                infiniteFrenzyCheckBox.CheckState.ToString(),
            };
            if (characterSpecificSettingsPanel.Controls.Count > 0)
            {
                foreach (Control activeControl in characterSpecificSettingsPanel.Controls)
                {
                    switch (activeControl)
                    {
                        case System.Windows.Forms.CheckBox checkbox:
                            currentProperties.Add(checkbox.CheckState.ToString());
                            break;
                        case ComboBox comboBox:
                            currentProperties.Add(comboBox.SelectedItem.ToString());
                            break;
                        case NumericUpDown numericUpDown:
                            currentProperties.Add(numericUpDown.Value.ToString());
                            break;
                    }
                }
            }
#pragma warning restore CS8604 // Possible null reference argument.
            SaveFileDialog comboSaveFileDialog = new()
            {
                DefaultExt = "P4U2 Trial Combo File|*.combo",
                Filter = "P4U2 Trial Combo File (*.P4U2TrialCombo)|*.P4U2TrialCombo",
                Title = "Save a P4U2 Trial Combo File"
            };

            if (comboSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using StreamWriter writer = new(comboSaveFileDialog.FileName);
                foreach (string property in currentProperties)
                {
                    writer.WriteLine(property);
                }
            }            
        }

        private static void SetControlValue(Control control, string value)
        {
            switch (control)
            {
                case System.Windows.Forms.TextBox textBox:
                    textBox.Text = value;
                    break;
                case RichTextBox richTextBox:
                    richTextBox.Text = value;
                    break;
                case ComboBox comboBox:
                    comboBox.SelectedItem = value;
                    break;
                case CheckBox checkBox:
                    checkBox.CheckState = (CheckState)Enum.Parse(typeof(CheckState), value);
                    break;
            }     
        }

        private void LoadFromTextFile(object sender, EventArgs e)
        {
            List<string> propertiesToLoad;

            OpenFileDialog comboOpenFileDialog = new()
            {
                Filter = "P4U2 Trial Combo File (*.P4U2TrialCombo)|*.P4U2TrialCombo",
                Title = "Open a P4U2 Trial Combo File",
                CheckFileExists = true,
            };

            if(comboOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                BtnClearCombo_Click(sender, e);

                string[] lines = File.ReadAllLines(comboOpenFileDialog.FileName);
                propertiesToLoad = new List<string>(lines);

                Control[] controlsToSet = new Control[]
                {                    
                    characterSelectComboBox,
                    comboInputTextBox,
                    stagePositionComboBox,
                    enemyBehaviorComboBox,
                    counterComboBox,
                    percentHPTextBox,
                    percentSPTextBox,
                    burstReadyCheckBox,
                    fullSPCheckBox,
                    awakeningCheckBox,
                    ichigekiReadyCheckBox,
                    playerHPRecoveryCheckBox,
                    enemyHPRecoveryCheckBox,
                    playerPanicCheckBox,
                    playerShockCheckBox,
                    personaBrokenCheckBox,
                    enemyFearCheckBox,
                    noMissCheckBox,
                    junhudoCheckBox,
                    shadowCheckBox,
                    infiniteFrenzyCheckBox
                };

                try
                {
                    for (int i = 0; i < controlsToSet.Length; i++)
                    {
                        if (i >= propertiesToLoad.Count)
                        {
                            throw new Exception($"Input data is missing value for control at index {i}");
                        }
                        if (controlsToSet[i] is ComboBox comboBox)
                        {
                            if (!comboBox.Items.Contains(propertiesToLoad[i]))
                            {
                                throw new Exception($"Input data contains invalid value for ComboBox at index {i}");
                            }
                        }
                        else if (controlsToSet[i] is System.Windows.Forms.CheckBox checkBox)
                        {
                            if (!Enum.TryParse(propertiesToLoad[i], out CheckState state))
                            {
                                throw new Exception($"Input data contains invalid value for CheckBox at index {i}");
                            }
                        }
                        SetControlValue(controlsToSet[i], propertiesToLoad[i]);
                    }

                    if (propertiesToLoad.Count > 21 && characterSpecificSettingsPanel.Controls.Count > 0)
                    {
                        int propertyIndex = 21;
                        foreach (Control activeControl in characterSpecificSettingsPanel.Controls)
                        {
                            switch (activeControl)
                            {
                                case Label:
                                    continue;
                                case System.Windows.Forms.CheckBox checkbox:
                                    checkbox.CheckState = (CheckState)Enum.Parse(typeof(CheckState), propertiesToLoad[propertyIndex]);
                                    break;
                                case ComboBox comboBox:
                                    comboBox.SelectedItem = propertiesToLoad[propertyIndex];
                                    break;
                                case NumericUpDown numericUpDown:
                                    numericUpDown.Value = decimal.TryParse(propertiesToLoad[propertyIndex], out decimal result) ? result : 0;
                                    break;
                            }
                            propertyIndex++;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show($"ERROR!!!\r\n\r\nMissing or incorrectly loaded P4U2 Trial Combo data!\r\nPlease make sure it has not been edited outside the tool!");
                    return;
                }
            }
        }

        private void CharacterSpecificSettingsTimer_Tick(object sender, EventArgs e)
        {
            UpdateCharacterSettings();
        }

        private void SaveComboToTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveToTextFile();
        }

        private void BtnSaveCombo_Click(object sender, EventArgs e)
        {
            SaveToTextFile();
        }

        private void LoadComboFromTxtToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            LoadFromTextFile(sender, e);
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}