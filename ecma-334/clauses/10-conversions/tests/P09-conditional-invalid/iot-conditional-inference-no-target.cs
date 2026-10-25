/*
Rules: P09-conditional-invalid
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: Echo(choose ? new First() : new Second())
Into: Echo<Root>(choose ? new First() : new Second())
*/
class Root { }
class First : Root { }
class Second : Root { }
class Program
{
    static T Echo<T>(T item) { return item; }
    static int Main(string[] args)
    {
        bool choose = args.Length == 0;
        Root item = Echo(choose ? new First() : new Second());
        return item == null ? 1 : 0;
    }
}
