/*
Rules: E15-14-2-nongeneric-enumerator-interface
Authority: ECMA-334 7th ed 15.14.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: yield return 13;
Into: yield break;
*/
using System;
using System.Collections;
class Program
{
    static int checks, failures;
    static IEnumerator Sequence() { yield return 13; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IEnumerator e = Sequence();
        Check(e.MoveNext(), "nongeneric-enumerator-has-value");
        Check((int)e.Current == 13, "nongeneric-enumerator-value");
        Check(!e.MoveNext(), "nongeneric-enumerator-end");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
