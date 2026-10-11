/*
Rules: E15-3-1-parameter-declared-member-name-collision
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: reject
Mutate: public int T;
Into: public int Number;
*/
class Meter<T> { public int T; }
class Program { static void Main() { } }
