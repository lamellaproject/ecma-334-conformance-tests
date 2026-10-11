/*
Rules: E15-2-3-parameter-class-name
Authority: ECMA-334 7th ed 15.2.3
Version: 7.3
Expected: reject
Mutate: class Packet<Packet>
Into: class Packet<T>
*/
class Packet<Packet> { }
class Program { static void Main() { } }
