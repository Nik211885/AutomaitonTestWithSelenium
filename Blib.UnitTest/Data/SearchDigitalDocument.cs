namespace Blib.UnitTest.Data;

public static class SearchDigitalDocument
{
    public static DataFormInputModel GetSearchDigitalDocumentModel()
    {
        return new DataFormInputModel()
        {
            DataInputModels =
            [
                new (){Key = "sel_bib_type_id", Value = "Thiếu nhi"}
            ]
        };
    }
}