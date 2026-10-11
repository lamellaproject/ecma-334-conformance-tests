/*
Rules: E10-6-1-no-implicit-unwrap
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: reject
Generated: clauses/10-conversions/generators/standard-matrices.py
*/
using System;
class Program
{
    static void Main()
    {
        double? input = null;
        long result = input;
    }
}
