/*
Rules: E15-6-2-1-parameter-space-unique-names
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: reject
Mutate: T Make<T, T>()
Into: T Make<T, U>()
Csc: CS0692
*/
class Holder { public T Make<T, T>() { return default(T); } }
class Program { static void Main() { } }
