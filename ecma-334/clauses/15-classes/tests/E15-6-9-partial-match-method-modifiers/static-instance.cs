/*
Rules: E15-6-9-partial-match-method-modifiers
Authority: ECMA-334 7th ed 15.6.9
Version: 7.3
Expected: reject
Mutate: partial void Record() { }
Into: static partial void Record() { }
Csc: CS0763
*/
partial class Gauge
{
    static partial void Record();
    partial void Record() { }
}
class Program { static void Main() { } }
