using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;

namespace Ucu.Poo.PersonExporter
{
    public class ExportCsv : ExporterBase
    {
        public override string GetPath()
        {
            return "Person-Report.csv";
        }

        public override void Export(IList<Person> people)
        {
            CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };

            using (StreamWriter writer = new StreamWriter(GetPath(), false, Encoding.UTF8))
            {
                using (CsvWriter csv = new CsvWriter(writer, config))
                {
                    csv.WriteHeader<Person>();
                    csv.NextRecord();
                    csv.WriteRecords(people);
                }
            }
        }
    }
}