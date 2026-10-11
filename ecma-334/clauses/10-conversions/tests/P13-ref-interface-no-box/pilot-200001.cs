/*
Rules: P13-ref-interface-no-box
Authority: csc 5.11.0-1.26425.128 (C# 13.0)
Version: 13.0
Expected: reject
Mutate: ICode boxed=value;
Into: ICode boxed=default(ICode);
*/
using System;

interface ICode{} ref struct RefValue:ICode{}
class Program
{
    static void Main()
    {
        RefValue value=default;ICode boxed=value;
    }
}
