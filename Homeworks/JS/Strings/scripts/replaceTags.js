function replaceTags(){
    var text = '<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>';
    var aOpenTagBeg = '<a href="',
        aOpenTagEnd = '">',
        aCloseTag = '</a>',
        urlOpenTagBeg = '[URL=',
        urlOpenTagEnd= ']',
        urlCloseTag = '[/URL]';

    text = replaceAll(text, aOpenTagBeg, urlOpenTagBeg);
    text = replaceAll(text, aOpenTagEnd, urlOpenTagEnd);
    text = replaceAll(text, aCloseTag, urlCloseTag);

    document.getElementById('result-task8').textContent = text;
    console.log(text);


}

function replaceAll(text, oldString, newString){
    var regex = new RegExp(oldString, 'gi');
    return text.replace(regex, newString);
}