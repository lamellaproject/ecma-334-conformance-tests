/*
Rules: E12-9-5-overload-resolution; E12-9-5-operand-conversion; E12-9-5-result-type
Authority: ECMA-334 7th ed 12.9.5
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: ~input
Into: new Answer(0)
*/
using System;
struct Answer { public int Value; public Answer(int v) { Value = v; } }
class Mask
{
    public int Value;
    public static Answer operator ~(Mask x) { Program.Received = x; return new Answer(x.Value + 30); }
}
class Narrow : Mask { }
class Program
{
    public static Mask Received;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Kind(Answer x) { return 1; }
    static int Kind(object x) { return 2; }
    static void Main()
    {
        Narrow input = new Narrow(); input.Value = 4; var result = ~input;
        Check(result.Value == 34, "chosen-operator"); Check(Received == input, "base-parameter-conversion");
        Check(Kind(result) == 1, "declared-return-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
