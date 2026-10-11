/*
Rules: E15-3-1-partial-duplicate-member; E15-3-1-partial-shared-space
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: reject
Mutate: partial class Meter { public int Mark = 229; }
Into: partial class Meter { public int Other = 229; }
*/
partial class Meter { public int Mark = 233; }
partial class Meter { public int Mark = 229; }
class Program { static void Main() { } }
