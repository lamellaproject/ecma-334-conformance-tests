/*
Rules: E16-4-2-no-circular-field-dependency; E16-4-2-dependency-closure
Authority: ECMA-334 7th ed 16.4.2
Version: 7.3
Expected: reject
Mutate: public First<Second<T>> Back;
Into: public T Back;
*/
struct First<T> { public Second<T> Next; }
struct Second<T> { public First<Second<T>> Back; }
class Program { static void Main() { } }
