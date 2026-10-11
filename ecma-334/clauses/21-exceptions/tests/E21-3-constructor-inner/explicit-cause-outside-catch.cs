/*
Rules: E21-3-constructor-inner; E21-3-inner-cause; E21-3-inner-type
Authority: ECMA-334 7th ed 21.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: new Exception("wrapper", original)
Into: new Exception("wrapper", null)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Exception original = new Exception("cause");
        // 21.3, p. 525: "The value of these properties can be specified in calls to the
        // instance constructor for System.Exception."
        Exception wrapper = new Exception("wrapper", original);
        Exception inner = wrapper.InnerException;
        Check(inner == original, "constructor-explicit-cause-outside-catch");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
