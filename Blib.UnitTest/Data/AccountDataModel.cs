using Blib.UnitTest.Untils.Configuration.Model;

namespace Blib.UnitTest.Data;

public static class AccountDataModel
{

    public static List<DataInputModel> GetAccountDataModel(AccountModel accountModel)
    {
        return
        [
            new("UserName", accountModel.UserName),
            new("Password", accountModel.Password)
        ];
    }
}
