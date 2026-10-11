/*
Rules: E15-6-2-1-parameter-space-unique-names
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: reject
Mutate: T Read<T>(T T)
Into: T Read<T>(T value)
Csc: CS0412
*/
class Holder { public T Read<T>(T T) { return default(T); } }
class Program { static void Main() { } }
