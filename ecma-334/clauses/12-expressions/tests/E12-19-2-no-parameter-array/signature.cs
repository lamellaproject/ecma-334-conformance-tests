/*
Rules: E12-19-2-no-parameter-array
Authority: ECMA-334 7th ed 12.19.2
Version: 7.3
Expected: reject
Mutate: params int[] values
Into: int[] values
*/
delegate int Count(int[] items);
class Program { static void Main() { Count function = (params int[] values) => values.Length; } }
