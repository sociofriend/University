using System;
namespace University2
{
    public class University
    {
        #region Lists
        public List<Faculty> list_faculties { get; set; }
        public List<Teacher> list_teachers { get; set; }
        public List<Student> list_students { get; set; }
        public List<FT_relation> list_ft_relation { get; set; }
        #endregion

        #region Constructors
        public University()
        {
            list_faculties = new List<Faculty>();
            list_teachers = new List<Teacher>();
            list_students = new List<Student>();
            list_ft_relation = new List<FT_relation>();
        }
        #endregion

        // create

        #region Method - Create faculty 
        public void CreateFaculty(string name)
        {
            Faculty objFaculty = new Faculty();
            objFaculty.Name = name;
            objFaculty.Id = Guid.NewGuid().ToString();
            list_faculties.Add(objFaculty);
        }
        #endregion

        #region Method - Register teacher
        //register teacher
        public void RegisterTeacher(string name)
        {
            Teacher objTeacher = new Teacher();
            objTeacher.Name = name;
            objTeacher.Id = Guid.NewGuid().ToString();
            list_teachers.Add(objTeacher);
        }
        #endregion

        #region Method - Admit student
        public void AdmitStudent(string name, string facultyId)
        {
            Student objStudent = new Student();
            objStudent.Name = name;
            objStudent.Id = Guid.NewGuid().ToString();
            objStudent.FacultyId = facultyId;
            list_students.Add(objStudent);
        }
        #endregion

        // connect

        #region Method - Set a faculty - teacher relation
        public void Set_FT_Relation(string facultyId, string teacherId)
        {
            FT_relation obj_FT_Relation = new FT_relation();
            obj_FT_Relation.FacultyId = facultyId;
            obj_FT_Relation.TeacherId = teacherId;
            obj_FT_Relation.FT_ContractId = Guid.NewGuid();
            list_ft_relation.Add(obj_FT_Relation);
        }

        public void PrintFaculties()
        {
            foreach (var f in list_faculties)
            {
                Console.WriteLine($"{f.Name} --> {f.Id}");
            }
        }
        #endregion


        // get

        #region Method - Get Teacher's ID by name
        public string GetTeacherIdByName(string name)
        {
            string result = string.Empty;
            foreach (var teacher in list_teachers)
            {
                if (string.Equals(name, teacher.Name))
                {
                    result = teacher.Id;
                }
            }
            return result;
        }
        #endregion

        #region Method - Get Faculty's ID by name
        public string GetFacultyIdByName(string name)
        {
            string result = string.Empty;
            foreach (var faculty in list_faculties)
            {
                if (string.Equals(name, faculty.Name))
                {
                    result = faculty.Id;
                }
            }

            return result;
        }
        #endregion

        #region Method - Get Teacher's name by ID
        public string GetTeacherNameById(string id)
        {
            string result = string.Empty; //datark string a
            foreach (var teacher in list_teachers)
            {
                if (string.Equals(id, teacher.Id))
                {
                    result = teacher.Name;
                }
            }
            return result;
        }
        #endregion

        // print
        #region Method - Print Teachers' name by facultyName
        public List<string> GetTeachersByFaculty(string facultyName)
        {
            List<string> result = new List<string>();

            //find facultyId by facultyName from List_faculties
            string facultyID = GetFacultyIdByName(name: facultyName);

            if (string.IsNullOrEmpty(facultyName))
            {
                Console.WriteLine("Could not find faculty");
                return result;
            }

            //loop in relationsList
            foreach (var relation in list_ft_relation)
            {
                //find record where facultyId is our faculty Id and get teacherId from it
                if (string.Equals(facultyID, relation.FacultyId))
                {
                    string teacherId = relation.TeacherId;
                    //find teacherName by teacherId and add it to our result;
                    string teacherName = GetTeacherNameById(id: teacherId);
                    result.Add(teacherName);
                }
            }


            return result;
        }
        #endregion

        #region Method - Print students' names' list by facultyName
        //REFACTOR = move to university, and work by calling methods
        
        public List<string> PrintStudentNamesByFaculty(string facultyName)
        {
            List <string> result_StudentName = new List<string>();

            string facultyId = GetFacultyIdByName(name: facultyName);

            foreach(var student in list_students)
            {
                if(string.Equals(student.FacultyId, facultyId))
                {
                    result_StudentName.Add(student.Name);
                }
            }
            return result_StudentName;
        }
        #endregion

        #region Method - Print total numbers (facultis, teachers, students) 
        public void PrintCountDetails()
        {
            Console.WriteLine($"Number of faculties: {list_faculties.Count}" +
                $"\nNumber of teachers: {list_teachers.Count}" +
                $"\nNumber of students: {list_students.Count}");
        }
        #endregion

    }
}

