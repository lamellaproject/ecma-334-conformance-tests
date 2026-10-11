/*
Rules: P09-native-nuint-uint-no-implicit
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
        nuint? input = (nuint)(97UL);
        uint? result = unchecked(input);
    }
}
