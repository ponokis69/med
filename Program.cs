using System.Data.SqlClient;

var connectionString = "Data Source = localhost; DataBase = med; User Id = root; Password = iopkl789";

try
{
    //using автоматически открывает и закрывает то что в () т.е в данном случае автоматически открывает и закрывает подключение
    using(var sqlConnection = new SqlConnection(connectionString))
    {
        //Программа ожидает выполнения этой команды и дальше не выполняется
        await sqlConnection.OpenAsync();

        //создание команды
        var sqlCommand = sqlConnection.CreateCommand();

        //заносим команду на языке sql
        sqlCommand.CommandText = "Insert into clients Values('pochta@mail.ru','pochta')";

        //Также ждем выполнения команды
        await sqlCommand.ExecuteNonQueryAsync();
    }

} catch {}

//Чтение данных из бд
try
{
    //создание подключения
    var sqlConnection = new SqlConnection(connectionString);

    //открытие подключения
    sqlConnection.Open();

    //создание команды чтения
    var sqlCommand = sqlConnection.CreateCommand();

    //кладешь команды в команду
    sqlCommand.CommandText = "SELECT * FROM clients";

    //выполнение команды и передача данных в чтение
    var reader = sqlCommand.ExecuteReader();

    //чтение данных
    if(reader != null)
    {
        while(reader.Read())
        {
            Console.WriteLine($"Id:{reader["id"]}, login:{reader["Email"]}, password:{reader["Password"]}");
        }
    }

    //Закрытие чтения и подключения соответственно ОБЯЗАТЕЛЬНО! Для того чтобы снова осуществить подключение необходимо закрыть уже существующее
    reader.Close();
    sqlConnection.Close();

} catch{}
