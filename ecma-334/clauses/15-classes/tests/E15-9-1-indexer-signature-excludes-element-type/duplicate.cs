/*
Rules: E15-9-1-indexer-signature-excludes-element-type; E15-9-1-indexer-signatures-unique
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: reject
Mutate: public string this[int index] => "east";
Into: public string this[string index] => "east";
Csc: CS0111
*/
class Grid { public int this[int index] => index; public string this[int index] => "east"; }
class Program { static void Main() { } }
