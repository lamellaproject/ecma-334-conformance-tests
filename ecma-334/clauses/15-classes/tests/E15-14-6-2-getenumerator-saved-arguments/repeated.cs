/*
Rules: E15-14-6-2-getenumerator-saved-arguments
Authority: ECMA-334 7th ed 15.14.6.2
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: value += 7;
Into: value = 7;
*/
using System;
using System.Collections;
using System.Collections.Generic;
class Program
{
    static int checks, failures;
    static IEnumerable<int> Sequence(int value) { value += 7; yield return value; value += 11; yield return value; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int argument = 13;
        IEnumerable<int> values = Sequence(argument);
        argument = 23;
        IEnumerator<int> first = values.GetEnumerator();
        Check(first.MoveNext() && first.Current == 20, "first-enumerator-initializes-from-saved-argument");
        Check(first.MoveNext() && first.Current == 31, "first-enumerator-can-modify-its-parameter");
        Check(!first.MoveNext(), "first-enumerator-argument-end");
        first.Dispose();
        IEnumerator second = ((IEnumerable)values).GetEnumerator();
        Check(second.MoveNext() && (int)second.Current == 20, "second-enumerator-restarts-from-original-argument");
        Check(second.MoveNext() && (int)second.Current == 31 && argument == 23, "second-enumerator-parameter-is-independent");
        Check(!second.MoveNext(), "second-enumerator-argument-end");
        ((IDisposable)second).Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
