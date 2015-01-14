namespace _13AMonsterGenerator
{
    internal class AttackType
    {
        public enum Type
        {
            Melee,
            Range,
            Close
        }

        public AttackType(Type type)
        {
            switch (type)
            {
                case Type.Melee:
                    SetMelee();
                    break;
                case Type.Range:
                    SetRange();
                    break;
                case Type.Close:
                    SetClose();
                    break;
                default:
                    SetMelee();
                    break;
            }
        }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string Name { get; private set; }
        public string Shortname { get; private set; }
        public int Weight { get; private set; }

        private void SetMelee()
        {
            Name = "Melee";
            Shortname = "";
            Weight = 8;
        }

        private void SetRange()
        {
            Name = "Range";
            Shortname = "R";
            Weight = 8;
        }

        private void SetClose()
        {
            Name = "Close";
            Shortname = "C";
            Weight = 4;
        }
    }
}