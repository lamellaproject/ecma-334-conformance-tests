/*
Rules: E15-2-5-interface-constraint-is-interface
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: struct Record
Into: interface Record
*/
struct Record { }
class Box<T> where T : class, Record { }
class Program { static void Main() { } }
