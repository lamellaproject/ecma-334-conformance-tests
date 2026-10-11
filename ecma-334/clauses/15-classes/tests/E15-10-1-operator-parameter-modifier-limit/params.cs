/*
Rules: E15-10-1-operator-parameter-modifier-limit
Authority: ECMA-334 7th ed 15.10.1
Version: 7.3
Expected: reject
Mutate: params int[] values
Into: int[] values
*/
class Gauge { public static int operator +(Gauge x, params int[] values) { return values.Length; } }
class Program { static void Main() { } }
