function reverseString(){
    var string = document.getElementById('input-task1').value;
    // TODO: trim

    var reversed = [];

    for (var index = string.length - 1 ; index >=0; index--) {
        reversed.push(string[index]);
    }

    document.getElementById('result-task1').textContent = reversed.join('');

}