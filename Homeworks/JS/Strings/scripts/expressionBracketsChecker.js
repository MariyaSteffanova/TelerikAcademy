function checkBrackets(){
    var expression = document.getElementById('input-task2').value;
    var result = areBracketsCorrect(expression) ? 'Correctly' : 'Incorrectly';

    document.getElementById('result-task2').textContent = result;


}

function areBracketsCorrect(expression){
    var count = 0;

    for(var symbol in expression){
        if(expression[symbol] === '('){
            count++;
        }
        else if(expression[symbol] === ')'){
            count--;
        }
        if(count < 0 ){
            return false;
        }
    }
    return true;
}