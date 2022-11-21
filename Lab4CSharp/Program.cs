using Lab4CSharp;
Console.WriteLine("Lab4 C# (Demenchuk dmytro)");

task1();
task2();
task3();

GC.Collect();

Console.WriteLine("The end Testing");


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

    var v1 = new VectorLong(5, 1);
    var v2 = new VectorLong(5, 3);

    v1.printVectorWithStartStrOrDefoult("v1 = ");
    v2.printVectorWithStartStrOrDefoult("v2 = ");

    v1 += v2;
    v1.printVectorWithStartStrOrDefoult("\nv1 += v2: ");
    v1.printVectorWithStartStrOrDefoult("v1 = ");
    
    v2 -= v1;
    v2.printVectorWithStartStrOrDefoult("\nv2 -= v1: ");

    (v2++).printVectorWithStartStrOrDefoult("\nv2++: ");

    if (v2)
        Console.WriteLine("\n(v2): є не нульові елементи\n");
    else Console.WriteLine("\n(v2): всi елементи нульові\n");

    if (v1)
        Console.WriteLine("\n(v1): є не нульові елементи\n");
    else Console.WriteLine("\n(v1): всi елементи нульові\n");

    Console.WriteLine(VectorLong.countNumOfVectors());
}
void task3()
{
    Console.WriteLine("Task 3 Tests:");

    var v1 = new MatrixLong(2, 2, 5);
    var v2 = new MatrixLong(2, 2, 2);

    v1.printVectorWithStartStrOrDefoult("v1 = ");
    v2.printVectorWithStartStrOrDefoult("v2 = ");

    v1 += v2;
    v1.printVectorWithStartStrOrDefoult("\nv1 += v2: ");
    v1.printVectorWithStartStrOrDefoult("v1 = ");

    v2 -= v1;
    v2.printVectorWithStartStrOrDefoult("\nv2 -= v1: ");

    (v2++).printVectorWithStartStrOrDefoult("\nv2++: ");

    if (v2)
        Console.WriteLine("\n(v2): є не нульові елементи\n");
    else Console.WriteLine("\n(v2): всi елементи нульові\n");

    if (v1)
        Console.WriteLine("\n(v1): є не нульові елементи\n");
    else Console.WriteLine("\n(v1): всi елементи нульові\n");

    Console.WriteLine(MatrixLong.countNumOfVectors());
}