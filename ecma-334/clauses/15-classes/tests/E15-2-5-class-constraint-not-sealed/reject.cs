/*
Rules: E15-2-5-class-constraint-not-sealed
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: sealed class Record
Into: class Record
*/
sealed class Record { }
class Box<T> where T : Record { }
class Program { static void Main() { } }
