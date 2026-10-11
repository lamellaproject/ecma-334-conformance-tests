/*
Rules: E12-12-13-target-type
Authority: ECMA-334 7th ed 12.12.13
Version: 7.3
Expected: reject
Mutate: static T Convert<T>(object value)
Into: static T Convert<T>(object value) where T : class
*/
class Program { static T Convert<T>(object value) { return value as T; } static void Main() { } }
