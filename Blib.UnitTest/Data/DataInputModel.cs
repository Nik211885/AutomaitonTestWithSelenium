namespace Blib.UnitTest.Data;

/// <summary>
///     Support for input with key and value input
/// </summary>
public class DataInputModel
{
    /// <summary>
    ///     f use want to specific key need add data  value
    /// </summary>
    public required string Key {get; set;}

    /// <summary>
    /// >data value in key one key has one or more value and just apply step by step
    /// </summary>
    public string Value { get; set; } 
};
/// <summary>
///     Collection off list data input model for input form
/// </summary>
public class DataFormInputModel
{
    /// <summary>
    ///     Collection with multi input it has form data
    /// </summary>
    public List<DataInputModel> DataInputModels { get; set; } = Enumerable.Empty<DataInputModel>().ToList();
};
