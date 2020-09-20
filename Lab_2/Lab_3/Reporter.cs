using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab_3
{
    static class Reporter
    {
        public static void ShowReport()
        {
            string file = SelectReport();
            StreamReader sr = new StreamReader(file);
            foreach (string student in GetStudents())
            {
                Console.WriteLine(student + "\t" + sr.ReadLine());
            }
            sr.Close();
        }
        public static void CreateReport()
        {
            string subject = GetSubject();
            DateTime dt = DateTime.Now;
            string path = Paths.root + "/" + Paths.reports + "/"+ subject + "_"+
                          dt.Date.ToString().Replace(" 0:00:00", "")+
                          "-" + dt.Hour + ".txt";


            Console.WriteLine("Отметьте присутствующих студентов  \"+\", отсутствующих \"-\" ");
            StreamWriter sw = File.AppendText(path);
            foreach (string student in GetStudents())
            {
                Console.Write(student + "\t");
                while (true)
                {
                    char sign = Console.ReadKey().KeyChar;
                    if (!Paths.validSigns.Contains(sign))
                    {
                        Console.WriteLine("\"+\" или \"-\"");
                        continue;
                    }
                    sw.WriteLine(sign);
                    break;
                }
                Console.WriteLine("\n");
            }
            sw.Close();
        }

        public static void OpenReport()
        {
            string file = SelectReport();
            System.Diagnostics.Process.Start("notepad.exe", file);
        }

        public static string GetSubject()
        {
            List<string> subjectList = File.ReadAllLines(@Paths.root +"/"+ Paths.subjects).ToList();

            Console.WriteLine("Выберите предмет (Введите номер)\n");
            for (int i=0; i<subjectList.Count; i++ )
            {
                Console.WriteLine(i + " - " + subjectList[i]);
            }
            
            
            int number = Int32.Parse(Console.ReadLine() ?? throw new Exception());
            
            return subjectList[number];
        }
        
        private static string SelectReport()
        {
            string path = Paths.root + "/" + Paths.reports;
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] fi = di.GetFiles();
            for (int i = 0; i < di.GetFiles().Length; i++)
            {
                Console.WriteLine(i + " " + fi[i].Name);
            }

            Console.WriteLine("\n Выберите отчет");
            int number = Int32.Parse(Console.ReadLine());
            return fi[number].ToString();
        }
        public static List<string> GetStudents()
        {
            List<string> studentList = File.ReadAllLines(@Paths.root +"/"+ Paths.students).ToList();
            
            return studentList;
        }
    }
}
