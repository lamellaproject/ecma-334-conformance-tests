/*
Rules: E10-6-1-classification; E10-6-1-wrap
Authority: ECMA-334 7th ed 10.6.1
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
            decimal? result = unchecked(input);
            Check(result.HasValue && result.Value==-79228162514264337593543950335m, "nullable-decimal-decimal-implicit-unchecked-wrap-0");
        }
        {
            decimal input = 79228162514264337593543950335m;
            decimal? result = unchecked(input);
            Check(result.HasValue && result.Value==79228162514264337593543950335m, "nullable-decimal-decimal-implicit-unchecked-wrap-1");
        }
        {
            decimal input = 0m;
            decimal? result = unchecked(input);
            Check(result.HasValue && result.Value==0m, "nullable-decimal-decimal-implicit-unchecked-wrap-2");
        }
        {
            decimal input = 1m;
            decimal? result = unchecked(input);
            Check(result.HasValue && result.Value==1m, "nullable-decimal-decimal-implicit-unchecked-wrap-3");
        }
        {
            decimal input = -1m;
            decimal? result = unchecked(input);
            Check(result.HasValue && result.Value==-1m, "nullable-decimal-decimal-implicit-unchecked-wrap-4");
        }
        {
            decimal input = 0.1m;
            decimal? result = unchecked(input);
            Check(result.HasValue && result.Value==0.1m, "nullable-decimal-decimal-implicit-unchecked-wrap-5");
        }
        {
            decimal input = -0.1m;
            decimal? result = unchecked(input);
            Check(result.HasValue && result.Value==-0.1m, "nullable-decimal-decimal-implicit-unchecked-wrap-6");
        }
        {
            decimal input = 1E-28m;
            decimal? result = unchecked(input);
            Check(result.HasValue && result.Value==1E-28m, "nullable-decimal-decimal-implicit-unchecked-wrap-7");
        }
        {
            decimal input = -1E-28m;
            decimal? result = unchecked(input);
            Check(result.HasValue && result.Value==-1E-28m, "nullable-decimal-decimal-implicit-unchecked-wrap-8");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
