using Dal;
using DalApi;
using DO;

namespace DalTest;

public class Program
{
    private static IDal s_dal = new DalList(); // אותחול DAL

    public static void Main(string[] args)
    {
        string name = "start";

        while (name != "0")
        {
            name = PrintMainMenu();
            switch (name)
            {
                case "1":
                    SubMenu<Student>("Student", s_dal.Student, AskStudent);
                    break;
                case "2":
                    SubMenu<Question>("Question", s_dal.Question, AskQuestion);
                    break;
                case "3":
                    SubMenu<Answer>("Answer", s_dal.Answer, AskAnswer);
                    break;
                case "4":
                    SubMenu<Test>("Test", s_dal.Test, AskTest);
                    break;
                case "5":
                    SubMenu<QuestionForTested>("QuestionForStudent", s_dal.QuestionForTested, AskQuestionForTested);
                    break;
                case "0":
                    Console.WriteLine("Exiting the program.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public static void SubMenu<T>(string name, ICrud<T> crud, Func<T> askFunc)
    {
        string selection = "start";

        while (selection != "0")
        {
            selection = PrintSubMenu();
            switch (selection)
            {
                case "1":
                    Console.WriteLine("Create functionality not yet implemented.");
                    T newObj = askFunc();
                    Create<T>(crud, newObj);
                    break;
                case "2":
                    Console.WriteLine("read functionality not yet implemented.");
                    Read<T>(crud);
                    break;
                case "3":
                    Console.WriteLine("Update functionality not yet implemented.");
                    T newObj = askFunc();
                    update<T>(crud, newObj);
                    break;
                case "4":
                    Console.WriteLine("Delete functionality not yet implemented.");
                    break;
                case "5":
                    Console.WriteLine("ReadAll functionality not yet implemented.");
                    ReadAll<T>(crud);
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    // פונקציה גנרית ליצירת אובייקט
    public static void Create<T>(ICrud<T> crud, T obj)
    {
        try
        {
            int id = crud.Create(obj);
            Console.WriteLine($"Object created successfully with ID: {id}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating object: {ex.Message}\n");
        }
    }

    // פונקציה גנרית לקריאת אובייקט
    public static void Read<T>(ICrud<T> crud)
    {
        Console.WriteLine("Enter ID to read:");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            T? result = crud.Read(id);
            if (result != null)
                Console.WriteLine($"Result: {result}\n");
            else
                Console.WriteLine("Object not found.\n");
        }
        else
        {
            Console.WriteLine("Invalid ID format.\n");
        }
    }

    // קריאת כל האובייקטים
    public static void ReadAll<T>(ICrud<T> crud)
    {
        var results = crud.ReadAll();
        if (results.Count > 0)
        {
            Console.WriteLine("All objects:");
            foreach (var item in results)
                Console.WriteLine(item);
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("No objects found.\n");
        }
    }

    //פונקצית עידכון לשימוש גינרי 
    public static void update<T>(ICrud<T> crud, T obj)
    {

   }
    public static Student AskStudent()
    {
        Console.WriteLine("Enter student ID:");
        int id = GetIntInput();
        Console.WriteLine("Enter student name:");
        string name = Console.ReadLine() ?? string.Empty;
        return new Student(id, name, 0, 0);
    }

    public static Question AskQuestion()
    {
        Console.WriteLine("Enter question ID:");
        int id = GetIntInput();
        Console.WriteLine("Enter question subject (0=Math, 1=English, 2=Science, 3=Grammar, 4=History):");
        Subject subject = GetSubject();
        return new Question(id, subject, 0, "Sample question");
    }

    public static QuestionForTested AskQuestionForTested()
    {
        Console.WriteLine("Enter student ID:");
        int studentId = GetIntInput();
        Console.WriteLine("Enter test ID:");
        int testId = GetIntInput();
        Console.WriteLine("Enter question ID:");
        int questionId = GetIntInput();
        return new QuestionForTested(studentId, testId, questionId, null);
    }

    public static Answer AskAnswer()
    {
        Console.WriteLine("Enter answer ID:");
        int id = GetIntInput();
        Console.WriteLine("Enter question ID:");
        int qId = GetIntInput();
        Console.WriteLine("Enter answer text:");
        string text = Console.ReadLine() ?? string.Empty;
        return new Answer(id, qId, text);
    }

    public static Test AskTest()
    {
        Console.WriteLine("Enter test ID:");
        int id = GetIntInput();
        Console.WriteLine("Enter test subject (0=Math, 1=English, 2=Science, 3=Grammar, 4=History):");
        Subject subject = GetSubject();
        return new Test(id, subject, DateTime.Now, 0);
    }

    private static int GetIntInput()
    {
        int result;
        while (!int.TryParse(Console.ReadLine(), out  result))
        {
            Console.WriteLine("Invalid input. Please enter a valid number:");
        }
        return result;
    }

    private static Subject GetSubject()
    {
        int result;
        while (!int.TryParse(Console.ReadLine(), out  result) || result < 0 || result > 4)
        {
            Console.WriteLine("Invalid input. Please enter a number between 0-4:");
        }
        return (Subject)result;
    }

    public static string PrintSubMenu()
    {
        Console.WriteLine("\nSub Menu:");
        Console.WriteLine("1. Create");
        Console.WriteLine("2. Read");
        Console.WriteLine("3. Update");
        Console.WriteLine("4. Delete");
        Console.WriteLine("5. ReadAll");
        Console.WriteLine("0. Exit");
        Console.Write("Enter your choice: ");
        return Console.ReadLine() ?? "0";
    }

    public static string PrintMainMenu()
    {
        Console.WriteLine("\nMain Menu:");
        Console.WriteLine("1. Student");
        Console.WriteLine("2. Question");
        Console.WriteLine("3. Answer");
        Console.WriteLine("4. Test");
        Console.WriteLine("5. QuestionForStudent");
        Console.WriteLine("0. Exit");
        Console.Write("Enter your choice: ");
        return Console.ReadLine() ?? "0";
    }
}




//מה שאני כתבתי:
//   יש שגיאות
//using DalApi;
//using DO;
//namespace DalTest;

//public class Program
//{
//    public static void Main(string[] args)
//    {
//        IDal s_dal;
//        string name = "start";
//        name = PrintMainMenu();
//        switch (name)
//        {
//            case "1":
//                SubMenu<Student>("Student", s_dal.Student, AskStudent);
//                break;
//            case "2":
//                SubMenu<Question>("Question", s_dal.Question, AskQuestion);
//                break;
//            case "3":
//                SubMenu<Answer>("Answer", s_dal.Answer, AskAnswer) ;
//                break;
//            case "4":
//                SubMenu<Test>("Test", s_dal.Test, AskTest);
//                break;
//            case "5":
//                SubMenu<QuestionForTested>("QuestionForStudent", s_dal.QuestionForTested, AskQuestionForTested);
//                break;
//            case "0":
//                Console.WriteLine("Exiting the program.");
//                break;
//            default:
//                Console.WriteLine("Invalid choice. Please try again.");
//                break;
//        }
//    }


//    public static void SubMenu<T>(string name, ICrud<T> crud, Func<T> askFunc)
//    {

//        string selection = "start";

//        while (selection != "0")
//        {
//            selection = PrintSubMenu();
//            switch (selection)
//            {

//                case "1":
//                    T newObj = askFunc();
//                    Create<T>(crud,askFunc);
//                    break;
//                case "2":
//                    Read<T>(crud);
//                    break;

//                case "3":
//                case "4":
//                case "5":
//                case "0":
//                default: break;
//            }
//        }
//    }
//    //פונקציה גנרית ליצירת אובייקט -צריכה ברור
//    public static void Create<T>(ICrud<T> crud,Func<T>func)
//    {
//        object newObj = func();

//    }
//    //פונקציה גנרית לקריאת אובייקט
//    public static void Read<T>(ICrud<T> crud)
//    {
//        Console.WriteLine("Enter ID to read:");
//        int id = int.Parse(Console.ReadLine());
//        crud.Read(id);

//    }

//    public static Student AskStudent() {
//        Student student = new Student();
//        Console.WriteLine("Enter student ID:");
//        Console.WriteLine("Enter student name:");
//        return student;
//    }
//    public static Question AskQuestion()
//    {
//        Question question = new Question();
//        Console.WriteLine("Enter question ID:");
//        Console.WriteLine("Enter question subject:");
//        return question;

//    }
//    public static QuestionForTested AskQuestionForTested()

//        {   QuestionForTested questionForTested = new QuestionForTested();
//            Console.WriteLine("Enter questionForTested ID:");
//            Console.WriteLine("Enter questionForTested subject:");
//            return questionForTested;
//        }
//    public static Answer AskAnswer()
//    {
//        Answer answer = new Answer();
//        Console.WriteLine("Enter answer ID:");
//        Console.WriteLine("Enter answer question ID:");
//        return answer;
//    }
//    public static Test AskTest()
//    {
//        Test test = new Test();
//        Console.WriteLine("Enter test ID:");
//        Console.WriteLine("Enter test name:");
//        return test;
//    }
//    public static string PrintSubMenu()
//    {
//        Console.WriteLine("Sub Menu:");
//        Console.WriteLine("1.Create");
//        Console.WriteLine("2. Read");
//        Console.WriteLine("3. Update");
//        Console.WriteLine("4. Delete");
//        Console.WriteLine("5. ReadAll");
//        Console.WriteLine("0. exit");
//        Console.Write("Enter your choice: ");
//        return Console.ReadLine();


//    }
//    public static string PrintMainMenu()
//    {
//        Console.WriteLine("Main Menu:");
//        Console.WriteLine("1. Student");
//        Console.WriteLine("2. Question");
//        Console.WriteLine("3. Answer");
//        Console.WriteLine("4. Test");
//        Console.WriteLine("5. QustionForStudent");
//        Console.WriteLine("0. exit");
//        Console.Write("Enter your choice: ");
//        return Console.ReadLine();
//    }

//}

