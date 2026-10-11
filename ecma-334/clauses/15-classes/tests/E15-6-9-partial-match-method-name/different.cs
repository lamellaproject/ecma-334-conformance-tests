/*
Rules: E15-6-9-partial-match-method-name
Authority: ECMA-334 7th ed 15.6.9
Version: 7.3
Expected: reject
Mutate: partial void Other() { }
Into: partial void Record() { }
Csc: CS0759
*/
partial class Gauge
{
    partial void Record();
    partial void Other() { }
}
class Program { static void Main() { } }
