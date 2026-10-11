/*
Rules: P09-native-nuint-float; P09-native-nullable-unwrap
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
            nuint? input = null;
            bool threw = false;
            try
            {
                float result = unchecked((float)input);
            }
            catch (InvalidOperationException)
            {
                threw = true;
            }
            catch (Exception error)
            {
                Console.WriteLine("EXCEPTION " + error.GetType().FullName);
            }
            Check(threw, "nuint-float-explicit-unchecked-null-unwrap");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
