/*
Rules: E18-2-2-new-class-only
Authority: ECMA-334 7th ed 18.2.2
Version: 7.3
Expected: reject
Mutate: new interface IMarker
Into: interface IMarker
Csc: CS0106
*/
new interface IMarker { }
class Program { static void Main() { } }
