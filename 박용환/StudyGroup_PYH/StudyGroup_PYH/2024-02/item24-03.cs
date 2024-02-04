using System;
using System.Reflection;

// 사용자 정의 Attribute 작성
// 클래스, 구조체에 적용
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class CustomAttribute : Attribute
{
    // Attribute에 부여할 속성 정의
    public string Description { get; }

    // 생성자를 통해 attribute에 값을 전달받음
    public CustomAttribute(string description)
    {
        Description = description;
    }
}

// Attribute를 사용하는 클래스
[Custom("This is a custom attribute class")]
public class SampleClass
{
    // 메서드 예제
    public void SampleMethod()
    {
        Console.WriteLine("Sample method executed.");
    }
}

// Attribute를 사용하는 클래스
[Custom("This is a custom attribute struct")]
public struct SampleStruct
{
    // 메서드 예제
    public void SampleMethod()
    {
        Console.WriteLine("Sample method executed.");
    }
}

// 리플렉션(Reflection)이란, 타입 자체의 정보를 이용해, 작업하는 것
// Reflection을 사용하여 Attribute 정보 읽기
class item2403
{
    static void Main()
    {
        // SampleClass 타입을 가져옴
        Type typeClass = typeof(SampleClass);

        // SampleClass에 부여된 CustomAttribute 정보를 읽어옴
        object[] attributesClass = typeClass.GetCustomAttributes(typeof(CustomAttribute), false);

        if (attributesClass.Length > 0)
        {
            // CustomAttribute의 값을 출력
            CustomAttribute customAttribute = (CustomAttribute)attributesClass[0];
            Console.WriteLine(customAttribute.Description);
        }
        else
        {
            Console.WriteLine("Custom attribute not found.");
        }

        // SampleStruct 타입을 가져옴
        Type typeStruct = typeof(SampleStruct);

        // SampleStruct에 부여된 CustomAttribute 정보를 읽어옴
        object[] attributesStruct = typeStruct.GetCustomAttributes(typeof(CustomAttribute), false);

        if (attributesStruct.Length > 0)
        {
            // CustomAttribute의 값을 출력
            CustomAttribute customAttribute = (CustomAttribute)attributesStruct[0];
            Console.WriteLine(customAttribute.Description);
        }
        else
        {
            Console.WriteLine("Custom attribute not found.");
        }
    }
}