/*
Rules: E23-7-string-initializer-pins
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: fixed (char* pointer = text)
Into: fixed (char* pointer = other)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        string text = new string(new char[] { 'r', 'e', 'e', 'd' });
        string other = new string(new char[] { 's', 'e', 'e', 'd' });
        fixed (char* pointer = text)
        {
            GC.Collect(2, GCCollectionMode.Forced, true, true);
            fixed (char* after = text) Check(pointer == after, "string-address-after-collection");
            Check(pointer[0] == 'r' && pointer[3] == 'd', "pinned-string-values");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
