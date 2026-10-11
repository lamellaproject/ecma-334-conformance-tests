/*
Rules: E9-3-reference-default
Authority: ECMA-334 7th ed 9.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: static object shared;
Into: static object shared = new object();
*/
using System;
class Holder { public string Text; public Action Callback; }
class Program
{
    static int checks, failures;
    static object shared;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder holder = new Holder();
        Check(shared == null, "static-reference-null");
        Check(holder.Text == null, "instance-string-null");
        Check(holder.Callback == null, "instance-delegate-null");
        object[] elements = new object[2];
        Check(elements[0] == null && elements[1] == null, "array-reference-elements-null");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
