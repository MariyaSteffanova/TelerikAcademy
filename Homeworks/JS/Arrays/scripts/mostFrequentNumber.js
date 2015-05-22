function findFrequent(){
    var numbers = [4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3];
    var count = 1,
        index = -1,
        maxCount = -1;

    document.getElementById('initial-task6').textContent = numbers.join(', ');

    numbers = numbers.sort(function(a,b){
        return a-b;
    })

    for (var ind = 1; ind <= numbers.length; ind++) {
        if(numbers[ind-1] === numbers[ind]){

            ++count;
        }
       else{
            count = 1;
        }
        if(count> maxCount){
            maxCount = count;
           // count = 1;
            index = ind;
        }
        console.log(numbers[ind]);
    }
    document.getElementById('result-task6').textContent = numbers[index] + ", " + maxCount + " times.";
}