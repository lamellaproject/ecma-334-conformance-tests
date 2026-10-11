/*
Rules: E12-8-15-predefined-increment-types; E12-8-15-predefined-decrement-types; E12-8-15-increment-value; E12-8-15-decrement-value; E12-8-15-result-type
Authority: ECMA-334 7th ed 12.8.15
Version: 7.3
Expected: run
Stdout: OK 12
Mutate: char sa = a++;
Into: char sa = a--;
*/
using System;
enum Tone : byte { Low = 4, High = 5 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        char a = 'd'; char sa = a++;
        Check(sa == 'd', "char-increment-old-value"); Check(a == 'e', "char-increment-new-value");
        sa = a--;
        Check(sa == 'e', "char-decrement-old-value"); Check(a == 'd', "char-decrement-new-value");
        decimal b = 4.5M; decimal sb = b++;
        Check(sb == 4.5M, "decimal-increment-old-value"); Check(b == 5.5M, "decimal-increment-new-value");
        sb = b--;
        Check(sb == 5.5M, "decimal-decrement-old-value"); Check(b == 4.5M, "decimal-decrement-new-value");
        Tone c = Tone.Low; Tone sc = c++;
        Check(sc == Tone.Low, "enum-increment-old-value"); Check(c == Tone.High, "enum-increment-new-value");
        sc = c--;
        Check(sc == Tone.High, "enum-decrement-old-value"); Check(c == Tone.Low, "enum-decrement-new-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
