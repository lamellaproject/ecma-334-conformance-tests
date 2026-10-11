/*
Rules: E15-3-8-static-no-this
Authority: ECMA-334 7th ed 15.3.8
Version: 7.3
Expected: reject
Mutate: return this;
Into: return null;
*/
class Register { public static object Value { get { return this; } } }
class Program { static void Main() { } }
