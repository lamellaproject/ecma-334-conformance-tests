/*
Rules: E18-2-2-unsafe-context
Authority: ECMA-334 7th ed 18.2.2
Version: 7.3
Expected: reject
Requirements: unsafe-disabled
Mutate: unsafe interface IMarker
Into: interface IMarker
Csc: CS0227
*/
// This test is compiled with unsafe compilation disabled in config/test-options.json.
unsafe interface IMarker { }
class Program { static void Main() { } }
