/*
Rules: E12-8-11-2-named-arguments
Authority: ECMA-334 7th ed 12.8.11.2
Version: 7.3
Expected: reject
Mutate: values[index: 0]
Into: values[0]
*/
class Program { static void Main() { int[] values = new int[1]; int result = values[index: 0]; } }
