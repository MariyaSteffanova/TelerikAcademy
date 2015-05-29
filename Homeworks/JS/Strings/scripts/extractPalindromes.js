function extractPalindromes(){
    var text = 'deleveled - something that goes out of level '+
        ' evitative – a grammatical case indicating fear or aversion ' +
        ' Malayalam – a language of South India ' +
        ' redivider – someone or something that redivides (tied for longest "real" palindrome that is not a proper noun and that appears in English dictionaries)'+
        ' releveler – (American spelling) someone or something that levels again (tied for longest "real" palindrome that is not a proper noun and that appears in English dictionaries).'+
        ' Rotavator – a type of machine for breaking up soil (trademark)';
    var words = text.split(' ');
    var palindromes = [];

    for(var w in words){
        var word = words[w].toLowerCase();
        var isPalindrome = true;
        for (var index = 0; index < word.length/2; index += 1) {

            if(word[index] !== word[word.length -1 - index]){
                isPalindrome = false;
            }

        }
        if(isPalindrome && word.length > 1){
            palindromes.push(word);
        }
    }

    console.log(palindromes.join('\n\r'));
    document.getElementById('result-task10').textContent = 'Palindromes: ' + palindromes.join(', ');
}