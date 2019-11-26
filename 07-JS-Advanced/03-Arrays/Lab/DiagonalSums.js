function solve(input){
    let first = 0;
    let second = 0;

    for (let i = 0; i < input.length; i++) {
        first += input[i][i];
        second += input[i][input.length - 1 - i];
    }

    let result = `${first} ${second}`;

    return result;
}