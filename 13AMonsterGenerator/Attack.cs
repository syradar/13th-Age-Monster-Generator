using System.Collections.Generic;
using System.ComponentModel;

namespace _13AMonsterGenerator
{
    internal class Attack
    {
        public int AttackModifier { get; private set; }
        public int Damage { get; private set; }
        public Defense AttackAgainstDefense { get; private set; }
        public List<Ability> ListOfAbilities { get; private set; }
        public string Name { get; private set; }
        public Effect OnHitEffect { get; private set; }

        public Attack(int attackModifier, Defense attackAgainstDefense, int damage, List<Ability> listOfAbilities, string name, Effect onHitEffect)
        {
            AttackModifier = attackModifier;
            AttackAgainstDefense = attackAgainstDefense;
            Damage = damage;
            ListOfAbilities = listOfAbilities;
            Name = name;
            OnHitEffect = onHitEffect;
        }

        public enum Defense
        {
            [Description("AC")] Ac,
            [Description("PD")] Pd,
            [Description("MD")] Md
        }
    }
}