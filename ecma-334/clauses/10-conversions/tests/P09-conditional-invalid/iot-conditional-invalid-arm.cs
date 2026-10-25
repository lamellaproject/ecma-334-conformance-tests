/*
Rules: P09-conditional-invalid
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: choose ? new Leaf() : new Pebble()
Into: choose ? new Leaf() : new Leaf()
*/
class Root { }
class Leaf : Root { }
class Pebble { }
class Program
{
    static int Main(string[] args)
    {
        bool choose = args.Length == 0;
        Root item = choose ? new Leaf() : new Pebble();
        return item == null ? 1 : 0;
    }
}
