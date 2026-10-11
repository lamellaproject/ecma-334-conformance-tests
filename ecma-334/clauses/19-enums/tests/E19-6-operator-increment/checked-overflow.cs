/*
Rules: E19-6-operator-increment; E19-6-operator-decrement
Authority: ECMA-334 7th ed 19.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: checked { high++; }
Into: unchecked { high++; }
*/
using System;
enum Code : byte { Low = 0, High = 255 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Code high = Code.High; bool overflowHigh = false;
        try { checked { high++; } }
        catch (OverflowException) { overflowHigh = true; }
        catch (Exception) { }
        Check(overflowHigh && high == Code.High, "increment-overflow-no-store");
        Code low = Code.Low; bool overflowLow = false;
        try { checked { --low; } }
        catch (OverflowException) { overflowLow = true; }
        catch (Exception) { }
        Check(overflowLow && low == Code.Low, "decrement-overflow-no-store");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
