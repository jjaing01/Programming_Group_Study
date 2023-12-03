using System;
using System.Collections.Generic;
using System.Linq;

/*
    * 타입 제약 조건
    
        제네릭 타입과 제네릭 메서드에 타입 매개변수를 포함시킬 때 제약 조건을 지정하면 타입 인수로 사용할 수 잇는 타입의 종류를 제한할 수 있다.

 */

public class cTypeOfRef
{

}

public struct cTypeOfValue
{

}

public class cConstraintsRef<T> //제약조건
{
    // T는 참조 형식이어야 함
}

public class cConstraintsValue<T> where T : struct //제약조건
{
    // T는 값 형식이어야 함

}

class cgeneric02
{
    static void Main()
    {
        //var ConstraintsRef = new cConstraintsRef<cTypeOfRef>();
        //var ConstraintsValue = new cConstraintsValue<cRefClass>();
        String? _String = null;
        //string.IsNullOrEmpty();

        string? a = "yong";
        string b = "hwan";
        Console.WriteLine($"a : {a}");
        Console.WriteLine($"b : {b}");
    }
}