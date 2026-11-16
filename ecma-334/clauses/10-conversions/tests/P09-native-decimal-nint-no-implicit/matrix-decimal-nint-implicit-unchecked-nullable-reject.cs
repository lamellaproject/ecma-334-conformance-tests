/*
Rules: P09-native-decimal-nint-no-implicit
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
        decimal? input = 97m;
        nint? result = unchecked(input);
    }
}
