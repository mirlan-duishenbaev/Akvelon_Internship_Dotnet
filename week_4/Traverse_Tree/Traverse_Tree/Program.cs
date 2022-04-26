using Traverse_Tree;

public class Programm
{
    public static void Main()
    {
        Student student1 = new Student() { Id = 5, FirstName = "John", LastName = "Maxwell" };
        Student student2 = new Student() { Id = 2, FirstName = "Kevin", LastName = "Dunn" };
        Student student3 = new Student() { Id = 8, FirstName = "Larry", LastName = "Barns" };

        Tree<Student> Left = new Tree<Student>()
        {
            Data = student2
        };
        Tree<Student> Right = new Tree<Student>()
        {
            Data = student3
        };

        Tree<Student> tree = new Tree<Student>()
        {
            Data = student1,
            Left = Left,
            Right = Right
        };

        Action<Student> myAction = x => Console.WriteLine("{0} : {1} {2}", x.Id, x.FirstName, x.LastName);

        Operations.DoTree(tree, myAction);

        Console.Read();
    }
}