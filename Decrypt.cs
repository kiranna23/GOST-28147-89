using System;

namespace Crypto
{
    public class Decrypt
    {
        public static string MainProgramm(byte[] key, byte[,] table2, byte[] TextBin)
        {
            string result = "";
            string[,] table11 = new string[8, 16];
            table11 = Converter.Table(table2);
            string KEY = Converter.Convert_key(key);
            string TEXT = Converter.Convert_key(TextBin);
            string[] blocks = Converter.Blocks(TEXT);

            for (int j = 0; j < blocks.Length; j++)
            {
                string N1 = blocks[j].Substring(blocks[j].Length / 2);
                string N2 = blocks[j].Substring(0, blocks[j].Length / 2);

                for (int i = 0; i < 8; i++)
                {
                    string X = KEY.Substring(i * 32, 32);
                    string CM1 = BasicStep.Step_1(N1, X);
                    string table = BasicStep.Step_2(table11, CM1);
                    string R2 = BasicStep.Step_3(table);
                    string CM2 = BasicStep.Step_4(R2, N2);
                    N2 = N1;
                    N1 = CM2;
                }
                for (int k = 0; k < 3; k++)
                {
                    for (int i = 7; i >= 0; --i)
                    {
                        string X = KEY.Substring(i * 32, 32);
                        string CM1 = BasicStep.Step_1(N1, X);
                        string table = BasicStep.Step_2(table11, CM1);
                        string R2 = BasicStep.Step_3(table);
                        string CM2 = BasicStep.Step_4(R2, N2);
                        if (i == 0 && k == 2)
                        {
                            N2 = CM2;
                        }
                        else
                        {
                            N2 = N1;
                            N1 = CM2;
                        }
                    }
                }
                result += Converter.Reverse_N(N1, N2);
            }
            return result;
        }
    }
}