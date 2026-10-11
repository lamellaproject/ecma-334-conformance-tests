/*
Rules: E15-2-5-depends-transitive; E15-2-5-depends
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where T : U
Into: 
*/
using System;
class Root { }
class Middle : Root { }
class Leaf : Middle { }
class Program
{
    static U Up<S,T,U>(S value) where S : T where T : U { return value; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Leaf item = new Leaf();
        Check(Up<Leaf,Middle,Root>(item) == item, "transitive-parameter-dependency");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
