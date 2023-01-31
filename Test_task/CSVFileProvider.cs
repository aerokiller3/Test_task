using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace ConsoleApp30;

public class CSVFileProvider : IFileProvider, IConfigProvider
{
    private List<Configuration> Configurations = new List<Configuration>();

    public void LoadFile(string filePath)
    {
        var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false,
            AllowComments= true,
            Comment = '#',
            Delimiter = ";"
        };

        using (var streamReader = File.OpenText(filePath))
        {
            using (var csvReader = new CsvReader(streamReader, csvConfig))
            {
                while (csvReader.Read())
                {
                    var configuration = new Configuration
                    {
                        Name = csvReader.GetField(0),
                        Description = csvReader.GetField(1)
                    };

                    Configurations.Add(configuration);
                }
            }
        }
    }

    public List<Configuration> GetConfigurations()
    {
        return Configurations;
    }
}
