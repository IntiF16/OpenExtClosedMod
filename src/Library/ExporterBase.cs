using System.Collections.Generic;

namespace Ucu.Poo.PersonExporter
{   
public abstract class ExporterBase
    {
        /// <summary>
        /// Esto pasó de ser una cosa que se daba en program a ser una propiedad acá a ser una variable publica a ser un metodo
        /// </summary>
        /// <returns> Va a devolver el string del path del archivo </returns>
        public abstract string GetPath();
        public abstract void Export(IList<Person> people);
    }
}