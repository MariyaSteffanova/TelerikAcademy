function biggerThanNeighbours(){
    var numbers = [1,2,3,4,3,3,7,0];
    var target = parseInt(document.getElementById('input-task6').value);
    var result = isBiggerThanNeighbours(numbers, target);

    document.getElementById('result-task6').textContent = result;

}

function firstBiggerThanNeighbours(){
    var numbers = [1,2,3,4,3,3,7,0];
    var result = isBiggerThanNeighbours(numbers);

    document.getElementById('result-task7').textContent = result;
}

function isBiggerThanNeighbours(arr, target){
    var result;
    if(!target){
        for (var ind = 1; ind < arr.length; ind++) {
            if((arr[ind-1] < arr[ind]) &&
                (arr[ind] > arr[ind+1])){
                return ind;
            }
            else{
                result =  -1;
            }
        }
    }
    else{
        if(arr[target -1] === undefined ||
            arr[target + 1] === undefined){
            return arr[target] + ' does not have two neighbours';
        }
        else{
            if(arr[target-1] < arr[target] &&
                arr[target] > arr[target + 1]){
                return true;
            }
            else{
                return false;
            }
        }
    }
    return result;
}