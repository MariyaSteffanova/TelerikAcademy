function reverseNumber(){
    var number = document.getElementById('input-task2').value;

    var result = [];

    for (var index = number.length - 1; index >= 0; index--) {
        result.push(number[index]);

    }

    document.getElementById('result-task2').textContent = 'Reversed: ' + result.join('');
}