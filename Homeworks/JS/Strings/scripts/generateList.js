var people = [
    {name: 'Pesho', age: 22},
    {name: 'Gosho', age: 24},
    {name: 'Tosho', age: 42},
    {name: 'Sasho', age: 32},
    {name: 'Misho', age: 28},
    {name: 'Pesho', age: 38}
];

var template = document.getElementById('list-item').innerHTML;

function generateList(){
    var ul = document.createElement('ul');

    for(var ind in people){
        var li = document.createElement('li');
        li.innerHTML = format(template, people[ind]);
        ul.appendChild(li);
    }
    document.body.appendChild(ul);
}
function format(string, person){
    var prop = string.match(/({\w+)/g);

    for (var index = 0; index < prop.length; index += 1) {
        prop[index] = prop[index].replace('{', '');
    }

    string = string.replace(/\-{(name)\}-/g,  person[prop[0]]);
    string = string.replace(/\-{(age)\}-/g,  person[prop[1]]);

    return string;
}

