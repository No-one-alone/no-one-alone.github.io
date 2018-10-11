// This is my Javascript file for the Number Checker web page for Homework#2 of CS 460
// Date finished: 10/10/2018


var firstInput = 0;

var secondInput = 0;


// This function checks if the inputs are valid
// and returns an error message to the user if they are not.
function checkInputs()
{
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
        $( '#error' ).append("<h4>Both inputs must be numbers!</h4>");
        
        return false;
    }

    // This checks if both numbers were within the valid range of 1 to 1000 (inclusive)
    // and sends an error message if not.
    if(!isNaN(firstInput) || !isNaN(secondInput))
    {
        if( firstInput < 1 || firstInput > 1000 || secondInput < 1 || secondInput > 1000)
        {
            $( '#error' ).append("<h4>Both inputs must be between 1 and 1000!</h4>");
        
            return false;
        }
    }

    
    return true; // If user inputs were valid, then true is returned.
}


//
function checkProperties()
{
    var compareChecked = $('#compare').is(":checked");
    var multipleChecked = $('#multiple').is(":checked");
    
    var checkCount = 0;

    if(compareChecked == false && multipleChecked == false)
    {
        propertyChecked = "None checked";
        relationFound = "Unknown";
    }

    backupPropertyChecked = "";
    backupRelationFound = "";
    secondProperty = "";
    if(compareChecked == true)
    {
        checkCount = checkCount + 1;
        propertyChecked = "Size Comparison"; //
        
        if(firstInput > secondInput)
        {
            relationFound = "First > Second";
        }

        if(firstInput < secondInput)
        {
            relationFound = "First < Second";
        }

        if(firstInput == secondInput)
        {
            relationFound = "First = Second";
        }

        backupPropertyChecked = propertyChecked;
        backupRelationFound = relationFound;
        secondProperty = "Second Property";
    }



    if(multipleChecked == true)
    {
        checkCount = checkCount + 1;
        propertyChecked = " \xa0 \xa0 Multiple";

        resultOne = firstInput % secondInput;

        resultTwo = secondInput % firstInput;

        if(resultOne == 0)
        {
            relationFound = "First is multiple of Second";
        }
        else if(resultTwo == 0)
        {
            relationFound = "Second is multiple of First";
        }
        else
        {
            relationFound = "Neither is multiple of other";
        }
    }



var rowHTML = "";
rowHTML = rowHTML + "<table style='width:100%'><tr>";


rowHTML = rowHTML + "<th>" + "First: " + firstInput + ", Second: " + secondInput + "</th>";
rowHTML = rowHTML + "<th>"+ propertyChecked + "</th>";
rowHTML = rowHTML + "<th>"+ relationFound + "</th></tr>";


if(checkCount != 2)
{
     backupPropertyChecked = "";
     backupRelationFound = "";
     secondProperty = "";
}


rowHTML = rowHTML + "<tr><th>" + secondProperty + "</th>";
rowHTML = rowHTML + "<th>"+ backupPropertyChecked + "</th>";
rowHTML = rowHTML + "<th>"+ backupRelationFound + "</th></tr>";

rowHTML = rowHTML + "<tr><th>\xa0</th></tr>";

rowHTML = rowHTML + "</table>";

$( ".target" ).append(rowHTML);


}


///
function resetInputs()
{
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
