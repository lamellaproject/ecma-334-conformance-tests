/*
Rules: E6-3-3-single-line-delimiters-ordinary
Authority: ECMA-334 7th ed 6.3.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: // amount = 86; /*
Into: amount = 86; // /*
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int amount = 15;
        // amount = 86; /*
        // */ amount = 93;
        Check(amount == 15, "block-markers-are-line-comment-text");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
