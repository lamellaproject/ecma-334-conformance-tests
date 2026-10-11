/*
Rules: E15-6-1-partial-void-only
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: partial int Read();
Into: partial void Read();
*/
partial class Holder { partial int Read(); }
class Program { static void Main() { } }
