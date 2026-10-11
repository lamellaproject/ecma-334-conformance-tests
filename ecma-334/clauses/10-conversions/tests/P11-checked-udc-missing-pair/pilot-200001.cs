/*
Rules: P11-checked-udc-missing-pair
Authority: csc 5.11.0-1.26425.128 (C# 11.0)
Version: 11.0
Expected: reject
Mutate: operator checked int
Into: operator int
*/
using System;

struct Broken{public static explicit operator checked int(Broken x)=>3;}
class Program
{
    static void Main()
    {

    }
}
