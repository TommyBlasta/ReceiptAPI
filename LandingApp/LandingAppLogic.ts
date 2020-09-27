function postReceipt(receiptString : string) : boolean
{
    const Http = new XMLHttpRequest();
    const url='localhost/api/AddReceipt';
    Http.open("POST", url);
    Http.send();
    //adds a handler to the http call
    Http.onreadystatechange = (e) => {
    console.log(Http.responseText);
    }
    return true;
}
function parseInputToReceipt()
{
    
}
class Receipt {
    seller: string;
    date: string;
    id: number;
    constructor(seller: string, date: string) {
      this.seller = seller;
      this.date = date;
      this.id = null;
    }
    toJSON(): string {
        return "{" + "id:" + this.id +
                "date:" + this.date +
                "seller" + this.seller + 
        +"}"
      }
  }