using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ClassroomProject
{
    public class Classroom
    {
        
        private List<Student> studentsList;

        
        public Classroom(int capacity)
        {
            Capacity = capacity;
            studentsList = new List<Student>(); 
        }
        public int Capacity { get; set; }

        public int Count { get { return studentsList.Count; } }

        public string RegisterStudent(Student nextStudent)
        {
            if(studentsList.Count < Capacity)
            {
                studentsList.Add(nextStudent);
                return $"Added student {nextStudent.FirstName} {nextStudent.LastName}";
            }

            return "No seats in the classroom";

        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student lookForDismiss = studentsList.FirstOrDefault(n => n.FirstName == firstName && n.LastName == lastName);

            if(lookForDismiss == null)
            {
                return "Student not found";
            }

            studentsList.Remove(lookForDismiss);
            return $"Dismissed student {firstName} {lastName}";
        }

        /*
          •	Method GetSubjectInfo(string subject) – returns all the students with the given subject in the following format:
            "Subject: {subjectName}
            Students:
            {firstName} {lastName}
            {firstName} {lastName}
                …"
            o	Returns "No students enrolled for the subject" if the student is not in the classroom


       */

        public string GetSubjectInfo(string subject)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Subject: {subject}");
            result.AppendLine("Students:");

            foreach (Student student in studentsList)
            {
                if(student.Subject == subject)
                {
                    result.AppendLine($"{student.FirstName} {student.LastName}");
                }
            }

            return result.ToString();
        }

        public int GetStudentsCount()
        {
            return Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return studentsList.FirstOrDefault(n => n.FirstName == firstName && n.LastName == lastName);
        }



    }
}
