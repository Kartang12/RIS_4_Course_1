using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CHAT_SERVER
{
    //delegate string[] ArrayReturner(string);
    class ClientObject
    {
        public string id;
        static protected internal NetworkStream stream;
        TcpClient client;
        ServerObject server;

        public ClientObject(TcpClient tcpClient, ServerObject serverObject)
        {
            client = tcpClient;
            server = serverObject;
            serverObject.AddConnection(this);
        }

        public void Execution()
        {
            try
            {
                stream = client.GetStream();
                string request;
                while (true)
                {
                        request = RecieveRequest();
                        Console.WriteLine("Incoming request "+ request);
                        try
                        {
                            Requests.sendList[request].Invoke();
                        }
                        catch(IndexOutOfRangeException)
                        {
                            try 
                            {
                                Requests.sendList[request].Invoke();
                            }
                            catch (IndexOutOfRangeException)
                            {
                                Console.WriteLine("No such request in list");
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Request <" + request + "> failed");
                            }
                        }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                server.RemoveConnection(this.id);
                Close();
            }
        }
        private static string RecieveRequest()
        {
            byte[] data = new byte[4];
            stream.Read(data, 0, 4);
            int size = BitConverter.ToInt32(data, 0) * 2;
            Console.WriteLine("Incoming size = " + size.ToString());
            data = new byte[size];

            stream.Read(data, 0, size);
            return Encoding.Unicode.GetString(data);
        }
        protected internal void Close()
        {
            if (stream != null)
                stream.Close();
            if (client != null)
                client.Close();
        }
        public class DataService
        {
            public static void SendSubjects()
            {
                string subjects = string.Join(";", GetSubjects());
                byte[] data = BitConverter.GetBytes(subjects.Length);
                stream.Write(data, 0, data.Length);
                data = Encoding.Unicode.GetBytes(subjects);
                stream.Write(data, 0, data.Length);
            }
            public static void SendDates() 
            {
                try
                {
                    string subject = RecieveRequest();
                    Console.WriteLine(subject);
                    string dates = string.Join(";", GetDates(subject));
                    byte[] data = BitConverter.GetBytes(dates.Length);
                    stream.Write(data, 0, data.Length);
                    data = Encoding.Unicode.GetBytes(dates);
                    stream.Write(data, 0, data.Length);
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.StackTrace);
                }
            }
            public static void SendStudents() 
            {
                string students = string.Join(";", GetStudents());
                byte[] data = BitConverter.GetBytes(students.Length);
                stream.Write(data, 0, data.Length);
                data = Encoding.Unicode.GetBytes(students);
                stream.Write(data, 0, data.Length);
            }
            public static void SendMarks() 
            {
                string subject = RecieveRequest();
                Console.WriteLine("\tSubject = " + subject);
                string date = RecieveRequest().Replace(':','^');
                Console.WriteLine("\tdate = " + date);
                string dates = string.Join(";", GetMarks(subject, date));
                byte[] data = BitConverter.GetBytes(dates.Length);
                stream.Write(data, 0, data.Length);
                data = Encoding.Unicode.GetBytes(dates);
                stream.Write(data, 0, data.Length);
            }
            public static void SaveReport() 
            {
                string subject = RecieveRequest();
                string date = RecieveRequest().Replace(':','^');
                string[] marks = RecieveRequest().Split(';');
                using (StreamWriter sw = File.CreateText(Paths.root + Paths.subjects + subject + "\\" + date + ".txt"))
                {
                    foreach (string mark in marks)
                    {
                        sw.WriteLine(mark);
                    }
                    sw.Close();
                }
            }
            static string[] GetMarks(string subject, string date)
            {
                return File.ReadAllLines(Paths.root + Paths.subjects + subject + 
                    "\\" + date + ".txt");
            }
            static string[] GetSubjects()
            {
                return File.ReadAllLines(Paths.root + Paths.subjectsFile);
            }
            static string[] GetStudents()
            {
                return File.ReadAllLines(Paths.root + Paths.students);
            }
            static string[] GetDates(string subject)
            {
                DirectoryInfo di = new DirectoryInfo(Paths.root + Paths.subjects + subject);
                FileInfo[] dates = di.GetFiles();
                string[] strDates = new string[dates.Length];
                if (dates.Length == 0)
                    return new string[] { "_"};

                for (int i=0; i< dates.Length; i++)
                {
                    strDates[i] = dates[i].Name; 
                }
                return strDates;
            }

            internal static void DeleteReport()
            {
                string subject = RecieveRequest();
                string date = RecieveRequest().Replace(':', '^');
                try
                {
                    File.Delete(Paths.root + Paths.subjects + subject + "\\" + date + ".txt");
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }
    }
}
