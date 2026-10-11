/*
Rules: E15-6-9-partial-unimplemented-no-entry-point
Authority: ECMA-334 7th ed 15.6.9
Version: 7.3
Expected: reject
Mutate: static partial void Main();
Into: static partial void Main(); static partial void Main() { }
Csc: CS5001
*/
partial class Program { static partial void Main(); }
