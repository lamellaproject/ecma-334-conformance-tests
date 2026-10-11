/*
Rules: E12-8-19-lexical
Authority: ECMA-334 7th ed 12.8.19
Version: 7.3
Expected: run
Stdout: OK 4
Version-Witness: version-witnesses/anonymous-body-context-a235740c72.cs.part
Mutate: operation = () => peak + step;
Into: operation = Capture(peak + step);
*/
using System;
class Program
{
    delegate int Operation();
    static Operation Capture(int value) { return () => value; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int peak = int.MaxValue, step = 1, direct = 0, result = 0;
        bool defaultOverflow = false, creationException = false, invocationOverflow = false;
        bool directWrongException = false, invocationWrongException = false;
        try { direct = peak + step; }
        catch (OverflowException) { defaultOverflow = true; }
        catch (Exception) { directWrongException = true; }
        Operation operation = () => 0;
        try
        {
            checked
            {
                operation = () => peak + step;
            }
        }
        catch (Exception) { creationException = true; }
        try { result = operation(); }
        catch (OverflowException) { invocationOverflow = true; }
        catch (Exception) { invocationWrongException = true; }
        Check(!directWrongException, "default-reference-exception");
        Check(!creationException, "anonymous-creation");
        Check(!invocationWrongException && invocationOverflow == defaultOverflow, "anonymous-body-overflow-context");
        Check(defaultOverflow || result == direct, "anonymous-body-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
