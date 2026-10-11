/*
Rules: E8-7-dynamic-new-forbidden
Authority: ECMA-334 7th ed 8.7
Version: 7.3
Expected: reject
Mutate: new dynamic()
Into: new object()
*/
class Program { static void Main() { var value = new dynamic(); } }
