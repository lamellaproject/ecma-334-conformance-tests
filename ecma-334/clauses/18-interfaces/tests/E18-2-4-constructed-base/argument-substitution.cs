/*
Rules: E18-2-4-constructed-base; E18-2-4-base-uses-parameters; E18-2-4-constructed-base-substitution; E18-2-4-inherited-type-substitution
Authority: ECMA-334 7th ed 18.2.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: interface IPair<T> : IRead<T[]>
Into: interface IPair<T> : IRead<T>
*/
using System;
interface IRead<T> { T Read(); }
interface IPair<T> : IRead<T[]> { }
class Pair : IPair<int> { public int[] Read() { return new int[] { 13, 17 }; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        // 18.2.4, p. 490 calls the interface base a class. That terminology is incorrect;
        // this test follows interface inheritance with type arguments substituted.
        IPair<int> pair = new Pair();
        IRead<int[]> reader = pair;
        Check(pair.Read()[0] == 13, "inherited-return-type-substitution");
        Check(reader.Read()[1] == 17, "constructed-base-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
