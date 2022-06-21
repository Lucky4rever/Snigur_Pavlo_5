Student Person1 = new Student();
Person1.Age = 18;
Person1.Presence = true;
Person1.HomeworkCheck = 6;
Person1.Course = 1;

Student Person2 = new Student();
Person2.Age = 18;
Person2.Presence = false;
Person2.HomeworkCheck = 0;
Person2.Course = 1;

Teacher Person3 = new Teacher();
Person3.Age = 47;
Person3.Presence = true;
Console.Write(Person1.Output());
Console.Write(Person2.Output());
Console.Write(Person3.Output());

class Teacher
{
    public bool Presence { get; set; }
    public int Age { get; set; }
    public string Output()
    {
        return $"Наявнiсть в аудиторiї: {Presence} Вiк: {Age}\n";
    }
}
class Student
{
    public int Course { get; set; }
    public bool Presence { get; set; }
    public int HomeworkCheck { get; set; }
    public int Age { get; set; }
    public string Output()
    {
        return $"Курс: {Course} Наявнiсть в аудиторiї: {Presence}  Перевiрка домашнiх завдань: {HomeworkCheck}  Вiк: {Age}\n";
    }
}
