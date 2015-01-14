using System.ComponentModel;

namespace _13AMonsterGenerator
{
    internal class Element
    {
        public enum ElementType
        {
            [Description("")]Regular,
            [Description("Fire")]Fire,
            [Description("Thunder")]Thunder,
            [Description("Ice")]Ice,
            [Description("Negative energy")]NegativeEnergy
        }
    }
}