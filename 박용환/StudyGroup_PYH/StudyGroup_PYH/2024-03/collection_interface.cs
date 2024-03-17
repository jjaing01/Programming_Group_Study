using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_PYH._2024_03
{
    internal class collection_interface
    {
        public static void Main()
        {
            // 1. interface 기반 설계
            // - 다른 컬렉션을 사용하더라도 똑같은 기능을 사용한다면 메소드는 동일한 이름으로 설계하는 것이 좋다. (feat. msdn)

            // 2. Collection 관련 주요 인터페이스
            // (1) IEnumerable<T>: 열거자(반복자)를 꺼내기 위한 GetEnumerator() 메소드를 지원하는 인터페이스 => 모든 컬렉션이 구현한다.
            // (2) ICollection<T>: Count, IsReadOnly, Add, Remove, Clear => 대부분의 컬렉션이 구현한다.
            // (3) IList<T>: T this[], IndexOf, Insert, RemoveAt => 주로 인덱서 관련을 지원한다.

            var list = new List<int>();
        }
    }
}
