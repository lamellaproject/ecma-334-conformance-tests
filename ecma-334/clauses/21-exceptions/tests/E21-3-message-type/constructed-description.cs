/*
Rules: E21-3-message-type; E21-3-message-description; E21-3-constructor-message
Authority: ECMA-334 7th ed 21.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: new Exception("the divisor cannot be zero")
Into: new Exception("another reason")
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Exception fault = new Exception("the divisor cannot be zero");
        string message = fault.Message;
        Check(message == "the divisor cannot be zero", "specified-string-description");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
