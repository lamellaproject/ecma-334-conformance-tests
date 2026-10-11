/*
Rules: E15-10-2-true-return-bool
Authority: ECMA-334 7th ed 15.10.2
Version: 7.3
Expected: reject
Mutate: int operator true
Into: bool operator true
Csc: CS0215
*/
using System;
class Gauge { public static int operator true(Gauge x) { throw new Exception(); } public static bool operator false(Gauge x) { return false; } }
class Program { static void Main() { } }
