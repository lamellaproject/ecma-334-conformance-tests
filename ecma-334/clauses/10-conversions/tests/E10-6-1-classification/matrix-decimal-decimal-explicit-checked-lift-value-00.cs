/*
Rules: E10-6-1-classification; E10-6-1-nonnull
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
            decimal? input = -79228162514264337593543950335m;
            decimal? result = checked((decimal?)input);
            Check(result.HasValue && result.Value==-79228162514264337593543950335m, "nullable-decimal-decimal-explicit-checked-lift-0");
        }
        {
            decimal? input = 79228162514264337593543950335m;
            decimal? result = checked((decimal?)input);
            Check(result.HasValue && result.Value==79228162514264337593543950335m, "nullable-decimal-decimal-explicit-checked-lift-1");
        }
        {
            decimal? input = 0m;
            decimal? result = checked((decimal?)input);
            Check(result.HasValue && result.Value==0m, "nullable-decimal-decimal-explicit-checked-lift-2");
        }
        {
            decimal? input = 1m;
            decimal? result = checked((decimal?)input);
            Check(result.HasValue && result.Value==1m, "nullable-decimal-decimal-explicit-checked-lift-3");
        }
        {
            decimal? input = -1m;
            decimal? result = checked((decimal?)input);
            Check(result.HasValue && result.Value==-1m, "nullable-decimal-decimal-explicit-checked-lift-4");
        }
        {
            decimal? input = 0.1m;
            decimal? result = checked((decimal?)input);
            Check(result.HasValue && result.Value==0.1m, "nullable-decimal-decimal-explicit-checked-lift-5");
        }
        {
            decimal? input = -0.1m;
            decimal? result = checked((decimal?)input);
            Check(result.HasValue && result.Value==-0.1m, "nullable-decimal-decimal-explicit-checked-lift-6");
        }
        {
            decimal? input = 1E-28m;
            decimal? result = checked((decimal?)input);
            Check(result.HasValue && result.Value==1E-28m, "nullable-decimal-decimal-explicit-checked-lift-7");
        }
        {
            decimal? input = -1E-28m;
            decimal? result = checked((decimal?)input);
            Check(result.HasValue && result.Value==-1E-28m, "nullable-decimal-decimal-explicit-checked-lift-8");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
