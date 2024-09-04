using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    public class Converter
    {
        public static string Convert_key(byte[] key)
        {
            string hex = "";
            string hexNumber = "";
            string result = "";
            int decNumber = 0;
            for (int i = 0; i < key.Length; i++)
            {
                decNumber = key[i];
                if (decNumber == 10 || decNumber == 11 || decNumber == 12 || decNumber == 13 || decNumber == 14 || decNumber == 15)
                {
                    hexNumber = decNumber.ToString("X");
                    hex = '0' + hexNumber;
                }
                else
                {
                    hexNumber = decNumber.ToString("X");
                    hex = hexNumber;
                    if (hex.Length == 1)
                        hex = '0' + hex;
                }
                for (int j = 0; j < 2; j++)
                {
                    string s = Char.ToString(hex[j]);
                    string binaryNumber = Convert.ToString(Convert.ToInt32(s, 16), 2);
                    if (binaryNumber.Length != 4)
                    {
                        int num = 4 - binaryNumber.Length;
                        for (int k = 0; k < num; k++)
                        {
                            result = result + "0";
                        }
                        result += binaryNumber;
                    }
                    else
                    {
                        result += binaryNumber;
                    }
                }
            }
            return result;
        }

        public static byte[] DataToByte(string data)
        {
            int size = data.Length / 8;
            byte[] result = new byte[size];
            for (int i = 0; i < size; i++)
            {
                string symbol = data.Substring(i * 8, 8);
                string hex = Convert.ToString(Convert.ToInt32(symbol, 2), 16);
                int num = Convert.ToInt32(hex, 16);
                result[i] = (byte)num;
            }

            return result;
        }
        public static string Convert_string(int[] result)
        {
            string res = "";
            for (int i = 0; i < result.Length; i++)
            {
                res += Convert.ToString(result[i]);
            }
            return res;
        }
        public static int Convert_dec(string res)
        {
            int j = 0;
            double result = 0;
            int result1 = 0;
            for (int i = res.Length - 1; i >= 0; --i)
            {
                int intN = (int)Char.GetNumericValue(res[i]);
                if (intN == 1)
                {
                    result += Math.Pow(2, j);
                }
                j++;
            }
            result1 = (int)result;
            return result1;
        }
        public static string[] Blocks(string Text)
        {
            int size = Text.Length / 64;
            string[] result = new string[size];
            for (int i = 0; i < size; i++)
            {
                result[i] = Text.Substring(i * 64, 64);
            }
            result = Enumerable.Reverse(result).ToArray();
            return result;
        }
        public static string Convert_text(string file)
        {
            string Result = "";
            byte[] buffer = Encoding.UTF8.GetBytes(file);
            byte[] buffer1 = Enumerable.Reverse(buffer).ToArray();
            Result = Convert_key(buffer1);
            return Result;
        }
        public static string Reverse_N(string N1, string N2)
        {
            string result = "", n1 = "", n2 = "";
            string[] buffer1 = new string[8];
            string[] buffer2 = new string[8];
            for (int i = 0; i < 8; i++)
            {
                buffer1[i] = N1.Substring(i * 4, 4);
                buffer2[i] = N2.Substring(i * 4, 4);
            }
            buffer1 = Enumerable.Reverse(buffer1).ToArray();
            buffer2 = Enumerable.Reverse(buffer2).ToArray();
            int j = 0;
            for (int i = 0; i < 4; i++)
            {
                n1 += buffer1[j + 1] + buffer1[j];
                n2 += buffer2[j + 1] + buffer2[j];
                j += 2;
            }
            result = n1 + n2;
            return result;
        }

        public static string[,] Table(byte[,] table)
        {
            string[,] buffer = new string[8, 16];
            string stroka = "";
            for (int i = 0; i < 8; i++)
            {
                byte[] byyte = new byte[8];
                for (int j = 0; j < 8; j++)
                {
                    byyte[j] = table[i, j];
                }
                stroka = Converter.Convert_key(byyte);
                for (int j = 0; j < 16; j = j + 2)
                {
                    string stroka1 = stroka.Substring(j * 4, 4);
                    string stroka2 = stroka.Substring((j + 1) * 4, 4);
                    buffer[i, j] = stroka2;
                    buffer[i, j + 1] = stroka1;
                }
            }
            return buffer;
        }
    }
}
