/*
Rules: E10-3-9-unconstrained-direct
Authority: ECMA-334 7th ed 10.3.9
Version: 7.3
Expected: reject
Mutate: return (int)x;
Into: return (int)(object)x;
*/
using System;


static class Bridge { public static int Cast<T>(T x) { return (int)x; } }

class Program
{
    static void Main()
    {

    }
}
