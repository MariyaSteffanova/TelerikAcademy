function countSubstrings(){
    var text = document.getElementById('initial-task3').textContent.toLowerCase();


    var count = 0;
    var target = document.getElementById('input-task3').value.toLowerCase() || 'in';
    var lastIndex = text.length;
    var indexOfTarget =text.indexOf(target);

    while(indexOfTarget >= 0){

        count++;
        text = text.substring(indexOfTarget + 1,lastIndex );
        indexOfTarget = text.indexOf(target);
        console.log(text);
    }

    document.getElementById('result-task3').textContent = 'Result: ' + count;
}