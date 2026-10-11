/*
Rules: E22-5-5-1-caller-info-query-substitution; E22-5-5-1-caller-info-query-location
Authority: ECMA-334 7th ed 22.5.5.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [System.Runtime.CompilerServices.CallerLineNumber] int line
Into: int line
*/
using System;
delegate int Projection(int value);
class Sequence
{
    public int Line;
    public Sequence Select(Projection projection, [System.Runtime.CompilerServices.CallerLineNumber] int line = -1)
    {
        return new Sequence { Line = line };
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
#line 500 "query-source.cs"
        var query = from n in new Sequence()
                    select n + 2;
#line default
        Check(query.Line == 501, "select-clause-location");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
