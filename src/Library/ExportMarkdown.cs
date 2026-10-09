using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ucu.Poo.PersonExporter
{
    public class ExportMarkdown : ExporterBase
    {
        public override string GetPath()
        {
            return "Person-Report.pdf";
        } 
        private static string EscapeMarkdown(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            string[] charsToEscape = new[] { "|", "*", "_", "`" };
            string result = value;

            foreach (string c in charsToEscape)
            {
                result = result.Replace(c, "\\" + c, StringComparison.Ordinal);
            }

            return result;
        }
        public override void Export(IList<Person> people)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("# Person Report");
            sb.AppendLine();
            sb.AppendLine("| First Name | Last Name | Age |");
            sb.AppendLine("|-----------|-----------|-----|");

            foreach (Person person in people)
            {
                sb.AppendLine($"| {EscapeMarkdown(person.FirstName)} | {EscapeMarkdown(person.LastName)} | {person.Age} |");
            }

            string markdown = sb.ToString();
            File.WriteAllText(GetPath(), markdown, Encoding.UTF8);
        }
    }

}