/*
Rules: E15-2-4-3-unique-interface-implementation
Authority: ECMA-334 7th ed 15.2.4.3
Version: 7.3
Expected: reject
Mutate: int IReading.Read() { return 271; }
Into: int Extra() { return 271; }
*/
interface IReading { int Read(); }
partial class Gauge : IReading { int IReading.Read() { return 269; } }
partial class Gauge { int IReading.Read() { return 271; } }
class Program { static void Main() { } }
