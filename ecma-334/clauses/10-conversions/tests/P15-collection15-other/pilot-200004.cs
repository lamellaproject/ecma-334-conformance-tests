/*
Rules: P15-collection15-other
Authority: csc 5.12.0-1.26529.118 (C# 15.0)
Version: 15.0
Expected: reject
Mutate: IReadOnlyList<int> value=[with(17),659];
Into: IReadOnlyList<int> value=default(IReadOnlyList<int>);
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

class Program
{
    static void Main()
    {
        IReadOnlyList<int> value=[with(17),659];
    }
}
