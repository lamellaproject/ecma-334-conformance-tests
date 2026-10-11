/*
Rules: E12-17-deconstruction-implicit-declarations; E12-17-deconstructing-tuple; E12-17-infer-deconstruction-type; E12-17-implicit-classification; E12-17-named-declaration-space
Authority: ECMA-334 7th ed 12.17
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: var (number, (text, wide))
Into: var (_, (text, wide))
*/
using System;
class Program
{
    static (int, (string, long)) Make() { return (23, ("word", 29L)); }
    static int Kind(int x) { return 1; } static int Kind(string x) { return 2; } static int Kind(long x) { return 3; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var (number, (text, wide)) = Make();
        Check(number == 23 && text == "word" && wide == 29L && Kind(number) == 1 && Kind(text) == 2 && Kind(wide) == 3, "deconstruction-designations-imply-declaration-expressions");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
