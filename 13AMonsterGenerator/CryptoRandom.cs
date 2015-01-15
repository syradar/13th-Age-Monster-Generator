using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _13AMonsterGenerator
{
    internal static class CryptoRandom
    {
        public static IList<T> Shuffle<T>(IList<T> list)
        {
            var copiedList = list.ToList();
            var provider = new RNGCryptoServiceProvider();
            int listCount = copiedList.Count;
            while (listCount > 1)
            {
                var box = new byte[1];
                do
                {
                    provider.GetBytes(box);
                } while (!(box[0] < listCount * (Byte.MaxValue / listCount)));

                var newRandomNumber = (box[0] % listCount);
                listCount--;
                var value = copiedList[newRandomNumber];
                copiedList[newRandomNumber] = copiedList[listCount];
                copiedList[listCount] = value;
            }

            return copiedList;
        }
    }
}