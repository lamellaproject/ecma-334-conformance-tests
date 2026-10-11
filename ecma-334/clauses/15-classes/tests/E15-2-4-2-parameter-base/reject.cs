/*
Rules: E15-2-4-2-parameter-base
Authority: ECMA-334 7th ed 15.2.4.2
Version: 7.3
Expected: reject
Mutate: class Packet<T> : T
Into: class Packet<T> : object
*/
class Packet<T> : T { }
class Program { static void Main() { } }
