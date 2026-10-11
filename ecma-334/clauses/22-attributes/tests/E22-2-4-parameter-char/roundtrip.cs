/*
Rules: E22-2-4-parameter-char
Authority: ECMA-334 7th ed 22.2.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [Mark('R')]
Into: [Mark('S')]
*/
using System;
class MarkAttribute : Attribute { public char Value; public MarkAttribute(char value) { Value = value; } }
[Mark('R')] class Item { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        char value = ((MarkAttribute)Attribute.GetCustomAttribute(typeof(Item), typeof(MarkAttribute))).Value;
        Check(value == 'R', "char-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
