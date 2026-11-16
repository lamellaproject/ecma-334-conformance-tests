/*
Rules: E12-8-4-syntax; E12-8-4-method-type-arguments; E12-8-4-local-reference
Authority: ECMA-334 7th ed 12.8.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int collected = Select<int>();
Into: int collected = Select<string>();
*/
using System;
class Program
{
    static int checks, failures;
    static int Select<T>() { return typeof(T) == typeof(int) ? 16 : 40; }
    static void Check(bool condition, string label)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + label); }
    }
    static int Main()
    {
        int collected = Select<int>();
        {
            int Select = 6;
            collected += Select;
        }
        Check(collected == 22, "type-argument-name-outside-full-name-invariance");
        Check(Select<long>() == 40, "generic-name-still-denotes-method");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
