/*
Rules: E7-1-entry-external-selection
Authority: ECMA-334 7th ed 7.1
Version: 7.3
Expected: run
Stdout: OK 2
Fixture: {"program":{"entry_point":"Chosen"}}
Mutate: static void Main(string[] arguments)
Into: static void Start(string[] arguments)
*/
using System;
class SpareClass
{
    public static int Calls;
    public static void Main() { Calls += 100; }
    public static int Main(string[] values) { Calls += 200; return 9; }
}
struct SpareStruct
{
    public static int Calls;
    public static void Main() { Calls += 300; }
    public static int Main(string[] values) { Calls += 400; return 17; }
}
class Chosen
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static void Main(string[] arguments)
    {
        Check(SpareClass.Calls == 0, "unselected-class-overloads");
        Check(SpareStruct.Calls == 0, "unselected-struct-overloads");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
