function solve() {
    document.getElementById('btnLoadTowns').addEventListener('click', main)

    async function main() {
        const towns = document.getElementById('towns').value.split(', ');
        const source = await fetch('http://127.0.0.1:5500/01.List-Towns/towns.hbs')
            .then(res => res.text())
            .catch(err => console.log(err));

        const template = Handlebars.compile(source);

        const html = template({ towns });
        document.getElementById('root').innerHTML = html;

        towns.value = "";
    }
}
solve()