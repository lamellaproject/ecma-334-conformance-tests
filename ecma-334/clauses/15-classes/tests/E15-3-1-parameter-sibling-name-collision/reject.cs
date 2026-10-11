/*
Rules: E15-3-1-parameter-sibling-name-collision
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: reject
Mutate: class Pair<T, T>
Into: class Pair<T, U>
*/
class Pair<T, T> { }
class Program { static void Main() { } }
