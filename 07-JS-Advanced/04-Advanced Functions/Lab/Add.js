function solve(num) {
    return function (added) {
        return num + added;
    };
}

let add = solve(5);
console.log(
    add(3)
);