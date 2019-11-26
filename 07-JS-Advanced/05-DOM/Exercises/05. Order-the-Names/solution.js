function solve() {
    let db = {};
    let arrFromLi = [...document.getElementsByTagName("li")];
    arrFromLi.map((x, i)=> db[String.fromCharCode(i + 65)] = [x.innerHTML.split(', ')]);

    function addElements() {
        let name = document.getElementsByTagName('input')[0].value.toLowerCase();
        let capitalizeName = name.charAt(0).toUpperCase() + name.slice(1);
        db[capitalizeName[0]].push(capitalizeName);
        
        arrFromLi.forEach((x, i) => x.innerHTML = db[String.fromCharCode(i + 65)].filter(e => e != "").join(', '));
        document.getElementsByTagName('input')[0].value = '';
    }

    document.getElementsByTagName('button')[0].addEventListener('click', addElements);
}