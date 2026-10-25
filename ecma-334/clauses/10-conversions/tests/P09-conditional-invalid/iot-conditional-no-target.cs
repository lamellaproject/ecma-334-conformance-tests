/*
Rules: P09-conditional-invalid
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: var item = choose ? new North() : new South();
Into: Root item = choose ? new North() : new South();
*/
class Root { }
class North : Root { }
class South : Root { }
class Program
{
    static int Main(string[] args)
    {
        bool choose = args.Length == 0;
        var item = choose ? new North() : new South();
        return item == null ? 1 : 0;
    }
}
