using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAT_SERVER
{
    //delegate string Getter();
    delegate void Sender();
    static class Requests
    {
        
        public static Dictionary<string, Sender> sendList = new Dictionary<string, Sender>()
        {
            { "getSubjects", ClientObject.DataService.SendSubjects },
            { "getDates",  ClientObject.DataService.SendDates},
            { "getStudents", ClientObject.DataService.SendStudents},
            { "getMarks",  ClientObject.DataService.SendMarks},
            { "save",  ClientObject.DataService.SaveReport},
            { "delete",  ClientObject.DataService.DeleteReport}
        };
    }
}
