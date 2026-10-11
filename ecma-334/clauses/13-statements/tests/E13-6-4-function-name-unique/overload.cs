/*
Rules: E13-6-4-function-name-unique
Authority: ECMA-334 7th ed 13.6.4
Version: 7.3
Expected: reject
Mutate: void Local(int value) { }
Into: void Other(int value) { }
*/
class Program { static void Main() { void Local() { } void Local(int value) { } } }
