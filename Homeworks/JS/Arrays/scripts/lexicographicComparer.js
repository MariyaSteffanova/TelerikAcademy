function compareCharArrays(){
    var first = document.getElementById('first-in-task2').value,
        second = document.getElementById('second-in-task2').value,
        result = compare(first, second);
    document.getElementById('result-task2').textContent = result;
}

function compare(a,b){

    var lenght = Math.min(a.length, b.length);

    for (var i = 0; i < lenght; i++) {
        if(a[i]<b[i]){
            return a;
        }
        else if(a[i]>b[i]){
            return b;
        }
    }
    return (a.length< b.length) ? a : b;
}