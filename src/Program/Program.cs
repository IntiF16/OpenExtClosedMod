//------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Ucu.Poo.PersonExporter
{
    /// <summary>
    /// Ejemplo de uso de la clase ReportGenerator. Crea varias personas y
    /// genera el reporte en un único formato elegido por el usuario.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Punto de entrada al programa.
        /// </summary>
        private static void Main()
        {
            List<Person> people = new List<Person>
            {
                new Person { FirstName = "Alice", LastName = "Johnson", Age = 30 },
                new Person { FirstName = "Bob", LastName = "Smith", Age = 42 },
                new Person { FirstName = "Charlie", LastName = "Brown", Age = 25 },
            };

            ReportGenerator generator = new ReportGenerator();
            string format;
            string outputPath;

            Dictionary<string,Type> DisplayableExports = generator.ExportTypes;
            Console.WriteLine("Elije el tipo de archivo para exportar");
            foreach (string key in DisplayableExports.Keys)
            {
                Console.WriteLine(key);
            }
            string TypeName = Console.ReadLine();
            TypeName = TypeName.ToUpper();
            Type type = DisplayableExports[TypeName];
            string result = generator.GenerateReport(people,type);

            if (!string.IsNullOrEmpty(result))
            {
                Console.WriteLine("Reporte generado en el directorio actual:");
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("No se pudo generar el reporte.");
            }
        }
    }
}
