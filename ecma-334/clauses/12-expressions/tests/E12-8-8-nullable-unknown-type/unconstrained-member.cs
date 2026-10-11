/*
Rules: E12-8-8-nullable-unknown-type
Authority: ECMA-334 7th ed 12.8.8
Version: 7.3
Expected: reject
Mutate: Read<T>(Cell<T>? receiver)
Into: Read<T>(Cell<T>? receiver) where T : class
*/
struct Cell<T> { public T Value; }
class Program
{
    static object Read<T>(Cell<T>? receiver) { return receiver?.Value; }
    static void Main() { Read<string>(null); }
}
