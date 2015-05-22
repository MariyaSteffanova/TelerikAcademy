function findMaxSequence(){
    var numbers = [2, 1, 1, 2, 3, 3, 2, 2, 2, 1];
    document.getElementById('initial-task3').textContent = numbers.join(' ,');
    var count = 1,
        index = -1,
        maxCount = -1;

    for (var ind = 1; ind < numbers.length; ind++) {
        if(numbers[ind-1] === numbers[ind]){

            count++;
        }
        if(count> maxCount){
            maxCount = count;
            count = 1;
            index = ind;
        }
    }

    document.getElementById('result-task3').textContent = numbers[index] + ", " + maxCount + " times.";
}