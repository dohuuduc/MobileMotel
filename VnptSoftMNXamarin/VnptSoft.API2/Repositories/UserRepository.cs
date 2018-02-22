using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VnptSoftMNCore.Dto;

namespace VnptSoft.API2.Repositories {
  public class UserRepository: IUserRepository {
    private const string CollectionId = "Users";
    private readonly IDbCollectionRepository<UserDto, string> _repo;

    public UserRepository(IDbCollectionRepository<UserDto, string> repo) {
      _repo = repo;
    }

    public async Task<bool> IsExistUserKey(string userKey) {
      var users = await _repo.GetItemsFromCollectionAsync(CollectionId);

      return users.Any(account => userKey.Equals(account.UserKey, StringComparison.CurrentCultureIgnoreCase));
    }
  }
}
