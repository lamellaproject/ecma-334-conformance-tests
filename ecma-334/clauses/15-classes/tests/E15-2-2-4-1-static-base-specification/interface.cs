/*
Rules: E15-2-2-4-1-static-base-specification
Authority: ECMA-334 7th ed 15.2.2.4.1
Version: 7.3
Expected: reject
Mutate: static class Gauge : IReading
Into: static class Gauge
*/
interface IReading { }
static class Gauge : IReading { }
class Program { static void Main() { } }
