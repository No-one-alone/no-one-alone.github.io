## Homework 3

Regarding the third homework, we had to learn how to install and use the Visual Studio IDE, learn the C# language,and rewrite an instructor-provided java program such that it matched the original as closely as possible but with C# instead of java while having the same program behavior. We also learned to use XML comments due to their utility in the Visual Studio environment along with implementing a .gitignore file to avoid having to add a large number of unnecessary files to our git repositories.


### Homework 3 Links
1. [Home page](https://no-one-alone.github.io/)
2. [Assignment Page](http://www.wou.edu/~morses/classes/cs46x/assignments/HW3_1819.html)
3. [Code Repository](https://github.com/No-one-alone/no-one-alone.github.io)
4. [Final Video Demo](https://www.youtube.com/watch?v=F9BMpgQGSkw)


### Part 1: The Phantom Git

No new commands were learned this week; however, we did have to learn as part of using the Visual Studio IDE to add a file called the following to the root of our git repository.

``` 
    .gitignore
```

This was necessary as without this file, we would end up with a large collection of files all demanding to be added to the repository when we issued a "git add ." command as part of the Visual Studio console app creation. The file itself was generated automatically but not quite painlessly using Visual Studio automatic features when creating a new project file.

### Part 2: Visual Studio IDE

I downloaded the Visual Studio program from [here](https://visualstudio.microsoft.com/vs/)

### Part 3: Translating a Java binary number generator program into an equivalent C# program

As per the assignment directions, I downloaded the "javacode2.zip" file from the homework#3 assignment page which contained the following files which made up the java program.

```
Node.java
QueueInterface.java
QueueUnderflowException.java 
LinkedQueue.java 
Main.java
```

The program served and behaved as a binary number list generator with the number of entries determined by a user supplied number (see bottom of webpage for program output and behavior):

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
The file names with question marks indicate where the file name for C# version had to be different from the original java file name due C# language requirements.

Ultimately, I ended up with these five files at the end.

```
Node.cs
IQueueInterface.cs
QueueUnderflowException.cs
LinkedQueue.cs
MainClass.cs
```


### Part 3.1: Notes on Java to C# translation and important language features.





### Part 3.4: Final Results

This shows how the overall file structure of my homework #2 project was organized which is pretty similar to homework #1.

![FileStructure](filestructurehw2.PNG)

Finally, we have a picture of the actual completed web page in its default state.

![Webpages](webpageofhw2.PNG)

And another after some user interaction.

![Webpages](webpageofhw2inaction.PNG)

As we can see, everything works and comes close to what was originally seen in the sketch made at the start of this project.

In general, this was another interesting experience in creating a webpage using HTML, styling it with CSS, and now adding dynamic behavior using Javascript along with jQuery.
