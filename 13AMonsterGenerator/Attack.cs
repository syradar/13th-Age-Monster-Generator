using System.Collections.Generic;
using System.ComponentModel;

namespace _13AMonsterGenerator
{
    internal class Attack
    {
        public int AttackModifier { get; private set; }
        public Damage Damage { get; private set; }
        public AttackType TypeOfAttack { get; private set; }
        public Defense AttackAgainstDefense { get; private set; }
        public List<Ability> ListOfAbilities { get; private set; }
        public string Name { get; private set; }
        public Effect OnHitEffect { get; private set; }

        public Attack(int attackModifier, AttackType attackType, Defense attackAgainstDefense, Damage damage,
                      List<Ability> listOfAbilities, string name, Effect onHitEffect)
        {
            AttackModifier = attackModifier;
            TypeOfAttack = attackType;
            AttackAgainstDefense = attackAgainstDefense;
            Damage = damage;
            ListOfAbilities = listOfAbilities;
            Name = name;
            OnHitEffect = onHitEffect;
        }

        public enum Defense
        {
            [Description("AC")] Ac = 12,
            [Description("PD")] Pd = 4,
            [Description("MD")] Md = 4
        }
    }
}