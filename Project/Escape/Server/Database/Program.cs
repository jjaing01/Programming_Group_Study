using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

class Program
{
    static void Main()
    {
        // Todo(박용환) : 추후 프로젝트에서 사용하는 db명으로 변경 필요 현재는 로컬에서 사용하는 db에 접근한 것.
        string connectionString = @"Data Source=localhost;Integrated Security=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connection successful!");

                // Todo(박용환) : 추후 예외처리 추가
                Load(connection);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Connection failed: " + ex.Message);
            }
        }

        bool Load(SqlConnection connection)
        {
            // master 데이터베이스에서 테이블 목록 조회
            var command = new SqlCommand("SELECT name FROM sys.tables", connection);
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;

            // executeReader : 데이터베이스에서 데이터를 읽어오는 데 사용되는 SqlCommand의 메서드
            // 호출 시 데이터베이스에 대한 쿼리를 실행하고 그 결과로 데이터 리더(DataReader) 객체를 반환
            var reader = command.ExecuteReader();

            // db에서 테이블 명 로드
            var tableList = new List<string>();
            while(reader.Read())
            {
                tableList.Add(reader.GetString(0));
            }

            // 리더 닫기
            reader.Close();

            // Todo(박용환) : general 하게 사용할 수 있도록 수정 필요. 현재는 테이블 마다 코드 추가 필요
            var accountDbContext = new AccountDbContext();
            var testDbContext = new TestDbContext();

            foreach (var table in tableList)
            {
                var tableCommand = new SqlCommand($"SELECT * FROM {table}", connection);
                SqlDataReader tableReader = tableCommand.ExecuteReader();

                // 로드 시 테이블에 pk가 잡혀있지 않다면 에러
                while (tableReader.Read())
                {
                    // Account 테이블이면 DbSet과 DbContext에 추가
                    if (table == "Account")
                    {
                        var accountDbSet = new AccountDbSet();

                        accountDbSet.Id = tableReader.GetInt64(tableReader.GetOrdinal("Id"));
                        accountDbSet.Name = tableReader.GetString(tableReader.GetOrdinal("Name"));

                        accountDbContext.Accounts.Add(accountDbSet);
                    }
                    // Test 테이블이면 DbSet과 DbContext에 추가
                    else if (table == "Test")
                    {
                        var testDbSet = new TestDbSet();

                        testDbSet.Id = tableReader.GetInt64(tableReader.GetOrdinal("Id"));
                        testDbSet.TestValue = tableReader.GetInt64(tableReader.GetOrdinal("TestValue"));

                        testDbContext.Tests.Add(testDbSet);
                    }
                }

                tableReader.Close();
            }

            return true;
        }

    }
}