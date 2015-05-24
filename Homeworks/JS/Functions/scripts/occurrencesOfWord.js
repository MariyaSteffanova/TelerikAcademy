function countOccurrences(){
    var text = (document.getElementById('initial-task3').textContent).split(/[\s,]+/);
    var target = 'Lorem',
        caseSensitiveResult,
        caseInsensitiveResult,
        space = new Array(20);

    caseSensitiveResult = countCaseSensitiveOccurrences(text, target);
    caseInsensitiveResult = countCaseInsensitiveOccurrences(text, target.toLowerCase());

    document.getElementById('result-task3').textContent = "Case sensitive occurrences: " + caseSensitiveResult +
                                    space.join('.') +   "Case insensitive occurrences: " + caseInsensitiveResult;
}

function countCaseSensitiveOccurrences(text, target){
    var count = 0;
    for(var word in text){
        if(text[word] === target){

            count++;
        }
    }

    return count;
}

function countCaseInsensitiveOccurrences(text, target){
    var count = 0;
    for(var word in text){
        if(text[word].toLowerCase() === target){

            count++;
        }
    }

    return count;
}