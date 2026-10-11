/*
Rules: E12-8-11-1-out-argument
Authority: ECMA-334 7th ed 12.8.11.1
Version: 7.3
Expected: reject
Mutate: values[out index]
Into: values[index]
*/
class Program { static void Main() { int index = 0; int[] values = new int[1]; int result = values[out index]; } }
