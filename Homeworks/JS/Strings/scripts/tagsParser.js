// TODO: nasted tags with recourssion or stack !!!! :))))
// TODO: nasted tags with recourssion or stack !!!! :))))
function parseTags(){
    var text = "We are <mixcase>living</mixcase> in a <upcase>yellow suBMarine</upcase>. We <mixcase>don't</mixcase> have <lowcase>anyTHing</lowcase> else.";

   var openTagBeg = '<',
       closeTagBeg = '</',
       tagEnd = '>',
       indexOpenTagBeg = 1,
       indexCloseTagBeg,
       indexTagEnd,
       currentTag,
       currentSubstring;

    String.prototype.toMixedCase = function(){
        var mixed = [];
        for (var ind = 0; ind < this.length; ind += 1) {
            var rand = Math.random();
            if(rand<0.5){
                mixed.push(this[ind].toUpperCase());
            }
            else{
               mixed.push(this[ind] =  this[ind].toLowerCase());
            }
        }
        return mixed.join('');

    };

    while(indexOpenTagBeg >=0){
        indexOpenTagBeg = text.indexOf(openTagBeg);
        indexTagEnd = text.indexOf(tagEnd);
        indexCloseTagBeg = text.indexOf(closeTagBeg);
        currentTag = (text.substring(indexOpenTagBeg + 1, indexTagEnd)).toLowerCase();
        currentSubstring = text.substring(indexTagEnd +1,indexCloseTagBeg);

        switch(currentTag){
            case 'upcase':
                    text = text.replace(currentSubstring, currentSubstring.toUpperCase());

                break;
            case 'lowcase':
                    text = text.replace(currentSubstring, currentSubstring.toLowerCase());
                break;
            case 'mixcase':
                    text = text.replace(currentSubstring, currentSubstring.toMixedCase());
                break;
        }

       var openTagToRemove = '<'+ currentTag + '>';
       var closeTagToRemove = '</' + currentTag + '>';
        text = text.replace(openTagToRemove, ' ');
        text= text.replace(closeTagToRemove, ' ');

    }
    document.getElementById('result-task4').textContent = text;
}