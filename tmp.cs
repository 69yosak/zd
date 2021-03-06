using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class Way //Класс описывающий маршрут 
{
    public int ID; //айдишник маршрута
    public List<string> names = new List<string>();//Название станций
    public List<int> times = new List<int>();//Время пути от предыдущей до текущей
    public List<int> prices = new List<int>();//Цена
    public List<Dictionary<string, List<string>>> places = new List<Dictionary<string, List<string>>>();//Массив словарей массивов с местами (тип мест )


    public void addWaypoint(string name, int time, int price, Dictionary<string, List<string>> place)// Метод класса : добавить точку маршрута
    {
        names.Add(name);
        times.Add(time);
        prices.Add(price);
        places.Add(place);
    }
}
public class User// Класса описывающий пользователя
{
    public string login = "";
    public string password = "";
    public float balance = 0;
    public string toString()
    {
        return $"{login}\n{password}\n{balance}";
    }
}
class HelloWorld// Основной класс приложения
{
    public static int lastID = 0;
    public static List<Way> myWays = generateWays();
    public static List<User> users = new List<User>();
    public static List<string> typeSeats = new List<string>() { "Сидячие", "Плацкарт", "Купе", "Люкс" };
    public static List<List<string>> tickets = new List<List<string>>();

    public static void saveTickets()//Функция сохранения в фаил "Билетов"
    {
        createFile("tickets.txt");
        string data = $"{tickets.Count}\n";
        foreach (var ticket in tickets)
        {
            int id = 0;
            data += ticket[id] + '\n'; id++;//wayId
            data += ticket[id] + '\n'; id++;//login
            data += ticket[id] + '\n'; id++;//name
            data += ticket[id] + '\n'; id++;//surname
            data += ticket[id] + '\n'; id++;//typeSeat
            data += ticket[id] + '\n';      //place
        }
        File.WriteAllText("tickets.txt", data);

    }
    public static void loadTickets()//Фунция загрузки из файла "Билетов"
    {
        string[] lines = File.ReadAllText("tickets.txt").Split('\n');
        int index = 0;
        int count = int.Parse(lines[index]); ++index;
        for (int i = 0; i < count; ++i)
        {
            List<string> ticket = new List<string>();
            ticket.Add(lines[index]); ++index; //wayId
            ticket.Add(lines[index]); ++index; //login
            ticket.Add(lines[index]); ++index; //name
            ticket.Add(lines[index]); ++index; //surname
            ticket.Add(lines[index]); ++index; //typeSeat
            ticket.Add(lines[index]); ++index; //place
            tickets.Add(ticket);
        }

    }
    static Dictionary<string, List<string>> generatePlace(int countSeats, int countPlats, int countCoupe, int countLuxe)//Функция генерации пустого вагона
    {
        typeSeats = new List<string>() { "Сидячие", "Плацкарт", "Купе", "Люкс" };
        Dictionary<string, List<string>> places = new Dictionary<string, List<string>>();
        List<string> tmp = new List<string>();
        for (int i = 0; i < countSeats; ++i)
        {
            tmp.Add("");
        }
        places.Add(typeSeats[0], tmp);
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
    public static void saveUsers()//Функция сохранения в фаил "Пользователей"
    {
        if (!File.Exists("users.txt"))
        {
            File.Create("users.txt");

        }
        string data = $"{users.Count}\n";
        for (int i = 0; i < users.Count; ++i)
        {
            data += ($"{users[i].toString()}\n");
        }
        File.WriteAllText("users.txt", data);
    }
    public static void loadUsers()//Фунция загрузки из файла "Пользователей"
    {
        users = new List<User>();
        if (!File.Exists("users.txt"))
        {
            return;
        }
        string[] lines = File.ReadAllText("users.txt").Split('\n');
        int index = 1;
        int Count = lines.Length - 1;
        while (index < Count)
        {
            User newUser = new User();
            newUser.login = lines[index];
            newUser.password = lines[index + 1];
            newUser.balance = float.Parse(lines[index + 2]);
            users.Add(newUser);
            index += 3;
        }
    }

    static List<Way> generateWays()//Функция генерации маршрута
    {
        List<Way> ways = new List<Way>();
        Way tmpWay = new Way();
        tmpWay.ID = lastID; lastID++;
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
        tmpWay.ID = lastID; lastID++;
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
        tmpWay.ID = lastID; lastID++;
        tmpWay.addWaypoint("Старомест", 0, 0, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Хайгарден", 120, 1000, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Эшворд", 80, 550, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Луговый дол", 70, 500, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Тамблтон", 140, 1000, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Королевская гавань", 200, 1800, generatePlace(18, 18, 12, 6));
        ways.Add(tmpWay);

        tmpWay = new Way();
        tmpWay.ID = lastID; lastID++;
        tmpWay.addWaypoint("Королевская гавань", 0, 0, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Тамблтон", 200, 1800, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Луговый дол", 140, 1000, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Эшворд", 70, 500, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Хайгарден", 80, 550, generatePlace(18, 18, 12, 6));
        tmpWay.addWaypoint("Старомест", 120, 1000, generatePlace(18, 18, 12, 6));
        ways.Add(tmpWay);

        return ways;
    }
    public static void createFile(string name)//Функция создания файла если его нет  
    {
        if (!File.Exists(name))
        {

            File.Create(name);
        }
    }
    public static void saveWays()//Функция сохранения машрута в файл "ways.txt"
    {


        createFile("ways.txt");

        string data = $"{myWays.Count}\n";
        for (int wayID = 0; wayID < myWays.Count; ++wayID)
        {
            data += $"{myWays[wayID].ID}\n";
            data += $"{myWays[wayID].names.Count}\n";
            foreach (string name in myWays[wayID].names)
            {
                data += name + "\n";
            }
            foreach (int price in myWays[wayID].prices)
            {
                data += $"{price}\n";
            }
            foreach (int time in myWays[wayID].times)
            {
                data += $"{time}\n";
            }
            for (int tmp = 0; tmp < myWays[wayID].places.Count; ++tmp)
            {
                foreach (string typeSeat in typeSeats)
                {
                    data += $"{myWays[wayID].places[tmp][typeSeat].Count}\n";
                    foreach (string place in myWays[wayID].places[tmp][typeSeat])
                    {
                        data += $"{place}\n";
                    }
                }
            }

            File.WriteAllText("ways.txt", data);
        }
    }
    public static void loadWays()//Функция загрузки из файла "ways.txt"
    {
        if (!File.Exists("ways.txt"))
        {
            myWays = generateWays();
            saveWays();
            return;
        }
        myWays = new List<Way>();
        string[] lines = File.ReadAllText("ways.txt").Split('\n');
        int countWays = int.Parse(lines[0]);
        int index = 1;
        for (int numWay = 0; numWay < countWays; ++numWay)
        {
            Way newWay = new Way();
            newWay.ID = int.Parse(lines[index]); index++;
            int CountWayPoints = int.Parse(lines[index]); index++;
            for (int i = 0; i < CountWayPoints; ++i)
            {
                newWay.names.Add(lines[index]); index++;
            }
            for (int i = 0; i < CountWayPoints; ++i)
            {
                newWay.prices.Add(int.Parse(lines[index])); index++;
            }
            for (int i = 0; i < CountWayPoints; ++i)
            {
                newWay.times.Add(int.Parse(lines[index])); index++;
            }


            for (int i = 0; i < CountWayPoints; ++i)
            {
                Dictionary<string, List<string>> tmpPlace = new Dictionary<string, List<string>>();
                foreach (string typeSeat in typeSeats)
                {
                    int Count = int.Parse(lines[index]); index++;
                    List<string> tmpList = new List<string>();
                    for (int j = 0; j < Count; ++j)
                    {
                        tmpList.Add(lines[index]); index++;
                    }
                    tmpPlace.Add(typeSeat, tmpList);
                }
                newWay.places.Add(tmpPlace);
            }
            myWays.Add(newWay);
            if (newWay.ID > lastID) lastID = newWay.ID;
        }
    }
    static void Main()//Точка входа в приложение
    {
        loadUsers();
        loadWays();
        loadTickets();
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
                        if (Console.ReadLine() == "12345") while (doLikeAdmin()) { };
                        break;
                    }
                case "2":
                    {
                        Console.Clear();
                        doLikeCLient();
                        break;
                    }
                default:
                    {
                        Console.Clear();
                        Console.WriteLine("не понял");
                        break;
                    }


            }
            Console.Clear();
        }

    }
    public static void printAminMenu()//Меню админа
    {
        Console.WriteLine("1)Добавить маршрут");
        Console.WriteLine("2)Удалить маршрут");
        Console.WriteLine("3)Выйти из аккаунта");
    }
    public static void printClientMenu()//Меню клиента
    {
        Console.Clear();
        Console.WriteLine("1)Посмотреть маршруты");
        Console.WriteLine("2)Купить билет(ы)");
        Console.WriteLine("3)Посмотреть мои билеты");
        Console.WriteLine("4)Выйти из аккаунта");

    }
    public static bool doLikeAdmin()//Функиция в меню админа
    {

        Console.Clear();
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
            case "3":
                {
                    return false;
                }
            default:
                {

                    break;
                }
        }
        return true;

    }
    public static bool checkLogin(string login)//Функция создания логина
    {
        foreach (User user in users)
        {
            if (user.login == login)
            {
                return true;
            }
        }
        return false;
    }
    public static bool clientCheckRegister(string login, string password)//Функция проверяющая логин и пароль
    {
        foreach (User user in users)
        {
            if (user.login == login && user.password == password)
            {
                return true;
            }
        }
        Console.WriteLine("Не верный логин или пароль");
        return false;
    }
    public static string ClientRegistr()//Функия регистрации пользователей
    {
        Console.WriteLine("Выберите тип авторизации");
        Console.WriteLine("1)Регистрация");
        Console.WriteLine("2)Вход");
        switch (Console.ReadLine())
        {
            case "1":
                {
                    User newUser = new User();
                    Console.WriteLine("Введите логин");

                    while (true)
                    {
                        newUser.login = Console.ReadLine();
                        if (checkLogin(newUser.login))
                        {
                            Console.WriteLine("Логин уже занят");
                            Console.WriteLine("Введите логин");
                        }
                        else
                        {

                            Console.WriteLine("Введите пароль");
                            newUser.password = Console.ReadLine();
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
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите пароль");
                    string password = Console.ReadLine();
                    if (clientCheckRegister(name, password))
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
    //                                            0                1           2         3               4               5
    static public List<string> generateTicket(int wayId, string login, string name, string surname, int typeSeat, string place)//Функция генерации билетов
    {
        return new List<string>()
        {
            $"{wayId}",
            login,
            name,
            surname,
            $"{typeSeat}",
            place
        };
    }

    public static string TicketToString(List<string> ticket)//Функция для отображения купленых билетов
    {
        return "Тип мест: " + typeSeats[int.Parse(ticket[4])] + ", Места: " + ticket[5] + ", Имя: " + ticket[2] + ", Фамилия: " + ticket[3];
    }

    public static void doLikeCLient()//Меню залогиневшегося клиента
    {
        string login = ClientRegistr();
        if (login == "")
        {
            return;
        }
        Console.Clear();
        Console.WriteLine("вы залогинились как Клиент");
        while (true)
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
                        List<List<string>> list = new List<List<string>>();
                        foreach (var ticket in tickets)
                        {
                            if (ticket[1] == login)
                            {
                                list.Add(ticket);
                            }
                        }
                        string data = "";
                        foreach (var ticket in list)
                        {
                            data += TicketToString(ticket) + "\n";
                        }
                        Console.Write(data);
                        if (list.Count == 0)
                        {
                            Console.WriteLine("У вас нет билетов");
                        }
                        Console.WriteLine("Напишите что угодно");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                case "4":
                    {
                        return;
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
    static void adminAddWay()//Функция для создание собственных маршрутов
    {
        Way newWay = new Way();
        newWay.ID = ++lastID;
        Console.WriteLine("Введите количество станций");
        int CountWayPoints = inputInt();
        if (CountWayPoints < 2) { Console.WriteLine("Неправильное количество станций. Должно быть >1"); return; }
        Console.WriteLine("Введите количество сидячих мест");
        int CountSeatsSeats = inputInt();
        Console.WriteLine("Введите количество плацкарт-мест");
        int CountPlatsSeats = inputInt();
        Console.WriteLine("Введите количество купе-мест");
        int CountCoupeSeats = inputInt();
        Console.WriteLine("Введите количество люкс-мест");
        int CountLuxeSeats = inputInt();
        for (int i = 0; i < CountWayPoints; ++i)
        {
            Console.WriteLine("Введите название станции");
            string name = Console.ReadLine();
            Console.WriteLine("Введите стоимость билета до следующей станции");
            int price = inputInt();
            Console.WriteLine("Введите длительность пути (в минутах) от предыдущей станции");
            int time = inputInt();
            newWay.addWaypoint(name, time, price, generatePlace(CountSeatsSeats, CountPlatsSeats, CountCoupeSeats, CountLuxeSeats));


        }
        myWays.Add(newWay);

        saveWays();
    }
    static void adminEraseWay()//Функция удаления маршрутов
    {
        showWays();
        Console.WriteLine("Введите номер маршрута для удаления или -1 для выхода");
        int wayID = inputInt() - 1;
        Console.WriteLine($"Вы Написали {wayID + 1}");
        if (wayID < 0 || wayID >= myWays.Count)
        {
            Console.WriteLine($"Не правильный номер маршрута{1}-{myWays.Count}");
            Console.WriteLine();
            return;
        }
        myWays.RemoveAt(wayID);
        saveWays();
    }
    static int inputInt()//Функция для проверки введеных значений 
    {
        while (true)
        {
            int answer;
            bool isSuccess = int.TryParse(Console.ReadLine(), out answer);
            if (isSuccess)
            {
                return answer;
            }
            else
            {
                Console.WriteLine("Нужно ввести целое число");
            }
        }
        return 0;
    }
    static void showWays()//Функция для просмотра маршрутов
    {
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
    static void printWay(Way way, int i0 = 0)//Функция отображения маршрутов 
    {
        for (int i = i0; i < way.names.Count; ++i)
        {
            Console.WriteLine($"{i + 1}: {way.names[i]}");
        }
    }
    static void printPlaces(Way way, int typeSeat, int i0, int i1)//Функция отображение мест 
    {
        List<string> MainList = new List<string>();
        for (int i = i0; i < i1; ++i)
        {
            List<string> places = way.places[i][typeSeats[typeSeat]];
            for (int j = 0; j < places.Count; ++j)
            {
                if (MainList.Count < places.Count)
                {
                    MainList.Add("+");
                }
                if (places[j] != "")
                {
                    MainList[j] = "-";
                }
            }
        }
        for (int i = 0; i < MainList.Count; ++i)
        {
            Console.Write(MainList[i] == "+" ? (i + 1 > 9 ? ($"{i + 1}") : ($" {i + 1}")) : "  ");
            Console.Write(" ");
        }
        Console.Write("\n");

    }
    static int countPlacesMayBuy(Way way, int typeSeat, int i0, int i1)//Функция проверки на свободные места 
    {
        int answer = 0;
        int countSeats = way.places[0][typeSeats[typeSeat]].Count;
        for (int i = 0; i < countSeats; ++i)
        {
            answer += checkPlaces(way, typeSeat, i0, i1, i) ? 1 : 0;
        }
        return answer;
    }
    static bool checkPlaces(Way way, int typeSeat, int i0, int i1, int numSeat)//Функция проверки на свободные места на определеных станциях
    {
        List<string> MainList = new List<string>();
        for (int i = i0; i < i1; ++i)
        {
            List<string> places = way.places[i][typeSeats[typeSeat]];
            for (int j = 0; j < places.Count; ++j)
            {
                if (MainList.Count < places.Count)
                {
                    MainList.Add("+");
                }
                if (places[j] != "")
                {
                    MainList[j] = "-";
                }
            }
        }
        return (MainList[numSeat] == "+");

    }
    static void giveCashBack(string login, float summ)//Функция начисления кешбека
    {
        foreach (User user in users)
        {
            if (user.login == login)
            {
                user.balance += summ;
            }
        }
    }
    static float getCashBack(string login)//Функция количества баллов на счете
    {
        float answer = 0;
        foreach (User user in users)
        {
            if (user.login == login)
            {
                answer = user.balance;
            }
        }
        return answer;
    }
    static void setCashBack(string login, float summ)//Функция оплаты баллами 
    {
        foreach (User user in users)
        {
            if (user.login == login)
            {
                user.balance = summ;
            }
        }
    }
    static void buyTicket(string login)//Функция для взаимодействия с билетами
    {
        showWays();
        Console.WriteLine("Введите номер маршрута");

        int wayId = inputInt() - 1;
        if (wayId < 0 || wayId >= myWays.Count)
        {
            Console.WriteLine("Не правильный номер маршрута");
            Console.WriteLine("Введите что угодно");
            Console.ReadLine();
            Console.Clear();
            return;
        }
        Console.Clear();

        Console.WriteLine("Выберите станцию отправления:");
        printWay(myWays[wayId]);
        int wayPoint1 = inputInt() - 1;
        if (wayPoint1 < 0 || wayPoint1 > myWays[wayId].names.Count)
        {
            Console.WriteLine("Нет такой станции");
            Console.WriteLine("Введите что угодно");
            Console.ReadLine();
            Console.Clear();
            return;
        }
        Console.Clear();
        Console.WriteLine("Выберите станцию прибытия:");
        printWay(myWays[wayId], wayPoint1 + 1);

        int wayPoint2 = inputInt() - 1;

        if (wayPoint1 < 0 || wayPoint1 > myWays[wayId].names.Count)
        {
            Console.WriteLine("Нет такой станции");
            Console.WriteLine("Введите что угодно");
            Console.ReadLine();
            Console.Clear();
            return;
        }
        if (wayPoint2 <= wayPoint1)
        {
            Console.WriteLine("Не правильное направление движения. Посмотрите обратный маршрут");
            Console.WriteLine("Введите что угодно");
            Console.ReadLine();
            Console.Clear();
            return;
        }
        Console.Clear();
        Console.WriteLine("Введите тип мест");
        for (int i = 0; i < typeSeats.Count; ++i)
        {
            Console.WriteLine($"{i + 1}) {typeSeats[i]}(Свободно: {countPlacesMayBuy(myWays[wayId], i, wayPoint1, wayPoint2)})");
        }

        int typeSeat = inputInt() - 1;
        Console.WriteLine("Введите количество билетов");
        int countPlaces = inputInt();


        if (typeSeat < 0 || typeSeat >= typeSeats.Count)
        {
            Console.WriteLine("Неправильный тип мест");
            Console.WriteLine("Введите что угодно");
            Console.ReadLine();
            Console.Clear();
            return;
        }
        Console.Clear();
        bool cond = false;
        int tmpWayPoint = -1;
        int tmpTypeSeat = -1;

        if (countPlacesMayBuy(myWays[wayId], typeSeat, wayPoint1, wayPoint2) < countPlaces)
        {

            for (tmpWayPoint = wayPoint1 + 1; tmpWayPoint < wayPoint2; ++tmpWayPoint)
            {
                if (countPlacesMayBuy(myWays[wayId], typeSeat, tmpWayPoint, wayPoint2) >= countPlaces)
                {
                    for (tmpTypeSeat = typeSeat - 1; tmpTypeSeat >= 0; --tmpTypeSeat)
                    {
                        if (countPlacesMayBuy(myWays[wayId], tmpTypeSeat, wayPoint1, tmpWayPoint) >= countPlaces)
                        {
                            cond = true;
                            break;
                        }
                    }
                    if (cond) break;
                }
            }
            if (cond)
            {
                Console.WriteLine("Есть Альтернатива");
                Console.WriteLine("1)Посмотреть");
                Console.WriteLine("2)Не интересно");

                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            Console.WriteLine($"{myWays[wayId].names[wayPoint1]}-{myWays[wayId].names[tmpWayPoint]} ({typeSeats[tmpTypeSeat]})\n{myWays[wayId].names[tmpWayPoint]}-{myWays[wayId].names[wayPoint2]} ({typeSeats[typeSeat]})");
                            Console.WriteLine("1)Согласиться");
                            Console.WriteLine("2)Не согласиться");
                            if (Console.ReadLine() != "1")
                            {
                                Console.WriteLine("Хорошо");
                                if (countPlacesMayBuy(myWays[wayId], typeSeat, wayPoint1, wayPoint2) < countPlaces)
                                {
                                    Console.WriteLine("Столько мест нет");
                                    Console.WriteLine("Введите что угодно");
                                    Console.ReadLine();
                                    Console.Clear();
                                    return;
                                }
                            }

                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Хорошо");
                            if (countPlacesMayBuy(myWays[wayId], typeSeat, wayPoint1, wayPoint2) < countPlaces)
                            {
                                Console.WriteLine("Столько мест нет");
                                Console.WriteLine("Введите что угодно");
                                Console.ReadLine();
                                Console.Clear();
                                return;
                            }
                            break;
                        }
                }
            }
            else
            {
                Console.WriteLine("Столько мест нет");
                Console.WriteLine("Введите что угодно");
                Console.ReadLine();
                Console.Clear();
                return;
            }
        }

        float priceTrip = 0;
        if (cond == true && tmpWayPoint != -1 && tmpTypeSeat != -1)
        {
            Console.WriteLine($"Сначала выбираем места типа {typeSeats[tmpTypeSeat]}");
            for (int i = 0; i < countPlaces; ++i)
            {

                Console.WriteLine("Выбирете место");
                printPlaces(myWays[wayId], tmpTypeSeat, wayPoint1, tmpWayPoint);
                int seatNum = inputInt() - 1;
                if (!checkPlaces(myWays[wayId], tmpTypeSeat, wayPoint1, tmpWayPoint, seatNum))
                {
                    Console.WriteLine("Не правильное место");
                    --i;
                    continue;
                }
                Console.WriteLine("Введите имя пассажира");
                string name = Console.ReadLine();
                Console.WriteLine("Введите фамилию пассажира");
                string surname = Console.ReadLine();
                for (int j = wayPoint1; j < wayPoint2; ++j)
                {
                    myWays[wayId].places[j][typeSeats[tmpTypeSeat]][seatNum] = name + " " + surname;
                    priceTrip += (float)(myWays[wayId].prices[j + 1] * Math.Pow(1.5, tmpTypeSeat));
                }
                tickets.Add(generateTicket(wayId, login, name, surname, tmpTypeSeat, $"{wayPoint1 + 1}-{tmpWayPoint + 1}"));
                saveTickets();
                Console.Clear();

            }
            Console.Clear();
            Console.WriteLine($"Теперь выбираем места типа {typeSeats[typeSeat]}");
            for (int i = 0; i < countPlaces; ++i)
            {

                Console.WriteLine("Выбирете место");
                printPlaces(myWays[wayId], typeSeat, tmpWayPoint, wayPoint2);
                int seatNum = inputInt() - 1;
                if (!checkPlaces(myWays[wayId], typeSeat, tmpWayPoint, wayPoint2, seatNum))
                {
                    Console.WriteLine("Не правильное место");
                    --i;
                    continue;
                }
                Console.WriteLine("Введите имя пассажира");
                string name = Console.ReadLine();
                Console.WriteLine("Введите фамилию пассажира");
                string surname = Console.ReadLine();
                for (int j = wayPoint1; j < wayPoint2; ++j)
                {
                    myWays[wayId].places[j][typeSeats[typeSeat]][seatNum] = name + " " + surname;
                    priceTrip += (float)(myWays[wayId].prices[j + 1] * Math.Pow(1.5, typeSeat));
                }
                tickets.Add(generateTicket(wayId, login, name, surname, typeSeat, $"{tmpWayPoint + 1}-{wayPoint2 + 1}"));
                saveTickets();

                Console.Clear();

            }
        }
        else
        {
            for (int i = 0; i < countPlaces; ++i)
            {

                Console.WriteLine("Выбирете место");
                printPlaces(myWays[wayId], typeSeat, wayPoint1, wayPoint2);
                int seatNum = inputInt() - 1;
                if (!checkPlaces(myWays[wayId], typeSeat, wayPoint1, wayPoint2, seatNum))
                {
                    Console.WriteLine("Не правильное место");
                    --i;
                    continue;
                }
                Console.WriteLine("Введите имя пассажира");
                string name = Console.ReadLine();
                Console.WriteLine("Введите фамилию пассажира");
                string surname = Console.ReadLine();
                for (int j = wayPoint1; j < wayPoint2; ++j)
                {
                    myWays[wayId].places[j][typeSeats[typeSeat]][seatNum] = name + " " + surname;
                    priceTrip += (float)(myWays[wayId].prices[j + 1] * Math.Pow(1.5, typeSeat));
                }
                tickets.Add(generateTicket(wayId, login, name, surname, typeSeat, $"{wayPoint1 + 1}-{wayPoint2 + 1}"));
                saveTickets();
                Console.Clear();
            }

        }

        Console.Clear();
        Console.WriteLine("Хотите ли вы доп. услуги?"); //Функция доп услуг
        Console.WriteLine("1)Да");
        Console.WriteLine("2)Нет");

        switch (Console.ReadLine())
        {
            case "1":
                {
                    Console.WriteLine("Хотите ли вы заказать питание?");
                    Console.WriteLine("1)Да");
                    Console.WriteLine("2)Нет");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            {
                                priceTrip += 2000;
                                Console.WriteLine("Еда заказана");
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Хорошо");
                                break;
                            }
                    }
                    Console.WriteLine("Хотите ли вы заказать трансфер до вокзала?");//Функция работы трансфера
                    Console.WriteLine("1)Да");
                    Console.WriteLine("2)Нет");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            {
                                priceTrip += 3000;
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

        Console.Clear();
        float cashBack = getCashBack(login);
        if (cashBack > 0)
        {
            Console.WriteLine($"У вас есть {cashBack} баллов. Списать?");
            Console.WriteLine("1)Да");
            Console.WriteLine("2)Нет");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        if (cashBack < priceTrip)
                        {
                            cashBack = 0;
                            priceTrip -= cashBack;
                        }
                        else
                        {
                            cashBack -= priceTrip;
                            priceTrip = 0;
                        }
                        break;
                    }
            }
        }

        setCashBack(login, cashBack);
        giveCashBack(login, priceTrip * (float)0.1);
        Console.WriteLine($"Вы потратили {priceTrip} рублей, у вас есть {getCashBack(login)} баллов");
        saveUsers();
        saveWays();
        Console.WriteLine("Введите что угодно");
        Console.ReadLine();
        Console.Clear();

    }

}




