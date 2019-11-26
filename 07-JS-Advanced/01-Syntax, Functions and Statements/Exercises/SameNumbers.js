function solve(input) {
    let arrayOfNumbers = String(input).split("");
    let isSame = true;
    let firstElement = arrayOfNumbers[0];

    arrayOfNumbers.forEach(function(element) {
        if(element != firstElement){
            isSame = false;
        }
    });

    let sum = arrayOfNumbers
    .map(Number)
    .reduce((acc, cur) => acc + cur);

    console.log(isSame);
    console.log(sum)
}

solve(2222222);