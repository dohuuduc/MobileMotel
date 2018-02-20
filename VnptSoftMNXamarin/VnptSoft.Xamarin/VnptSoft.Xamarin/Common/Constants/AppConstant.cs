using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VnptSoft.Xamarin.Common.Constants {
  public static class AppConstant {
    // Config
    public const int HttpClientTimeOut = 30;
    public const string AppKey = "myUPS";
    public const string AppName = "VNPT-XAMARIN";
    public const string BaseUrl = "http://localhost:50788/";
    public const string DateFormat = "yyyy-MM-ddTHH:mm:ss";


    // Menu 
    public const string IconSource = "logo_vnpt.png";
    public const string TrangChu = "Home Manager";

    // Status
    public const string TatCa = "Tất cả";
    public const string ChoKham = "Chờ khám";
    public const string DangKham = "Đang khám";
    public const string KetThucKham = "Kết thúc khám";
    public const string ChoDangKham = "Chờ + Đang khám";
    public const string Error = "Lỗi";
    public const string Message = "Mất kết nối mạng";
    public const string Cancel = "OK";

    // Color
    public const string BlueColor = "#00aae4";
    public const string BlackColor = "#000000";
    public const string WhiteColor = "#FFFFFF";
  }
}
