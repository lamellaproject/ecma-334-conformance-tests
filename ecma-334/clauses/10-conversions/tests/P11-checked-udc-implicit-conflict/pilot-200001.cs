/*
Rules: P11-checked-udc-implicit-conflict
Authority: csc 5.11.0-1.26425.128 (C# 11.0)
Version: 11.0
Expected: reject
Mutate: implicit operator int
Into: explicit operator int
*/
using System;

struct Broken{public static implicit operator int(Broken x)=>3;public static explicit operator checked int(Broken x)=>5;}
class Program
{
    static void Main()
    {

    }
}
