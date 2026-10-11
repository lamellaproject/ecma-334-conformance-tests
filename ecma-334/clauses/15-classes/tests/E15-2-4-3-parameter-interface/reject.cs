/*
Rules: E15-2-4-3-parameter-interface
Authority: ECMA-334 7th ed 15.2.4.3
Version: 7.3
Expected: reject
Mutate: class Packet<T> : object, T
Into: class Packet<T> : object, ITag
*/
interface ITag { }
class Packet<T> : object, T { }
class Program { static void Main() { } }
