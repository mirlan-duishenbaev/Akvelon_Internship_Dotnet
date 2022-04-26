using Traverse_Tree;

public class Programm
{
    public static void Main()
    {
        Tree<Student> tree = new Tree<Student>();

        Action<Student> myAction = x => Console.WriteLine("{0} : {1}", x.FirstName, x.LastName);

        Operations.DoTree(tree, myAction);
    }
}