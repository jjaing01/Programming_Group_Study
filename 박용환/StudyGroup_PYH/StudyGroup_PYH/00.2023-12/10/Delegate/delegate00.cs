using System;

/*
 * 델리게이트
    1. 타입 안정성이 있다. 델리게이트는 특정 시그니처(매개변수 및 반환 형식)를 가진 메서드만 참조할 수 있다.
    2. 여러 메서드를 동시에 참조할 수 있는 다중 대리자를 지원한다.

 * 메서드 그룹 변환
    델리게이트를 선언할 때 메서드의 그룹을 사용하여 델리게이트를 초기화하는 것을 의미한다.
 */

// 델리게이트 정의
delegate void Delegate00(int a, int b);
class delegate00
{
    static void Main()
    {
        // 메서드 그룹 변환을 사용하여 델리게이트 인스턴스 생성
        Delegate00 delegate00 = AddNumbers; // new Delegate(AddNumbers);
        delegate00 += SubNumbers;

        delegate00(5, 1);

        // 메서드 그룹 변환으로 콜백 실행
        PerformOperation(1, 2, delegate00);
    }

    // 델리게이트와 시그니처가 일치하는 메서드
    static void AddNumbers(int a, int b)
    {
        Console.WriteLine($"Sum: {a + b}");
    }
    static void SubNumbers(int a, int b)
    {
        Console.WriteLine($"Sum: {a - b}");
    }

    static void PerformOperation(int x, int y, Delegate00 callback)
    {
        // 등록된 콜백 실행
        callback(x, y);
    }
}