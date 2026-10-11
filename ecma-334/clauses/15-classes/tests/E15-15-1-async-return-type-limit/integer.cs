/*
Rules: E15-15-1-async-return-type-limit
Authority: ECMA-334 7th ed 15.15.1
Version: 7.3
Expected: reject
Mutate: async int Read()
Into: int Read()
*/
class Program { static async int Read() { return 13; } static void Main() { } }
