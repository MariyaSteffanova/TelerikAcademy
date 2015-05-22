function increaseArrayMembers(){
    var numbers = [];

    for(var index = 0; index < 20; index++){
        numbers.push(index*5);
    }

    document.getElementById('result-task1').textContent = "Array: " + numbers.join(',');
}