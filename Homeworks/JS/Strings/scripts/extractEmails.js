function extractEmails(){
    var text = 'If you have questions about LINQ or Unity you can write on ivaylo.kenov@abg.gr. If you have questions about algorythms you can write to Nikolay Kostov at nikolay_kostov@abc.en. If you have another questions you can write to te follow contacts: academy.telerik@telerik.net, zdravko9georgiev@insomnia.es, doncho-minkov@giginmail.com or evlogi.hristov_9@example.fr. ';
    var regex = /([a-zA-Z0-9._-]+@[a-zA-Z]+\.[a-zA-Z]+)/gi;
    var emails = text.match(regex);

    for(var email in emails){
        var p = document.createElement('p');
        p.textContent = emails[email];
        document.getElementById('result-task9').appendChild(p);
    }

    console.log(emails.join('\n\r'));

}