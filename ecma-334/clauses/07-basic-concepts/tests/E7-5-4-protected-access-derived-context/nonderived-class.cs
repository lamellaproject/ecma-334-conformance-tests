/*
Rules: E7-5-4-protected-access-derived-context; E7-5-3-protected-domain
Authority: ECMA-334 7th ed 7.5.4
Version: 7.3
Expected: reject
Mutate: protected int value = 89;
Into: internal int value = 89;
*/
class Root { protected int value = 89; }
class Program { static void Main() { int value = new Root().value; } }
