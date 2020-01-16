const actions = {
    add: (a, x) => [...a, x],
    remove: (a, x) => a.filter(y => y !== x),
    print: (a, _) => console.log(a.join(", "))
};

function solve(input){
    let arr = [];

    for (let i = 0; i < input.length; i++) {
        let [command, params] = input[i].split(" ");
        arr = actions[command](arr, params);
    }
}