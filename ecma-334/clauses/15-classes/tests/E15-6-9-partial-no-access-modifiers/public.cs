/*
Rules: E15-6-9-partial-no-access-modifiers
Authority: ECMA-334 7th ed 15.6.9
Version: 7.3
Expected: reject
Mutate: public partial void Record();
Into: partial void Record();
*/
partial class Gauge { public partial void Record(); }
class Program { static void Main() { } }
