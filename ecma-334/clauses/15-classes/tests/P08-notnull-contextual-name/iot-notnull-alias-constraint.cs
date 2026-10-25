/*
Rules: P08-notnull-contextual-name
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: reject
Mutate: Keep(new Other());
Into: Keep(new Child());
*/
using notnull = Parent;
class Parent { }
class Child : Parent { }
class Other { }
class Program
{
    static T Keep<T>(T value) where T : notnull { return value; }
    static int Main()
    {
        Keep(new Other());
        return 0;
    }
}
