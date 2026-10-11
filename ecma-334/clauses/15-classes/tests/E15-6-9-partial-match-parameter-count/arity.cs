/*
Rules: E15-6-9-partial-match-parameter-count
Authority: ECMA-334 7th ed 15.6.9
Version: 7.3
Expected: reject
Mutate: partial void Record(int used, int extra)
Into: partial void Record(int used)
Csc: CS0759
*/
partial class Gauge
{
    partial void Record(int declared);
    partial void Record(int used, int extra) { }
}
class Program { static void Main() { } }
