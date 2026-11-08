/*
Rules: E8-4-5-constraint-boxing; E8-4-5-constraint-substitution; E8-4-5-type-constraint-conversion-required; E8-4-5-constraint-failure-error
Authority: ECMA-334 7th ed 8.4.5
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/E8-4-5-constraint-boxing/nullable-enum-parameter-bound.cs.part
Mutate: new Bucket<State?, object>()
Into: new Bucket<State, object>()
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    enum State { Cold = 5, Warm = 9 }
    class Bucket<T, U> where T : U { }
    static int Main()
    {
        object instance = new Bucket<State?, object>();
        Check(instance != null, "constructed-class-with-substituted-object-bound");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
