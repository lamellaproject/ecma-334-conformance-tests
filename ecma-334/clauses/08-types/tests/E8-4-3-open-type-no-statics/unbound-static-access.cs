/*
Rules: E8-4-3-open-type-no-statics
Authority: ECMA-334 7th ed 8.4.3
Version: 7.3
Expected: reject
Mutate: Slot<>.Value
Into: Slot<object>.Value
*/
class Slot<T> { public static T Value; }
class Program { static void Main() { object value = Slot<>.Value; } }
