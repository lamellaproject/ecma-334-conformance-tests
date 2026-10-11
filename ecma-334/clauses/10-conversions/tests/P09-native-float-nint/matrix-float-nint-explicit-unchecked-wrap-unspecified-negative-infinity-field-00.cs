/*
Rules: P09-native-float-nint; P09-native-nullable-wrap
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 1
Generated: clauses/10-conversions/generators/native-matrices.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        {
            float input = float.NegativeInfinity;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                nint? result = unchecked((nint?)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "float-nint-explicit-unchecked-wrap-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
