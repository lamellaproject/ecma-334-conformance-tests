/*
Rules: E15-6-9-partial-match-parameter-modifiers
Authority: ECMA-334 7th ed 15.6.9
Version: 7.3
Expected: reject
Mutate: partial void Record(ref int used)
Into: partial void Record(in int used)
*/
partial class Gauge
{
    partial void Record(in int declared);
    partial void Record(ref int used) { }
}
class Program { static void Main() { } }
