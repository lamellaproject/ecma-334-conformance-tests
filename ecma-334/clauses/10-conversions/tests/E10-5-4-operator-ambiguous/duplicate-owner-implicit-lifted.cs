/*
Rules: E10-5-4-operator-ambiguous
Authority: ECMA-334 7th ed 10.5.4
Version: 7.3
Expected: reject
Generated: clauses/10-conversions/generators/standard-matrices.py
*/
using System;
struct First { public static implicit operator Second(First x) { return new Second(); } }
struct Second { public static implicit operator Second(First x) { return new Second(); } }
class Program
{
    static void Main()
    {
        First? input = new First(); Second? result = input;
    }
}
