// This is my Javascript file for the Number Checker web page for Homework#2 of CS 460
// Date finished: 10/10/2018


function checkInputs()
{
    var firstInput = parseInt(document.getElementById('firstinputnumber').val())
    /*
    if(isNaN(firstInput))
    {
        var node = document.getElementById("error");
        var heading = document.createElement("h4");
        var message = document.createTextNode("Both inputs must be numbers!" + firstInput);
        node.style.background = "red";
        node.style.color = "white";
        node.style.padding = "1px";
        heading.appendChild(message);
        node.appendChild(heading);

        return false;
    }
    if(!isNaN(firstInput))
    {
        if( firstInput < 1 || firstInput > 1000)
        {
            var message = document.createTextNode("Both inputs must be between 1 and 1000!");
        }
        return false;
    }

    */
    return true
}

function propertyAnalysis()
{
    if(checkInputs())
    {

    }

    return false
}