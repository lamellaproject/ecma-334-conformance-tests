/*
Rules: E15-6-9-partial-match-parameter-types
Authority: ECMA-334 7th ed 15.6.9
Version: 7.3
Expected: reject
Mutate: partial void Record(long used)
Into: partial void Record(int used)
Csc: CS0759
*/
partial class Gauge
{
    partial void Record(int declared);
    partial void Record(long used) { }
}
class Program { static void Main() { } }
