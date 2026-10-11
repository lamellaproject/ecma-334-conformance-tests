/*
Rules: P09-native-float-nint
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 3
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
            const float input = -3.40282347e+38f;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                nint result = unchecked((nint)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "float-nint-explicit-unchecked-True-0");
        }
        {
            const float input = 3.40282347e+38f;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                nint result = unchecked((nint)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "float-nint-explicit-unchecked-True-1");
        }
        {
            const float input = 9.22337204e+18f;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                nint result = unchecked((nint)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "float-nint-explicit-unchecked-True-12");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
