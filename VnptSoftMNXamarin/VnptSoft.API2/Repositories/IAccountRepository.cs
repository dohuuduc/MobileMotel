using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VnptSoftMNCore.Dto;

namespace VnptSoft.API2.Repositories {
  public interface IAccountRepository {
    Task<AccountDto> GetAccountInfoByUserKey(string userKey);
  }
}

