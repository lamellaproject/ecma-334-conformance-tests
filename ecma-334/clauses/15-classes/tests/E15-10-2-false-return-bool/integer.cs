/*
Rules: E15-10-2-false-return-bool
Authority: ECMA-334 7th ed 15.10.2
Version: 7.3
Expected: reject
Mutate: int operator false
Into: bool operator false
Csc: CS0215
*/
using System;
class Gauge { public static int operator false(Gauge x) { throw new Exception(); } public static bool operator true(Gauge x) { return false; } }
class Program { static void Main() { } }
