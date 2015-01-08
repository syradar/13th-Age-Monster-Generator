using System.Collections.Generic;
using System.Linq;

namespace _13AMonsterGenerator
{
    internal static class DifficultyValue
    {
        private static List<double> standardDifficultyValue = new List<double> {0.5, 0.7, 1, 1.5, 2, 3, 4};
        private static List<double> mookDifficultyValue = new List<double> {0.1, 0.15, 0.2, 0.3, 0.4, 0.6, 0.8};
        private static List<double> largeDifficultyValue = new List<double> {1, 1.5, 2, 3, 4, 6, 8};
        private static List<double> hugeDifficultyValue = new List<double> {1.5, 2, 3, 4, 6, 8, 12};

        public static double GetDifficultyValue(PlayerTier.Tiers tier, int monsterLevelAdjustment,
                                                string monsterType)
        {
            double difficultyValue = 0;

            switch (monsterType)
            {
                case "Standard":
                {
                    switch (tier)
                    {
                        case PlayerTier.Tiers.Adventure:
                        {
                            difficultyValue = standardDifficultyValue.ElementAt(monsterLevelAdjustment + 2);
                            break;
                        }

                        case PlayerTier.Tiers.Champion:
                        {
                            difficultyValue = standardDifficultyValue.ElementAt(monsterLevelAdjustment + 1);
                            break;
                        }

                        case PlayerTier.Tiers.Epic:
                        {
                            difficultyValue = standardDifficultyValue.ElementAt(monsterLevelAdjustment);
                            break;
                        }
                    }
                    break;
                }
                case "Mook":
                {
                    switch (tier)
                    {
                        case PlayerTier.Tiers.Adventure:
                        {
                            difficultyValue = mookDifficultyValue.ElementAt(monsterLevelAdjustment + 2);
                            break;
                        }

                        case PlayerTier.Tiers.Champion:
                        {
                            difficultyValue = mookDifficultyValue.ElementAt(monsterLevelAdjustment + 1);
                            break;
                        }

                        case PlayerTier.Tiers.Epic:
                        {
                            difficultyValue = mookDifficultyValue.ElementAt(monsterLevelAdjustment);
                            break;
                        }
                    }
                    break;
                }
                case "Large":
                {
                    switch (tier)
                    {
                        case PlayerTier.Tiers.Adventure:
                        {
                            difficultyValue = largeDifficultyValue.ElementAt(monsterLevelAdjustment + 2);
                            break;
                        }

                        case PlayerTier.Tiers.Champion:
                        {
                            difficultyValue = largeDifficultyValue.ElementAt(monsterLevelAdjustment + 1);
                            break;
                        }

                        case PlayerTier.Tiers.Epic:
                        {
                            difficultyValue = largeDifficultyValue.ElementAt(monsterLevelAdjustment);
                            break;
                        }
                    }
                    break;
                }
                case "Huge":
                {
                    switch (tier)
                    {
                        case PlayerTier.Tiers.Adventure:
                        {
                            difficultyValue = hugeDifficultyValue.ElementAt(monsterLevelAdjustment + 2);
                            break;
                        }

                        case PlayerTier.Tiers.Champion:
                        {
                            difficultyValue = hugeDifficultyValue.ElementAt(monsterLevelAdjustment + 1);
                            break;
                        }

                        case PlayerTier.Tiers.Epic:
                        {
                            difficultyValue = hugeDifficultyValue.ElementAt(monsterLevelAdjustment);
                            break;
                        }
                    }
                    break;
                }
            }
            return difficultyValue;
        }
    }
}