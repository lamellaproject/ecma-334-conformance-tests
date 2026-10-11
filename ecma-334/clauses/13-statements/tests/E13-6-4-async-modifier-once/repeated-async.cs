/*
Rules: E13-6-4-async-modifier-once
Authority: ECMA-334 7th ed 13.6.4
Version: 7.3
Expected: reject
Mutate: async async void Local()
Into: async void Local()
*/
class Program { static void Main() { async async void Local() { } } }
