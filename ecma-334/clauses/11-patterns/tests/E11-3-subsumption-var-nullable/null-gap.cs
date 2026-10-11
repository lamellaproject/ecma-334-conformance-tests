/*
Rules: E11-3-subsumption-var-nullable
Authority: ECMA-334 7th ed 11.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: case int first: return 1;
Into: case var first: return 1;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Select(int? input)
    {
        switch (input)
        {
            case int first: return 1;
            case var rest: return 2;
        }
    }
    static void Main()
    {
        Check(Select(null) == 2, "nullable-null-gap");
        Check(Select(29) == 1, "nullable-value-covered");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
