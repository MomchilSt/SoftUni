function addItem() {
    const SELECTORS ={
        list: '#items',
        input: '#newItemText'
    }

    let text = document.querySelector(SELECTORS.input);
    let li = document.createElement('li');
    li.innerHTML = text.value;
    document.querySelector(SELECTORS.list).appendChild(li);

    text.value = '';
}