using System.Text;
using Blib.UnitTest.Untils.Configuration.Model;

namespace Blib.UnitTest.Untils.Configuration;
/// <summary>
///     Create url builder build address to test you can use different schema
///     of different advance authentication username and password
/// </summary>
/// <param name="addressModel"></param>
public class UrlBuilder(AddressModel? addressModel)
{
    /// <summary>
    ///  Flags with changing with https and http don't support  ftp and otherwise and default is https 
    /// </summary>
    private bool _securitySchema = true;
    /// <summary>
    ///  Flags with  navigation uri when you call build it has used make build url
    /// </summary>
    private string? _navigationUri;
    /// <summary>
    ///     Information with address need test
    /// </summary>
    private readonly AddressModel? _addressModel = addressModel;
    /// <summary>
    ///  If you want to change scheme http otherwise default https 
    /// </summary>
    /// <returns></returns>

    public UrlBuilder CreateWithNotSecuritySchema()
    {
        _securitySchema = false;
        return this;
    }
    /// <summary>
    ///  Navigation url address make test pages
    /// </summary>
    /// <param name="pageUri"></param>
    /// <returns></returns>

    public UrlBuilder Navigation(string pageUri)
    {
        _navigationUri = pageUri;
        return this;
    }
    /// <summary>
    ///  Build url with navigation and scheme you has changing
    /// </summary>
    /// <returns>return  url make test page</returns>
    /// <exception cref="Exception"></exception>
    public string Build()
    {
        if (_addressModel is null)
        {
            throw new Exception("You must set address environment need test");
        }
        var sb = new StringBuilder();
        var scheme = _securitySchema ? "https" : "http";
        sb.Append($"{scheme}:\\");
        sb.Append(_addressModel.HostName);
        if (!string.IsNullOrWhiteSpace(_addressModel.Port))
        {
            sb.Append($":{_addressModel.Port}");
        }
        if (!string.IsNullOrWhiteSpace(_addressModel.Page))
        {
            sb.Append($"/{_addressModel.Page}");
        }

        if (!string.IsNullOrWhiteSpace(_navigationUri))
        {
            sb.Append($"/{_navigationUri}");
        }
        return sb.ToString();
    }

}