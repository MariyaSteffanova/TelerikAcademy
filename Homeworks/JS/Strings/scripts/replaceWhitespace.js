function replaceWhitespace(){
    var text = "We are   living in a yellow submarine. We don't have anything   else.";

    var text = text.replace(/ /gi, '&nbsp;');
    //var text = replaceAll(text, ' ', '&nbsp;');

    console.log(text);

    //HTML GUI
    document.getElementById('result-task5').textContent = text;
    document.getElementById('result-task5').style.wordWrap = 'break-word';
    var ps = document.createElement('p');
    ps.textContent = 'P.S: You can take a look at js file for the two ways I found to replace all strings and maybe use replaceAll ' +
        'function for your library for JS exam :) (if you don\'t have it already of course)';
    ps.style.color = '#693';
    document.getElementById('result-task5').appendChild(ps);
}

function replaceAll(text, oldString, newString){
    var regex = new RegExp(oldString, 'gi');
    return text.replace(regex, newString);
}