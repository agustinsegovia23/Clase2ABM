public class Users{
    public Users(string name, string surname, int age)
    {
        Name = name;
        Surname = surname;
        Age = age;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public int Age { get; set; }
}