/*
Rules: E15-6-9-partial-one-implementation
Authority: ECMA-334 7th ed 15.6.9
Version: 7.3
Expected: reject
Mutate: partial void Record(int second) { }
Into: // duplicate implementation removed
Csc: CS0757
*/
partial class Gauge
{
    partial void Record(int declared);
    partial void Record(int first) { }
}
partial class Gauge
{
    partial void Record(int second) { }
}
class Program { static void Main() { } }
