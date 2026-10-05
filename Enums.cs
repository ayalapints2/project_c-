
namespace DO;

record  Test
{
    int id;
   enum topic;
   DateTime dateOfTest;
    int countQuestion;
    public Test(int countQuestion, DateTime dateOfTest ,topic topic)
    {
     
    }
    public Test();
   
}

record Question
{
    int id;
    enum topic;
    string content;
    int corectAnswer;
    public Question();
    //בנאי עם פרמטרים
    public Question(int id, topic topic, string content, int corectAnswer)
    {
        
    }
}

record Answer
{
    int id;
    Question id;
    string answer;
    public Answer();
    public Answer(int id, Question id, string answer)
    {
        
    }

}

record Student
{
        
}
record QuestionForTest
{

}
public record student(int id, string name,int age);





