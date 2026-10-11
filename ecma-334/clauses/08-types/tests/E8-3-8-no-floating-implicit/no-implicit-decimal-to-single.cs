/*
Rules: E8-3-8-no-floating-implicit
Authority: ECMA-334 7th ed 8.3.8
Version: 7.3
Expected: reject
Mutate: float value = source;
Into: float value = (float)source;
*/
class Program { static void Main() { decimal source = 2.5m; float value = source; } }
