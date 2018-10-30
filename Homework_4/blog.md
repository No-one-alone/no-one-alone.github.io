## Homework 4

For the fourth homework, we had to learn the basics of the ASP.NET MVC 5 platform, along with how to use the HTTP GET and POST requests for webpages of the app that respond to user input with output. This involved using query strings and passing the information using the GET and POST reqests. Furthermore, we had to learn about Views and Controllers and the use of the related ViewBag and Request dynamic objects inherent to the Model-View-Controller paradigm. Finally, we learned the basics of applying the language of the Razor HTML helpers as useful constructs to aid our development of the web app.


### Homework 4 Links
1. [Home page](https://no-one-alone.github.io/)
2. [Assignment Page](http://www.wou.edu/~morses/classes/cs46x/assignments/HW4_1819.html)
3. [Code Repository](https://github.com/No-one-alone/no-one-alone.github.io)
4. [Final Video Demo](https://www.youtube.com/watch?v=vVG3dyfr420&feature=youtu.be)
5. [demo](./Homework_4/Homework_4/Views/Home/Index.cshtml)

### Part 1: Attack of the Git

No new commands were learned this week; however, we did have to learn as part of using the Visual Studio IDE to add a file called the following to the root of our git repository.

``` 
    .gitignore
```

This was necessary as without this file, we would end up with a large collection of files all demanding to be added to the repository when we issued a "git add ." command as part of the Visual Studio console app creation. The file itself was generated automatically but not quite painlessly using Visual Studio automatic features when creating a new project file.

### Part 2: Visual Studio IDE

I downloaded the Visual Studio program from [here](https://visualstudio.microsoft.com/vs/)

### Part 3: Translating a Java binary number generator program into an equivalent C# program and notes on important language features.

As per the assignment directions, I downloaded the "javacode2.zip" file from the homework#3 assignment page which contained the following five files which made up the java program.

```
Node.java
QueueInterface.java
QueueUnderflowException.java 
LinkedQueue.java 
Main.java
```

The program served and behaved as a binary number list generator with the number of entries determined by a user supplied number (see bottom of webpage for program output and behavior) via the following command:

```
java Main 12
```

We were advised to recode or implement these classes into C# versions and the appropriate dialect of "C-sharpese" in this order:

```
1. Node.java ⟶ Node.cs
2. QueueInterface.java ⟶ ?.cs
3. QueueUnderflowException.java ⟶ QueueUnderflowException.cs
4. LinkedQueue.java ⟶ LinkedQueue.cs
5. Main.java ⟶ ?.cs
```
The file names with question marks indicate where the file name for the C# version had to be different from the original java file name due to C# language requirements.

Ultimately, I ended up with these five files at the end.

```
Node.cs
IQueueInterface.cs
QueueUnderflowException.cs
LinkedQueue.cs
MainClass.cs
```


### Part 3.1: Translating Node.java ⟶ Node.cs



### Part 3.2: Translating QueueInterface.java ⟶ IQueueInterface.cs




### Part 3.3: QueueUnderflowException.java ⟶ QueueUnderflowException.cs



### Part 3.4: LinkedQueue.java ⟶ LinkedQueue.cs

```csharp

```

### Part 3.5: Main.java ⟶ MainClass.cs



### Part 3.6: XML comments

The required XML comments proved easy to implement and use in the C# program. All one had to do in the IDE was simply type
```
  ///
```
above the line of code in question and one would get something like the following

```
  /// <summary>
  /// 
  /// </summary>
  /// <param name="args"></param>
  /// <returns></returns>
```
In particular, the exact HTML elements generated are context sensitive in that what is generated is directly matched with the type and level of code statement e.g. (a method/function -with or without parameter vs. a class vs. an interface vs. a namespace).


### Part 3.7: Final Results

This shows how the overall file structure of my homework #3 project was organized in Visual Studio Code which is a little different compared to the last few homeworks due to the structure and content of a C# console app created via Visual Studio IDE.

![FileStructure](hw3_file_organization.PNG)

Next, we have a picture of the behavior of the original java program.

![Webpag](java_progam_behavior.PNG)

And a picture of the near identical behavior of the C# program it was translated into.

![Web](csharp_progam_behavior.PNG)

As we can see, everything works regarding our translated C# program which is identical in behavior and output to the original java program excepting the inclusion of some additional exception handling as seen with the new message for the user

```
I'm sorry, I can't use the non-positive integer: -1
```

In general, this was an interesting experience in becoming aquainted with the Visual Studio IDE and the C# language along with using this knowledge to translate a Java program into an equivalent version wholly written in C# but with effectively identical behavior.
