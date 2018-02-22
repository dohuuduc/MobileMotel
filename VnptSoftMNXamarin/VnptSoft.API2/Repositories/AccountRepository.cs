using System;
using System.Linq;
using System.Threading.Tasks;
using VnptSoftMNCore.Dto;

namespace VnptSoft.API2.Repositories {
  public class AccountRepository: IAccountRepository {
    private const string CollectionId = "Accounts";
    private readonly IDbCollectionRepository<AccountDto, string> _repo;

    public AccountRepository(IDbCollectionRepository<AccountDto, string> repo) {
      _repo = repo;
    }

    public async Task<AccountDto> GetAccountInfoByUserKey(string userKey) {
      var accounts = await _repo.GetItemsFromCollectionAsync(CollectionId);

      return accounts.FirstOrDefault(account => userKey.Equals(account.UserKey, StringComparison.CurrentCultureIgnoreCase));
    }
  }
}
