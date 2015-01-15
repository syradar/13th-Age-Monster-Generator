using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13AMonsterGenerator
{
    class DefenseType
    {
        public DefenseType(Type type)
        {
            switch (type)
            {
                case Type.Ac:
                    SetAc();
                    break;
                case Type.Pd:
                    SetMd();
                    break;
                case Type.Md:
                    SetPd();
                    break;
                default:
                    SetAc();
                    break;
            }
        }

        public DefenseType()
        {
        }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string Name { get; private set; }
        public string Shortname { get; private set; }
        public int Weight { get; private set; }

        private void SetAc()
        {
            Name = "Armour Class";
            Shortname = "AC";
            Weight = 12;
        }

        private void SetMd()
        {
            Name = "Mental Defense";
            Shortname = "MD";
            Weight = 4;
        }

        private void SetPd()
        {
            Name = "Physical Defense";
            Shortname = "PD";
            Weight = 4;
        }

        public enum Type
        {
            Ac,
            Pd,
            Md
        }
    }
}
