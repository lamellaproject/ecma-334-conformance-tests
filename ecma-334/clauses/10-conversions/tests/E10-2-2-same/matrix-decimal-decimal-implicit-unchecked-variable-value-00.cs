/*
Rules: E10-2-2-same
Authority: ECMA-334 7th ed 10.2.2
Version: 7.3
Expected: run
Stdout: OK 9
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
            decimal input = -79228162514264337593543950335m;
            decimal result = unchecked(input);
            Check(result==-79228162514264337593543950335m, "decimal-decimal-implicit-unchecked-variable-0");
        }
        {
            decimal input = 79228162514264337593543950335m;
            decimal result = unchecked(input);
            Check(result==79228162514264337593543950335m, "decimal-decimal-implicit-unchecked-variable-1");
        }
        {
            decimal input = 0m;
            decimal result = unchecked(input);
            Check(result==0m, "decimal-decimal-implicit-unchecked-variable-2");
        }
        {
            decimal input = 1m;
            decimal result = unchecked(input);
            Check(result==1m, "decimal-decimal-implicit-unchecked-variable-3");
        }
        {
            decimal input = -1m;
            decimal result = unchecked(input);
            Check(result==-1m, "decimal-decimal-implicit-unchecked-variable-4");
        }
        {
            decimal input = 0.1m;
            decimal result = unchecked(input);
            Check(result==0.1m, "decimal-decimal-implicit-unchecked-variable-5");
        }
        {
            decimal input = -0.1m;
            decimal result = unchecked(input);
            Check(result==-0.1m, "decimal-decimal-implicit-unchecked-variable-6");
        }
        {
            decimal input = 1E-28m;
            decimal result = unchecked(input);
            Check(result==1E-28m, "decimal-decimal-implicit-unchecked-variable-7");
        }
        {
            decimal input = -1E-28m;
            decimal result = unchecked(input);
            Check(result==-1E-28m, "decimal-decimal-implicit-unchecked-variable-8");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
