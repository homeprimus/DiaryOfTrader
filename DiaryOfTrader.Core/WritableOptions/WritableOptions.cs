using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace DiaryOfTrader.Core.WritableOptions
{

  public class WritableOptions<T> : IWritableOptions<T> where T : class, new()
  {
    private readonly IHostEnvironment _environment;
    private readonly IOptionsMonitor<T> _options;
    private readonly string _section;
    private readonly string _file;

    public WritableOptions(IHostEnvironment environment, IOptionsMonitor<T> options, string section, string file)
    {
      _environment = environment;
      _options = options;
      _section = section;
      _file = file;
    }

    public T Value => _options.CurrentValue;
    public T Get(string name) => _options.Get(name);

    public void Update(Action<T> applyChanges)
    {
      var fileProvider = _environment.ContentRootFileProvider;
      var fileInfo = fileProvider.GetFileInfo(_file);
      var physicalPath = fileInfo.PhysicalPath;

      var jObject = JsonNode.Parse(File.ReadAllText(physicalPath!));
      var sectionObject = JsonSerializer.Deserialize<T>(jObject![_section]);

      applyChanges(sectionObject!);

      jObject[_section] = JsonNode.Parse(JsonSerializer.Serialize(sectionObject));
      File.WriteAllText(physicalPath!, JsonSerializer.Serialize(jObject, new JsonSerializerOptions() { WriteIndented = true }));
    }
  }

  public static class ServiceCollectionExtensions
  {
    public static void ConfigureWritable<T>(this IServiceCollection services, IConfigurationSection section, string file = "appsettings.json") where T : class, new()
    {
      services.Configure<T>(section);
      services.AddTransient<IWritableOptions<T>>(provider =>
      {
        var environment = provider.GetService<IHostEnvironment>();
        var options = provider.GetService<IOptionsMonitor<T>>();
        return new WritableOptions<T>(environment!, options!, section.Key, file);
      });
    }
  }
}
