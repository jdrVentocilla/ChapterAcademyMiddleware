using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleNET48
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cervesa cervesa = new Cervesa("01","Cusqueña");
            cervesa = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.ReadLine();
        }

        public  class Cervesa
        {
            public string id { get; set; }
            public string nombre { get; set; }

            public Cervesa(string id, string nombre)
            {
                this.id = id;
                this.nombre = nombre;
            }

            ~Cervesa() {

                Console.WriteLine("Me estoy eliminaddo.");
            
            }
        }
    }
}
