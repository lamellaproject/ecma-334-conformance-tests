/*
Rules: P12-readonly-method-writable
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: reject
Mutate: InReader reader=Readers.Read;
Into: InReader reader=default(InReader);
*/
using System;

delegate int InReader(in int n);static class Readers{public static int Read(ref int n){n++;return n;}}
class Program
{
    static void Main()
    {
        InReader reader=Readers.Read;
    }
}
