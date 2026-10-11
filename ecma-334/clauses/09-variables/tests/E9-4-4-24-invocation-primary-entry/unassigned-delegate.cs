/*
Rules: E9-4-4-24-invocation-primary-entry
Authority: ECMA-334 7th ed 9.4.4.24
Version: 7.3
Expected: reject
Mutate: System.Action callback;
Into: System.Action callback = () => { };
Csc: CS0165
*/
class Program { static void Main() { System.Action callback; callback(); } }
