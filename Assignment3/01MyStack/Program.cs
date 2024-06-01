/* C# Assignment 03
    Introduction to C# and Data Types
    SEP Full Stack
    Timothy Yang
    May 29th, 2024
*/

/*
1. Describe the problem generics address.
    Generics address the problem of code duplication and type safety. They allow you to create classes, methods, and data structures that can operate on any data type without compromising type safety. This means you can write a generic class or method once and use it with different types, ensuring that you don't need to write multiple versions of the same class or method for different data types.
2. How would you create a list of strings, using the generic List class?
    You can create a list of strings using the generic List class like this:
        List<string> stringList = new List<string>();
3. How many generic type parameters does the Dictionary class have?
    The Dictionary class has two generic type parameters: TKey and TValue.
4. True/False. When a generic class has multiple type parameters, they must all match.
    False. When a generic class has multiple type parameters, they do not need to match. Each type parameter can represent a different data type.
5. What method is used to add items to a List object?
    The method used to add items to a List object is Add. For example:
        List<string> stringList = new List<string>();
        stringList.Add("example");
6. Name two methods that cause items to be removed from a List.
    Two methods that cause items to be removed from a List are Remove and RemoveAt.
        List<string> stringList = new List<string> { "one", "two", "three" };
        stringList.Remove("two");      // Removes the first occurrence of "two"
        stringList.RemoveAt(0);        // Removes the item at index 0 ("one")
7. How do you indicate that a class has a generic type parameter?
    You indicate that a class has a generic type parameter by using angle brackets (<>) after the class name with the type parameter inside the brackets. For example:
    public class MyGenericClass<T>
    {
        // Class implementation
    }
8. True/False. Generic classes can only have one generic type parameter.
    False. Generic classes can have multiple generic type parameters. For example:
    public class MyGenericClass<T1, T2>
    {
        // Class implementation
    }
9. True/False. Generic type constraints limit what can be used for the generic type.
    True. Generic type constraints limit what types can be used for the generic type, ensuring that the types meet certain criteria. For example:
    public class MyGenericClass<T> where T : IDisposable
    {
        // Class implementation
    }
10. True/False. Constraints let you use the methods of the thing you are constraining to.
    True. Constraints allow you to use the methods and properties of the type you are constraining to. For example, if you constrain a type to IDisposable, you can call the Dispose method on instances of that type.
*/

using System;

namespace CustomStack
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a stack of integers
            MyStack<int> intStack = new MyStack<int>();
            intStack.Push(1);
            intStack.Push(2);
            intStack.Push(3);

            Console.WriteLine("Count: " + intStack.Count());  // Output: Count: 3
            Console.WriteLine("Pop: " + intStack.Pop());      // Output: Pop: 3
            Console.WriteLine("Count: " + intStack.Count());  // Output: Count: 2

            // Create a stack of strings
            MyStack<string> stringStack = new MyStack<string>();
            stringStack.Push("Hello");
            stringStack.Push("World");

            Console.WriteLine("Count: " + stringStack.Count());  // Output: Count: 2
            Console.WriteLine("Pop: " + stringStack.Pop());      // Output: Pop: World
            Console.WriteLine("Count: " + stringStack.Count());  // Output: Count: 1
        }
    }
}
