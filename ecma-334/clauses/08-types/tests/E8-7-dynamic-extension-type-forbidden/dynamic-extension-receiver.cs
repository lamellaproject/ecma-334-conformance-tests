/*
Rules: E8-7-dynamic-extension-type-forbidden
Authority: ECMA-334 7th ed 8.7
Version: 7.3
Expected: reject
Mutate: this dynamic value
Into: this object value
*/
static class Extensions { public static int Read(this dynamic value) { return 1; } }
class Program { static void Main() { } }
