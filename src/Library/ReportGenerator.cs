//------------------------------------------------------------------------------
// <copyright file="ReportGenerator.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Ucu.Poo.PersonExporter
{
    public class ReportGenerator
    {


        private Dictionary<string, Type> exportTypes = new Dictionary<string, Type>();
        public ReportGenerator()
        {
            ///Genera un Assembly en este caso para buscar tipos de datos hijos.
            System.Reflection.Assembly assembly = typeof(ReportGenerator).Assembly;
            System.Type[] types = assembly.GetTypes();
            foreach (Type type in types) 
            //Si es subclase de Exporter y no es abstracta significa que es un exportador utilizable y va para el diccionario
            {if (type.IsSubclassOf(typeof(ExporterBase) ))
                {
                    if (!type.IsAbstract)
                    {   
                        String CleanType = type.Name.ToString();
                        string CleanerType = type.Name.Substring(6);
                        CleanerType = CleanerType.ToUpper();
                        exportTypes.Add($"{CleanerType}", type);

                    }
                }
            }
        }
        public Dictionary<string, Type> ExportTypes{ get{ return exportTypes;}}

        /// <summary>
        /// Genera un reporte de una lista de personas en el formato indicado.
        /// </summary>
        /// <param name="people">Lista de personas a incluir en el
        /// reporte.</param>
        /// <param name="format">Formato de salida del reporte. Valores
        /// esperados: "PDF" o "HTML".</param>
        /// <param name="outputPath">Ruta completa del archivo de salida que se
        /// va a generar.</param>
        /// <returns>Retorna <c>true</c> si los reportes fueron generados y
        /// <c>false</c> en caso contrario.</returns>
        public string GenerateReport(IList<Person> people, Type type)
        {
            
            if (people == null)
            {
                return "";
            }
   
            if (!exportTypes.ContainsValue(type))
            {
                return "";
            }
            ExporterBase exportInstance = (ExporterBase)Activator.CreateInstance(type);
            exportInstance.Export(people);
            return exportInstance.GetPath();
        }

    }
}
