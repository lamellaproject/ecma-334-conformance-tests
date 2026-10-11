/*
Rules: E12-10-5-decimal-scale; E12-10-5-decimal-predefined; E12-10-5-decimal-equivalence; E12-10-5-decimal-overflow
Authority: ECMA-334 7th ed 12.10.5
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: System.Decimal r = x + y;
Into: System.Decimal r = x - y;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Scale(decimal x) { return (Decimal.GetBits(x)[3] >> 16) & 255; }
    static void Main()
    {
        decimal x = 1.20M, y = 0.003M; System.Decimal r = x + y;
        Check(r == 1.203M && Scale(r) == 3, "larger-right-scale");
        Check(r == Decimal.Add(x, y), "decimal-operation-equivalence");
        x = -1.200M; y = 0.03M; r = x + y; Check(r == -1.170M && Scale(r) == 3, "larger-left-scale");
        x = decimal.MaxValue; y = 1M; bool overflow = false;
        try { r = unchecked(x + y); } catch (OverflowException) { overflow = true; } catch (Exception) { }
        Check(overflow, "unchecked-still-throws");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
