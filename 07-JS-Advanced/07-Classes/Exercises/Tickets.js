function solve(ticketArr, sortingBy){    
    class Ticket {
        constructor(destination, price, status){
           this.destination = destination;
           this.price = price;
           this.status = status;
        }
    }

     let unsortedTickets = [];
     
     for (let ticket of ticketArr) {
         let[destination, price, status] = ticket.split('|');
         price = Number(price);
         unsortedTickets.push(new Ticket(destination, price, status));
     }

     let sortedTickets;
     switch (sortingBy){
        case "destination":
            sortedTickets = unsortedTickets.sort((a, b) => a.destination.localeCompare(b.destination));
            break;
        case "price":
            sortedTickets = unsortedTickets.sort((a, b) => a.price - b.price);
            break;
        case "status":
            sortedTickets = unsortedTickets.sort((a, b) => a.status.localeCompare(b.status));
            break;
    }

    return sortedTickets;
 }