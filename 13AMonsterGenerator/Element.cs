using System.ComponentModel;

namespace _13AMonsterGenerator
{
    internal class Element
    {
        public enum ElementType
        {
            [Description("")]Regular,
            [Description("fire")]Fire,
            [Description("thunder")]Thunder,
            [Description("cold")]Ice,
            [Description("negative energy")]NegativeEnergy
        }
    }
}