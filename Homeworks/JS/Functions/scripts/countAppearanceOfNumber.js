function countAppearanceOfNumber(){
    var arr = [4,1,5,4,2,3,4,5,4]//parseInt(document.getElementById('initial-task3').textContent).split(/[\s,]+/);
    var target = parseInt(document.getElementById('input-task5').value),
        result;


    result = countOccurrences(arr, target);


    document.getElementById('result-task5').textContent = "Appearance: " + result + ' times.';
}

function countOccurrences(arr, target){
    var count = 0;
    for(var num in arr){
        if(arr[num] === target){

            count++;
        }
    }

    return count;
}

