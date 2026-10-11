/*
Rules: P11-static-conversion-ambiguous
Authority: csc 5.11.0-1.26425.128 (C# 11.0)
Version: 11.0
Expected: reject
Mutate: where T:IFirst<T>,ISecond<T>
Into: where T:IFirst<T>
*/
using System;


interface IFirst<T> where T:IFirst<T>{static abstract implicit operator T(int x);}
interface ISecond<T> where T:ISecond<T>{static abstract implicit operator T(int x);}
static class Convert{public static T Read<T>(int x) where T:IFirst<T>,ISecond<T> =>x;}

class Program
{
    static void Main()
    {

    }
}
