/*
Rules: E10-2-2-same; E10-2-2-no-effect; E10-2-1-categories
Authority: ECMA-334 7th ed 10.2.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int same = input;
Into: int same = 0;
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int input = Environment.ExitCode + 37;
        int same = input;
        object token = new object(); object copy = token;
        Check(same == 37 && ReferenceEquals(token, copy), "E10-2-2-same-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
