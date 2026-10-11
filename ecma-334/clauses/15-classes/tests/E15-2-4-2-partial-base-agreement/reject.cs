/*
Rules: E15-2-4-2-partial-base-agreement
Authority: ECMA-334 7th ed 15.2.4.2
Version: 7.3
Expected: reject
Mutate: partial class Gauge : Other
Into: partial class Gauge : Root
*/
class Root { }
class Other { }
partial class Gauge : Root { }
partial class Gauge : Other { }
class Program { static void Main() { } }
