using System;
using System.IO;

namespace Problem_4_Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream file = new FileStream("../copyMe.png", FileMode.Open))
            {
                using (FileStream theCopy = new FileStream("../copy.png", FileMode.Create))
                {
                    byte[] buffer = new byte[4096];
                    while(true)
                    {
                        var readBytesCount = file.Read(buffer, 0, buffer.Length);
                        if (readBytesCount<=0)
                        {
                            break;
                        }
                        theCopy.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
