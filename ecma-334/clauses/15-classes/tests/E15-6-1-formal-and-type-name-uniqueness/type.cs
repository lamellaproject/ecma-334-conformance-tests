/*
Rules: E15-6-1-formal-and-type-name-uniqueness
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public void Touch<T, T>()
Into: public void Touch<T, U>()
Csc: CS0692
*/
class Holder { public void Touch<T, T>() { } }
class Program { static void Main() { } }
