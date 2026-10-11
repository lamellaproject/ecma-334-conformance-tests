/*
Rules: E15-6-2-1-invocation-local-storage
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: int saved = value;
Into: int saved = 0;
*/
using System;
class Program
{
    static int Depth(int value)
    {
        int saved = value;
        if (value > 0)
        {
            int nested = Depth(value - 1);
            Check(value == saved, "parameter-preserved-across-nested-invocation");
            Check(saved == nested + 1, "local-preserved-across-nested-invocation");
        }
        return saved;
    }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Depth(2) == 2, "outer-invocation-has-independent-local-and-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
