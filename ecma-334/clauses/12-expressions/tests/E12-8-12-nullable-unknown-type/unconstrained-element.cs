/*
Rules: E12-8-12-nullable-unknown-type
Authority: ECMA-334 7th ed 12.8.12
Version: 7.3
Expected: reject
Mutate: Read<T>(Cell<T>? receiver)
Into: Read<T>(Cell<T>? receiver) where T : class
*/
struct Cell<T> { public T this[int index] { get { return default(T); } } }
class Program
{
    static object Read<T>(Cell<T>? receiver) { return receiver?[0]; }
    static void Main() { Read<string>(null); }
}
