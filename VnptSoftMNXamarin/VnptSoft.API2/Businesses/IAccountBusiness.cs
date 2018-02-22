using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VnptSoftMNCore.Core.Models;

namespace VnptSoft.API2.Businesses {
  public interface IAccountBusiness {
    Task<AccountInfo> GetAccountInfoByUserKey(JiraCredential jiraCredential);

    Task<Stream> GetAvatar(JiraCredential jiraCredential, string avatarUrl);
  }
}
