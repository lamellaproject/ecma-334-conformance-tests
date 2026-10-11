/*
Rules: E9-4-4-20-yield-expression-entry; E9-4-4-20-yield-return-end
Authority: ECMA-334 7th ed 9.4.4.20
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: yield return (cell = 64);
Into: yield return 64;
*/
using System;
using System.Collections.Generic;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static IEnumerable<int> Values()
    {
        int cell;
        yield return (cell = 64);
        yield return cell;
        yield break;
    }
    static void Main()
    {
        IEnumerator<int> iterator = Values().GetEnumerator();
        Check(iterator.MoveNext() && iterator.Current == 64, "assignment-in-yield-expression");
        Check(iterator.MoveNext() && iterator.Current == 64, "assignment-after-yield-statement");
        Check(!iterator.MoveNext(), "yield-break-completes-iterator");
        iterator.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
