using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CHAT_CLIENT
{
    public partial class Form1 : Form
    {
        List<string> subjects;
        List<DateTime> classesDates = new List<DateTime>();
        List<string> students;
        List<string> marks;

        Dictionary<string, string> studentsD;

        private const string host = "127.0.0.1";
        private const int port = 8888;

        static TcpClient client;
        static NetworkStream stream;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Connect();
            }
            catch (Exception ex) { };
            StudentsGrid.AutoGenerateColumns = false;
            SendRequest("getStudents");
            students = RecieveData().Split(';').ToList<string>();
            studentsD = new Dictionary<string, string>();
            marks = new List<string>();
            foreach (string st in students)
            {
                studentsD.Add(st, "-");
                marks.Add("-");
            }

            SendRequest("getSubjects");
            subjects = RecieveData().Split(';').ToList<string>();

            var studentsTable = from row in studentsD select new { Student = row.Key, Mark = row.Value };
            studentCol.DataPropertyName = "Student";
            markCol.DataPropertyName = "Mark";
            StudentsGrid.DataSource = studentsTable.ToArray();

            subjectCol.DataPropertyName = "subject";
            SubjectGrid.DataSource = subjects.Select(x => new { subject = x }).ToList();

            dateCol.DataPropertyName = "date";
        }

        private string RecieveData()
        {
            try
            {
                byte[] data = new byte[4];
                stream.Read(data, 0, data.Length);
                int size = BitConverter.ToInt32(data, 0) * 2;
                data = new byte[size];

                stream.Read(data, 0, size);
                return Encoding.Unicode.GetString(data);
            }
            catch (Exception ex)
            {
                Disconnect();
                return string.Empty;
            }
        }

        private void SendRequest(string request)
        {
            byte[] data = BitConverter.GetBytes(request.Length);
            stream.Write(data, 0, data.Length);
            data = Encoding.Unicode.GetBytes(request);
            string a = Encoding.Unicode.GetString(data);

            stream.Write(data, 0, data.Length);
        }

        private void Connect()
        {
            client = new TcpClient();
            client.Connect(host, port);
            stream = client.GetStream();
        }

        private void Disconnect()
        {
            if (stream != null)
                stream.Close();
            if (client != null)
                client.Close();
            Environment.Exit(0);
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SendRequest("save");
                SendRequest(SubjectGrid.CurrentCell.Value.ToString());
                SendRequest(DateGrid.SelectedCells[0].Value.ToString());

                int i = 0;
                foreach (string student in students)
                    marks[i++] = studentsD[student];

                SendRequest(string.Join(";", marks));
            }
            catch (Exception ex) { }

        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Connect();
            }
            catch { ErrorLabel.Text = "Ошибка подключения"; }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            //string newDate = dt.Date.ToString().Replace("00:00:00", dt.Hour + ":00:00");
            string newDate = dt.ToString();
            classesDates = new List<DateTime>();
            classesDates.Add(DateTime.Parse(newDate));

            DateGrid.DataSource = classesDates.Select(x => new { date = x }).ToList();
            int length = DateGrid.Rows.Count;
            foreach (DataGridViewRow row in DateGrid.Rows)
            {
                row.Selected = true;
            }
            if (length > 0)
                DateGrid.Rows[length - 1].Selected = true;
        }

        private void StudentsGrid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string student = StudentsGrid.SelectedRows[0].Cells[0].Value.ToString();
            studentsD[student] = ChangeMark();

            var _priceDataArray = from row in studentsD select new { Student = row.Key, Mark = row.Value };
            StudentsGrid.DataSource = _priceDataArray.ToArray();
        }

        private string ChangeMark()
        {
            if (StudentsGrid.SelectedRows[0].Cells[1].Value.ToString() == "-")
                return "+";
            return "-";
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            SendRequest(Requests.delete);
            SendRequest(SubjectGrid.CurrentCell.Value.ToString());
            SendRequest(DateGrid.SelectedCells[0].Value.ToString());

            SubjectGrid_CellClick(sender, null);
        }

        private void SubjectGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SendRequest("getDates");
            SendRequest(SubjectGrid.CurrentCell.Value.ToString());

            var income = RecieveData();
            if (income == "0")
                return;
            var rawDate = income.Split(';');
            if (rawDate[0] == "_")
            {
                DateGrid.DataSource = new List<string>().Select(x => new { date = x }).ToList();
                return;
            }
            classesDates = new List<DateTime>();
            foreach (string date in rawDate)
            {
                DateTime temp;
                if (DateTime.TryParse(date.Replace(".txt", "").Replace('^', ':'), out temp))
                    classesDates.Add(temp);
                else
                    classesDates.Add(DateTime.MinValue);
            }
            DateGrid.DataSource = classesDates.Select(x => new { date = x }).ToList();
        }

        private void DateGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SendRequest("getMarks");
            SendRequest(SubjectGrid.CurrentCell.Value.ToString());
            SendRequest(DateGrid.CurrentCell.Value.ToString());
            marks = RecieveData().Split(';').ToList<string>();
            int i = 0;

            foreach (string student in students)
                studentsD[student] = marks[i++];

            var _priceDataArray = from row in studentsD select new { Student = row.Key, Mark = row.Value };
            StudentsGrid.DataSource = _priceDataArray.ToArray();
        }
    }
}
