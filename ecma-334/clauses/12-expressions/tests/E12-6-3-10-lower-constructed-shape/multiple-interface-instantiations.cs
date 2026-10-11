/*
Rules: E12-6-3-10-lower-constructed-shape
Authority: ECMA-334 7th ed 12.6.3.10
Version: 7.3
Expected: reject
Mutate: Observe(new Both())
Into: Observe((View<string>)new Both())
*/
interface View<T> { }
class Both : View<string>, View<object> { }
class Program
{
    static void Observe<T>(View<T> value) { }
    static void Main() { Observe(new Both()); }
}
