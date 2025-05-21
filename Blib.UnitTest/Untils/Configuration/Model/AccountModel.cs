using System.Text.Json.Serialization;

namespace Blib.UnitTest.Untils.Configuration.Model;
/// <summary>
///     Account need login and make test function for account
/// </summary>
public record AccountModel(
    string UserName,
    string Password,
    RolePermission Role);

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RolePermission
{
    Management,
    ManagementReader
}