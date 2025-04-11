using ITHelpDeskClient.Models;
using System.Text;

namespace ITHelpDeskClient.Services.Export
{
    public class ExportCSV
    {
        public string GenerateCsv<T>(IEnumerable<T> items)
        {
            var csvBuilder = new StringBuilder();

            // Obtener las propiedades de la clase genérica T
            var properties = typeof(T).GetProperties();

            // Agregar encabezados del CSV (nombres de las propiedades)
            var header = string.Join(",", properties.Select(p => p.Name));
            csvBuilder.AppendLine(header);

            // Agregar los valores de las propiedades para cada elemento de la lista
            foreach (var item in items)
            {
                var values = properties.Select(p =>
                {
                    var value = p.GetValue(item);
                    return value != null ? value.ToString()!.Replace(",", ";") : ""; // Reemplaza comas para evitar problemas en CSV
                });

                csvBuilder.AppendLine(string.Join(",", values));
            }

            return csvBuilder.ToString();
        }

    }
}
