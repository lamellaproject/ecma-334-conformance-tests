/*
Rules: E15-9-1-indexer-signature-excludes-parameter-names; E15-9-1-indexer-signatures-unique
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: reject
Mutate: public int this[int second] => 5;
Into: public int this[long second] => 5;
Csc: CS0111
*/
class Grid { public int this[int first] => 3; public int this[int second] => 5; }
class Program { static void Main() { } }
