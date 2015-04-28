function oddOrEven(){
    var number = document.getElementById('numberToCheck').value;
    var result = (parseInt(number)%2)===1?'odd':'even';
    var output = number + ' is ' + result;
    document.getElementById('result-task1').textContent = output;
}
function devidedBy7and5(){
    var number = document.getElementById('devidableNumber').value;
    number= parseInt(number);
    var result = (number%7 === 0) && (number%5===0)?' CAN ':' CAN NOT ';
    var output = number +  result + 'be devided by 7 and 5 at the same time without reminder';
    document.getElementById('result-task2').textContent = output;
}
function calcRectangleArea(){
    var width = document.getElementById('width').value;
    var height = document.getElementById('height').value;
    var result = width*1 * height*1;
    var output = 'Rectangle area is: ' + result;
    document.getElementById('result-task3').textContent = output;
}
function checkThirdDigit(){
    var number = document.getElementById('input-task4').value;
    var thirdDigit = parseInt((number%1000)/100);
    var result = thirdDigit === 7 ? ' True ' : ' False ';
    document.getElementById('result-task4').textContent = result;
}
function check3DigitBinary(){
    var container = document.getElementById('result-task5');
    var number = parseInt(document.getElementById('input-task5').value);
    var binary = parseInt(number.toString(2));
    var result = parseInt((binary%1000)/100)===1? '1' : '0';
    var output = document.createElement('p');
    output.textContent = 'Bit #3 (counting from 0): ' + result;
    container.appendChild(output);
    var output2 = document.createElement('p');
    output2.textContent = 'Binary representation: ' + binary;
    container.appendChild(output2);
}
function checkIfPointIsInCircle(){
    var x = parseInt(document.getElementById('x').value);
    var y = parseInt(document.getElementById('y').value);
    //(x- xC)^2 + (y - yC)^2 = r^2
    var result = ((x -0)*(x-0) + (y-0)*(y-0)) <= 5*5? ' IS ' : ' IS NOT ';
    var output = 'Point' + result + 'inside the Circle(0,5)';
    document.getElementById('result-task6').textContent = output;
}
function checkIfPrime(){
    var number = parseInt(document.getElementById('input-task7').value);
    var root = Math.sqrt(number);
    var isPrime = true;
    for (i = 2; i <= root; i++){
        if((number%i) ===0){
            isPrime=false;
        }
    }
    var result = isPrime? ' IS ' : ' IS NOT ';
    var output = number + result + 'prime.';
    document.getElementById('result-task7').textContent = output;
}
function calcTrapezoidArea(){
    var sideA = parseInt(document.getElementById('sideA').value);
    var sideB = parseInt(document.getElementById('sideB').value);
    var height = parseInt(document.getElementById('heightH').value);
    var result = ((sideA+sideB)/2)*height;
    var output= 'Area: ' + result;
    document.getElementById('result-task8').textContent = output;
}
function pointPosition(){
    var x = parseInt(document.getElementById('x').value);
    var y = parseInt(document.getElementById('y').value);
    //(x- xC)^2 + (y - yC)^2 = r^2
    var isInsideCircle = (((x -1)*(x-1) + (y-1)*(y-1)) <= 3*3)? ' IS ' : ' IS NOT ';
    var isInsideRectangle = (x>=1)
                            &&(x<=3)
                            &&(y>=-1)
                            &&(y<=5)
                            ? ' IS ' : 'IS NOT';
    var output = 'Point' + isInsideCircle + 'inside the Circle((1,1),3) and ' + isInsideRectangle + 'inside the Rectangle' ;
    document.getElementById('result-task9').textContent = output;
}

//Common fincs
function clearTextArea(){
    var clear = document.getElementById('result-task5');
    clear.clearAttributes();
}