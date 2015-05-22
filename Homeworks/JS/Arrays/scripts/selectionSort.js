function selectionSort(){
    var numbers = [8,3,6,1,9,2,5,4,7];

    var min,
        i,
        j,
        temp;

    document.getElementById('initial-task5').textContent = numbers.join(', ');

    for ( j = 0; j < numbers.length-1; j++) {

        min = j;

        for ( i = j+1; i < numbers.length; i++) {
            if(numbers[i] < numbers[min]){
                min = i;
            }
        }

        if(min != j){
            temp = numbers[j];
            numbers[j] = numbers[min];
            numbers[min] = temp;
        }

    }

    document.getElementById('result-task5').textContent = numbers.join(', ');
}