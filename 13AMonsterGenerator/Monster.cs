using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _13AMonsterGenerator
{
    internal class Monster
    {
        private static readonly List<string> MonsterSizeList = new List<string> {"Standard", "Mook", "Large", "Huge"};
        private static readonly List<string> MonsterRoleList = new List<string> {"Mook", "Archer", "Caster", "Leader", "Spoiler", "Troop", "Wrecker"};
        private static readonly List<string> MonsterTypeList = new List<string> {"Aberration", "Beast", "Construct", "Demon", "Dragon", "Giant", "Humanoid", "Ooze", "Plant", "Undead"};
        private Random random;

        public Monster(PlayerTier playerTier)
        {
            PlayerTier = playerTier;
            CreateNewMonsterFromLevel();
        }

        public string Name { get; set; }
        public int Level { get; set; }
        public string MonsterSize { private set; get; }
        public string MonsterRole { private set; get; }
        public string MonsterType { private set; get; }
        public int InitiativeModifier { get; set; }
        public List<Attack> ListOfAttacks { get; set; }
        public List<Ability> ListOfAbilities { get; set; }
        public int ArmourClass { get; set; }
        public int HealthPoints { get; set; }
        public int PhysicalDefense { get; set; }
        public int MentalDefense { get; set; }
        public PlayerTier PlayerTier { get; private set; }
        public double MonsterDifficultyValue { get; private set; }

        private void CreateNewMonsterFromLevel()
        {
            random = new Random();
            PlayerTier.SetMonsterLevelAdjustment(
                PlayerTier.MonsterLevelAdjustmentRange.ElementAt(
                    random.Next(PlayerTier.MonsterLevelAdjustmentRange.Count)));

            Level = PlayerTier.Level + PlayerTier.MonsterLevelAdjustment;
            if (Level < 0)
            {
                Level = 0;
            }

            MonsterRole = MonsterRoleList.ElementAt(random.Next(MonsterRoleList.Count));
            MonsterSize = MonsterSizeList.ElementAt(random.Next(MonsterSizeList.Count));
            MonsterType = MonsterTypeList.ElementAt(random.Next(MonsterTypeList.Count));
            if (MonsterSize.Equals("Mook") && !MonsterRole.Equals("Mook"))
            {
                MonsterRole = "Mook";
            }
            MonsterDifficultyValue = DifficultyValue.GetDifficultyValue(PlayerTier.Tier,PlayerTier.MonsterLevelAdjustment, MonsterSize);

        }

        public String GetMonster()
        {
            var sb = new StringBuilder();

            sb.Append(MonsterSize.Equals("Standard") || MonsterSize.Equals("Mook") ? "" : MonsterSize + " ");
            sb.Append(Level);
            sb.Append(GetNumberSuffix(Level));
            sb.Append(" level ");

            sb.Append(MonsterRole);
            sb.AppendFormat(" [{0}]", MonsterType);
            sb.Append(" Difficulty Value: ");
            sb.Append(MonsterDifficultyValue);

            return sb.ToString();
        }

        private string GetNumberSuffix(int number)
        {
            if (number == 1)
            {
                return "st";
            }
            if (number == 2)
            {
                return "nd";
            }
            if (number == 3)
            {
                return "rd";
            }
            return "th";
        }
    }
}