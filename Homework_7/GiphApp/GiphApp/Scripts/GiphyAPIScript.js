
 // @param {any} keyWord Word we want to get a .gif of
 
function requestGIF(keyWord) {
    var source = "Giphy/Image/" + keyWord;

    $.ajax({
        type: "GET",
        dataType: "json",
        url: source,
        success: showAppImage,
        error: ajaxErrorMessage
    });
}


 // @param {any} imageData JSON data received from GIPHY server

function showAppImage(imageData) {
    var image = imageData.data.images.fixed_height_small.url; //URI of the .gif to display

    $("#live-display").append("<img src=\"" + image + "\"/>&nbsp;"); //Appends .gif to HTML document
}

function ajaxErrorMessage() {
    alert("Unable to load image");
}

/**
 * The main method which drives the script.
 */
function main() {
    $("#textbox").keypress(function (e) {
        if (e.keyCode == 32) { //Listens for spacebar press from input box
            var input = document.getElementById("textbox").value; //Gets text from input box.
            input = input.split(" "); //Splits words into an array.
            input = input[input.length - 1]; //Get the last word in "array"
            var word = input.toLowerCase(); //Converts word to all lowercase to check against "boring" words


            // this is a list of words to ignore as not "interesting."
            var boringWords = ["i", "in", "a", "but", "going", "i'm", "my", ",", ".", "",
                "for", "not", "of", "to", "from", "make", "just", "know",
                "other", "this", "than", "then", "as", "he", "he's", "his",
                "him", "she", "she's", "her", "so", "we", "is", "be", "see",
                "you", "later", "the", "i've", "isn't", "got"];


            var excludedWords = [",", ".", "", "/", ";", "a", "an", "the", "i", "me", "we", "to", "for", "going",
                "of", "to", "you", "be", "is", "he", "she", "them", "this", "other", "not", "in", "toward", "and", "so", "but", "yet",
                "before", "as", "since", "when", "while", "until", "after", "later", "next", "all", "or", "thus", "my", "our", "on",
                "about", "above", "among", "at", "before", "in", "of", "with", "into", "by", "over", "beyond", "plus", "out", "down", "off", "near", "at",
                "next", "past", "future", "regardless", "upon", "via", "with", "also", "without", "through", "except", "inside", "outside", "per", "until", "upon"];


            
            if (excludedWords.includes(word)) { //this checks if it is a boring word
                $("#live-display").append("<label>" + input + "</label>&nbsp;") //This displays a entered word as plain text
            }
            else { 
                requestGIF(input); 
            }
        }
    });
}

$(document).ready(main); //Calls main() when page is loaded.