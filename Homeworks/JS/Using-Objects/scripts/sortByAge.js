function Person(fname, lname, ageInit){
    return {
        firstName: fname,
        lastName: lname,
        age: ageInit,
        printObj: function(){
            return this.firstName + ' ' + this.lastName + ' ' + this.age;
        }
    };
}

function compare(a,b) {
    if (a.age < b.age)
        return -1;
    if (a.age > b.age)
        return 1;
    return 0;
}

function findYoungest(){
    var people2 =[
         new Person('Peter', 'Strashimirov', 31),
         new Person('Toshko', 'Roshkov', 29),
         new Person('George', 'Carlin', 54)
        ];


    for(var person in people2){
        if(people2[person].age) {
            var paragraph = document.createElement('p');
            var str = people2[person].printObj();
            console.log(str);
            paragraph.textContent = str;
            document.getElementById('initial-task5').appendChild(paragraph);
        }
    }
    people2 = people2.sort(compare);
    document.getElementById('result-task5').textContent = "Youngest : " + people2[0].printObj();

}