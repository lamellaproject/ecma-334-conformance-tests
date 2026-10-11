/*
Rules: E12-8-7-1-class-variable-field
Authority: ECMA-334 7th ed 12.8.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Touch(ref receiver.value);
Into: Touch(ref copy);
*/
using System;
class Worker { public int value = 3; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Touch(ref int value) { value++; }
    static void Main()
    {
        Worker receiver = new Worker();
        int copy = receiver.value;
        Touch(ref receiver.value);
        Check(receiver.value == 4, "class-instance-field-member-access-refers-to-field-variable");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
