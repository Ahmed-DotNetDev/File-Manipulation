class UserManagement
{
    private const string fileName = "Data.txt";

    public void createUser(int id, string username)
    {
        List<string> data = ReadFile();
        data.Add($"{id},{username}");
        WriteInFile(data);
    }

    public void delete(int id)
    {
        List<string> line = ReadFile();
        int index = FindUserIndexById(line, id);
        if (index != -1)
        {
            line.RemoveAt(index);
            WriteInFile(line);
        }
        else
        {
            System.Console.WriteLine("Not found !");
        }

    }

    private List<string> ReadFile()
    {
        List<string> listFiles = new List<string>();
        if (File.Exists(fileName))
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string? lines;
                while ((lines = reader.ReadLine()) != null)
                {
                    listFiles.Add(lines);
                }
            }
        }
        return listFiles;
    }
    private void WriteInFile(List<string> data)
    {
        using (StreamWriter s = new StreamWriter(fileName))
        {
            foreach (var item in data)
            {
                s.WriteLine(item);
            }
        }
    }

    public void getUserById(int id)
    {
        List<string> tempo = ReadFile();
        int index = FindUserIndexById(tempo, id);
        if (index != -1)
        {
            string[] args = tempo[index].Split(",");
            System.Console.WriteLine($"Id: {args[0]} username: {args[1]}");
        }
        else
        {
            System.Console.WriteLine("Not found !");
        }
    }

    private int FindUserIndexById(List<string> line, int id)
    {
        for (int i = 0; i < line.Count; i++)
        {
            string[] args = line[i].Split(",");
            if (int.Parse(args[0]) == id)
            {
                return i;
            }
        }
        return -1;
    }
    public void updateUser(int id)
    {
        List<string> line = ReadFile();
        int index = FindUserIndexById(line, id);
        if (index != -1)
        {
            string? username = Console.ReadLine();
            string[] args = line[index].Split(',');
            line[index] = $"{id},{username}";
            WriteInFile(line);
        }
        else
        {
            System.Console.WriteLine("Not found !");
        }

    }
}

class Program
{
    public static void Main(string[] args)
    {
        UserManagement userManagement = new UserManagement();
        System.Console.WriteLine("Enter 1 to create user");
        System.Console.WriteLine("Enter 2 to update user");
        System.Console.WriteLine("Enter 3 to get user");
        System.Console.WriteLine("Enter 4 to delete user");
        int option = Convert.ToInt32(Console.ReadLine());//1,2,3,4
        switch (option)
        {

            case 1:
                int id; string? username;
                id = Convert.ToInt32(Console.ReadLine());
                username = Console.ReadLine();
                userManagement.createUser(id, username);
                break;
            case 2:
                id = Convert.ToInt32(Console.ReadLine());
                username = Console.ReadLine();
                userManagement.updateUser(id);
                break;

            case 3:
                userManagement.getUserById(1);
                break;
            case 4:
                userManagement.delete(1);
                break;

        }
    }
}

