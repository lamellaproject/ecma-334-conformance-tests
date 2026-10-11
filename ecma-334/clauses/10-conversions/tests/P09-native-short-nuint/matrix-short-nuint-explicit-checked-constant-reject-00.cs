/*
Rules: P09-native-short-nuint; E12-23-exception
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
        const short input = (short)(-32768);
        nuint result = checked((nuint)input);
    }
}
