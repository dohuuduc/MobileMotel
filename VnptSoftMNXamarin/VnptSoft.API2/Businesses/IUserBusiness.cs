using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VnptSoftMNCore.Core.Models;

namespace VnptSoft.API2.Businesses {
  public interface IUserBusiness {
    Task<HttpResponseMessage> Login(JiraCredential jiraCredential);
  }

}
