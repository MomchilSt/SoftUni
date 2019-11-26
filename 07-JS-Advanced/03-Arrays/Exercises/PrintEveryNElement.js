function solve(arr){
    let n = +arr.pop();
    return arr.filter((el, index) => {
        return index % n == 0;
    })
    .join("\n");
}

solve(['5', 
'20', 
'31', 
'4', 
'20', 
'2']
);