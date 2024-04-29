using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityGradeSystem.Entity;

namespace UniversityGradeSystem
{
    public class Program
    {
        static void Main(string[] args)
        {   
            string username , password;
            bool loginSuccess = false;


            List<Student> students = new List<Student>();
            Student student0 = new Student("Ali", "Abc", 101 , new int[] {90 , 56 , 54 });
            Student student1 = new Student("Beyza", "Basd", 22 , new int[] {56 , 60 , 79 });
            Student student2 = new Student("Ceyda", "Casdsa", 233 , new int[] {68 , 67 , 90 });
            Student student3 = new Student("Deniz", "ADsad", 674 , new int[] {67 , 90 , 54 });
            Student loggedInStudent = null;

            //Student objelerimi login sayfasina yollayabilmek icin listeye ekledim
            students.Add(student0);
            students.Add(student1);
            students.Add(student2);
            students.Add(student3);

            Console.Write("Enter username:");
            username= Console.ReadLine();
            Console.Write("\nEnter password:");
            password= Console.ReadLine();

            //username ve password kontrol edip giris yapan ogrenciyi tespit etme

            foreach (Student student in students)
            {
                if (username.Equals(student.Username) && password.Equals(student.Password))
                {
                    Console.WriteLine("\n~~Login successful~~\n");
                    loginSuccess = true;
                    loggedInStudent=student;
                    break;
                }
            }

            if (loginSuccess)
            {
                loggedInStudent.Display();
            }
            else
            {
                Console.WriteLine("Invalid username or password ");
            }


            Console.ReadLine();
        }
    }
}
