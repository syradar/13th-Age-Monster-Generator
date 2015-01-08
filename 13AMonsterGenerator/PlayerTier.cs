using System.Collections.Generic;
using System.Linq;

namespace _13AMonsterGenerator
{
    internal class PlayerTier
    {
        public enum Tiers
        {
            Adventure,
            Champion,
            Epic
        };

        public PlayerTier(int level)
        {
            Level = level;
            GetTierFromLevel();
            GetMonsterLevelAdjustmentsFromTier();
            MonsterLevelAdjustment = MonsterLevelAdjustmentRange.ElementAt(3);
        }

        public int Level { get; private set; }
        public Tiers Tier { get; private set; }
        public string Name { get; private set; }
        public List<int> MonsterLevelAdjustmentRange { get; private set; }
        public int MonsterLevelAdjustment { get; private set; }

        public void SetMonsterLevelAdjustment(int monsterLevelAdjustment)
        {
            if (MonsterLevelAdjustmentRange.Contains(monsterLevelAdjustment))
            {
                MonsterLevelAdjustment = monsterLevelAdjustment;
            }
        }

        private void GetTierFromLevel()
        {
            if (Level >= 0 && Level <= 4)
            {
                Tier = Tiers.Adventure;
                Name = "Adventure";
            }
            else if (Level >= 5 && Level <= 7)
            {
                Tier = Tiers.Champion;
                Name = "Champion";
            }
            else if (Level >= 8 && Level <= 10)
            {
                Tier = Tiers.Epic;
                Name = "Epic";
            }
        }

        private void GetMonsterLevelAdjustmentsFromTier()
        {
            if (Tier.Equals(Tiers.Adventure))
            {
                MonsterLevelAdjustmentRange = new List<int> {-2, -1, 0, 1, 2, 3, 4};
            }
            else if (Tier.Equals(Tiers.Champion))
            {
                MonsterLevelAdjustmentRange = new List<int> {-1, 0, 1, 2, 3, 4, 5};
            }
            else if (Tier.Equals(Tiers.Epic))
            {
                MonsterLevelAdjustmentRange = new List<int> {0, 1, 2, 3, 4, 5, 6};
            }
        }
    }
}