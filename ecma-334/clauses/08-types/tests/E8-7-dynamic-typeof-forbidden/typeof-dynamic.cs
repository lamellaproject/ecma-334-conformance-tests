/*
Rules: E8-7-dynamic-typeof-forbidden
Authority: ECMA-334 7th ed 8.7
Version: 7.3
Expected: reject
Mutate: typeof(dynamic)
Into: typeof(object)
*/
class Program { static void Main() { var type = typeof(dynamic); } }
