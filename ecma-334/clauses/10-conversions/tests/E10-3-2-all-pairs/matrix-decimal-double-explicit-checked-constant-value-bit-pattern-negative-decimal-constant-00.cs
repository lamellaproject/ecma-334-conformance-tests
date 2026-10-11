/*
Rules: E10-3-2-all-pairs; E10-3-2-decimal; E12-23-numeric
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 7
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
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14262900019882360832UL, "decimal-double-explicit-checked-constant-0");
        }
        {
            const decimal input = -1m;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==13830554455654793216UL, "decimal-double-explicit-checked-constant-4");
        }
        {
            const decimal input = -0.1m;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==13815242216921733530UL, "decimal-double-explicit-checked-constant-6");
        }
        {
            const decimal input = -1E-28m;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==13411632789134008345UL, "decimal-double-explicit-checked-constant-8");
        }
        {
            const decimal input = -9007199254740993m;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14069245235905429504UL, "decimal-double-explicit-checked-constant-12");
        }
        {
            const decimal input = -9007199254740992m;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14069245235905429504UL, "decimal-double-explicit-checked-constant-13");
        }
        {
            const decimal input = -9007199254740991m;
            double result = checked((double)input);
            Check(unchecked((ulong)BitConverter.DoubleToInt64Bits(result))==14069245235905429503UL, "decimal-double-explicit-checked-constant-14");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
