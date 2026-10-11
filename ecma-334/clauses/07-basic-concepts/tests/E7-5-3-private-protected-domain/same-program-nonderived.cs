/*
Rules: E7-5-3-private-protected-domain; E7-5-4-protected-access-derived-context
Authority: ECMA-334 7th ed 7.5.3
Version: 7.3
Expected: reject
Mutate: private protected int value = 83;
Into: internal int value = 83;
*/
class Root { private protected int value = 83; }
class Program { static void Main() { int value = new Root().value; } }
