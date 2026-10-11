/*
Rules: E12-19-2-explicit-compatible-types
Authority: ECMA-334 7th ed 12.19.2
Version: 7.3
Expected: reject
Mutate: (long first, int second) =>
Into: (int first, long second) =>
*/
delegate long Combine(int first, long second);
class Program { static void Main() { Combine function = (long first, int second) => first + second; } }
