/*
Rules: E15-6-9-partial-no-explicit-interface
Authority: ECMA-334 7th ed 15.6.9
Version: 7.3
Expected: reject
Mutate: partial void IRelay.Record()
Into: void IRelay.Record()
Csc: CS0754
*/
interface IRelay { void Record(); }
partial class Gauge : IRelay
{
    partial void Record();
    partial void IRelay.Record() { }
}
class Program { static void Main() { } }
