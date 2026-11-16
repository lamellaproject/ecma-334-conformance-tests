/*
Rules: P09-native-long-nint-no-implicit
Authority: csc 5.12.0-1.26529.118 (C# 9.0)
Version: 9.0
Expected: reject
Generated: clauses/10-conversions/generators/sample-matrix.py
*/
using System;
class Program
{
    static void Main()
    {
        long input = 17;
        nint output = input;
    }
}
