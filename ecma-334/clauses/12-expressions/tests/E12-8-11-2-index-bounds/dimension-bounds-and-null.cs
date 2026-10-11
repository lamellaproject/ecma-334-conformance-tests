/*
Rules: E12-8-11-2-index-bounds; E12-8-11-2-index-out-of-range; E12-8-11-2-array-null
Authority: ECMA-334 7th ed 12.8.11.2
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: values[2, 0]
Into: values[1, 0]
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[,] values = new int[2, 3];
        bool caught = false;
        try { int result = values[2, 0]; } catch (IndexOutOfRangeException) { caught = true; } catch (Exception) { }
        Check(caught, "first-dimension-upper-bound");
        caught = false;
        try { int result = values[0, 3]; } catch (IndexOutOfRangeException) { caught = true; } catch (Exception) { }
        Check(caught, "second-dimension-upper-bound");
        caught = false;
        try { int result = values[0, -1]; } catch (IndexOutOfRangeException) { caught = true; } catch (Exception) { }
        Check(caught, "negative-index-below-bound");
        values = null; caught = false;
        try { int result = values[-1, 99]; } catch (NullReferenceException) { caught = true; } catch (Exception) { }
        Check(caught, "null-array-preempts-bounds-failure");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
