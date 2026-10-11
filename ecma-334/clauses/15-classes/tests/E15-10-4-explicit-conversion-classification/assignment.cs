/*
Rules: E15-10-4-explicit-conversion-classification
Authority: ECMA-334 7th ed 15.10.4
Version: 7.3
Expected: reject
Mutate: int value = new Gauge();
Into: int value = (int)new Gauge();
Csc: CS0266
*/
class Gauge { public static explicit operator int(Gauge x) { return 19; } }
class Use { public int value; public Use() { int value = new Gauge(); this.value = value; } }
class Program { static void Main() { } }
