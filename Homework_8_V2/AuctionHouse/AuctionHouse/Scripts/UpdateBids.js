// development of this code was greatly aided by consultation with Manuel.

// This makes a request to bidUpdateRequest in ItemsController
function bidUpdateRequest() {

    console.log("test1");
    var inputID = document.getElementById("table-id").value; //this retrieves the listing ID from HTML ID attribute
    var id = parseInt(inputID); // this parses the input into an int
    var source = "/Items/BidUpdateRequest/" + id; // this appends it to the required URI string.

    console.log("test2");

    // This is the actaul ajax call.
    $.ajax({
        type: "GET",
        dataType: "json",
        url: source,
        success: BidsDisplay,
        error: ajaxError
    });
}

    // appends the list of bids to view.
    /*@param {any} bidList JSON reponse received from BidRequest in BidController.*/

    function BidsDisplay(Listing) {
        console.log("test3");
        // This checks whether json response is empty
        if (Listing.length == 0) // If list empty, this displays a message to the user.
        {
            console.log("test4");
            $("message").empty(); // This clears the message if it already exists.
            $("message").append("no bids to display. Be the First to bid on this item!"); // appends this message to display to the user
        }
        else // loaded response; display bidding data.
        {
            console.log("test5");
            $("message").empty(); // This clears message if already exists.
           // $("message").remove(); // This clears any old bidding data away
            $(".bid-info").remove();
            //This Displays the bidding data a row at a time.
            for (var i = 0; i < Listing.length; i++)
            {
                // A bit of a complicated string for producing both the content and structure of the entries for the table.
                $(".table").append("<tr class=\"bid-info\"><td>" + Listing[i].Buyer + "</td><td>$" + Number(Listing[i].Amount).toLocaleString('en-US', { minimumFractionDigits: 2 }) + "</td></tr>");
            }
        }
    }



    
    /**
 * Displays pop-up message
 */
    function ajaxError() {
        alert("Unable to reach server. Please try again later!!!");
    }

    /**
     * The main method that "drives" the script 
     */
    function main() {
        bidUpdateRequest(); //makes initial call to bidRequest() method.

        var interval = 1000 * 5; //timer interval set for 5 second update.

        window.setInterval(bidUpdateRequest, interval); //refreshes bid list every 5 seconds
    }

    $(document).ready(main()); //Calls main() when page is loaded
