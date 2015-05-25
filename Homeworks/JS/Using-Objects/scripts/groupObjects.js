function groupObjects(){
    var people = [
        new personBuilder('Pesho', 'Georgiev', 22),
        new personBuilder('Pesho', 'Stamatov', 33),
        new personBuilder('Pesho', 'Ivanov',44),
        new personBuilder('Gosho', 'Georgiev', 22),
        new personBuilder('Gosho', 'Stamatov', 44),
        new personBuilder('Gosho', 'Ivanov', 33),
        new personBuilder('Stamat', 'Georgiev', 33),
        new personBuilder('Stamat', 'Stamatov', 22),
        new personBuilder('Stamat', 'Ivanov', 44)
    ];


    personBuilder.prototype.toString = function(){
        return this.firstName + ' ' + this.lastName + ' ' + this.age + ';';
    }

    properties = ['firstName','lastName', 'age'];
     for(var prop in properties){
         var currGroup = group(people, properties[prop]);
         console.log(currGroup);
     }
    document.getElementById('result-task6').textContent =
        "Sorry, I really  have no nerves to print it in the HTML :D You can see the result in the console (F12). Thank you!";

}

function group(arr, property){
    var group = [];

    for(var index in arr){

        var currProp = arr[index][property];
        if(typeof currProp != 'undefined' && !(typeof currProp === 'function')) {
            group[currProp] = group[currProp] ? group[currProp] : [];
            group[currProp].push(arr[index]);
        }

    }
    return group;
}

function personBuilder(fname, lname, ageInit){
    return {
        firstName: fname,
        lastName: lname,
        age: ageInit
    }
}