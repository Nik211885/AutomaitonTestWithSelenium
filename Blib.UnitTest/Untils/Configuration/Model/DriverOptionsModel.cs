using System.Text.Json.Serialization;

namespace Blib.UnitTest.Untils.Configuration.Model;
/// <summary>
///   Information about option with driver model
/// </summary>
public record DriverOptionsModel(
    string DriverPath,
    DriverType DriverType,  
    bool DisableInterface,
    bool SandBox,
    bool DisableDevShmUsage
    );

[JsonConverter(typeof(JsonStringEnumConverter))]    
public enum DriverType
{
    Chrome,
    Firefox,
    Edg
}