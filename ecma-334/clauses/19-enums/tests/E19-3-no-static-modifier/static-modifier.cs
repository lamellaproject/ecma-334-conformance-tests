/*
Rules: E19-3-no-static-modifier
Authority: ECMA-334 7th ed 19.3
Version: 7.3
Expected: reject
Mutate: static enum Code
Into: enum Code
*/
static enum Code { Mark }
class Program { static void Main() { } }
