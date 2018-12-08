## Homework 7

This week our homework


### Homework 7 Links
1. [Home page](https://no-one-alone.github.io/)
2. [Assignment Page](http://www.wou.edu/~morses/classes/cs46x/assignments/HW5_1819.html)
3. [Code Repository](https://github.com/No-one-alone/no-one-alone.github.io)
4. [Final Video Demo](https://www.youtube.com/watch?v=bAsLXYbIFYY)
5. [Server-Side validation using Postman](https://www.youtube.com/watch?v=8WHSrMvnnqY)


### Part 1: Creation of ASP.NET MVC 5 web app with Visual Studio IDE

As before, we created the new empty MVC 5 web application using the same process seen in homework 4's blog along with adding the microsoft.net.compilers package to avoid the cloning issue.

### Part 2: Editing the MVC 5 project and adding features.

At the conclusion of this project, we had these edited or added files.

```
up.sql
down.sql
Request.cs
RequestContext.cs
Web.config
HomeControllers.cs
RequestsController.cs
Index.cshtml
Create.cshtml
Listing.cshtml
_Layout.cshtml

```

We will proceed to cover the use of the files in the project.

### Part 2.1: Database creation ⟶ local database under App_Data



### Part 2.2: Database table creation ⟶ up.sql and down.sql components



### Part 2.3: Data Model ⟶ Request.cs component






### Part 2.4: Data Access Layer ⟶ RequestContext.cs component








### Part 2.6: Landing page ⟶ _Layout.cshmtl component



### Part 2.7 Landing page ⟶ Index.cshtml



### Part 2.8:  View for "Make a Request" ⟶ Create.cshtml




### Part 2.9:  View for "View Requests" ⟶ Listing.cshtml




### Part 2.10:  Controller for the "Make a Request" webpage ⟶ RequestsController.cs



### Part 3: Final Results


This shows how the overall file structure of my homework #5 project was organized in Visual Studio Code which is just a bit different compared to the last homework due to the addition of files under the Models, DAL, and App_Data folders.

![FileStructure](./Images/file_structure.PNG)


And this is a picture of the landing page of the web app.

![Web](./Images/home_page.PNG)

Furthermore, the "Make a Request" web page can be seen here.

![Web](./Images/make_request.PNG)

And the related "View Requests" page here.

![Web](./Images/view_request.PNG)

Note how the entries are sorted and ordered from oldest-first.

Lastly, we can see these pages in action via the valid submission here.

![Web](./Images/submit.PNG)

Followed by the redirect to the request list here with the new entry at the bottom.

![Web](./Images/submit_made.PNG)

As we can see, everything has been implemented regarding our ASP.NET MVC 5 web application and can be seen to work both according to the above screenshots and the video demo in the link at the top with respect to validation.

In general, this was a trying but useful experience in becoming aquainted with creating and utilizing the ASP.NET MVC 5 platform for creating web applications under the Model-View-Controller paradigm with a local database for persistent storage.