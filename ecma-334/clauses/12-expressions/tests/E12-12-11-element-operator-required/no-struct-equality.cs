/*
Rules: E12-12-11-element-operator-required
Authority: ECMA-334 7th ed 12.12.11
Version: 7.3
Expected: reject
Mutate: struct Token { }
Into: class Token { }
*/
struct Token { }
class Program { static void Main() { bool b = (new Token(), 1) == (new Token(), 1); } }
