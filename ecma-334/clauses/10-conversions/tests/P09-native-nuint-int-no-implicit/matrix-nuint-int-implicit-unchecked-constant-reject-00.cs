/*
Rules: P09-native-nuint-int-no-implicit
Authority: csc 5.12.0-1.26529.118 (C# 9.0)
Version: 9.0
Expected: reject
Generated: clauses/10-conversions/generators/native-matrices.py
*/
using System;
class Program
{
    static void Main()
    {
        const nuint input = (nuint)(0UL);
        int result = unchecked(input);
    }
}
