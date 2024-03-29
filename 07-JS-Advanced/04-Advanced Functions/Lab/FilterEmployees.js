 function filterByProp(prop, value, element){
     return element[prop] === value;
}

function splitParams(ctriteria){
     return ctriteria.split('-');
}

function formatEmployee(el, i){
    return `${i}. ${el.first_name} ${el.last_name} - ${el.email}`;
}

function solve(data, criteria){
    return criteria === 'all'
    ? JSON.parse(data)
    .map(formatEmployee)
    .join('\n')
    : JSON.parse(data)
    .filter(filterByProp.bind(undefined, ...splitParams(ctriteria)))
    .map(formatEmployee)
    .join('\n');
}