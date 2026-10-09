using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ucu.Poo.PersonExporter
{   
public class ExportHtml: ExporterBase
    {
        public override string GetPath()
        {
            return "Person-Report.html";
        }

        public override void Export(IList<Person> people)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html lang=\"es\">");
            sb.AppendLine("<head>");
            sb.AppendLine("  <meta charset=\"utf-8\" />");
            sb.AppendLine("  <title>Person Report</title>");
            sb.AppendLine("  <style>");
            sb.AppendLine("    table { border-collapse: collapse; width: 100%; }");
            sb.AppendLine("    th, td { border: 1px solid #ccc; padding: 4px 8px; }");
            sb.AppendLine("    th { background-color: #f0f0f0; }");
            sb.AppendLine("  </style>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");
            sb.AppendLine("  <h1>Person Report</h1>");
            sb.AppendLine("  <table>");
            sb.AppendLine("    <thead>");
            sb.AppendLine("      <tr>");
            sb.AppendLine("        <th>First Name</th>");
            sb.AppendLine("        <th>Last Name</th>");
            sb.AppendLine("        <th>Age</th>");
            sb.AppendLine("      </tr>");
            sb.AppendLine("    </thead>");
            sb.AppendLine("    <tbody>");

            foreach (Person person in people)
            {
                sb.AppendLine("      <tr>");
                sb.AppendLine($"        <td>{System.Net.WebUtility.HtmlEncode(person.FirstName)}</td>");
                sb.AppendLine($"        <td>{System.Net.WebUtility.HtmlEncode(person.LastName)}</td>");
                sb.AppendLine($"        <td>{person.Age}</td>");
                sb.AppendLine("      </tr>");
            }

            sb.AppendLine("    </tbody>");
            sb.AppendLine("  </table>");
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            File.WriteAllText(GetPath(), sb.ToString(), Encoding.UTF8);
        }
    }
}

