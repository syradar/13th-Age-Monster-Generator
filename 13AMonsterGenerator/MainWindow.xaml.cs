using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using Newtonsoft.Json;

namespace _13AMonsterGenerator
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private List<Ability> _abilityList;

        public MainWindow()
        {
            InitializeComponent();
            InitializeGui();
            PopulateAbilityList();
        }

        private void PopulateAbilityList()
        {
            try
            {
                var abilityDeserializeObject = JsonConvert.DeserializeObject<List<AbilityDTO>>(File.ReadAllText(Properties.Resources.AbilitiesJsonPath));

                _abilityList = new List<Ability>();
                foreach (var abilityDto in abilityDeserializeObject)
                {
                    _abilityList.Add(new Ability(abilityDto));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Could not find Abilities.json in Data folder :(");
                Application.Current.Shutdown();
            }
        }

        private void InitializeGui()
        {
            for (var i = 1; i <= 10; i++)
            {
                PlayerLevelComboBox.Items.Add(i);
            }

            PlayerLevelComboBox.SelectedIndex = 0;
        }

        private void GenerateMonsterClicked(object sender, RoutedEventArgs e)
        {
            var playerTier = new PlayerTier((int) PlayerLevelComboBox.SelectedValue);
            var monster = new Monster(new PlayerTier((int)PlayerLevelComboBox.SelectedValue), _abilityList.ToList());
            OutputMonster(playerTier, monster);
        }

        private void OutputMonster(PlayerTier pt, Monster monster)
        {
            MonsterTextBox.Text = String.Empty;
            MonsterTextBox.AppendText("Player Level: " + pt.Level.ToString());
            MonsterTextBox.AppendText(Environment.NewLine + "Monster Level Adjustment Range: ");
            foreach (var monsterLevelAdjustment in pt.MonsterLevelAdjustmentRange)
            {
                MonsterTextBox.AppendText(monsterLevelAdjustment.ToString() + ", ");
            }

            MonsterTextBox.AppendText(Environment.NewLine + "Monster Tier: ");

            MonsterTextBox.AppendText(pt.Name);

            MonsterTextBox.AppendText(Environment.NewLine);
            MonsterTextBox.AppendText("Monster Level Adjustment: " + monster.PlayerTier.MonsterLevelAdjustment);
            MonsterTextBox.AppendText(Environment.NewLine);
            MonsterTextBox.AppendText(Environment.NewLine);
            MonsterTextBox.AppendText("<<Generated listOfAbilities>>");
            MonsterTextBox.AppendText(Environment.NewLine);


            MonsterTextBox.AppendText(monster.Name);
            MonsterTextBox.AppendText(Environment.NewLine);
            MonsterTextBox.AppendText(monster.GetMonster());
            MonsterTextBox.AppendText(Environment.NewLine);

            foreach (var attack in monster.ListOfAttacks)
            {
                MonsterTextBox.AppendText(attack.Name);
                MonsterTextBox.AppendText(" +");
                MonsterTextBox.AppendText(attack.AttackModifier.ToString());
                MonsterTextBox.AppendText(" vs. ");
                MonsterTextBox.AppendText(EnumUtilites.StringValueOf(attack.AttackAgainstDefense));
                MonsterTextBox.AppendText(" -- ");
                MonsterTextBox.AppendText(attack.Damage.ToString());
                MonsterTextBox.AppendText(" ");
                MonsterTextBox.AppendText(attack.OnHitEffect.Description);
                MonsterTextBox.AppendText(Environment.NewLine);
                OutputAbility(attack.ListOfAbilities, true);
            }
            MonsterTextBox.AppendText(Environment.NewLine);

            OutputAbility(monster.ListOfAbilities, false);

            MonsterTextBox.AppendText("AC ");
            MonsterTextBox.AppendText(monster.ArmourClass.ToString());
            MonsterTextBox.AppendText(" HP ");
            MonsterTextBox.AppendText(monster.HealthPoints.ToString());

            MonsterTextBox.AppendText(Environment.NewLine);

            MonsterTextBox.AppendText("PD ");
            MonsterTextBox.AppendText(monster.PhysicalDefense.ToString());
            MonsterTextBox.AppendText(" MD ");
            MonsterTextBox.AppendText(monster.MentalDefense.ToString());
            MonsterTextBox.AppendText(Environment.NewLine);

            if (monster.MonsterRole.Equals("Mook"))
            {
                MonsterTextBox.AppendText("Mook: Kill one ");
                MonsterTextBox.AppendText(monster.Name);
                MonsterTextBox.AppendText(" ");
                MonsterTextBox.AppendText(monster.MonsterType);
                MonsterTextBox.AppendText(" for every ");
                MonsterTextBox.AppendText(monster.HealthPoints.ToString());
                MonsterTextBox.AppendText("  damage you deal to the mob");
            }
        }

        private void OutputAbility(IEnumerable<Ability> listOfAbilities, bool isIndented)
        {
            foreach (var ability in listOfAbilities)
            {
                MonsterTextBox.AppendText(isIndented ? "    " : "");
                if (ability.Name != null)
                {
                    MonsterTextBox.AppendText(ability.Name);
                    MonsterTextBox.AppendText(" ");
                }

                MonsterTextBox.AppendText(EnumUtilites.StringValueOf(ability.AbilityTrigger));
                MonsterTextBox.AppendText(": ");

                foreach (var effect in ability.Effects)
                {
                    MonsterTextBox.AppendText(effect.Description);
                    MonsterTextBox.AppendText(". ");
                }

                MonsterTextBox.AppendText(Environment.NewLine);
            }
        }
    }
}