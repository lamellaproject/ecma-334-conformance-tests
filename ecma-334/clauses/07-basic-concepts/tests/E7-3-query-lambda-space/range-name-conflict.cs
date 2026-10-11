/*
Rules: E7-3-query-lambda-space; E7-3-nested-local-name-conflict
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: reject
Mutate: from item in
Into: from range in
*/
using System;
class Query<T>
{
    T value;
    public Query(T item) { value = item; }
    public Query<R> Select<R>(Func<T, R> project) { return new Query<R>(project(value)); }
}
class Program
{
    static void Main()
    {
        int item = 17;
        var result = from item in new Query<int>(23) select item;
    }
}
