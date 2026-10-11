/*
Rules: E6-2-5-generic-identifier-keywords
Authority: ECMA-334 7th ed 6.2.5
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: input is Crate<int> matched
Into: input is Crate<string> matched
*/
using System;
class Crate<T> { public int Number = 16; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool Make(out Crate<int> result) { result = new Crate<int>(); return true; }
    static void Main()
    {
        object input = new Crate<int>();
        Check(input is Crate<int> matched && matched.Number == 16, "identifier-after-is-type");
        int selected = 0;
        switch (input) { case Crate<int> found: selected = found.Number; break; }
        Check(selected == 16, "identifier-after-case-type");
        bool made = Make(out Crate<int> output);
        Check(made && output.Number == 16, "identifier-after-out-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
