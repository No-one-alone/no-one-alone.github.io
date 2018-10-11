// This is my Javascript file for the Number Checker web page for Homework#2 of CS 460
// It is responsible for taking input from the user on the html page and returning
// dynamically inserted or modified html into said web page to indicate answer 
// results or any error on the part of the user.
// Date finished: 10/11/2018

var firstInput = 0; // This is a global variable to hold the first user inputted number.

var secondInput = 0; // This is a global variable to hold the second user inputted number.


// This function checks if the inputs are valid
// and returns an error message to the user if they are not.
// It takes no parameters.
// Returns a boolean.
function checkInputs() 
{
    var firstInputted = $('#firstinputnumber')[0].value;  //returns a jQuery Object of the first input number.
    var secondInputted = $('#secondinputnumber')[0].value;  //returns a jQuery Object of the first input number.

    firstInput = parseInt(firstInputted); // Parses jQuery object to get value of first input.
    secondInput = parseInt(secondInputted); // Parses jQuery object to get value of second input.

    // This resets the error message if one was already present.
    $('#error').empty(); // more JQuery.

    // This checks if both inputs were numbers
    // and sends an error message if not.
    if (isNaN(firstInput) || isNaN(secondInput)) 
    {
        $('#error').append("<h4>Both inputs must be numbers!</h4>"); // jQuery to append html error message to webpage.

        return false; // indicates that inputs were not valid.
    }

    // This checks if both numbers were within the valid range of 1 to 1000 (inclusive)
    // and sends an error message if not.
    if (!isNaN(firstInput) || !isNaN(secondInput)) {
        if (firstInput < 1 || firstInput > 1000 || secondInput < 1 || secondInput > 1000) 
        {
            $('#error').append("<h4>Both inputs must be between 1 and 1000!</h4>"); // jQuery to append html error message to webpage.

            return false; // indicates that inputs were not valid.
        }
    }


    return true; // If user inputs were valid, then true is returned.
}


// This function serves to check
// the properties indicated by the user
// of the input numbers and add the 
// results to the webpage via dynamically
// inserted HTML.
// Takes no parameters.
// Does not return anything.
function checkProperties() 
{
    var compareChecked = $('#compare').is(":checked"); // jQuery to determine if compare checkbox was checked.
    var multipleChecked = $('#multiple').is(":checked"); // jQuery to determine if multiple checkbox was checked.

    // This checks if neither box was checked.
    if (compareChecked == false && multipleChecked == false) 
    {
        propertyChecked = "None checked"; // creates string value to indicate no property was checked.
        relationFound = "Unknown"; // creates string value to indicate relation is unknown.
    }

    backupPropertyChecked = ""; // This stores second property in the event both boxes are checkec.
    backupRelationFound = ""; // This stores second relationship found if indicated.
    secondProperty = ""; // This indicates whether second property was desired.

    if (compareChecked == true) // This checks if compare box was checked.
    {
        propertyChecked = "Size Comparison"; // creates string value to indicate property checked.

        if (firstInput > secondInput) // This tests the ordinal relationship between the inputs.
        {
            relationFound = "First > Second"; // creates string value to indicate relation.
        }

        if (firstInput < secondInput) // This tests the ordinal relationship between the inputs.
        {
            relationFound = "First < Second"; // creates string value to indicate relation.
        }

        if (firstInput == secondInput) // This tests the ordinal relationship between the inputs, specifically equality.
        {
            relationFound = "First = Second"; // creates string value to indicate relation.
        }

        backupPropertyChecked = propertyChecked; // stores backup of property checked.
        backupRelationFound = relationFound; // stores backup of relation found.
        secondProperty = "Second Property"; // stores second property string value.
    }



    if (multipleChecked == true) // This checks if the multiple box was checked.
    {
        propertyChecked = " \xa0 \xa0 Multiple"; // creates string value to indicate property checked.

        resultOne = firstInput % secondInput; // stores remainder of first number modulo second number.

        resultTwo = secondInput % firstInput; // stores remainder of second number modulo first number.

        if (resultOne == 0) // This tests if first is multiple of the second.
        {
            relationFound = "First is multiple of Second"; // creates string value to indicate relation.
        }
        else if (resultTwo == 0) // This tests if second is multiple of the first.
        {
            relationFound = "Second is multiple of First"; // creates string value to indicate relation.
        }
        else 
        {
            relationFound = "Neither is multiple of other"; // creates string value to indicate relation.
        }
    }

    // The following is just the html and javascript for inserting the answers into the webpage.

    var rowHTML = ""; // This initializes our string which will contain the html for the answers.

    rowHTML = rowHTML + "<table style='width:100%'><tr>"; // This adds the beginning table element and row element tags.

    rowHTML = rowHTML + "<th>" + "First: " + firstInput + ", Second: " + secondInput + "</th>"; // This adds the input numbers with header cell tags.

    rowHTML = rowHTML + "<th>" + propertyChecked + "</th>"; // This adds the property that was checked with header cell tags.

    rowHTML = rowHTML + "<th>" + relationFound + "</th></tr>"; // This adds the relation that was found with header cell tags.

    if (compareChecked == false || multipleChecked == false) // This tests if both check boxes were NOT checked.
    {
        backupPropertyChecked = ""; // resets value of string.
        backupRelationFound = ""; // resets value of string.
        secondProperty = ""; // resets value of string.
    }

    rowHTML = rowHTML + "<tr><th>" + secondProperty + "</th>"; // This adds the second property label if present with row and header cell tags.

    rowHTML = rowHTML + "<th>" + backupPropertyChecked + "</th>"; // This adds the second property if indicated with header cell tags.

    rowHTML = rowHTML + "<th>" + backupRelationFound + "</th></tr>"; // This adds the relation found for second property if indicated with header cell and row ending tags.

    rowHTML = rowHTML + "<tr><th>\xa0</th></tr>"; // This just adds a space between rows of answwers with header and row tags.

    rowHTML = rowHTML + "</table>"; // This adds the end tag of the table element.

    $(".target").append(rowHTML); // This uses jQuery to append the constructed html element of answers to the web page.
}


// This function serves
// to reset the input number boxes
// back to the orginal values
// of 1 and 1.
// It takes no parameters.
function resetInputs() 
{
    // This jQuery code modifies the input number box html such that the value is now 1 again.
    $("div.inside1").replaceWith("<div class='inside1'><label for='first number'>First Number: &nbsp &nbsp &nbsp</label><input type='number' min='1' max='1000' value='1' id='firstinputnumber'></div>");
    $("div.inside2").replaceWith("<div class='inside2'><label for='second number'>Second Number:&nbsp</label><input type='number' min='1' max='1000' value='1' id='secondinputnumber'></div>");
}


// This function serves as the entry point for
// the hw2 javascript file.
// It is responsible for calling its various methods
// when the user clicks "Analyze".
// It takes no parameters.
function propertyAnalysis() 
{
    if (checkInputs()) // This checks if the inputs are valid.
    {
        checkProperties(); // This analyzes the properties of the input numbers.
    }

    resetInputs(); // This resets the inputs when the "analyze" button is clicked.

    return false; // must return this else results do not show up corretly on html page.
}
