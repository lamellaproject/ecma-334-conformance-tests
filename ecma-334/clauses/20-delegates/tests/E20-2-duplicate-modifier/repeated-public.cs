/*
Rules: E20-2-duplicate-modifier
Authority: ECMA-334 7th ed 20.2
Version: 7.3
Expected: reject
Mutate: public public delegate void Notice();
Into: public delegate void Notice();
Csc: CS1004
*/
public public delegate void Notice();
class Program { static void Main() { } }
