/*
Rules: E15-6-9-partial-match-parameter-modifiers
Authority: ECMA-334 7th ed 15.6.9
Version: 7.3
Expected: reject
Mutate: partial void Record(int used)
Into: partial void Record(ref int used)
Csc: CS0759
*/
partial class Gauge
{
    partial void Record(ref int declared);
    partial void Record(int used) { }
}
class Program { static void Main() { } }
