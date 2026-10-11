/*
Rules: E10-2-2-same; E12-23-numeric
Authority: ECMA-334 7th ed 10.2.2
Version: 7.3
Expected: run
Stdout: OK 4
Generated: clauses/10-conversions/generators/standard-matrices.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        {
            const decimal input = -79228162514264337593543950335m;
            decimal result = unchecked(input);
            Check(result==-79228162514264337593543950335m, "decimal-decimal-implicit-unchecked-constant-0");
        }
        {
            const decimal input = -1m;
            decimal result = unchecked(input);
            Check(result==-1m, "decimal-decimal-implicit-unchecked-constant-4");
        }
        {
            const decimal input = -0.1m;
            decimal result = unchecked(input);
            Check(result==-0.1m, "decimal-decimal-implicit-unchecked-constant-6");
        }
        {
            const decimal input = -1E-28m;
            decimal result = unchecked(input);
            Check(result==-1E-28m, "decimal-decimal-implicit-unchecked-constant-8");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
