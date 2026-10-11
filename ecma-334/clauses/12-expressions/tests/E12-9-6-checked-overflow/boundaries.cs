/*
Rules: E12-9-6-checked-overflow
Authority: ECMA-334 7th ed 12.9.6
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: checked(++b)
Into: unchecked(++b)
*/
using System;
enum Small : byte { Max = 255 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        byte b = byte.MaxValue; int i = int.MinValue; Small e = Small.Max; char c = char.MinValue;
        bool cb = false, ci = false, ce = false, cc = false;
        try { byte v = checked(++b); } catch (OverflowException) { cb = true; } catch (Exception) { }
        try { int v = checked(--i); } catch (OverflowException) { ci = true; } catch (Exception) { }
        try { Small v = checked(++e); } catch (OverflowException) { ce = true; } catch (Exception) { }
        try { char v = checked(--c); } catch (OverflowException) { cc = true; } catch (Exception) { }
        Check(cb && b == byte.MaxValue, "byte-no-store-on-throw"); Check(ci && i == int.MinValue, "int-no-store-on-throw");
        Check(ce && e == Small.Max, "enum-no-store-on-throw"); Check(cc && c == char.MinValue, "char-no-store-on-throw");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
