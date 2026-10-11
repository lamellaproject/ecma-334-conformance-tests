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
        int a = int.MaxValue;
        try { checked { a++; } } catch (OverflowException) { threw = true; } catch (Exception) { }
        Check(threw, "int-increment-overflow"); Check(a == int.MaxValue, "int-increment-no-store");
        a = int.MinValue; threw = false;
        try { checked { a--; } } catch (OverflowException) { threw = true; } catch (Exception) { }
        Check(threw, "int-decrement-overflow"); Check(a == int.MinValue, "int-decrement-no-store");
        uint b = uint.MaxValue; threw = false;
        try { checked { b++; } } catch (OverflowException) { threw = true; } catch (Exception) { }
        Check(threw, "uint-increment-overflow"); Check(b == uint.MaxValue, "uint-increment-no-store");
        b = 0; threw = false;
        try { checked { b--; } } catch (OverflowException) { threw = true; } catch (Exception) { }
        Check(threw, "uint-decrement-overflow"); Check(b == 0, "uint-decrement-no-store");
        long c = long.MaxValue; threw = false;
        try { checked { c++; } } catch (OverflowException) { threw = true; } catch (Exception) { }
        Check(threw, "long-increment-overflow"); Check(c == long.MaxValue, "long-increment-no-store");
        c = long.MinValue; threw = false;
        try { checked { c--; } } catch (OverflowException) { threw = true; } catch (Exception) { }
        Check(threw, "long-decrement-overflow"); Check(c == long.MinValue, "long-decrement-no-store");
        ulong d = ulong.MaxValue; threw = false;
        try { checked { d++; } } catch (OverflowException) { threw = true; } catch (Exception) { }
        Check(threw, "ulong-increment-overflow"); Check(d == ulong.MaxValue, "ulong-increment-no-store");
        d = 0; threw = false;
        try { checked { d--; } } catch (OverflowException) { threw = true; } catch (Exception) { }
        Check(threw, "ulong-decrement-overflow"); Check(d == 0, "ulong-decrement-no-store");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
