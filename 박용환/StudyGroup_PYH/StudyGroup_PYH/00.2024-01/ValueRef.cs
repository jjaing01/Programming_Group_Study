using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_PYH._00._2024_01
{
    class ValueRef
    {
    }
}


// C++과의 차이점
// C++ 의 pointer/reference 와 C#의 reference 와는 다르다. C++ 에서는 무조건 value 형태이고, 부수적으로 pointer/reference 형으로 생성 하는 것이지만, C# 에서는 reference 형이면, 무조건 reference형으로 생성해야 하기 때문이다.

// 구분
// 대체로 reference 로 쓰고, 다음의 경우에 만족할 경우 Value 사용
// 1. 단순이 저장용도로 쓸 것이면 value 로 사용
// 2. 모든 public interface가 단지 내부값 확인하는데 쓰인다면, value로 사용
// 3. 타입이 앞으로 상속될 가능성이 없다면, value를 사용
// 4. 타입이 앞으로 다형적으로 사용 될 필요가 없다면, value를 사용
// 5. 타입에 행동이 있어야 한다면, reference로 정의 해서 사용


// 클래스 내부 객체에 대한 reference 반환을 피하라
// value 타입을 이용하기
// immutable 타입 사용하기
// 읽기용 interface 이용하기
// 읽기용 wapper 이용하기