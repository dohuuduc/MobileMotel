using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VnptSoft.API2.Repositories {
  public interface IUserRepository {
    Task<bool> IsExistUserKey(string userKey);
  }
}
