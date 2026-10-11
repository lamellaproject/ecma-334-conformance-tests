/*
Rules: E12-2-2-untyped-tuple-value
Authority: ECMA-334 7th ed 12.2.2
Version: 7.3
Expected: reject
Mutate: var pair = (null, null);
Into: (object, object) pair = (null, null);
*/
class Program { static void Main() { var pair = (null, null); } }
