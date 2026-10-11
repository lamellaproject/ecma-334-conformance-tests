/*
Rules: P11-scope-unsafe-mismatch
Authority: csc 5.11.0-1.26425.128 (C# 11.0)
Version: 11.0
Expected: reject
Mutate: ScopedReader value=Readers.Return;
Into: ScopedReader value=default(ScopedReader);
*/
using System;

delegate ref int ScopedReader(scoped ref int n);static class Readers{public static ref int Return(ref int n)=>ref n;}
class Program
{
    static void Main()
    {
        ScopedReader value=Readers.Return;
    }
}
