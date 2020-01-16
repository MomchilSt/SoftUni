function solve(){
    let currentText = '';

    function append(string){
        currentText += string;
    }

    function removeStart(n){
        currentText = currentText.substring(n);
    }

    function removeEnd(n){
        currentText = currentText.substring(0, currentText.length - n);
    }

    function print(){
        console.log(currentText);
    }

    return{
        append,
        removeStart,
        removeEnd,
        print
    };
}