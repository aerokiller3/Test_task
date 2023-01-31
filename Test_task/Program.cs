
using ConsoleApp30;

var xmlProvider = new XMLFileProvider();
var csvProvider = new CSVFileProvider();
var providers = new List<IConfigProvider> { xmlProvider, csvProvider };

var path = AppDomain.CurrentDomain.BaseDirectory;

xmlProvider.LoadFile(path + @"..\..\..\files\Configurations.xml");
csvProvider.LoadFile(path + @"..\..\..\files\Configurations.csv");

var storage = new ApplicationDbContext();

foreach (var provider in providers)
{
    await storage.SetAsync(provider.GetConfigurations());

    var dbConfigurations = await storage.GetAsync();

    if (dbConfigurations.Any())
    {
        foreach (var conf in dbConfigurations)
        {
            Console.WriteLine(conf.Name + "-" + conf.Description);
        }
    }
}

Console.ReadLine();