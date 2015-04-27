var string = 'some string';
var int = 54;
var float = 6.9;
var array = ['a','b','c'];
var object = {task: 1};
var func =  function(){
    return;
};
var undefVariable = undefined;
var nullVariable = null;

var variables = [string, int, float, array, object, func, undefVariable, nullVariable];

function printLiterals(){
    for(var variable in variables){
        var result = variables[variable];
        var mydiv = document.getElementById("container-literals");
        console.log(result);
        mydiv.appendChild(document.createTextNode(result));
        mydiv.innerHTML += '<br/>';
    }
}

function printTypeofVariables(){
    for(var variable in variables){
        var result = getTypeofVar(variables[variable]);
        var mydiv = document.getElementById("container");
        console.log(result);
        mydiv.appendChild(document.createTextNode(result));
        mydiv.innerHTML += '<br/>';
    }
}

function getTypeofVar(variable){
    var result= variable;
    result += ' is ' + typeof variable;
    return result;
}