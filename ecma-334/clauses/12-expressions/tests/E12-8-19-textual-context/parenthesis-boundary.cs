/*
Rules: E12-8-19-textual-context
Authority: ECMA-334 7th ed 12.8.19
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: checked(peak - 3) + 4
Into: checked(peak - 3 + 4)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int peak = int.MaxValue;
        bool directOverflow = false, nestedOverflow = false, wrongException = false;
        int direct = 0, nested = 0;
        try { direct = peak + 1; }
        catch (OverflowException) { directOverflow = true; }
        catch (Exception) { wrongException = true; }
        try { nested = checked(peak - 3) + 4; }
        catch (OverflowException) { nestedOverflow = true; }
        catch (Exception) { wrongException = true; }
        bool same = directOverflow == nestedOverflow && (directOverflow || direct == nested);
        Check(!wrongException && same, "operation-outside-checked-parentheses");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
