/*
Rules: E15-8-1-event-attributes; E15-8-1-grammar-add-accessor-declaration; E15-8-1-grammar-remove-accessor-declaration
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: [Mark(17)]
Into: [Mark(18)]
*/
using System;
class MarkAttribute : Attribute { public int Code; public MarkAttribute(int code) { Code = code; } }
class Source
{
    [Mark(17)] public event Action Signal
    {
        [Mark(23)] add { }
        [Mark(29)] remove { }
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool HasCode(object[] attrs, int code) { return attrs.Length == 1 && ((MarkAttribute)attrs[0]).Code == code; }
    static void Main()
    {
        System.Reflection.EventInfo signal = typeof(Source).GetEvent("Signal");
        Check(HasCode(signal.GetCustomAttributes(typeof(MarkAttribute), false), 17), "event-attribute");
        Check(HasCode(signal.GetAddMethod().GetCustomAttributes(typeof(MarkAttribute), false), 23), "add-attribute");
        Check(HasCode(signal.GetRemoveMethod().GetCustomAttributes(typeof(MarkAttribute), false), 29), "remove-attribute");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
