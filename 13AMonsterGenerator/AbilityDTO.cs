using System.Collections.Generic;

namespace _13AMonsterGenerator
{
    internal class AbilityDTO
    {
        public string Name { get; set; }
        public List<Effect> Effects { get; set; }

        public AbilityDTO(string name, IEnumerable<string> effects)
        {
            Name = name;
            Effects = new List<Effect>();
            foreach (var effect in effects)
            {
                Effects.Add(new Effect(effect));
            }
        }
    }
}