using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    public class File1
    {
        public static byte[] ReadKey(string filePath)
        {
            byte[] key = new byte[32];
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    using (BinaryReader binaryReader = new BinaryReader(fileStream))
                    {
                        byte[] buffer = new byte[8];
                        int bytesRead;
                        int i = 0;
                        int m = 3;
                        int n = 0;
                        if (fileStream.Length != 32)
                            return null;

                        while ((bytesRead = binaryReader.Read(buffer, 0, buffer.Length)) > 0)
                        {

                            for (int k = 0; k < 2; k++)
                            {
                                for (int j = 0; j < 4; j++)
                                {
                                    key[j + n] = buffer[m - j];
                                }
                                m = 7;
                                n += 4;
                            }
                            m = 3;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading binary file: {0}", ex.Message);
            }
            return key;
        }

        public static byte[] ReadTextBin(string filePath)
        {
            byte[] data = new byte[1];
            if (File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        if (fs.Length % 8 != 0)
                            return null;
                        data = new byte[fs.Length];
                        int bytesRead = br.Read(data, 0, data.Length);
                        data = Enumerable.Reverse(data).ToArray();
                    }
                }
            }
            else
            {
                Console.WriteLine("File does not exist");
            }
            return data;
        }

        public static byte[,] ReadTableBin(string filePath)
        {
            byte[,] table = new byte[8, 8];
            if (File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        long a = fs.Length;
                        if (a != 64)
                            return null;
                        byte[] buffer = new byte[8];
                        int bytesRead;
                        int i = 0;

                        while ((bytesRead = br.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            for (int j = 0; j < 8; j++)
                                table[i, j] = buffer[j];
                            i++;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("File does not exist");
            }
            return table;
        }

        public static string ReadText(string filePath1)
        {
            long a = 0;
            using (FileStream fs = new FileStream(filePath1, FileMode.Open))
            {
                a = fs.Length;
            }
            string readText = File.ReadAllText(filePath1);
            if (a % 8 == 0)
            {
                return readText;
            }
            else
            {
                return null;
            }
        }

        public static void WriteDataToBinaryFile(string data)
        {
            byte[] dataByte = Converter.DataToByte(data);
            string fileName = "C:\\Users\\User\\OneDrive\\Рабочий стол\\gost\\result1.bin";
            try
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
                {
                    using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
                    {
                        binaryWriter.Write(dataByte);
                    }
                }
                Console.WriteLine("Data has been successfully written to binary file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while writing data to binary file: " + ex.Message);
            }
        }
        public static void WriteDataToTxtFile(string data)
        {
            byte[] dataByte = Converter.DataToByte(data);
            string result = Encoding.UTF8.GetString(dataByte);
            string fileName = "result1.txt";
            try
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
                {
                    using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
                    {
                        binaryWriter.Write(result);
                    }
                }
                Console.WriteLine("Data has been successfully written to txt file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while writing data to txt file: " + ex.Message);
            }
        }
    }
}
