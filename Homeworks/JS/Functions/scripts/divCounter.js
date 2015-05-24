var divs = document.getElementsByTagName('div');

function count(){
    var count = divs.length;
    document.getElementById('result-container').textContent = count;
}


