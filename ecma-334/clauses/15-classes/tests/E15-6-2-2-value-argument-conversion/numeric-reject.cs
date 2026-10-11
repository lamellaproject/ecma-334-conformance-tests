/*
Rules: E15-6-2-2-value-argument-conversion
Authority: ECMA-334 7th ed 15.6.2.2
Version: 7.3
Expected: reject
Mutate: Holder.Read(1.5m)
Into: Holder.Read(3)
Csc: CS1503
*/
class Holder { public static int Read(int value) { return value; } }
class Program { static void Main() { Holder.Read(1.5m); } }
