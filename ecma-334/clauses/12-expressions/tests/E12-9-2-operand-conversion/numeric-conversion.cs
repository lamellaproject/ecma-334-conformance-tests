/*
Rules: E12-9-2-operand-conversion; E12-9-2-result-type
Authority: ECMA-334 7th ed 12.9.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: +new Token()
Into: 0
*/
using System;
struct Token
{
    public static implicit operator int(Token x) { Program.Calls++; return 12; }
}
class Program
{
    public static int Calls;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Kind(int x) { return 1; }
    static int Kind(long x) { return 2; }
    static void Main()
    {
        var result = +new Token();
        Check(result == 12, "converted-value"); Check(Calls == 1, "conversion-once"); Check(Kind(result) == 1, "int-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
