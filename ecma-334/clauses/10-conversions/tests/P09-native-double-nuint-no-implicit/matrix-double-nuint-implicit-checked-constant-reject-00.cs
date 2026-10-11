/*
Rules: P09-native-double-nuint-no-implicit
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Generated: clauses/10-conversions/generators/native-matrices.py
*/
using System;
class Program
{
    static void Main()
    {
        const double input = -1.7976931348623157e+308d;
        nuint result = checked(input);
    }
}
