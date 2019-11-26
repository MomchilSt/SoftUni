function intersect(a, b){
    return a.filter((element, index) => b[index] === element).length;
}

function solve(input){
    let result = 0;
    for (let i = 0; i < input.length; i++) {
        result += intersect(input[i], input[i + 1]);
    }

    return result;
}