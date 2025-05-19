using Blib.UnitTest.Untils;
using Blib.UnitTest.Untils.Configuration.Model;

namespace Blib.UnitTest.Data;

public static class AccountDataModel
{
    /// <summary>
    ///     Get data is account model include account username and password in config.json
    ///     Why you don't need file csv for account  
    /// </summary>
    /// <param name="accountModel"></param>
    /// <returns></returns>
    public static DataFormInputModel GetAccountDataModel(AccountModel accountModel)
    {
        return new DataFormInputModel()
        {
            DataInputModels =
            [
                new() { Key = "username", Value = accountModel.UserName },
                new() { Key = "password", Value = accountModel.Password }
            ]
        };
    }
}
