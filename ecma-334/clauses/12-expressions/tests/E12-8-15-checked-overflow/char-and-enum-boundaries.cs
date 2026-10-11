/*
Rules: E12-8-15-checked-overflow
Authority: ECMA-334 7th ed 12.8.15
Version: 7.3
Expected: run
Stdout: OK 8
Mutate: checked { a++; }
Into: unchecked { a++; }
*/
using System;
enum Tone : byte { Bottom = 0, Top = 255 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        char a = char.MaxValue; bool threw = false;
        try { checked { a++; } } catch (OverflowException) { threw = true; } catch (Exception) { }
        Check(threw, "char-increment-overflow"); Check(a == char.MaxValue, "char-increment-no-store");
        a = char.MinValue; threw = false;
        try { checked { a--; } } catch (OverflowException) { threw = true; } catch (Exception) { }
        Check(threw, "char-decrement-overflow"); Check(a == char.MinValue, "char-decrement-no-store");
        Tone b = Tone.Top; threw = false;
        try { checked { b++; } } catch (OverflowException) { threw = true; } catch (Exception) { }
        Check(threw, "enum-increment-overflow"); Check(b == Tone.Top, "enum-increment-no-store");
        b = Tone.Bottom; threw = false;
        try { checked { b--; } } catch (OverflowException) { threw = true; } catch (Exception) { }
        Check(threw, "enum-decrement-overflow"); Check(b == Tone.Bottom, "enum-decrement-no-store");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
