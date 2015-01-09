using System;
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
            MonsterTextBox.AppendText("<<Generated monster>>");
            MonsterTextBox.AppendText(Environment.NewLine);


            MonsterTextBox.AppendText(monster.GetMonster());
            MonsterTextBox.AppendText(Environment.NewLine);
            MonsterTextBox.AppendText(monster.HealthPoints.ToString());

            MonsterTextBox.AppendText(Environment.NewLine);
            MonsterTextBox.AppendText(Environment.NewLine);
            MonsterTextBox.AppendText(Environment.NewLine);


        }
    }
}