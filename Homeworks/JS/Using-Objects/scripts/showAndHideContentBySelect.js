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