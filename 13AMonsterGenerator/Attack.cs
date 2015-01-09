using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace _13AMonsterGenerator
{
    internal class Attack
    {
        public int attackModifier { get; private set; }
        public int damage { get; private set; }
        public Defense AttackAgainstDefense { get; private set; }
        public List<Ability> listOfAbilities { get; private set; }
        public string name { get; private set; }
        public Effect onHitEffect { get; private set; }

        public Attack(int attackModifier, Defense attackAgainstDefense, int damage, List<Ability> listOfAbilities, string name, Effect onHitEffect)
        {
            this.attackModifier = attackModifier;
            AttackAgainstDefense = attackAgainstDefense;
            this.damage = damage;
            this.listOfAbilities = listOfAbilities;
            this.name = name;
            this.onHitEffect = onHitEffect;
        }

        public enum Defense
        {
            [Description("AC")] Ac,
            [Description("PD")] Pd,
            [Description("MD")] Md,
        }
    }
}