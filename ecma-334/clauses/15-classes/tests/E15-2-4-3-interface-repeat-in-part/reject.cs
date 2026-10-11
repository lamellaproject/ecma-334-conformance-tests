/*
Rules: E15-2-4-3-interface-repeat-in-part
Authority: ECMA-334 7th ed 15.2.4.3
Version: 7.3
Expected: reject
Mutate: partial class Gauge : ITag, ITag
Into: partial class Gauge : ITag
*/
interface ITag { }
partial class Gauge : ITag, ITag { }
partial class Gauge { int marker; }
class Program { static void Main() { } }
