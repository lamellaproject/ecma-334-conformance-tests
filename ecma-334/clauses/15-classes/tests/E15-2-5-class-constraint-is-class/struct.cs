/*
Rules: E15-2-5-class-constraint-is-class
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: struct Record
Into: class Record
*/
struct Record { }
class Box<T> where T : Record { }
class Program { static void Main() { } }
