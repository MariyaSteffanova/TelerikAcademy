function findMaxIncreasingSequence(){
    var numbers = [3, 2, 3, 4, 2, 2, 4];

    var count = 0,
        index = -1,
        maxCount = -1,
        increasingSeq = [];

    document.getElementById('initial-task4').textContent = numbers.join(' ,');

    for (var ind = 1; ind < numbers.length; ind++) {
        if(numbers[ind-1] < numbers[ind]){

            count++;
        }
        else{
            count = 0;
        }
        if(count> maxCount){
            maxCount = count;
            index = ind;
        }

    }
    for (var i = index-maxCount; i <= index; i++) {
        increasingSeq.push(numbers[i]);

    }

    document.getElementById('result-task4').textContent = increasingSeq.join(' ,');
}