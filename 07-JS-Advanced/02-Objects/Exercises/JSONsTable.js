function solve(input){

    return `<table>
    ${input.map(e => JSON.parse(e))
        .reduce((acc, curr) => {
        acc += ` <tr>\n    <td>${curr.name}</td>\n     <td>${curr.position}</td>\n     <td>${curr.salary}</td>\n </tr>\n`;
        return acc;
        }, '')}</table>`;
        
}