/*
Rules: P09-native-sbyte-nuint; E12-23-exception
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
        const sbyte input = (sbyte)(-1);
        nuint result = checked((nuint)input);
    }
}
