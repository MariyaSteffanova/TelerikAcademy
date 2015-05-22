function showDiv(elem){
    var containers = document.getElementsByClassName('task-container');
    for(var index in containers){
        if(containers[index].id == elem.value){
            containers[index].style.display = "block";
        }
        else{
            containers[index].style.display = "none";
        }
    }
}

function printNumbers(){
    var number = parseInt(document.getElementById('input-task1').value);

    for(var num = 1; num <= number; num++){
        document.getElementById('result-task1').textContent += (num + '  ');
    }
}

function printNotDivisibleBy3And7(){
    var number = parseInt(document.getElementById('input-task2').value);


    for(var num = 1; num <= number; num++){
        var isDivisibleBy3 = num%3 === 0;
        var isDivisibleBy7 = num%7 === 0;
        if(!(isDivisibleBy3 && isDivisibleBy7)) {
            document.getElementById('result-task2').textContent += (' ' + num + ' ');
        }
    }
}

function findMinAndMaxValue(){
    var sequence = document.getElementById('input-task3').value.split(/[\s,]+/);

    var min = findMin(sequence);
    var max = findMax(sequence);

    document.getElementById('result-task3').textContent = "Min: " + min +" | " + " Max: " + max;

}

function findMin(sequence){
    var minIndex = 0;

    for(var index = 0; index < sequence.length; index++){
        if(sequence[index] < sequence[minIndex]){
            minIndex = index;
        }
    }
    return sequence[minIndex];
}

function findMax(sequence){
    var maxIndex = 0;

    for(var index = 0; index < sequence.length; index++){
        if(sequence[index] > sequence[maxIndex]){
            maxIndex = index;
        }
    }
    return sequence[maxIndex];
}

function compareProperties(){

    var properties = [];
    for (var prop in document) {
        properties.push(prop);
    }
    var documentMin = findMin(properties);
    var documentMax = findMax(properties);

    properties = [];

    for (var prop in window) {
        properties.push(prop);
    }
    var windowMin = findMin(properties);
    var windowMax = findMax(properties);

    properties = [];

    for (var prop in navigator) {
        properties.push(prop);
    }
    var navwMin = findMin(properties);
    var navwMax = findMax(properties);


    document.getElementById('document').textContent = "DOCUMENT: " + "Min: " + documentMin + " | " + "Max: " + documentMax;
    document.getElementById('window').textContent = "WINDOW: " + "Min: " + windowMin + " | " + "Max: " + windowMax;
    document.getElementById('navigator').textContent = "NAVIGATOR: " + "Min: " + navwMin + " | " + "Max: " + navwMax;
}