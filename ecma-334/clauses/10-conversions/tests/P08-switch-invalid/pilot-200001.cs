/*
Rules: P08-switch-invalid
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: reject
Mutate: _ => 256
Into: _ => 255
*/
using System;


class Program
{
    static void Main()
    {
        int selector=1; byte value=selector switch {0 => 251, _ => 256};
    }
}
