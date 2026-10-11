/*
Rules: E14-8-1-alias-member-not-found
Authority: ECMA-334 7th ed 14.8.1
Version: 7.3
Expected: reject
Mutate: Scope::Box<int, string> value
Into: Scope::Box<int> value
*/
using Scope = Harbor;
namespace Harbor { class Box<T> { } }
class Program
{
    static void Main() { Scope::Box<int, string> value = null; }
}
