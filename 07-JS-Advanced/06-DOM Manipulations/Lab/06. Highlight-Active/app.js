function focus() {
    let allDivs = document.querySelectorAll('div div');

    let arr = Array.from(allDivs);


        function focuseElement(event) {
            event.target.parentNode.className = 'focused';
            event.target.css = css;
        }
        function unfocuseElement(event) {
            event.target.parentNode.className = '';
        }

        arr.forEach(element => {
            element.addEventListener("focus", focuseElement);
            element.addEventListener("blur", unfocuseElement);
        });
}