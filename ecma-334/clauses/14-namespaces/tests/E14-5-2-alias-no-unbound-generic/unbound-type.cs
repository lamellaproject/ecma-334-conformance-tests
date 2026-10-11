/*
Rules: E14-5-2-alias-no-unbound-generic
Authority: ECMA-334 7th ed 14.5.2
Version: 7.3
Expected: reject
Mutate: using Pick = Harbor.Box<>;
Into: using Pick = Harbor.Box<int>;
*/
using Pick = Harbor.Box<>;
namespace Harbor { class Box<T> { } }
class Program
{
    static void Main() { Pick value = null; }
}
