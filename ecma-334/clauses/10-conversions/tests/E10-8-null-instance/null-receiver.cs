/*
Rules: E10-8-null-instance
Authority: ECMA-334 7th ed 10.8
Version: 7.3
Expected: run
Stdout: OK 1
Version-Witness: version-witnesses/null-receiver-6112aacd1c.cs.part
Mutate: receiver.Touch
Into: new Receiver().Touch
*/
using System;
class Receiver { public void Touch() { } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Receiver receiver = null;
        try
        {
            Action converted = receiver.Touch;
            Check(false, "null-receiver/required-exception");
        }
        catch (NullReferenceException)
        {
            Check(true, "null-receiver/required-exception");
        }
        catch (Exception error)
        {
            Check(false, "null-receiver/exception-type");
            Console.WriteLine("EXCEPTION " + error.GetType().FullName);
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
