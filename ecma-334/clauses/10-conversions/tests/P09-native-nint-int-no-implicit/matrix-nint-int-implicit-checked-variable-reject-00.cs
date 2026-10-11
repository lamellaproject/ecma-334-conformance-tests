/*
Rules: P09-native-nint-int-no-implicit
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
        nint input = (nint)(long.MinValue);
        int result = checked(input);
    }
}
