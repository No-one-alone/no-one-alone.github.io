// makes a request to bidRequest in BidController

/**
 * Makes a request to BidRequest() in BidController */
function bidUpdateRequest() {

    console.log("test1");
    var input = document.getElementById("listing-id").value; //retrieves listing ID from HTML ID attribute
    var id = parseInt(input); //parses the input as an int
    var source = "/Items/BidUpdateRequest/" + id; //appends it to URI string.

    console.log("test2");

    $.ajax({
        type: "GET",
        dataType: "json",
        url: source,
        success: showBids,
        error: ajaxError
    });
}

    // appends the list of bids to view.
    /*@param {any} bidList JSON reponse received from BidRequest in BidController.*/

    function showBids(bidList) {
        console.log("test3");
        // checks whether json response is empty
        if (bidList.length == 0) // empty response, display message to user.
        {
            console.log("test4");
            $("message").empty(); // clears message if already exists.
            $("message").append("no bids to display. Be the First to bid on this item!"); // appends this message to display to user
        }
        else // loaded response; display bidding data.
        {
            console.log("test5");
            $("message").empty(); // clears message if already exists.
           // $("message").remove(); // clears any old bidding data.
            $(".bid-info").remove();
            //Displays row-by-row bidding data.
            for (var i = 0; i < bidList.length; i++)
            {
                $(".table").append("<tr class=\"bid-info\"><td>" + bidList[i].Buyer + "</td><td>$" + Number(bidList[i].Amount).toLocaleString('en-US', { minimumFractionDigits: 2 }) + "</td></tr>");
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

        var interval = 1000 * 5; //timer interval

        window.setInterval(bidUpdateRequest, interval); //refreshes bid list every 5 seconds
    }

    $(document).ready(main()); //Calls main() when page is loaded

































/* 
//var ajax_call = function () {
$(document).ready(function (){
    //your jQuery ajax code

    // trouble shooter
    console.log("script load")

    var getBids = function () {

        var id = parseInt($('#itemId').html().trim());

        // trouble shooter
        console.log("item id")

        var source = "/Items/"
        
         //Construct the AJAX call to retrieve the Bids for the item associated with the id/
            $.ajax({
                type: "GET",
               dataType: "json",
              //url: "/CONTROLLER/ACTION",
              url: source,
              data: { "id": VARIABLE },
              success: DisplayBids,
              error: errorAjax

    });
};


function DisplayBids(latestBid) {
    //add new bids to table
    if (latestBid.price > latestPrice) {
        $("#bids").prepend("<tr><td>" + latestBid.buyer + "</td><td>" + latestBid.price + "</td></tr>");
        latestPrice = latestBid.price;
    }
}


function errorAjax() {
    console.log("error in ajax");
}

// updates bids for display.
var X = 5; // for five seconds

var interval = 1000 * X; // where X is your timer interval in X seconds

window.setInterval(ajax_call, interval);

*/