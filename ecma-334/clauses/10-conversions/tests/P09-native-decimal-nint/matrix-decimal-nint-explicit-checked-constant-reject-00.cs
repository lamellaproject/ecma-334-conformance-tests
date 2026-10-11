/*
Rules: P09-native-decimal-nint; E12-23-exception
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
        const decimal input = -79228162514264337593543950335m;
        nint result = checked((nint)input);
    }
}
