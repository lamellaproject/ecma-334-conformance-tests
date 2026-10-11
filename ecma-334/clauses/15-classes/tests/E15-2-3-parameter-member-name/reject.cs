/*
Rules: E15-2-3-parameter-member-name
Authority: ECMA-334 7th ed 15.2.3
Version: 7.3
Expected: reject
Mutate: public int T;
Into: public int Value;
*/
class Packet<T> { public int T; }
class Program { static void Main() { } }
