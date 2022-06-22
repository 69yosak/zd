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
    static List<string> typeSeats = new List<string>() { "Сидячие", "Плацкарт", "Купе", "Люкс" };
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
        int Count=lines.Length-1;
        while(index<Count)
        {
            User newUser = new User();
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
    public static void saveWays()
    {
        if(!File.Exists("ways.txt"))
        {
            File.Create("ways.txt");
        }
        string data=$"{myWays.Count}\n";
        for(int wayID=0;wayID<myWays.Count;++wayID)
        {
            data+=$"{myWays[wayID].names.Count}\n";
            foreach(string name in myWays[wayID].names)
            {
                data+=name+"\n";
            }
            foreach(int price in myWays[wayID].prices)
            {
                data+=$"{price}\n";
            }
            foreach(int time in myWays[wayID].times)
            {
                data+=$"{time}\n";
            }
            for (int tmp=0;tmp<myWays[wayID].places.Count;++tmp)
            {
                foreach(string typeSeat in typeSeats)
                {
                    data+=$"{myWays[wayID].places[tmp][typeSeat].Count}\n";
                    foreach(string place in myWays[wayID].places[tmp][typeSeat])
                    {
                        data+=$"{place}\n";
                    }
                }
            }

        File.WriteAllText("ways.txt",data);
        }
    }
    public static void loadWays()
    {
        if(!File.Exists("users.txt"))
        {
            myWays=generateWays();
            return;
        }
        myWays=new List<Way>();
        string[] lines=File.ReadAllText("ways.txt").Split('\n');
        int countWays=int.Parse(lines[0]);
        int index=1;
        for(int numWay=0;numWay<countWays;++numWay)
        {
            Way newWay=new Way();
            int CountWayPoints=int.Parse(lines[index]);index++;
            for(int i=0;i<CountWayPoints;++i)
            {
                newWay.names.Add(lines[index]);index++;
            }
            for(int i=0;i<CountWayPoints;++i)
            {
                newWay.prices.Add(int.Parse(lines[index]));index++;
            }
            for(int i=0;i<CountWayPoints;++i)
            {
                newWay.times.Add(int.Parse(lines[index]));index++;
            }
            

            for(int i=0;i<CountWayPoints;++i)
            {
                Dictionary<string,List<string>> tmpPlace = new Dictionary<string, List<string>>();
                foreach(string typeSeat in typeSeats)
                {
                    int Count = int.Parse(lines[index]);index++;
                    List<string> tmpList=new List<string>();
                    for(int j =0;j<Count;++j)
                    {
                        tmpList.Add(lines[index]);index++;
                    }
                    tmpPlace.Add(typeSeat,tmpList);
                }
                newWay.places.Add(tmpPlace);
            }
            myWays.Add(newWay);
        }
    }
    static void Main()
    {
        loadUsers();
        loadWays();
        //showWays();
        // saveWays();
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
                        if (Console.ReadLine() == "12345") while(true) doLikeAdmin();
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
        Console.WriteLine("вы вошли как Админ");
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
        string login=ClientRegistr();
        if(login=="")
        {
            return;
        }
        Console.WriteLine("вы залогинились как Клиент");
        while(true)
        {
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
                        buyTicket(login);
                        break;
                    }
                case "3":
                {
                    Console.WriteLine("Личный кабинет в разработке");
                    break;
                }
                default:
                    {
                        return;
                        break;
                    }
            }
        }

    }
    static void adminAddWay()
    {
        Way newWay = new Way();
        Console.WriteLine("Введите количество станций");
        int CountWayPoints=int.Parse(Console.ReadLine());
        if(CountWayPoints<2){Console.WriteLine("Неправильное количество станций. Должно быть >1");return;}
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

        saveWays();
    }
    static void adminEraseWay()
    {
        showWays();
        Console.WriteLine("Введите номер маршрута для удаления");
        int wayID = int.Parse(Console.ReadLine())-1;
        Console.WriteLine($"Вы Написали {wayID+1}");
        if(wayID<1||wayID>=myWays.Count)
        {
            Console.WriteLine($"Не правильный номер маршрута{1}-{myWays.Count}");
            Console.WriteLine();
            return;
        }
        myWays.RemoveAt(wayID);
        saveWays();
    }

    static void showWays()
    {
        //   Console.WriteLine($"len ways:{myWays.Count}");
        for (int wayID = 0; wayID < myWays.Count; ++wayID)
        {
            Console.WriteLine("");
            Console.WriteLine($"Маршрут №{wayID + 1}");

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
            Console.Write(" ");
        }
        Console.Write("\n");

    }
    static int countPlacesMayBuy(Way way,int typeSeat, int i0, int i1)
    {
        int answer=0;
        int countSeats=way.places[0][typeSeats[typeSeat]].Count;
        for(int i=0;i<countSeats;++i)
        {
            answer+= checkPlaces(way,typeSeat, i0,i1,i) ? 1 : 0 ;
        }
        return answer;
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
    static void giveCashBack(string login,float summ)
    {
        foreach(User user in users)
        {
            if(user.login==login)
            {
                user.balance+=summ;
            }
        }
    }
    static float getCashBack(string login)
    {
        float answer=0;
        foreach(User user in users)
        {
            if(user.login==login)
            {
                answer=user.balance;
            }
        }
        return answer;
    }
    static void setCashBack(string login,float summ)
    {
        foreach(User user in users)
        {
            if(user.login==login)
            {
                user.balance=summ;
            }
        }
    }
    static void buyTicket(string login)
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
            Console.WriteLine($"{i+1}) {typeSeats[i]}(Свободно{countPlacesMayBuy(myWays[wayId],i,wayPoint1,wayPoint2)})");
        }
        int typeSeat=int.Parse(Console.ReadLine())-1;
        if(typeSeat<0 || typeSeat >= typeSeats.Count || countPlacesMayBuy(myWays[wayId],typeSeat,wayPoint1,wayPoint2)==0)
        {
            Console.WriteLine("Неправильный тип мест");
            return;
        }
        Console.WriteLine("Введите количество билетов");
        int countPlaces = int.Parse(Console.ReadLine());
        if(countPlacesMayBuy(myWays[wayId],typeSeat,wayPoint1,wayPoint2)<countPlaces)
        {
            Console.WriteLine("Столько мест нет");
            return;
        }
        float priceTrip=0;
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
            for(int j=wayPoint1;j<wayPoint2;++j)
            {
                myWays[wayId].places[j][typeSeats[typeSeat]][seatNum]=name+" "+surname;
                priceTrip+=myWays[wayId].prices[j+1];
            }
            //Console.WriteLine($"");
        }
        Console.WriteLine("Хотите ли вы доп. услуги?");
        Console.WriteLine("1)Да");
        Console.WriteLine("2)Нет");

        switch(Console.ReadLine())
        {
            case "1":
            {
                Console.WriteLine("Хотите ли вы заказать питание?");
                Console.WriteLine("1)Да");
                Console.WriteLine("2)Нет");
                switch(Console.ReadLine())
                {
                    case "1":
                    {
                        priceTrip+=2000;
                        Console.WriteLine("Еда заказана");
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Хорошо");
                        break;
                    }
                }
                Console.WriteLine("Хотите ли вы заказать трансфер до вокзала?");
                Console.WriteLine("1)Да");
                Console.WriteLine("2)Нет");
                switch(Console.ReadLine())
                {
                    case "1":
                    {
                        priceTrip+=3000;
                        Console.WriteLine("Трансфер заказан");
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Хорошо");
                        break;
                    }
                }
                
                
                break;
            }
            default:
            {
                Console.WriteLine("хорошо");
                break;
            }
            
        }

        float cashBack=getCashBack(login);
                if(cashBack>0)
                {
                    Console.WriteLine($"У вас есть {cashBack} баллов. Списать?");
                    Console.WriteLine("1)Да");
                    Console.WriteLine("2)Нет");

                    switch(Console.ReadLine())
                    {
                        case "1":
                        {
                            if(cashBack < priceTrip)
                            {
                                cashBack=0;
                                priceTrip-=cashBack;
                            }
                            else
                            {
                                cashBack-=priceTrip;
                                priceTrip=0;
                            }
                            break;
                        }
                    }
                }
                setCashBack(login,cashBack);
                giveCashBack(login,priceTrip*(float)0.1);
                Console.WriteLine($"Вы потратили {priceTrip} рублей, у вас есть {getCashBack(login)} баллов");
                saveUsers();
                saveWays();

    }

}




