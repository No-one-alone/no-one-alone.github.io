// This is my Javascript file for the Number Checker web page for Homework#2 of CS 460
// Date finished: 10/10/2018

//var compareChecked = false;

//var multipleChecked = false;

var firstInput = 0;

var secondInput = 0;


// This function checks if the inputs are valid
// and returns an error message to the user if they are not.
function checkInputs()
{
    // Extracts the user inputs from the input numbers part.
  //  firstInput = parseInt(document.getElementById('firstinputnumber').value);
  //  secondInput = parseInt(document.getElementById('secondinputnumber').value);

    var firstInputted = $('#firstinputnumber')[0].value; ;  //returns a jQuery Object
    var secondInputted = $('#secondinputnumber')[0].value; ;  //returns a jQuery Object

    firstInput = parseInt(firstInputted);
    secondInput = parseInt(secondInputted);

    // This resets the error message if one was already present.
    $('#error').empty(); // more JQuery
   
    // This checks if both inputs were numbers
    // and sends an error message if not.
    if(isNaN(firstInput) || isNaN(secondInput))
    {
       
    //    var node = document.getElementById("error"); // retrieves the "error" element
        var node = $('#error')[0]; // retrieves the "error" element
        
        var heading = document.createElement("h4");  // creates "heading" element
    //    var heading = $('#h4')[0]; // creates "heading" element

        var message = document.createTextNode("Both inputs must be numbers!"); // creates error message.
        node.style.background = "red"; // sets background of error message.
        node.style.color = "white"; // sets the color of the letters of the message.
        //node.style.padding = "1px";
        heading.appendChild(message); // appends the message to the heading.
        node.appendChild(heading); // appends the message to the node.
        
        return false;
    }

    // This checks if both numbers were within the valid range of 1 to 1000 (inclusive)
    // and sends an error message if not.
    if(!isNaN(firstInput) || !isNaN(secondInput))
    {
        if( firstInput < 1 || firstInput > 1000 || secondInput < 1 || secondInput > 1000)
        {
        //    var node = document.getElementById("error"); // retrieves the "error" element
        
            var node = $('#error')[0]; // retrieves the "error" element

            var heading = document.createElement("h4"); // creates "heading" element
            var message = document.createTextNode("Both inputs must be between 1 and 1000!"); // creates error message.
            node.style.background = "red"; // sets background of error message.
            node.style.color = "white"; // sets the color of the letters of the message.
            //node.style.padding = "1px";
            heading.appendChild(message); // appends the message to the heading.
            node.appendChild(heading); // appends the message to the node.

            return false;
        }

        
    
    }

    
    return true; // If user inputs were valid, then true is returned.
}



function checkProperties()
{
    var compareChecked = $('#compare').is(":checked");
    var multipleChecked = $('#multiple').is(":checked");
    
    var checkCount = 0;

    if(compareChecked == false && multipleChecked == false)
    {
        propertyChecked = " \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 None checked ";
        relationFound = " \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 Unknown";
    }

    backupPropertyChecked = "";
    backupRelationFound = "";
    secondProperty = "";
    if(compareChecked == true)
    {
        checkCount = checkCount + 1;
        propertyChecked = " \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 Size Comparison ";
        
        if(firstInput > secondInput)
        {
            relationFound = "\xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 First > Second";
        }

        if(firstInput < secondInput)
        {
            relationFound = "\xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 First < Second";
        }

        if(firstInput == secondInput)
        {
            relationFound = "\xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 First = Second";
        }

        backupPropertyChecked = propertyChecked;
        backupRelationFound = relationFound;
        secondProperty = "Second Property";
    }



    if(multipleChecked == true)
    {
        checkCount = checkCount + 1;
        propertyChecked = " \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 Multiple  ";

        resultOne = firstInput % secondInput;

        resultTwo = secondInput % firstInput;

        if(resultOne == 0)
        {
            relationFound = "\xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 First is multiple of Second";
        }
        else if(resultTwo == 0)
        {
            relationFound = "\xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 Second is multiple of First";
        }
        else
        {
            relationFound = "\xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 \xa0 Neither is multiple of other";
        }
    }


    var node = document.getElementById("totaltarget"); 

    var outTable = document.createElement("table");
    outTable.setAttribute("id", "outTable");
    node.appendChild(outTable);

    // find table element
    var endTable = document.getElementById("outTable");

    // create empty <tr> element and add it to the first position of the table
    var row = endTable.insertRow(0);

    // insert new cells (<td>) elements at the 1st, 2nd, and 3rd position of the "new" <tr> element:
    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);
    var cell3 = row.insertCell(2);

    // add content to cells
    cell1.innerHTML = "First: " + firstInput + ", Second: " + secondInput;
    cell2.innerHTML = propertyChecked;
    cell3.innerHTML = relationFound;

    
    if(checkCount != 2)
    {
         backupPropertyChecked = "";
         backupRelationFound = "";
         secondProperty = "";
    }


        // create empty <tr> element and add it to the first position of the table
        var row = endTable.insertRow(1);

        // insert new cells (<td>) elements at the 1st, 2nd, and 3rd position of the "new" <tr> element:
        var cell1 = row.insertCell(0);
        var cell2 = row.insertCell(1);
        var cell3 = row.insertCell(2);
   
        // add content to cells
        cell1.innerHTML = secondProperty;
        cell2.innerHTML = backupPropertyChecked;
        cell3.innerHTML = backupRelationFound;
    

/*
    if(compareCheck == true && multipleChecked == true)
    {
        alert("reached");
        //var node = document.getElementById("totaltarget"); 

       // var outTable = document.createElement("table");
       // outTable.setAttribute("id", "outTable");
       // node.appendChild(outTable);


       // find table element
       //var endTable = document.getElementById("outTable");

       endTable = document.getElementById("outTable");
       // create empty <tr> element and add it to the first position of the table
       var row = endTable.insertRow(1);
   
       // insert new cells (<td>) elements at the 1st, 2nd, and 3rd position of the "new" <tr> element:
       var cell1 = row.insertCell(0);
       var cell2 = row.insertCell(1);
       var cell3 = row.insertCell(2);
   
       // add content to cells
       cell1.innerHTML = "First: " + firstInput + ", Second: " + secondInput;
       cell2.innerHTML = backupPropertyChecked;
       cell3.innerHTML = backupRelationFound;
    }
*/


}


function resetInputs()
{
   // var inputOne = $( "container outer" ).find( "firstinputnumber" );

   // htmlStr = "<input type='reset' value='Reset the form'>";

    //$("div.inside" ).append(htmlStr);

    $( "div.inside1" ).replaceWith( "<div class='inside1'><label for='first number'>First Number: &nbsp &nbsp &nbsp</label><input type='number' min='1' max='1000' value='1' id='firstinputnumber'></div>");
    $( "div.inside2" ).replaceWith( "<div class='inside2'><label for='second number'>Second Number:&nbsp</label><input type='number' min='1' max='1000' value='1' id='secondinputnumber'></div>");


}




// This function serves as the entry point for
// the hw2 javascript file.
// It is responsible for calling its various methods
// when the user clicks "Analyze"
function propertyAnalysis()
{
    if(checkInputs())
    {
        checkProperties();
    }

    resetInputs();

    return false
}

       // var node = document.getElementById("totaltarget");
        
      //  var heading = document.createElement("h3");
        
       // heading.appendChild(message);
       // node.appendChild(heading);

       // alert("reached");

       /*
        var node = document.getElementById("totaltarget"); // retrieves the "error" element
        var heading = document.createElement("h4");  // creates "heading" element
        var message = document.createTextNode("string here"); // creates error message.
      //  node.style.background = "red"; // sets background of error message.
       // node.style.color = "white"; // sets the color of the letters of the message.
        //node.style.padding = "1px";
        heading.appendChild(message); // appends the message to the heading.
        node.appendChild(heading); // appends the message to the node.
        */