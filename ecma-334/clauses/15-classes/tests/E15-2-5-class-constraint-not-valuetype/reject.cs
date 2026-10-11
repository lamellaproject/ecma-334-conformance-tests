/*
Rules: E15-2-5-class-constraint-not-valuetype
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: where T : System.ValueType
Into: where T : struct
*/
class Box<T> where T : System.ValueType { }
class Program { static void Main() { } }
