/*
Rules: E15-7-3-nonref-get-return-conversion
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: reject
Mutate: return "nine";
Into: return 9;
*/
class Box { public int Item { get { return "nine"; } } }
class Program { static void Main() { } }
