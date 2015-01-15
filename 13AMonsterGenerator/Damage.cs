using System.ComponentModel;

namespace _13AMonsterGenerator
{
    internal class Damage
    {
        public enum Type
        {
            [Description("")] Direct = 10,
            [Description("ongoing")] Ongoing = 2
        };

        public Damage(int damageNumber, Element.ElementType damageElement, Type damageType)
        {
            DamageNumber = damageNumber;
            DamageElement = damageElement;
            DamageType = damageType;
        }

        public int DamageNumber { get; private set; }
        public Element.ElementType DamageElement { get; private set; }
        public Type DamageType { get; private set; }
    }
}