// This is my Javascript file for the Number Checker web page for Homework#2 of CS 460
// Date finished: 10/10/2018

var compareChecked = false;

var multipleChecked = false;

// This function checks if the inputs are valid
// and returns an error message to the user if they are not.
function checkInputs()
{
    // Extracts the user inputs from the input numbers part.
    var firstInput = parseInt(document.getElementById('firstinputnumber').value);
    var secondInput = parseInt(document.getElementById('secondinputnumber').value);

    // This resets the error message if one was already present.
    $('#error').empty();
   
    // This checks if both inputs were numbers
    // and sends an error message if not.
    if(isNaN(firstInput) || isNaN(secondInput))
    {
       
        var node = document.getElementById("error"); // retrieves the "error" element
        var heading = document.createElement("h4");  // creates "heading" element
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
            var node = document.getElementById("error"); // retrieves the "error" element
            var heading = document.createElement("h4"); // creates "heading" element
            var message = document.createTextNode("Both inputs must be between 1 and 1000!"); // creates error message.
            node.style.background = "red"; // sets background of error message.
            node.style.color = "white"; // sets the color of the letters of the message.
            //node.style.padding = "1px";
            heading.appendChild(message); // appends the message to the heading.
            node.appendChild(heading); // appends the message to the node.

       
        }
        return false;
    }

    return true; // If user inputs were valid, then true is returned.
}

// This function serves as the entry point for
// the hw2 javascript file.
// It is responsible for calling its various methods
// when the user clicks "Analyze"
function propertyAnalysis()
{
    if(checkInputs())
    {
         compareChecked = $('#compare').is(":checked");
         multipleChecked = $('#multiple').is(":checked");


        if(compareChecked == true)
        {
            var node = document.getElementById("error"); // retrieves the "error" element
            var heading = document.createElement("h4");  // creates "heading" element
            var message = document.createTextNode("Both inputs must be numbers!"); // creates error message.
            node.style.background = "red"; // sets background of error message.
            node.style.color = "white"; // sets the color of the letters of the message.
            //node.style.padding = "1px";
            heading.appendChild(message); // appends the message to the heading.
            node.appendChild(heading); // appends the message to the node.
        }







    }

    return false
}