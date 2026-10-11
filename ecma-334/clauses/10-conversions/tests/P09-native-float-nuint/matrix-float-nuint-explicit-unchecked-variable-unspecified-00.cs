/*
Rules: P09-native-float-nuint
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 4
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
            float input = -3.40282347e+38f;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                nuint result = unchecked((nuint)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "float-nuint-explicit-unchecked-False-0");
        }
        {
            float input = 3.40282347e+38f;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                nuint result = unchecked((nuint)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "float-nuint-explicit-unchecked-False-1");
        }
        {
            float input = -1.0f;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                nuint result = unchecked((nuint)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "float-nuint-explicit-unchecked-False-5");
        }
        {
            float input = 1.84467441e+19f;
            bool completed = false;
            try
            {
                // Every destination value is allowed; check only successful completion.
                nuint result = unchecked((nuint)input);
                completed = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(completed, "float-nuint-explicit-unchecked-False-11");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
