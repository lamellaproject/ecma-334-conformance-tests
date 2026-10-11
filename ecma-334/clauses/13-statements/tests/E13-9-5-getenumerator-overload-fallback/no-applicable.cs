/*
Rules: E13-9-5-getenumerator-overload-fallback
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public IEnumerator GetEnumerator(int required)
Into: public IEnumerator GetEnumerator()
*/
using System;
using System.Collections;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    class Source : IEnumerable
    {
        public IEnumerator GetEnumerator(int required) { throw new Exception(); }
        IEnumerator IEnumerable.GetEnumerator() { return new int[] { 23 }.GetEnumerator(); }
    }
    static void Main()
    {
        int total = 0;
        foreach (int item in new Source()) { total += item; }
        Check(total == 23, "required-argument-falls-back");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
