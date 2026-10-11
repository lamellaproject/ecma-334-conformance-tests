/*
Rules: E7-4-4-enum-members
Authority: ECMA-334 7th ed 7.4.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: enum Label
Into: class Label
*/
using System;
enum Label { Low = 17, High = 23 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Label value = Label.Low;
        Check((int)value == 17 && value.CompareTo(Label.High) < 0, "enum-constant-and-enum-member");
        Check(value.Equals(Label.Low), "enum-equality-member");
        Check(value.GetType() == typeof(Label) && typeof(Label).BaseType == typeof(Enum), "enum-object-member-and-base");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
