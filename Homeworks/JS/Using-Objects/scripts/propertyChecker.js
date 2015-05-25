function checkProperty(){
    var person = new personBuilder('pesho', 'stamatov', 28);

    //GUI Properties
    var propertiesStr = '';
    for(var prop in person){
        propertiesStr += prop + ', ';
    }
    document.getElementById('initial-task4').textContent = 'Properties: ' + propertiesStr;
    document.getElementById('hint').style.display = 'none';
    var target = (document.getElementById('input-task4').value).trim();
    var hasProp = hasProperty(person, target);

    document.getElementById('result-task4').textContent = hasProp ? 'YES' : 'NO';

}
function personBuilder(fname, lname, ageInit){
    return {
        firstName: fname,
        lastName: lname,
        age: ageInit
    }
}
function hasProperty(obj, property){
    for(var prop in obj ){
        if(prop === property){
            return true;
        }
    }
    return false;
}

