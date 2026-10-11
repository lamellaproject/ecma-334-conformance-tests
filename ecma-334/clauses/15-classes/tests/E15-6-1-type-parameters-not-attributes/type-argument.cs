/*
Rules: E15-6-1-type-parameters-not-attributes
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: [Marker(typeof(T))]
Into: [Marker(typeof(int))]
Csc: CS0246
*/
class MarkerAttribute : System.Attribute { public MarkerAttribute(System.Type type) { } }
class Holder
{
    [Marker(typeof(T))]
    public void Touch<T>() { }
}
class Program { static void Main() { } }
