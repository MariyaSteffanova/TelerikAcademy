function parseURL(){

    var urlTest = new URL('http://telerikacademy.com/Courses/Courses/Details/239');

    console.log(urlTest);
    console.log(urlTest.protocol);
    console.log(urlTest.server);
    console.log(urlTest.resource);

    for(var prop in urlTest){
        if(typeof urlTest[prop] !== "function") {
            var p = document.createElement('p');
            p.textContent = prop + ' : ' + urlTest[prop];
            document.getElementById('result-task7').appendChild(p);
        }
    }


}

function URL(href){
    this.element = function(){
        var a = document.createElement('a');
        a.href = href;
        return a;
    }
    this.protocol = this.element()['protocol'];
    this.server = this.element()['host'];
    this.resource = this.element()['pathname'];
}

//Second way:

/*
function parseURL(){
    var a= document.createElement('a');
    a.href = 'http://telerikacademy.com/Courses/Courses/Details/239';

    var urlTest = new URL(a);

    //Copy output lines for debug
    console.log(urlTest);
    console.log(urlTest.protocol);
    console.log(urlTest.server);
    console.log(urlTest.resource);
}

function URL(href){
    this.protocol = href['protocol'];
    this.server = href['host'];
    this.resource = href['pathname'];
}*/
