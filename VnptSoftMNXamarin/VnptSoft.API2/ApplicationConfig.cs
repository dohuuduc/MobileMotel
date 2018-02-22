using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VnptSoft.API2 {
  public class ApplicationConfig {
    public int SearchLimit { get; set; }

    public int ItemsPerPage { get; set; }

    public bool SendLogMessagesToClient { get; set; }

    public int PasswordExpiryTimeInMinutes { get; set; }

    public int AccessFailedCount { get; set; }

    public int LockedUserIdTimeInMinutes { get; set; }

    public string CosmosDbConnectionString { get; set; }

    public string AuthKey { get; set; }

    public string DatabaseId { get; set; }

    public int AuthenticationExpiryTimeInMinutes { get; set; }
  }
}