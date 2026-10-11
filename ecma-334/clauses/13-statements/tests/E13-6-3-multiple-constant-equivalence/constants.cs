/*
Rules: E13-6-3-multiple-constant-equivalence; E13-6-3-form-constant-declaration; E13-6-3-form-constant-list; E13-6-3-form-constant-declarator; E13-6-3-constant-declared-type; E13-6-3-constant-declarator-value; E13-6-3-constant-value-name; E13-6-1-form-constant-declaration
Authority: ECMA-334 7th ed 13.6.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: const long first = 2, second = first + 3;
Into: const long first = 3, second = first + 3;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Kind(int n) { return 1; }
    static int Kind(long n) { return 2; }
    static void Main()
    {
        const long first = 2, second = first + 3;
        const long separateFirst = 2;
        const long separateSecond = separateFirst + 3;
        Check(first == separateFirst && second == separateSecond && second == 5, "multiple-constant-values");
        Check(Kind(first) == 2 && Kind(second) == 2, "constants-have-declared-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
