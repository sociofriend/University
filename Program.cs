namespace University2;
class Program
{
    static void Main(string[] args)
    {
        University objUniversity = new University();

        // create
        #region Method Call - Create faculty
        string newFaculty;
        Console.WriteLine("Faculties' number.");
        //int numberOfNewFaculties = Convert.ToInt32(Console.ReadLine());
        int numberOfNewFaculties = 1; // ++ 

        for (int i = 0; i < numberOfNewFaculties; i++)
        {
            Console.WriteLine("Faculty name.");
            //newFaculty = Console.ReadLine(); 
            newFaculty = "Soc"; // ++
            objUniversity.CreateFaculty(newFaculty);
        }
        #endregion

        #region Method Call - Employ teacher
        string newTeacher;
        Console.WriteLine("Teachers' number.");
        //int numberOfNewTeachers = Convert.ToInt32(Console.ReadLine());
        int numberOfNewTeachers = 1;
        for (int i = 0; i < numberOfNewTeachers; i++)
        {
            Console.WriteLine("Teacher name.");
            //newTeacher = Console.ReadLine();
            newTeacher = "GT"; // ++
            objUniversity.RegisterTeacher(newTeacher);
        }
        #endregion

        #region Method Call - Admit student

        objUniversity.PrintFaculties();

        string newStudent;
        Console.WriteLine("Students' number.");
        //int numberOfNewStudents = Convert.ToInt32(Console.ReadLine());
        int numberOfNewStudents = 1; // ++

        string facultyNameForSearch;

        for (int i = 0; i < numberOfNewStudents; i++)
        {
            Console.WriteLine("Student name.");
            //newStudent = Console.ReadLine();
            newStudent = "LA"; // ++

            Console.WriteLine("Student's faculty name.");
            //facultyNameForSearch = Console.ReadLine();
            facultyNameForSearch = "Soc"; // ++

            foreach (var faculty in objUniversity.list_faculties) //REFACTOR
            {
                if (faculty.Name == facultyNameForSearch)
                {
                    objUniversity.AdmitStudent(newStudent, faculty.Id);
                }
            }
        }
        #endregion

        // connect
        #region Method Call - Set a contract for faculty and teacher
        // get count of iterations
        //int numberOfNewRelations = Convert.ToInt32(Console.ReadLine());
        int numberOfNewRelations = 1; // ++

        // loop with that count
        for (int i = 0; i < numberOfNewRelations; i++)
        {
            // get teacher name from console
            //cw
            //string teacherNameForRelation = Console.ReadLine();
            string teacherNameForRelation = "GT"; // ++

            // find teacher ID by name
            string teacherIdForRelation = objUniversity.GetTeacherIdByName(teacherNameForRelation);

            if (string.IsNullOrEmpty(teacherIdForRelation))
            {
                Console.WriteLine("Could not find teacher.");
                return;
            }

            // get faculty name from console
            //string facultyNameForRelation = Console.ReadLine();
            string facultyNameForRelation = "Soc"; // ++

            // find faculty ID from console
            string facultyIdForRelation = objUniversity.GetFacultyIdByName(facultyNameForRelation);

            if (string.IsNullOrEmpty(facultyIdForRelation))
            {
                Console.WriteLine("Could not find faculty.");
                return;
            }
            // call University fanction for creation of relation
            objUniversity.Set_FT_Relation(facultyId: facultyIdForRelation, teacherId: teacherIdForRelation);

        }
        #endregion

        // print
        #region Method Call - Print teachers' names by faculty
        //string facultyName = Console.ReadLine();
        string facultyName = "Soc"; // ++
        List<string> teachersByFaculty = objUniversity.GetTeachersByFaculty(facultyName: facultyName);
        foreach (var teacherName in teachersByFaculty)
        {
            Console.WriteLine($"Soc teacher --> {teacherName}");
        }
        #endregion

        #region Method Call - Print students' names by facultyName

        // string _facultyName = Console.ReadLine();
        string _facultyName = "Soc"; // ++

        List<string> _studentNamesForPrint = objUniversity.PrintStudentNamesByFaculty(_facultyName);

        foreach (var studentName in _studentNamesForPrint)
        {
            Console.WriteLine($"Soc student --> {studentName}");
        }
        #endregion

        #region Method Call - Print total numbers(facultis, teachers, students)
        objUniversity.PrintCountDetails();
        #endregion

        Console.ReadLine();
    }
}

