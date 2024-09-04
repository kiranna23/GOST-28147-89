using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    public class BasicStep
    {
        public static string Step_1(string N1, string X)
        {
            int[] result = new int[32];
            int a = 0;
            for (int i = 31; i >= 0; --i)
            {
                int intN1 = (int)Char.GetNumericValue(N1[i]);
                int intX = (int)Char.GetNumericValue(X[i]);
                int s = intN1 + intX + a;
                if (s < 2)
                {
                    result[i] = s;
                    a = 0;
                }
                if (s == 2)
                {
                    result[i] = 0;
                    a = 1;
                }
                if (s == 3)
                {
                    result[i] = 1;
                    a = 1;
                }
            }
            string binarySum = Converter.Convert_string(result);
            return binarySum;
        }
        public static string Step_2(string[,] table1, string CM1)
        {
            string result = "";
            for (int i = 0; i < CM1.Length / 4; i++)
            {
                string buffer = CM1.Substring(i * 4, 4);
                int num = Converter.Convert_dec(buffer);
                result += table1[8 - i - 1, num];
            }
            return result;
        }
        public static string Step_3(string R1)
        {
            string buffer = R1.Substring(11, 21);
            buffer += R1.Substring(0, 11);
            return buffer;
        }
        public static string Step_4(string R2, string N2)
        {
            int[] result = new int[32];
            for (int i = 31; i >= 0; --i)
            {
                int intR2 = (int)Char.GetNumericValue(R2[i]);
                int intN2 = (int)Char.GetNumericValue(N2[i]);
                int s = intR2 + intN2;
                if (s == 1)
                {
                    result[i] = 1;
                }
                else
                {
                    result[i] = 0;
                }
            }
            string binarySum = Converter.Convert_string(result);
            return binarySum;
        }
    }
}
