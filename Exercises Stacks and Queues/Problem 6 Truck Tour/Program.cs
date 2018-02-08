using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_6_Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            long numberOfPumps = long.Parse(Console.ReadLine());
            Queue<long[]> petrolPumps = new Queue<long[]>();
            long petrolInTruck=0;
            for (long i = 0; i < numberOfPumps; i++)
            {
               petrolPumps.Enqueue(Console.ReadLine().Split().Select(long.Parse).ToArray());
            }

            bool token = true;
            for (long i = 0; i < numberOfPumps; i++)
            {
                for (long j = 0; j < numberOfPumps; j++)
                {
                    var curentPump = petrolPumps.Peek();
                    petrolInTruck += curentPump[0]- curentPump[1];
                    petrolPumps.Enqueue(petrolPumps.Dequeue());
                    if (petrolInTruck<0)
                    {
                        token = false;
                    }
                }

                if (token)
                {
                    Console.WriteLine(i);
                    break;
                }
                else
                {
                    petrolInTruck = 0;
                    petrolPumps.Enqueue(petrolPumps.Dequeue());
                    token = true;
                }
            }
        }
    }
}
