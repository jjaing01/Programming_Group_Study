using System.IO;

namespace StudyGroup_PYH._2024_02
{
    internal class Using
    {
        public static void Main()
        {
            FileStream fs = new FileStream("A.txt", FileMode.CreateNew);
            try
            {
                // 예외 가능성이 있는 것들은 이 쪽에 쓰자
            }
            finally
            {
                if (fs is null)
                {
                    fs.Dispose();
                }
            }

            // 위 코드를 자동 생성할 수 있다.
            // 1. using 키워드를 통해
            // 2. 
            using (FileStream fs2 = new FileStream("A.txt", FileMode.CreateNew))
            {
                // using => Try~Finally
                // 자원 관리를 용이하게 하기 위해 사용함
                // 아직 예외 처리를 한 것은 아니므로 내부에 try~catch로 예외 처리 가느아하다.
            }
        }
    }
}
