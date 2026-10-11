/*
Rules: E7-4-5-string-alias-members
Authority: ECMA-334 7th ed 7.4.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: string value = "leaf";
Into: object value = "leaf";
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string value = "leaf";
        Check(value.Length == 4 && value.GetType() == typeof(System.String), "string-instance-members");
        Check(string.Empty == System.String.Empty, "string-static-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
