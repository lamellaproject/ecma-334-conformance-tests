/*
Rules: E15-2-1-constraints-require-parameters
Authority: ECMA-334 7th ed 15.2.1
Version: 7.3
Expected: reject
Mutate: class Packet where T : class
Into: class Packet<T> where T : class
*/
class Packet where T : class { }
class Program { static void Main() { } }
