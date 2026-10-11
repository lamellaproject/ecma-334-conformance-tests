/*
Rules: E8-3-11-tuple-new-syntax-forbidden
Authority: ECMA-334 7th ed 8.3.11
Version: 7.3
Expected: reject
Mutate: new (int, int)(3, 9)
Into: new System.ValueTuple<int, int>(3, 9)
*/
class Program { static void Main() { var tuple = new (int, int)(3, 9); } }
