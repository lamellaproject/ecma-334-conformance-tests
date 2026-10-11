/*
Rules: E12-8-13-context
Authority: ECMA-334 7th ed 12.8.13
Version: 7.3
Expected: reject
Mutate: Box saved = this;
Into: Box saved = null;
*/
class Box { Box saved = this; }
class Program { static void Main() { new Box(); } }
