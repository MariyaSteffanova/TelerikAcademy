var arr = [];
Array.prototype.remove = function(element){
    for(var el in arr){
        if(arr[el] === element){
              arr.splice(el,1);
        }
    }
    return arr;
}

function removeElements(){
     arr = [1,2,1,4,1,3,4,1,111,3,2,1,'1'];
    var target = parseInt(document.getElementById('input-task2').value);
    arr = arr.remove(target);

    document.getElementById('result-task2').textContent = arr.join(', ');
}