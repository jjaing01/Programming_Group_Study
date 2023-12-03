using System;
using System.Collections.Generic;
using System.Linq;

/*
    * 타입추론

        C# 컴파일러가 제네릭 메서드나 제네릭 클래스를 사용할 때, 사용자가 명시적으로 타입을 지정하지 않아도 컴파일러가 타입을 추론하는 기능

 */

public class cInferenceClass<T>
{
    public T Value { get; set; }

    public T2 MyMethod<T2>(T2 value)
    {
        return value;
    }
}

class cgeneric01
{
    static void Main()
    {
        // 일반적인 타입 지정
        List<int> intList = new List<int>();

        var varList = new List<int>();

        // 제네릭 클래스에서의 타입 추론
        var cInference = new cInferenceClass<int>();
        cInference.Value = 42;

        // 제네릭 메서드에서의 타입 추론
        int intInference = cInference.MyMethod(42); // T2는 int로 추론
        string stringInference = cInference.MyMethod("Hello"); // T2는 string으로 추론

        // 추론은 컴파일 시점에 이루어짐 var -> cInferenceClass<int>
    }
}