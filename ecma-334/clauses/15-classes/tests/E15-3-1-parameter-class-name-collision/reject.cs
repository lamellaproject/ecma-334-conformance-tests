/*
Rules: E15-3-1-parameter-class-name-collision
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: reject
Mutate: class Meter<Meter>
Into: class Meter<T>
*/
class Meter<Meter> { }
class Program { static void Main() { } }
