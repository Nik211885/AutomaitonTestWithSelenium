using Blib.UnitTest.Data;

namespace Blib.UnitTest.Untils;

public static class ReadCsvFileUntil
{
    /// <summary>
    /// Reads a CSV file and returns an IEnumerable of DataFormInputModel row-by-row using yield.
    /// </summary>
    /// <param name="fileName">CSV file name (without extension) in the Statics folder</param>
    /// <param name="prefix">File extension, default is "csv"</param>
    /// <returns>IEnumerable of DataFormInputModel</returns>
    public static (bool Success, IEnumerable<DataFormInputModel> Data) TryReadCsvFile(string fileName,
        string prefix = "csv")
    {
        var path = @$"{Directory.GetCurrentDirectory()}\Statics\{fileName}.{prefix}";

        if (!File.Exists(path))
        {
            return (false, []);
        }

        IEnumerable<DataFormInputModel> ReadLines()
        {
            var lines = File.ReadLines(path).ToList();
            if (lines.Count < 2) yield break;

            var labels = lines[0].Split(',');

            for (var i = 1; i < lines.Count; i++)
            {
                var line = lines[i].Split(',');
                var model = new DataFormInputModel();

                for (var j = 0; j < labels.Length; j++)
                {
                    var value = j < line.Length ? line[j] : string.Empty;
                    model.DataInputModels.Add(new DataInputModel
                    {
                        Key = labels[j],
                        Value = value
                    });
                }

                yield return model;
            }
        }

        return (true, ReadLines());
    }
}