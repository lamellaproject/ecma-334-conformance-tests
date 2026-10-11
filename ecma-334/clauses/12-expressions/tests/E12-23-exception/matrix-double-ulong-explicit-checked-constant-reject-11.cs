/*
Rules: E12-23-exception
Authority: ECMA-334 7th ed 12.23
Version: 7.3
Expected: reject
Generated: clauses/10-conversions/generators/standard-matrices.py
*/
using System;
class Program
{
    static void Main()
    {
        const double input = 1.8446744073709552e+19d;
        ulong result = checked((ulong)input);
    }
}
