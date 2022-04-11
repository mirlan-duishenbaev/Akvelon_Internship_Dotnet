using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managed_Threading_Task1
{
    public class DanceFloor
    {
        public static void AllAreDancing(int dance)
        {
            Console.WriteLine($"Dancer {Thread.CurrentThread.Name} is dancing {(enums.Dance)dance}");
        }
    }
}
