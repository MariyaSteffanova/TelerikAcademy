function stringFormat(){
    var firstString = format('Hello {0}!', 'Peter');
    var frmt = '{0}, {1}, {0} text {2}';
    var secondString = format(frmt, 1, 'Pesho', 'Gosho');

    console.log(firstString);
    console.log(secondString);

    var p = document.createElement('p');
    p.textContent = firstString;
    document.getElementById('result-task11').appendChild(p);

    var p2 = document.createElement('p');
    p2.textContent = secondString;
    document.getElementById('result-task11').appendChild(p2);
}

function format(){
    var args = arguments;
    var string = args[0];

    // for firstString:
    //     args[0] = 'Hello {0}!'
    //     args[1] = 'Peter'
    // ------------------------
    // for secondString :
    //     args[0] = frmt
    //     args[1] = 1
    //     args[2] = 'Pesho'
    //     args[3] = 'Gosho'

    for (var index = 1; index < args.length; index += 1) {
        var placeholder = '{' + (index-1) + '}';

        // replacing all placeholders with equal numbers, for exaple in frmt there are 2 placeholders with value 0
        while(string.indexOf(placeholder) > -1) {
            string = string.replace(placeholder, args[index]) // ex.: replace {0} with 1
        }
    }

    return string;
}