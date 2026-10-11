/*
Rules: E15-2-5-parameter-constraint-is-parameter
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: where T : V
Into: where T : U
*/
namespace V { }
class Box<T,U> where T : V { }
class Program { static void Main() { } }
