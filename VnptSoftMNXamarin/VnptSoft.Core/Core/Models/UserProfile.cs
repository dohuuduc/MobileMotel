using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VnptSoftMNCore.Core.Models {
  public class UserProfile {
    /// <summary>
    /// Jira api link to get this user profile
    /// </summary>
    public string Self { get; set; }

    /// <summary>
    /// Jira key of this user
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    /// Jira user name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Email address
    /// </summary>
    public string EmailAddress { get; set; }

    /// <summary>
    /// Avatar links with four size
    /// </summary>
    public Avatarurls AvatarUrls { get; set; }

    /// <summary>
    /// Full name of this Jira user
    /// </summary>
    public string DisplayName { get; set; }

    /// <summary>
    /// Jira user status
    /// </summary>
    public bool Active { get; set; }

    /// <summary>
    /// Jira user timezone
    /// </summary>
    public string TimeZone { get; set; }

    /// <summary>
    /// Jira user locale
    /// </summary>
    public string Locale { get; set; }
  }

  public class Avatarurls {
    public string _48x48 { get; set; }
    public string _24x24 { get; set; }
    public string _16x16 { get; set; }
    public string _32x32 { get; set; }
  }
}