/*
Rules: E12-8-11-2-index-types
Authority: ECMA-334 7th ed 12.8.11.2
Version: 7.3
Expected: reject
Mutate: values[0.0]
Into: values[0]
*/
class Program { static void Main() { int[] values = new int[1]; int result = values[0.0]; } }
