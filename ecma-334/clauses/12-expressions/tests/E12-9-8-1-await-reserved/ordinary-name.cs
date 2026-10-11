/*
Rules: E12-9-8-1-await-reserved
Authority: ECMA-334 7th ed 12.9.8.1
Version: 7.3
Expected: reject
Mutate: int await = 4
Into: int @await = 4
*/
class Program { static async void Worker() { int await = 4; } static void Main() { } }
