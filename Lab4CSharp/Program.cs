using Lab4CSharp;
Console.WriteLine("Lab4 C# (Demenchuk dmytro)");

//task1();
task2();
task3();







void task1()
{
    Console.WriteLine("Task 1 Tests:");

    Money money = (Money)"1 3";
    string str = money;

    Console.WriteLine(str);
    Console.WriteLine(money);

    Console.WriteLine(money + money++);
    Console.WriteLine(money - ++money);

    money[1] = 0;
    Console.WriteLine(!money);
}
void task2()
{
    Console.WriteLine("Task 2 Tests:");
}
void task3()
{
    Console.WriteLine("Task 3 Tests:");
}
