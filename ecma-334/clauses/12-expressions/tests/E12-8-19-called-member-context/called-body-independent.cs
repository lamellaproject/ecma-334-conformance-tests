/*
Rules: E12-8-19-called-member-context
Authority: ECMA-334 7th ed 12.8.19
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: checked(Add(peak, step))
Into: checked(peak + step)
*/
using System;
class Program
{
    static int Add(int left, int right) { return left + right; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int peak = int.MaxValue, step = 1, direct = 0, enclosed = 0;
        bool directOverflow = false, enclosedOverflow = false, wrongException = false;
        try { direct = Add(peak, step); }
        catch (OverflowException) { directOverflow = true; }
        catch (Exception) { wrongException = true; }
        try { enclosed = checked(Add(peak, step)); }
        catch (OverflowException) { enclosedOverflow = true; }
        catch (Exception) { wrongException = true; }
        bool same = directOverflow == enclosedOverflow && (directOverflow || direct == enclosed);
        Check(!wrongException && same, "called-body-keeps-default-context");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
