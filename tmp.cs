using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class Way
{
    public List<string> names = new List<string>();
    public List<int> times = new List<int>();
    public List<int> prices = new List<int>();

    public List<Dictionary<string, List<string>>> places = new List<Dictionary<string, List<string>>>();
    public void addWaypoint(string name, int time, int price, Dictionary<string, List<string>> place)
    {
        names.Add(name);
        times.Add(time);
        prices.Add(price);
        places.Add(place);
    }
    // void buyTicket()
}
public class User
{
    public string login="";
    public string password="";
    public float balance=0;
    public string toString()
    {
        return $"{login}\n{password}\n{balance}";
    }
}
class HelloWorld
{
    public static List<Way> myWays = generateWays();
    public static List<User> users = new List<User>();
    static List<string> typeSeats = new List<string>() { "seats", "plats", "coupe", "luxe" };
    static Dictionary<string, List<string>> generatePlace(int countSeats, int countPlats, int countCoupe, int countLuxe)
    {
        typeSeats = new List<string>() { "seats", "plats", "coupe", "luxe" };
        // Console.WriteLine($"{1}");
        Dictionary<string, List<string>> places = new Dictionary<string, List<string>>();
        List<string> tmp = new List<string>();
        for (int i = 0; i < countSeats; ++i)
        {
            tmp.Add("");
        }
        // Console.WriteLine($"{2}");
        // Console.WriteLine($"{typeSeats.Count}");
        places.Add(typeSeats[0], tmp);
        // Console.WriteLine($"{typeSeats.Count}");
        places[typeSeats[1]] = new List<string>();
        for (int i = 0; i < countPlats; ++i)
        {
            places[typeSeats[1]].Add("");
        }
        places[typeSeats[2]] = new List<string>();
        for (int i = 0; i < countCoupe; ++i)
        {
            places[typeSeats[2]].Add("");
        }
        places[typeSeats[3]] = new List<string>();
        for (int i = 0; i < countLuxe; ++i)
        {
            places[typeSeats[3]].Add("");
        }
        return places;
    }
    public static void saveUsers()
    {
        if(!File.Exists("users.txt"))
        {
            File.Create("users.txt");
        }
        string data=$"{users.Count}\n";
        for(int i=0;i<users.Count;++i)
        {
            data+=($"{users[i].toString()}\n");
        }
        File.WriteAllText("users.txt",data);
    }
    public static void loadUsers()
    {
        users=new List<User>();
        if(!File.Exists("users.txt"))
        {
            return;
        }
        string[] lines=File.ReadAllText("users.txt").Split('\n');
        int index=1;
        int Count=lines.Length;
Console.WriteLine($"Count:{Count}");
        while(index<Count)
        {
            User newUser = new User();
            Console.WriteLine($"'{lines[index+0]}'{lines[index+1]}'{lines[index+2]}'");
            newUser.login=lines[index+0];
            newUser.password=lines[index+1];
            newUser.balance=float.Parse(lines[index+2]);
            users.Add(newUser);
            index+=3;
        }
    }
    static List<Way> generateWays()
    {
        List<Way> ways = new List<Way>();
        Way tmpWay = new Way();
        tmpWay.addWaypoint("Чёрный замок", 0, 0, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Последний очаг", 180, 1500, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Винтерфэл", 155, 1300, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Ров кейлин", 200, 1800, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Близнецы", 140, 1000, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Риверан", 70, 500, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Хайгарден", 80, 550, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Солнечное копьё", 120, 1000, generatePlace(18, 18, 12, 6));
        ways.Add(tmpWay);

        tmpWay = new Way();
        tmpWay.addWaypoint("Солнечное копьё", 0, 0, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Хайгарден", 120, 1000, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Риверан", 80, 550, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Близнецы", 70, 500, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Ров кейлин", 140, 1000, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Винтерфелл", 200, 1800, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Последний очаг", 155, 1300, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Чёрный замок", 180, 1500, generatePlace(18, 18, 12, 6));
        ways.Add(tmpWay);

        tmpWay = new Way();
        tmpWay.addWaypoint("Старомест", 0, 0, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Хайгарден", 120, 1000, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Эшворд", 80, 550, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Луговый дол", 70, 500, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Тамблтон", 140, 1000, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Королевская гавань", 200, 1800, generatePlace(18, 18, 12, 6));
        ways.Add(tmpWay);

        tmpWay = new Way();
        tmpWay.addWaypoint("Королевская гавань", 0, 0, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Тамблтон", 200, 1800, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Луговый дол", 140, 1000, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Эшворд", 70, 500, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Хайгарден", 80, 550, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Старомест", 120, 1000, generatePlace(18, 18, 12, 6));
        ways.Add(tmpWay);

        return ways;
        // void addWaypoint(string name,int time,int price,Dictionary<string,List<string>>place)
    }


    static void Main()
    {
        loadUsers();
        while (true)
        {
            Console.WriteLine("Привет, выбери роль");
            Console.WriteLine("1)Админ");
            Console.WriteLine("2)Клиент");
            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Console.WriteLine("Введите пароль админитратора(12345)");
                        if (Console.ReadLine() == "12345") doLikeAdmin();
                        break;
                    }
                case "2":
                    {
                        doLikeCLient();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("не понял");
                        break;
                    }


            }
            // Console.Clear();
        }

    }
    public static void printAminMenu()
    {
        Console.WriteLine("1)Добавить маршрут");
        Console.WriteLine("2)Удалить маршрут");
    }
    public static void printClientMenu()
    {
        Console.WriteLine("1)Посмотреть маршруты");
        Console.WriteLine("2)Купить билет(ы)");
        Console.WriteLine("3)Coming soon");
    }
    public static void doLikeAdmin()
    {
        Console.WriteLine("вы залогинились как Админ");
        printAminMenu();
        switch (Console.ReadLine())
        {
            case "1":
                {
                    adminAddWay();
                    break;
                }
            case "2":
                {
                    adminEraseWay();
                    break;
                }
            default:
                {

                    break;
                }
        }

    }
    public static bool checkLogin(string login)
    {
        foreach (User user in users)
        {
            if(user.login == login)
            {
                return true;
            }
        }
        return false;
    }
    public static bool clientCheckRegister(string login, string password)
    {
        foreach(User user in users)
        {
            if(user.login==login && user.password==password)
            {
                return true;
            }
        }
        Console.WriteLine("Не верный логин или пароль");
        return false;
    }
    public static string ClientRegistr()
    {
        Console.WriteLine("1)Регистрация");
        Console.WriteLine("2)Вход");
        switch(Console.ReadLine())
        {
            case "1":
            {
                User newUser = new User();
                Console.WriteLine("Введите логин");
                
                while(true)
                {
                    newUser.login=Console.ReadLine();
                    if (checkLogin(newUser.login))
                    {
                        Console.WriteLine("Логин уже занят");
                        Console.WriteLine("Введите логин");
                    }
                    else
                    {
                        
                        Console.WriteLine("Введите пароль");
                        newUser.password=Console.ReadLine();
                        users.Add(newUser);

                        Console.WriteLine("Успешная регистрация");
                        saveUsers();
                        return newUser.login;
                    }
                }

            }
            case "2":
            {
                
                Console.WriteLine("Введите логин");
                string name=Console.ReadLine();
                Console.WriteLine("Введите пароль");
                string password=Console.ReadLine();
                if(clientCheckRegister(name,password))
                {
                    return name;
                }
                else return "";
            }
            default:
            {
                return "";
            }
        }
    }
    public static void doLikeCLient()
    {
        if(ClientRegistr()=="")
        {
            return;
        }
        Console.WriteLine("вы залогинились как Клиент");
        printClientMenu();
        switch (Console.ReadLine())
        {
            case "1":
                {
                    showWays();
                    break;
                }
            case "2":
                {
                    buyTicket();
                    break;
                }
            //   case "3":
            //   {

            //     break;
            //   }
            default:
                {

                    break;
                }
        }

    }
    static void adminAddWay()
    {
        Way newWay = new Way();
        Console.WriteLine("Введите количество станций");
        int CountWayPoints=int.Parse(Console.ReadLine());
        Console.WriteLine("Введите количество сидячих мест");
        int CountSeatsSeats=int.Parse(Console.ReadLine());
        Console.WriteLine("Введите количество плацкартных мест");
        int CountPlatsSeats=int.Parse(Console.ReadLine());
        Console.WriteLine("Введите количество купешных мест");
        int CountCoupeSeats=int.Parse(Console.ReadLine());
        Console.WriteLine("Введите количество люксовых мест");
        int CountLuxeSeats=int.Parse(Console.ReadLine());
        for (int i=0;i<CountWayPoints;++i)
        {
            Console.WriteLine("Введите название станции");
            string name = Console.ReadLine();
            Console.WriteLine("Введите стоимость проезда от предыдущей станции");
            int price=int.Parse(Console.ReadLine());
            Console.WriteLine("Введите длительность проезда (в минутах) от предыдущей станции");
            int time=int.Parse(Console.ReadLine());
            newWay.addWaypoint(name,time,price,generatePlace(CountSeatsSeats,CountPlatsSeats,CountCoupeSeats,CountLuxeSeats));

            
        }
        myWays.Add(newWay);
    }
    static void adminEraseWay()
    {
        showWays();
        Console.WriteLine("Введите номер маршрута для удаления");
        int wayID = int.Parse(Console.ReadLine());
        myWays.RemoveAt(wayID);
    }

    static void showWays()
    {
        //   Console.WriteLine($"len ways:{myWays.Count}");
        for (int wayID = 0; wayID < myWays.Count; ++wayID)
        {
            Console.WriteLine("");
            Console.WriteLine($"маршрут№{wayID + 1}");

            for (int i = 0; i < myWays[wayID].names.Count; ++i)
            {
                Console.WriteLine(myWays[wayID].names[i]);
            }
        }
    }
    static void printWay(Way way, int i0 = 0)
    {
        for (int i = i0; i < way.names.Count; ++i)
        {
            Console.WriteLine($"{i + 1}: {way.names[i]}");
        }
    }
    static void printPlaces(Way way,int typeSeat, int i0, int i1)
    {
        List <string> MainList=new List<string>();
        for (int i=i0;i<i1;++i)
        {
            List<string>places=way.places[i][typeSeats[typeSeat]];
            for(int j=0;j<places.Count;++j)
            {
                if(MainList.Count<places.Count)
                {
                    MainList.Add("+");
                }
                if(places[j]!="")
                {
                    MainList[j]="-";
                }
            }
        }
        for(int i=0;i<MainList.Count;++i)
        {
            Console.Write(MainList[i] == "+" ? (i + 1 > 9 ? ($"{i + 1}") : ($" {i + 1}")) : "  ");
            
        }

    }
    static bool checkPlaces(Way way,int typeSeat, int i0, int i1,int numSeat)
    {
        List <string> MainList=new List<string>();
        for (int i=i0;i<i1;++i)
        {
            List<string>places=way.places[i][typeSeats[typeSeat]];
            for(int j=0;j<places.Count;++j)
            {
                if(MainList.Count<places.Count)
                {
                    MainList.Add("+");
                }
                if(places[j]!="")
                {
                    MainList[j]="-";
                }
            }
        }
        return (MainList[numSeat]=="+");

    }
    static void buyTicket()
    {
        showWays();
        Console.WriteLine("Введите номер маршрута");

        int wayId = int.Parse(Console.ReadLine()) - 1;
        Console.WriteLine("Выберите станцию отправления:");
        printWay(myWays[wayId]);
        int wayPoint1 = int.Parse(Console.ReadLine()) - 1;
        if (wayPoint1 < 0 || wayPoint1 > myWays[wayId].names.Count)
        {
            Console.WriteLine("Нет такой станции");
            return;
        }
        Console.WriteLine("Выберите станцию прибытия:");
        printWay(myWays[wayId], wayPoint1);

        int wayPoint2 = int.Parse(Console.ReadLine()) - 1;

        if (wayPoint1 < 0 || wayPoint1 > myWays[wayId].names.Count)
        {
            Console.WriteLine("Нет такой станции");
            return;
        }
        if (wayPoint2 <= wayPoint1)
        {
            Console.WriteLine("Не правильное направление движения. Посмотрите обратный маршрут");
            return;
        }
        Console.WriteLine("Введите тип мест");
        for(int i=0;i<typeSeats.Count;++i)
        {
            Console.WriteLine($"{i+1}) {typeSeats[i]}");
        }
        int typeSeat=int.Parse(Console.ReadLine())-1;
        if(typeSeat<0 || typeSeat >= typeSeats.Count)
        {
            Console.WriteLine("Неправильный тип мест");
            return;
        }
        Console.WriteLine("Введите количество билетов");
        int countPlaces = int.Parse(Console.ReadLine());
        for(int i=0;i<countPlaces;++i)
        {
            Console.WriteLine("Выбирете место");
            printPlaces(myWays[wayId], typeSeat ,wayPoint1, wayPoint2);
            int seatNum=int.Parse(Console.ReadLine())-1;
            if(!checkPlaces(myWays[wayId], typeSeat ,wayPoint1, wayPoint2,seatNum))
            {
                Console.WriteLine("Не правильное место");
                --i;
                continue;
            }
            Console.WriteLine("Введите имя пассажира");
            string name=Console.ReadLine();
            Console.WriteLine("Введите фамилию пассажира");
            string surname=Console.ReadLine();
            for(i=wayPoint1;i<wayPoint2;++i)
            {
                myWays[wayId].places[i][typeSeats[typeSeat]][seatNum]=name+" "+surname;
            }
        }
        //Console.WriteLine("Хотите ли вы купить")

        

    }

}




