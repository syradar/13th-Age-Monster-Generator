using System.Collections.Generic;
using System.ComponentModel;

namespace _13AMonsterGenerator
{
    internal class Ability
    {
        public enum Trigger
        {
            Natural6Plus,
            Natural11Plus,
            [Description("Natural 16+")] Natural16Plus,
            Natural20,
            NaturalOddHit,
            NaturalOddMiss,
            [Description("Natural Even Hit")] NaturalEvenHit,
            NaturalEvenMiss,
            Hit,
            Miss,
            [Description("")] None
        }

        public Ability(string name, Trigger trigger, List<Effect> effects)
        {
            Name = name;
            AbilityTrigger = trigger;
            Effects = effects;
        }

        public Ability(string name, List<Effect> effects)
        {
            Name = name;
            Effects = effects;
            AbilityTrigger = Trigger.None;
        }

        public Ability(Trigger trigger, List<Effect> effects)
        {
            AbilityTrigger = trigger;
            Effects = effects;
            Name = "";
        }

        public List<Effect> Effects { get; private set; }
        public string Name { get; private set; }
        public Trigger AbilityTrigger { get; private set; }
    }
}