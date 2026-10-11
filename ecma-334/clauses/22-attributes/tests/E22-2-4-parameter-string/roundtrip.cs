/*
Rules: E22-2-4-parameter-string
Authority: ECMA-334 7th ed 22.2.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [Mark("cedar")]
Into: [Mark("fir")]
*/
using System;
class MarkAttribute : Attribute { public string Value; public MarkAttribute(string value) { Value = value; } }
[Mark("cedar")] class Item { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string value = ((MarkAttribute)Attribute.GetCustomAttribute(typeof(Item), typeof(MarkAttribute))).Value;
        Check(value == "cedar", "string-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
