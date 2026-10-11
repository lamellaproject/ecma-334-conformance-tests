/*
Rules: E9-2-9-scope-suspension; E9-2-9-local-lifetime-minimum
Authority: ECMA-334 7th ed 9.2.9
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: int cell = 19;
Into: int cell = 0;
*/
using System;
using System.Collections.Generic;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static IEnumerable<int> Values()
    {
        int cell = 19;
        yield return cell;
        cell += 8;
        yield return cell;
    }
    static void Main()
    {
        IEnumerator<int> iterator = Values().GetEnumerator();
        bool first = iterator.MoveNext();
        Check(first && iterator.Current == 19, "local-before-suspension");
        int unrelated = 300;
        unrelated++;
        bool second = iterator.MoveNext();
        Check(second && iterator.Current == 27, "local-after-suspension");
        Check(unrelated == 301, "caller-storage-independent");
        Check(!iterator.MoveNext(), "iterator-scope-ended");
        iterator.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
