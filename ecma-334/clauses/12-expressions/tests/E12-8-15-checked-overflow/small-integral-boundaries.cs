/*
Rules: E12-8-15-checked-overflow
Authority: ECMA-334 7th ed 12.8.15
Version: 7.3
Expected: run
Stdout: OK 16
Mutate: checked { a++; }
Into: unchecked { a++; }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        bool threw = false;
        sbyte a = sbyte.MaxValue;
        try { checked { a++; } } catch (OverflowException) { threw = true; } catch (Exception) { }
        Check(threw, "sbyte-increment-overflow"); Check(a == sbyte.MaxValue, "sbyte-increment-no-store");
        a = sbyte.MinValue; threw = false;
        try { checked { a--; } } catch (OverflowException) { threw = true; } catch (Exception) { }
        Check(threw, "sbyte-decrement-overflow"); Check(a == sbyte.MinValue, "sbyte-decrement-no-store");
        byte b = byte.MaxValue; threw = false;
        try { checked { b++; } } catch (OverflowException) { threw = true; } catch (Exception) { }
        Check(threw, "byte-increment-overflow"); Check(b == byte.MaxValue, "byte-increment-no-store");
        b = 0; threw = false;
        try { checked { b--; } } catch (OverflowException) { threw = true; } catch (Exception) { }
        Check(threw, "byte-decrement-overflow"); Check(b == 0, "byte-decrement-no-store");
        short c = short.MaxValue; threw = false;
        try { checked { c++; } } catch (OverflowException) { threw = true; } catch (Exception) { }
        Check(threw, "short-increment-overflow"); Check(c == short.MaxValue, "short-increment-no-store");
        c = short.MinValue; threw = false;
        try { checked { c--; } } catch (OverflowException) { threw = true; } catch (Exception) { }
        Check(threw, "short-decrement-overflow"); Check(c == short.MinValue, "short-decrement-no-store");
        ushort d = ushort.MaxValue; threw = false;
        try { checked { d++; } } catch (OverflowException) { threw = true; } catch (Exception) { }
        Check(threw, "ushort-increment-overflow"); Check(d == ushort.MaxValue, "ushort-increment-no-store");
        d = 0; threw = false;
        try { checked { d--; } } catch (OverflowException) { threw = true; } catch (Exception) { }
        Check(threw, "ushort-decrement-overflow"); Check(d == 0, "ushort-decrement-no-store");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
