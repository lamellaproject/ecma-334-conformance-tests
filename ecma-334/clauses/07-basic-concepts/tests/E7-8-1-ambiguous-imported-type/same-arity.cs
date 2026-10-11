/*
Rules: E7-8-1-ambiguous-imported-type
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: reject
Mutate: using West;
Into: using South;
Csc: CS0104
*/
using East;
using West;
namespace East { public class Fruit<T> { } }
namespace West { public class Fruit<T> { } }
namespace South { }
class Program { static void Main() { Fruit<int> item = null; } }
