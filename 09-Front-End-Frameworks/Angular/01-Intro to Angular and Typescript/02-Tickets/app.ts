import Ticket from "./Ticket";

function processTickets(t: string[], sortCrit: string): Array<Ticket> {
  let result = [];

  for (const data of t) {
    const args = data.split("|");
    const [destination, price, status] = args;

    result.push(new Ticket(destination, Number(price), status));
  }

  switch (sortCrit) {
    case "destination":
      result = result.sort((a, b) => a.destination.localeCompare(b.destination));
      break;
    case "price":
      result = result.sort((a, b) => a.price - b.price);
      break;
    case "status":
      result = result.sort((a, b) => a.status.localeCompare(b.status));
      break;
  }

  return result;
}

const destination = processTickets([
  "Philadelphia|94.20|available",
  "New York City|95.99|available",
  "New York City|95.99|sold",
  "Boston|126.20|departed",
], "destination");

const status = processTickets([
  "Philadelphia|94.20|available",
  "New York City|95.99|available",
  "New York City|95.99|sold",
  "Boston|126.20|departed",
], "status");

const price = processTickets([
  "Philadelphia|94.20|available",
  "New York City|95.99|available",
  "New York City|95.99|sold",
  "Boston|126.20|departed",
], "price");

console.log("\n");
console.log(destination);
console.log("\n");
console.log(status);
console.log("\n");
console.log(price);