using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Web;
using Weible_Lib;

namespace Weible_Weather
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                System.Reflection.AssemblyName testAssembly =
                    System.Reflection.AssemblyName.GetAssemblyName("Weible_Lib.DLL");

                UseLibrary.searchFunction();
            }

            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("The file cannot be found.");
                Console.ReadKey();
            }

            catch (BadImageFormatException)
            {
                Console.WriteLine("The file is not an assembly.");
                Console.ReadKey();
            }

            catch (System.IO.FileLoadException)
            {
                System.Console.WriteLine("The assembly has already been loaded.");
                System.Console.ReadKey();
            }
            UseLibrary.run();
        }
    }
}
