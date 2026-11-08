/*
Rules: E8-4-5-ed3-nullable-boxing-constraint
Authority: ECMA-334 3rd ed 25.7.1
Version: ISO-2
Expected: run
Stdout: OK 1
Version-Witness: version-witnesses/E8-4-5-ed3-nullable-boxing-constraint/nullable-to-object-constraint.cs.part
Mutate: where T : U
Into: where T : U, IDisposable
*/
// ECMA-334 3rd ed 25.7.1, p. 404 (PDF p. 424).
using System;
class Holder<T, U> where T : U {}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static int Main()
    {
        Holder<int?, object> value = new Holder<int?, object>();
        Check(value != (object)null, "nullable-object-constraint");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
