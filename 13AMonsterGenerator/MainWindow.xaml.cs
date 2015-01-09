using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace _13AMonsterGenerator
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeGui();
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
            var pt = new PlayerTier((int) PlayerLevelComboBox.SelectedValue);
            var monster = new Monster(new PlayerTier((int) PlayerLevelComboBox.SelectedValue));

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
                MonsterTextBox.AppendText(attack.name);
                MonsterTextBox.AppendText(" +");
                MonsterTextBox.AppendText(attack.attackModifier.ToString());
                MonsterTextBox.AppendText(" vs. ");
                MonsterTextBox.AppendText(EnumUtilites.StringValueOf(attack.AttackAgainstDefense));
                MonsterTextBox.AppendText(" -- ");
                MonsterTextBox.AppendText(attack.damage.ToString());
                MonsterTextBox.AppendText(" ");
                MonsterTextBox.AppendText(attack.onHitEffect.description);
                MonsterTextBox.AppendText(Environment.NewLine);
                AddAbility(attack.listOfAbilities, true);
            }
            MonsterTextBox.AppendText(Environment.NewLine);

            AddAbility(monster.ListOfAbilities, false);

            MonsterTextBox.AppendText(Environment.NewLine);
            MonsterTextBox.AppendText("Attack: " + (monster.Level + 5));
            MonsterTextBox.AppendText(" Damage: " + (monster.Level + 1 * 8));
            MonsterTextBox.AppendText(Environment.NewLine);

            MonsterTextBox.AppendText("AC ");
            MonsterTextBox.AppendText(monster.ArmourClass.ToString());
            MonsterTextBox.AppendText(" HP ");
            MonsterTextBox.AppendText(monster.HealthPoints.ToString());

            MonsterTextBox.AppendText(Environment.NewLine);

            MonsterTextBox.AppendText("PD ");
            MonsterTextBox.AppendText(monster.PhysicalDefense.ToString());
            MonsterTextBox.AppendText(" MD ");
            MonsterTextBox.AppendText(monster.MentalDefense.ToString());
        }

        private void AddAbility(IEnumerable<Ability> listOfAbilities, bool isIndented)
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
                    MonsterTextBox.AppendText(effect.description);
                    MonsterTextBox.AppendText(". ");
                }

                MonsterTextBox.AppendText(Environment.NewLine);
            }
        }
    }
}