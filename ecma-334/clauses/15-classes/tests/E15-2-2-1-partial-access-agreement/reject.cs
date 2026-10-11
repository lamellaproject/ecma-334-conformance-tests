/*
Rules: E15-2-2-1-partial-access-agreement
Authority: ECMA-334 7th ed 15.2.2.1
Version: 7.3
Expected: reject
Mutate: internal partial class Gauge
Into: public partial class Gauge
*/
public partial class Gauge { }
internal partial class Gauge { }
class Program { static void Main() { } }
