/*
Rules: E12-6-2-3-normal-array-argument
Authority: ECMA-334 7th ed 12.6.2.3
Version: 7.3
Expected: reject
Mutate: Read(values: new long[] { 7L })
Into: Read(values: new int[] { 7 })
*/
class Program { static void Read(params int[] values) { } static void Main() { Read(values: new long[] { 7L }); } }
