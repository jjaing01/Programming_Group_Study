using System;
using System.Collections.Generic;
using System.Linq;


// 명령적 프로그래밍: 명령어를 사용해 어떻게 작업을 수행할지 직접 명시, 상태 변경에 중점. (순서 중점)
// 선언적 프로그래밍: 원하는 결과를 선언하고, 시스템이 자체적으로 작업 방법을 결정, 명령의 순서가 중요하지 않음.
class item24
{
    static void Main()
    {
        // 명령적 프로그래밍(Imperative programming) - 배열의 짝수만 필터링
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        List<int> evenNumbers = new List<int>();

        foreach (int num in numbers)
        {
            if (num % 2 == 0)
            {
                evenNumbers.Add(num);
            }
        }

        Console.WriteLine(string.Join(", ", evenNumbers));

        // 선언적 프로그래밍(Declarative Programming) - 배열의 짝수만 필터링
        List<int> numbers2 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        // 어떻게 짝수를 찾아내는지에 대한 구체적인 절차나 루프 등은 개발자에게 숨겨져 있음
        var evenNumbers2 = numbers2.Where(num => num % 2 == 0); 
        Console.WriteLine(string.Join(", ", evenNumbers));
    }
}

// 명령적 접근 방식은 명시적인 루프와 조건문을 사용하여 짝수를 필터링하고 결과를 새로운 리스트에 추가
// 반면에 선언적 접근 방식에서는 LINQ를 사용하여 필터링 조건을 선언하고, 어떻게 필터링을 수행할지 명시하지 않음
// LINQ는 내부에서 쿼리를 최적화하고 결과를 생성.

// 선언적 프로그래밍의 경우 필터링 조건이 더 명확하게 표현되고 코드가 간결하다.