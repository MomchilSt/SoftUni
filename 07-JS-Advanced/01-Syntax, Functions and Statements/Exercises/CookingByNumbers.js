function solve(array){
    let number = Number(array.shift());

    let operations = {
        chop: (num) => { return num / 2 },
        dice: (num) => { return Math.sqrt(num) },
        spice: (num) => { return ++num },
        bake: (num) => { return num *= 3 },
        fillet: (num) => { return num *= 0.8 }
    }

    for (let index = 0; index < array.length; index++) {
        number = operations[array[index]](number);
        console.log(number)
    }
}