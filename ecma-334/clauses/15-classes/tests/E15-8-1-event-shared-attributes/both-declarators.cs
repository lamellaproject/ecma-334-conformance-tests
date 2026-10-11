/*
Rules: E15-8-1-event-shared-attributes
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: [Mark(31)]
Into: [Mark(32)]
*/
using System;
class MarkAttribute : Attribute { public int Code; public MarkAttribute(int code) { Code = code; } }
class Source { [Mark(31)] public event Action East, West; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool HasCode(string name)
    {
        object[] attrs = typeof(Source).GetEvent(name).GetCustomAttributes(typeof(MarkAttribute), false);
        return attrs.Length == 1 && ((MarkAttribute)attrs[0]).Code == 31;
    }
    static void Main()
    {
        Check(HasCode("East"), "first-declarator-attribute");
        Check(HasCode("West"), "second-declarator-attribute");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
