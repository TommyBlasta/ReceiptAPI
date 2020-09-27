function postReceipt(receiptString) {
    var Http = new XMLHttpRequest();
    var url = 'localhost/api/AddReceipt';
    Http.open("POST", url);
    Http.send();
    //adds a handler to the http call
    Http.onreadystatechange = function (e) {
        console.log(Http.responseText);
    };
    return true;
}
