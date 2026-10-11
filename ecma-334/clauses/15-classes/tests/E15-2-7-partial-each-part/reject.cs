/*
Rules: E15-2-7-partial-each-part
Authority: ECMA-334 7th ed 15.2.7
Version: 7.3
Expected: reject
Mutate: class Meter { public int Right; }
Into: partial class Meter { public int Right; }
*/
partial class Meter { public int Left; }
class Meter { public int Right; }
class Program { static void Main() { } }
