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
        private Monster _monster;
        private PlayerTier _playerTier;

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
                var abilityDeserializeObject =
                    JsonConvert.DeserializeObject<List<AbilityDTO>>(
                        File.ReadAllText(Properties.Resources.AbilitiesJsonPath));

                _abilityList = new List<Ability>();
                foreach (var abilityDto in abilityDeserializeObject)
                {
                    _abilityList.Add(new Ability(abilityDto));
                }
            }
            catch (IOException e)
            {
                MessageBox.Show("Could not find Abilities.json in Data folder :(" + Environment.NewLine + e);
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
            _playerTier = new PlayerTier((int) PlayerLevelComboBox.SelectedValue);
            _monster = new Monster(new PlayerTier((int) PlayerLevelComboBox.SelectedValue), _abilityList.ToList());

            if (!txtMonsterName.Text.Equals(""))
            {
                _monster.Name = txtMonsterName.Text;
            }

            OutputMonster(_playerTier, _monster);
            txtMonsterName.IsEnabled = true;
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


            monster.ListOfAttacks =
                monster.ListOfAttacks.OrderByDescending(d => d.TypeOfAttack.Name == "Melee")
                    .ThenBy(d => d.TypeOfAttack.Name == "Range")
                    .ThenBy(d => d.TypeOfAttack.Name == "Close")
                    .ThenBy(d => d.AttackAgainstDefense.Shortname == "MD")
                    .ThenBy(d => d.AttackAgainstDefense.Shortname == "PD")
                    .ThenBy(d => d.AttackAgainstDefense.Shortname == "AC")
                    .ToList();
            foreach (var attack in monster.ListOfAttacks)
            {
                MonsterTextBox.AppendText(attack.TypeOfAttack.Shortname);
                if (attack.TypeOfAttack.Shortname.Equals("R") || attack.TypeOfAttack.Shortname.Equals("C"))
                {
                    MonsterTextBox.AppendText(": ");
                }
                MonsterTextBox.AppendText(attack.Name);
                MonsterTextBox.AppendText(" +");
                MonsterTextBox.AppendText(attack.AttackModifier.ToString());
                MonsterTextBox.AppendText(" vs. ");
                MonsterTextBox.AppendText(attack.AttackAgainstDefense.Shortname);
                MonsterTextBox.AppendText(" -- ");
                MonsterTextBox.AppendText(attack.Damage.DamageNumber.ToString());
                MonsterTextBox.AppendText(" ");
                MonsterTextBox.AppendText(EnumUtilites.StringValueOf(attack.Damage.DamageType));
                MonsterTextBox.AppendText(" ");
                MonsterTextBox.AppendText(EnumUtilites.StringValueOf(attack.Damage.DamageElement));
                MonsterTextBox.AppendText(" damage ");
                MonsterTextBox.AppendText(attack.OnHitEffect.Description);
                MonsterTextBox.AppendText(Environment.NewLine);
                OutputAbilities(attack.ListOfAbilities, true);
            }
            MonsterTextBox.AppendText(Environment.NewLine);

            OutputAbilities(monster.ListOfAbilities, false);

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

        private void OutputAbilities(IEnumerable<Ability> listOfAbilities, bool isIndented)
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

                var newEffectDescription = "";

                foreach (var effect in ability.Effects)
                {
                    if (effect.Description.Contains("MONSTER_NAME"))
                    {
                        newEffectDescription = effect.Description.Replace("MONSTER_NAME", _monster.Name);
                    }
                    MonsterTextBox.AppendText(newEffectDescription);
                    MonsterTextBox.AppendText(". ");
                }

                MonsterTextBox.AppendText(Environment.NewLine);
            }
        }

        private void TxtMonsterNameChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            _monster.Name = txtMonsterName.Text;
            OutputMonster(_playerTier, _monster);
        }
    }
}