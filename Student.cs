using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace UniversityGradeSystem.Entity
{
    public class Student
    {
        string Name {  get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
        public int[] Grades {  get; set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Mail {  get; private set; }

        public Student(string name, string lastName, int id, int[] grades)
        {
            if (grades.Length != 3)
            {
                throw new IndexOutOfRangeException("Numbers array must have exactly 3 elements.");
            }

            Name = name;
            LastName = lastName;
            Id = id;
            Grades = grades;
            Username = $"{Name.ToLower()}{LastName.ToLower()}{Id}";
            Password = $"{Name.ToLower()}{LastName.ToLower()}{Id}";
            Mail = $"{Name.ToLower()}{LastName.ToLower()}{Id}@gmail.com";
        }

       

        public void Display()
        {
            Console.WriteLine($"{Id}|{Name} {LastName} 's Grades");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Matematik\tFizik\t\tKimya");
            Console.WriteLine($"{Grades[0]}\t\t{Grades[1]}\t\t{Grades[2]}");
            char[] letterGrades = ToLetterGrade();
            Console.WriteLine($"{letterGrades[0]}\t\t{letterGrades[1]}\t\t{letterGrades[2]}");
            Console.WriteLine("Average : " + Average());
            SendEmail();
        }

        public double Average()
        {
            double average = 0;
            for(int i=0;i<Grades.Length;i++ )
            {
                average += Grades[i];
            }
            return (average/Grades.Length);
        }

        public char[] ToLetterGrade()
        {
            char[] letters=new char[Grades.Length];

            for(int i = 0; i < Grades.Length; i++)
            {
                int grade = Grades[i];
                switch (grade)
                {
                    case int n when (n >= 90 && n <= 100):
                        letters[i] = 'A';
                        break;
                    case int n when (n >= 80 && n <= 90):
                        letters[i] = 'B';
                        break;
                    case int n when (n >= 70 && n <= 80):
                        letters[i] = 'C';
                        break;
                    case int n when (n >= 60 && n <= 70):
                        letters[i] = 'D';
                        break;
                    case int n when (n >= 50 && n <= 60):
                        letters[i] = 'F';
                        break;
                    default:
                        Console.WriteLine("Invalid grade.");
                        break;

                }
            }
            return letters;
            
        }
        private void SendEmail()
        {
            string senderMail = "beykent@gmail.com";
            string password = "beykenT0123";
            string receiverMail = Mail;

            //internetten gordugum sunucu ve port numarasi
            string smtpServer = "smtp.gmail.com";
            int port = 587;

            //mailin konusu ve icerigi
            MailMessage mail = new MailMessage(senderMail,receiverMail);
            mail.Subject = "Grade Averages";
            mail.Body = $"{Id}-{Name}{LastName}, \n Your grade average is {Average()} . ";

            //client olusturma icin buldugum ornek kod blogu

            SmtpClient smtpClient = new SmtpClient(smtpServer);
            smtpClient.Port = port;
            smtpClient.Credentials = new NetworkCredential(senderMail, password);
            smtpClient.EnableSsl = true;                                                          // SSL/TLS şifreleme kullanılıyorsa true, kullanılmıyorsa false(ne olduguna bak)

            try
            {
                smtpClient.Send(mail);
                Console.WriteLine($"Mail sended :{receiverMail}");
            }catch(Exception e)
            {
                Console.WriteLine($"Error:{e.Message}");
            }
        }


        //son
    }
}
