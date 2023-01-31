using System.ComponentModel.DataAnnotations;

namespace ConsoleApp30;
public class Configuration
{
    [Key]
    public string Name { get; set; }
    public string Description { get; set; }
}
