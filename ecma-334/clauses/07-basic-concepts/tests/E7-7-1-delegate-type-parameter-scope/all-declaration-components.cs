/*
Rules: E7-7-1-delegate-type-parameter-scope
Authority: ECMA-334 7th ed 7.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: delegate T Map<T, U>(U value)
Into: delegate T Map<V, U>(U value)
*/
using System;
delegate T Map<T, U>(U value) where T : U;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Map<int, int> operation = value => value + 1;
        Check(operation(71) == 72, "type-parameters-in-return-parameters-and-constraint");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
