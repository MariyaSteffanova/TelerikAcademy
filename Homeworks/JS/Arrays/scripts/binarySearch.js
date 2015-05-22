function binarySearch(){
    var numbers = [5,6,7,8,9,10,11,12,13,14,15,16,17];
    var min = 0,
        max = numbers.length- 1,
        key = parseInt(document.getElementById('input-task7').value);
    var result = search(numbers, key, min, max);

    document.getElementById('initial-task7').textContent = 'Sorted array: ' + numbers.join(', ');
    document.getElementById('result-task7').textContent = 'Number ' + numbers[result] + ' found at index: ' + result;
}

function search( arr, key, min, max){
   var mid = parseInt((min + max)/2);

    if(arr[mid] > key){
        return search(arr, key, min, mid - 1);
    }
    else if(arr[mid] < key){
        return search(arr, key, mid + 1, max);
    }
    else{
        return mid;
    }
}