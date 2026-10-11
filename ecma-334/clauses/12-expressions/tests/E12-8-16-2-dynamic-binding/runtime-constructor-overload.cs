/*
Rules: E12-8-16-2-dynamic-binding; E12-8-16-2-dynamic-runtime-types; E12-8-16-2-dynamic-static-type
Authority: ECMA-334 7th ed 12.8.16.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: new Choice(argument)
Into: new Choice((object)argument)
*/
using System;
public class Choice
{
    public int Selected;
    public Choice(int number) { Selected = 1; }
    public Choice(string text) { Selected = 2; }
    public Choice(object value) { Selected = 3; }
}
class Program
{
    static int Choose(Choice value) { return 1; }
    static int Choose(object value) { return 2; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic argument = 12;
        var number = new Choice(argument);
        argument = "word";
        var text = new Choice((dynamic)argument);
        Check(number.Selected == 1, "runtime-int-constructor");
        Check(text.Selected == 2, "runtime-string-constructor");
        Check(Choose(number) == 1, "dynamic-creation-keeps-static-created-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
