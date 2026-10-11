/*
Rules: E12-11-dynamic-binding; E12-11-dynamic-result-type; E12-11-dynamic-runtime-resolution
Authority: ECMA-334 7th ed 12.11
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: input << count
Into: input >> count
*/
using System;
public class Answer { public int Value; public Answer(int v) { Value = v; } }
public class Number
{
    public static Answer operator <<(Number x, int y) { return new Answer(11 + y); }
    public static Answer operator >>(Number x, int y) { return new Answer(17 + y); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Pick(Answer x) { return 1; }
    static int Pick(object x) { return 2; }
    static void Main()
    {
        dynamic input = new Number(); int count = 3; var r = input << count;
        Check(r.Value == 14, "runtime-left-operator"); Check(Pick(r) == 1, "dynamic-result-type");
        input = 48; dynamic runtimeCount = 2; Check(input >> runtimeCount == 12, "integer-runtime-types");
        Number typed = new Number(); Check((typed >> runtimeCount).Value == 19, "only-count-dynamic");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
