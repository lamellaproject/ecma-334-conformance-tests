/*
Rules: E12-19-1-body-null-conditional; E12-19-1-body-null-conditional-priority
Authority: ECMA-334 7th ed 12.19.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: () => receiver?.Touch(Argument())
Into: () => receiver.Touch(Argument())
*/
using System;
delegate void Invoke();
class Receiver { public void Touch(int value) { Program.Trace += "M"; } }
class Program
{
    public static string Trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Argument() { Trace += "A"; return 43; }
    static void Main()
    {
        Receiver receiver = null;
        Invoke function = () => receiver?.Touch(Argument());
        function();
        Check(Trace == "", "null-body-skips-argument-and-invocation");
        receiver = new Receiver();
        function();
        Check(Trace == "AM", "null-conditional-invocation-body-void-call");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
