/*
Rules: E12-9-4-overload-resolution; E12-9-4-operand-conversion; E12-9-4-result-type
Authority: ECMA-334 7th ed 12.9.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: !input
Into: new Answer(0)
*/
using System;
struct Answer { public int Value; public Answer(int v) { Value = v; } }
class Flag
{
    public int Value;
    public static Answer operator !(Flag x) { Program.Received = x; return new Answer(x.Value + 20); }
}
class Narrow : Flag { }
class Program
{
    public static Flag Received;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Kind(Answer x) { return 1; }
    static int Kind(object x) { return 2; }
    static void Main()
    {
        Narrow input = new Narrow(); input.Value = 4; var result = !input;
        Check(result.Value == 24, "chosen-operator"); Check(Received == input, "base-parameter-conversion");
        Check(Kind(result) == 1, "declared-return-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
