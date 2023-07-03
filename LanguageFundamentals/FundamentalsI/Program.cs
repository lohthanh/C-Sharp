// for (int i = 1; i <= 255; i++)
// {
//     Console.WriteLine(i);
// }

Random rand = new Random();

// for (int i = 1; i <=5; i++)
// {
//     Console.WriteLine(rand.Next(10,21));
// }

// int sum = 0;
// int random = 0;
// for (int i = 1; i <=5; i++)
// {
//    random = rand.Next(10, 21);
//    sum += random;
// //    Console.WriteLine(random);
// }
// Console.WriteLine(sum);

// for (int i = 1; i < 101; i++)
// {
//     if (i % 3 == 0 || i % 5 == 0) {
//         Console.WriteLine(i);
//     }
// }

// for (int i = 1; i < 101; i++)
// {
//     if (i % 3 == 0) {
//         Console.WriteLine("Fizz");
//     }
//     if (i % 5 == 0) {
//         Console.WriteLine("Buzz");
//     }
// }

// for (int i = 1; i < 101; i++)
// {
//     if (i % 3 == 0) {
//         Console.WriteLine("Fizz");
//     }
//     if (i % 5 == 0) {
//         Console.WriteLine("Buzz");
//     }
//     if (i % 3 == 0 && i % 5 == 0) {
//         Console.WriteLine("FizzBuzz");
//     }
// }

int i = 1;
while (i < 101)
{
    if (i % 3 == 0) {
        Console.WriteLine("Fizz");
    }
    if (i % 5 == 0) {
        Console.WriteLine("Buzz");
    }
    if (i % 3 == 0 && i % 5 == 0) {
        Console.WriteLine("FizzBuzz");
    }
    i++;
}