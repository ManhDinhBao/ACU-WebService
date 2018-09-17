using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WSACU
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WSACU : System.Web.Services.WebService
{    
    string conString = "Data Source=192.168.1.51,1433;Initial Catalog = IBSACU; User ID = ibs; Password=ibs;";
    //string conString = "Data Source=10.173.24.199,1433;Initial Catalog = IBSACU; User ID = ibs; Password=ibs;";

    public WSACU()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    #region User
    [WebMethod]
    public DataSet UserQuery(string workingTag,string @userId, string userName, string passWord)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@userId", @userId));
        listParam.Add(Tuple.Create("@userName", userName));
        listParam.Add(Tuple.Create("@passWord", passWord));
        DataSet ds = Function.Query("SUSerQry", listParam);
        return ds;
    }

    [WebMethod]
    public DataSet UserSave(string workingTag,string userId,string optLevel, string userName, string password, string personName, byte[] avatar, string email,string phoneNo,bool status,DateTime startDate,DateTime experiedDate, string person, DateTime mDate)
    {
        DataSet ds = Function.UserSave("SUSerSave", workingTag, userId, optLevel, userName, password, personName, avatar, email,phoneNo,status, startDate, experiedDate, person, mDate);
        return ds;
    }

    [WebMethod]
    public DataSet GroupUserQuery(string workingTag, string groupId, string groupName)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@groupId", groupId));
        listParam.Add(Tuple.Create("@groupName", groupName));
        DataSet ds = Function.Query("SGUserMQry", listParam);
        return ds;
    }

    [WebMethod]
    public DataSet GroupUserSave(string workingTag, string groupId, string groupName, string Person, DateTime mDate)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@groupId", groupId));
        listParam.Add(Tuple.Create("@groupName", groupName));
        listParam.Add(Tuple.Create("@Person", Person));
        listParam.Add(Tuple.Create("@mDate", mDate.ToString()));

        DataSet ds = Function.Save("SGUserMSave", workingTag, listParam);
        return ds;
    }

    [WebMethod]
    public DataSet GroupUserDetailQuery(string workingTag, string groupUserId, string userId)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@groupUserId", groupUserId));
        listParam.Add(Tuple.Create("@userId", userId));
        DataSet ds = Function.Query("SGUserDQry", listParam);
        return ds;
    }

    [WebMethod]
    public DataSet GroupUserDetailSave(string workingTag, string groupUserId, string userId, string Person, DateTime mDate)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@groupUserId", groupUserId));
        listParam.Add(Tuple.Create("@userId", userId));
        listParam.Add(Tuple.Create("@Person", Person));
        listParam.Add(Tuple.Create("@mDate", mDate.ToString()));

        DataSet ds = Function.Save("SGUserDSave", workingTag, listParam);
        return ds;
    }
    #endregion

    #region Card
    [WebMethod]
    public DataSet CardQuery(string workingTag, string cardId,string cardNo)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@cardId", cardId));
        listParam.Add(Tuple.Create("@cardNo", cardNo));

        DataSet ds = Function.Query("SCardMQry", listParam);
        return ds;
    }

    [WebMethod]
    public DataSet CardSave(string workingTag, string cardId, string cardNo, string Person, DateTime mDate)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@cardId", cardId));
        listParam.Add(Tuple.Create("@cardNo", cardNo));
        listParam.Add(Tuple.Create("@Person", Person));
        listParam.Add(Tuple.Create("@mDate", mDate.ToString()));

        DataSet ds = Function.Save("SCardMSave", workingTag, listParam);
        return ds;
    }

    [WebMethod]
    public DataSet CardDetailQuery(string workingTag, string userId, string cardNo)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@userId", userId));
        listParam.Add(Tuple.Create("@cardNo", cardNo));

        DataSet ds = Function.Query("SCardDQry", listParam);
        return ds;
    }

    [WebMethod]
    public DataSet CardDetailSave(string workingTag, string cardNo, string userId, string Person, DateTime mDate)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@userId", userId));
        listParam.Add(Tuple.Create("@cardNo", cardNo));
        listParam.Add(Tuple.Create("@Person", Person));
        listParam.Add(Tuple.Create("@mDate", mDate.ToString()));

        DataSet ds = Function.Save("SCardDSave", workingTag, listParam);
        return ds;
    }
    #endregion

    #region Access
    [WebMethod]
    public DataSet GroupAccessQuery(string workingTag, string groupId, string groupName)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@groupId", groupId));
        listParam.Add(Tuple.Create("@groupName", groupName));
        DataSet ds = Function.Query("SGAccessQry", listParam);
        return ds;
    }

    [WebMethod]
    public DataSet GroupAccessSave(string workingTag, string groupId, string groupName, string groupDescription, string Person, DateTime mDate)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@groupId", groupId));
        listParam.Add(Tuple.Create("@groupName", groupName));
        listParam.Add(Tuple.Create("@groupDescription", groupDescription));
        listParam.Add(Tuple.Create("@Person", Person));
        listParam.Add(Tuple.Create("@mDate", mDate.ToString()));

        DataSet ds = Function.Save("SGAccessSave", workingTag, listParam);
        return ds;
    }

    [WebMethod]
    public DataSet GroupAccessUQuery(string workingTag, string groupId, string userId)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@groupId", groupId));
        listParam.Add(Tuple.Create("@userId", userId));
        DataSet ds = Function.Query("SGAccessUQry", listParam);
        return ds;
    }

    [WebMethod]
    public DataSet GroupAccessUSave(string workingTag, string groupAccessId, string userId, string Person, DateTime mDate)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@groupId", groupAccessId));
        listParam.Add(Tuple.Create("@userId", userId));
        listParam.Add(Tuple.Create("@Person", Person));
        listParam.Add(Tuple.Create("@mDate", mDate.ToString()));

        DataSet ds = Function.Save("SGAccessUSave", workingTag, listParam);
        return ds;
    }

    [WebMethod]
    public DataSet GroupAccessLQuery(string workingTag, string groupId, string accessLevelId)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@groupId", groupId));
        listParam.Add(Tuple.Create("@accessLevelId", accessLevelId));
        DataSet ds = Function.Query("SGAccessLQry", listParam);
        return ds;
    }

    [WebMethod]
    public DataSet GroupAccessLSave(string workingTag, string groupAccessId, string accessLevelId, string Person, DateTime mDate)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@groupId", groupAccessId));
        listParam.Add(Tuple.Create("@accessLevelId", accessLevelId));
        listParam.Add(Tuple.Create("@Person", Person));
        listParam.Add(Tuple.Create("@mDate", mDate.ToString()));

        DataSet ds = Function.Save("SGAccessLSave", workingTag, listParam);
        return ds;
    }

    [WebMethod]
    public DataSet GroupAccessUGQuery(string workingTag, string groupId, string userGroupId)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@groupId", groupId));
        listParam.Add(Tuple.Create("@userGroupId", userGroupId));
        DataSet ds = Function.Query("SGAccessUGQry", listParam);
        return ds;
    }

    [WebMethod]
    public DataSet GroupAccessUGSave(string workingTag, string groupAccessId, string userGroupId, string Person, DateTime mDate)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@groupId", groupAccessId));
        listParam.Add(Tuple.Create("@groupUserId", userGroupId));
        listParam.Add(Tuple.Create("@Person", Person));
        listParam.Add(Tuple.Create("@mDate", mDate.ToString()));

        DataSet ds = Function.Save("SGAccessUGSave", workingTag, listParam);
        return ds;
    }

    [WebMethod]
    public DataSet AccessLevelQry(string workingTag, string accessLevelID, string accessLevelName)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@accessLevelID", accessLevelID));
        listParam.Add(Tuple.Create("@accessLevelName", accessLevelName));

        DataSet ds = Function.Query("SAccessLevelMQry", listParam);
        return ds;
    }

    [WebMethod]
    public DataSet AccessLevelSave(string workingTag, string accessLevelID, string accessLevelName, string Person, DateTime mDate)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@accessLevelID", accessLevelID));
        listParam.Add(Tuple.Create("@accessLevelName", accessLevelName));
        listParam.Add(Tuple.Create("@Person", Person));
        listParam.Add(Tuple.Create("@mDate", mDate.ToString()));

        DataSet ds = Function.Save("SAccessLevelMSave", workingTag, listParam);
        return ds;
    }

    [WebMethod]
    public DataSet AccessLevelDQry(string workingTag, string accessLevelID)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@accessLevelID", accessLevelID));

        DataSet ds = Function.Query("SAccessLevelDQry", listParam);
        return ds;
    }
    [WebMethod]
    public DataSet AccessLevelDSave(string workingTag, string accessLevelID, string doorID, string Person, DateTime mDate)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@accessLevelID", accessLevelID));
        listParam.Add(Tuple.Create("@doorID", doorID));
        listParam.Add(Tuple.Create("@Person", Person));
        listParam.Add(Tuple.Create("@mDate", mDate.ToString()));

        DataSet ds = Function.Save("SAccessLevelDSave", workingTag, listParam);
        return ds;
    }
    [WebMethod]
    public DataSet AccessLevelSQry(string workingTag, string accessLevelID)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@accessLevelID", accessLevelID));

        DataSet ds = Function.Query("SAccessLevelSQry", listParam);
        return ds;
    }

    [WebMethod]
    public DataSet AccessLevelSSave(string workingTag, string accessLevelID, string scheduleID, string Person, DateTime mDate)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@accessLevelID", accessLevelID));        
        listParam.Add(Tuple.Create("@scheduleID", scheduleID));
        listParam.Add(Tuple.Create("@Person", Person));
        listParam.Add(Tuple.Create("@mDate", mDate.ToString()));

        DataSet ds = Function.Save("SAccessLevelSSave", workingTag, listParam);
        return ds;
    }

    #endregion

    #region Door
    [WebMethod]
    public DataSet DoorQuery(string workingTag, string doorId, string doorName, string deviceId)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@doorId", doorId));
        listParam.Add(Tuple.Create("@doorName", doorName));
        listParam.Add(Tuple.Create("@deviceId", deviceId));

        DataSet ds = Function.Query("SDoorQry", listParam);
        return ds;
    }

    [WebMethod]
    public DataSet DoorSave(string workingTag, string doorId, string doorName, string deviceId, string readerNumber, string inputNumber, string outputNumber, string relayNumber, string Person, DateTime mDate)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@doorId", doorId));
        listParam.Add(Tuple.Create("@doorName", doorName));
        listParam.Add(Tuple.Create("@deviceId", deviceId));
        listParam.Add(Tuple.Create("@readerNumber", readerNumber));
        listParam.Add(Tuple.Create("@inputNumber", inputNumber));
        listParam.Add(Tuple.Create("@outputNumber", outputNumber));
        listParam.Add(Tuple.Create("@relayNumber", relayNumber));
        listParam.Add(Tuple.Create("@Person", Person));
        listParam.Add(Tuple.Create("@mDate", mDate.ToString()));

        DataSet ds = Function.Save("SDoorSave", workingTag, listParam);
        return ds;
    }

    #endregion

    #region Schedule
    [WebMethod]
    public DataSet ScheduleQry(string workingTag, string scheduleId,string scheduleName)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@ScheduleId", scheduleId));
        listParam.Add(Tuple.Create("@ScheduleName", scheduleName));

        DataSet ds = Function.Query("SScheduleMQry", listParam);
        return ds;
    }

    [WebMethod]
    public DataSet ScheduleSave(string workingTag, string scheduleId, string scheduleName, string description, string Person, DateTime mDate)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@scheduleId", scheduleId));
        listParam.Add(Tuple.Create("@scheduleName", scheduleName));
        listParam.Add(Tuple.Create("@description", description));
        listParam.Add(Tuple.Create("@Person", Person));
        listParam.Add(Tuple.Create("@mDate", mDate.ToString()));

        DataSet ds = Function.Save("SScheduleMSave", workingTag, listParam);
        return ds;
    }

    [WebMethod]
    public DataSet PeriodQuery(string workingTag, string scheduleId)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@ScheduleId", scheduleId));        

        DataSet ds = Function.Query("SScheduleDQry", listParam);
        return ds;
    }

    [WebMethod]
    public DataSet PeriodSave(string workingTag, string ScheduleId, string DayInWeek, DateTime StartTime, DateTime EndTime, string Person, DateTime mDate)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@ScheduleId", ScheduleId));
        listParam.Add(Tuple.Create("@DayInWeek", DayInWeek));
        listParam.Add(Tuple.Create("@StartTime", StartTime.ToShortTimeString()));
        listParam.Add(Tuple.Create("@EndTime", EndTime.ToShortTimeString()));
        listParam.Add(Tuple.Create("@Person", Person));
        listParam.Add(Tuple.Create("@mDate", mDate.ToString()));

        DataSet ds = Function.Save("SScheduleDSave", workingTag, listParam);
        return ds;
    }
    #endregion

    #region Device
    [WebMethod]
    public DataSet DeviceQuery(string workingTag, string deviceId, string deviceName, string deviceIP)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@deviceId", deviceId));
        listParam.Add(Tuple.Create("@deviceName", deviceName));
        listParam.Add(Tuple.Create("@deviceIP", deviceIP));
        DataSet ds = Function.Query("SDeviceQry", listParam);
        return ds;
    }

    [WebMethod]
    public DataSet DeviceSave(string workingTag, string deviceId, string deviceName, string deviceIP, string Person, DateTime mDate)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@deviceId", deviceId));
        listParam.Add(Tuple.Create("@deviceName", deviceName));
        listParam.Add(Tuple.Create("@deviceIP", deviceIP));
        listParam.Add(Tuple.Create("@Person", Person));
        listParam.Add(Tuple.Create("@mDate", mDate.ToString()));

        DataSet ds = Function.Save("SDeviceSave", workingTag, listParam);
        return ds;
    }
    #endregion

    #region Event
    [WebMethod]
    public DataSet EventQry(string workingTag, string eventId, string cardNo, string sDate, string eDate)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@eventId", eventId));
        listParam.Add(Tuple.Create("@cardNo", cardNo));
        listParam.Add(Tuple.Create("@sDate", sDate));
        listParam.Add(Tuple.Create("@eDate", eDate));
        DataSet ds = Function.Query("SEventQry", listParam);
        return ds;
    }

    [WebMethod]
    public DataSet EventSave(string workingTag, string eventId, DateTime eventDate, string device, string functionCode, string cardNo, string doorId, string status)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@eventId", eventId));        
        listParam.Add(Tuple.Create("@eventDate", eventDate.ToString()));        
        listParam.Add(Tuple.Create("@device", device));
        listParam.Add(Tuple.Create("@functionCode", functionCode));
        listParam.Add(Tuple.Create("@cardNo", cardNo));
        listParam.Add(Tuple.Create("@doorId", doorId));
        listParam.Add(Tuple.Create("@status", status));

        DataSet ds = Function.Save("SEventSave", workingTag, listParam);
        return ds;
    }
    #endregion

    [WebMethod]
    public DataSet OperatorQuery(string workingTag, string optLevelid, string optLevelName, string userId)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@optLevelid", optLevelid));
        listParam.Add(Tuple.Create("@optLevelName", optLevelName));
        listParam.Add(Tuple.Create("@userId", optLevelName));

        DataSet ds = Function.Query("SOperatorQry", listParam);
        return ds;
    }

    [WebMethod]
    public DataSet AttendanceQuery(string workingTag, DateTime attendanceDate)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@aDate", attendanceDate.ToString()));

        DataSet ds = Function.Query("SAttendanceQry", listParam);
        return ds;
    }

    [WebMethod]
    public DataSet LoginQuery(string workingTag, DateTime fromDate, DateTime toDate)
    {
        List<Tuple<string, string>> listParam = new List<Tuple<string, string>>();
        listParam.Add(Tuple.Create("@workingTag", workingTag));
        listParam.Add(Tuple.Create("@sDate", fromDate.ToString()));
        listParam.Add(Tuple.Create("@eDate", toDate.ToString()));

        DataSet ds = Function.Query("SLoginQry", listParam);
        return ds;
    }

}

