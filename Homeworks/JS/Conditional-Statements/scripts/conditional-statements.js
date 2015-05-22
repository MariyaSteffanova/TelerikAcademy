function exchangeValues(){
    var first = parseFloat(document.getElementById('input-task1-first').value.replace(',','.'));
    var second = parseFloat(document.getElementById('input-task1-second').value.replace(',','.'));
    // 5 3 -> 3 5
    var smaller = first;
    var bigger = second ;
    if(first>second){
        smaller = second;
        bigger = first;
    }
    document.getElementById('result-task1-first').textContent = 'a = ' + smaller;
    document.getElementById('result-task1-second').textContent ='b = ' + bigger;
}
function checkProductSign(){
    var first = parseFloat(document.getElementById('input-task2-first').value.replace(',','.'));
    var second = parseFloat(document.getElementById('input-task2-second').value.replace(',','.'));
    var third = parseFloat(document.getElementById('input-task2-third').value.replace(',','.'));
    var count = 0;
    var result;
    //use sequence of if statements
    if(first===0 || second === 0 || third === 0) {
        result = '0';
    }
    else {
        if (first < 0) {
            count++;
        }
        if (second < 0) {
            count++;
        }
        if (third < 0) {
            count++;
        }
        if (count % 2 == 0) {
            result = '+';
        }
        else {
            result = '-';
        }
    }
    document.getElementById('result-task2').textContent = 'Sign of the product is:  ' + result;
}


function findBiggestFrom3(){
    var first = parseFloat(document.getElementById('input-task3-first').value.replace(',','.'));
    var second = parseFloat(document.getElementById('input-task3-second').value.replace(',','.'));
    var third = parseFloat(document.getElementById('input-task3-third').value.replace(',','.'));
    var biggest = findBiggestNum(first, second, third);
    document.getElementById('result-task3').textContent = 'Biggest is:  ' + biggest;
}

function sortDescending(){
    var numbers = new Array(3);
     numbers[0] = parseInt(document.getElementById('input-task4-first').value);
     numbers[1] = parseInt(document.getElementById('input-task4-second').value);
     numbers[2] = parseInt(document.getElementById('input-task4-third').value);
    var sorted = sortArr(numbers);
    document.getElementById('result-task4').textContent = numbers.join('  ');
}

function spellDigit(){
    var digit = parseInt(document.getElementById('input-task5').value);
    var result;

    switch(digit){
        case 0: result='zero'; break;
        case 1: result='one'; break;
        case 2: result='two'; break;
        case 3: result='three'; break;
        case 4: result='four'; break;
        case 5: result='five'; break;
        case 6: result='six'; break;
        case 7: result='seenv'; break;
        case 8: result='eight'; break;
        case 9: result='nine'; break;
        default :
                result = 'Please enter digit. (0-9)'
            break;
    }
    document.getElementById('result-task5').textContent = result;
}

function calcQuadraticEquation(){
    var a = parseFloat(document.getElementById('input-task6-first').value.replace(',','.'));
    var b = parseFloat(document.getElementById('input-task6-second').value.replace(',','.'));
    var c = parseFloat(document.getElementById('input-task6-third').value.replace(',','.'));

    var container = document.getElementById('result-task6');

    var D = (b*b) - 4*a*c;

    if(D<0){
        container.textContent = 'No real roots';
    }
    if(D===0){
        var x = -b/(2*a);
        container.textContent = 'x = ' + x;
    }
    if(D>0){
        var x1 = (-b - Math.sqrt(D))/(2*a);
        var x2 = (-b + Math.sqrt(D))/(2*a);

        document.getElementById('result-task6').textContent = 'x1 = ' + x1 + ' , x2 = ' + x2;
    }

}

function findBiggestFrom5(){
    var numbers = new Array(5);
    numbers[0] = parseInt(document.getElementById('input-task7-first').value);
    numbers[1] = parseInt(document.getElementById('input-task7-second').value);
    numbers[2] = parseInt(document.getElementById('input-task7-third').value);
    numbers[3] = parseInt(document.getElementById('input-task7-fourth').value);
    numbers[4] = parseInt(document.getElementById('input-task7-fifth').value);
    var sorted = sortArr(numbers);
    document.getElementById('result-task7').textContent = sorted[0];
}

function translateNumber(){
    var number = parseInt(document.getElementById('input-task8').value);
    var numberAsWord = translate(number);
    document.getElementById('result-task8').textContent = numberAsWord ;
}
//Common
function translate(number){
    var result = '';
    var thirdDigit = number / 100;
    var hundred = " hundred ",
        ty = "ty",
        teen = "teen";

    var firstDigitStr = [ "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" ];
    var secondDigitStr =[ " ", "", "twenty", "thirty", "forty", "fifty" ];
    var tenToNineteen = [ "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen" ];

    if (number < 0 || 1000 <= number)
    {
        result += "I don't know this number :( Please enter a number in the range [0..999]";
    }
    else
    {
        if (number==0)
        {
            result += firstDigitStr[0];
        }
        if (number >= 100) // for(i=0, number >99 || number < 1000, i++)
        {
            switch (thirdDigit)
            {
                case 0:
                    result += " ";
                    break;
                case 1:
                    result += firstDigitStr[1] + hundred;
                    break;
                case 2:
                    result += firstDigitStr[2] + hundred;
                    break;
                case 3:
                    result += firstDigitStr[3] + hundred;
                    break;
                case 4:
                    result += firstDigitStr[4] + hundred;
                    break;
                case 5:
                    result += firstDigitStr[5] + hundred;
                    break;
                case 6:
                    result += firstDigitStr[6] + hundred;
                    break;
                case 7:
                    result += firstDigitStr[7] + hundred;
                    break;
                case 8:
                    result += firstDigitStr[8] + hundred;
                    break;
                case 9:
                    result += firstDigitStr[9] + hundred;
                    break;
                default:
                    break;
            }
            if (number >= 100 && number % 100 <= 20 && number%100>0)
            {
                result += "and ";
            }
        }

        number %= 100;
        if (number >= 20)
        {
            var secondDigit = number / 10;
            switch (secondDigit)
            {
                case 0:
                    result += secondDigitStr[0];
                    break;
                case 1:
                    result += secondDigitStr[1];
                    break;
                case 2:
                    result += secondDigitStr[2];
                    break;
                case 3:
                    result += secondDigitStr[3];
                    break;
                case 4:
                    result += secondDigitStr[4];
                    break;
                case 5:
                    result += secondDigitStr[5];
                    break;
                case 6:
                    result += firstDigitStr[6] + ty;
                    break;
                case 7:
                    result += firstDigitStr[7] + ty;
                    break;
                case 8:
                    result += firstDigitStr[8] + ty;
                    break;
                case 9:
                    result += firstDigitStr[9] + ty;
                    break;
                default:
                    break;
            }
            if (number >= 20 && (number % 10) > 0)
            {
                result += "-";
            }
            number %= 10;
        }

        if (10 <= number || number < 20)
        {
            switch (number)
            {
                case 10:
                    result += tenToNineteen[0];
                    break;
                case 11:
                    result += tenToNineteen[1];
                    break;
                case 12:
                    result += tenToNineteen[2];
                    break;
                case 13:
                    result += tenToNineteen[3];
                    break;
                case 14:
                    result += tenToNineteen[4];
                    break;
                case 15:
                    result += tenToNineteen[5];
                    break;
                case 16:
                    result += firstDigitStr[6] + teen;
                    break;
                case 17:
                    result += firstDigitStr[7] + teen;
                    break;
                case 18:
                    result += firstDigitStr[8] + teen;
                    break;
                case 19:
                    result += firstDigitStr[9] + teen;
                    break;

                default:
                    break;
            }

        }
        if (number < 10)
        {
            switch (number)
            {
                case 1:
                    result += firstDigitStr[1];
                    break;
                case 2:
                    result += firstDigitStr[2];
                    break;
                case 3:
                    result += firstDigitStr[3];
                    break;
                case 4:
                    result += firstDigitStr[4];
                    break;
                case 5:
                    result += firstDigitStr[5];
                    break;
                case 6:
                    result += firstDigitStr[6];
                    break;
                case 7:
                    result += firstDigitStr[7];
                    break;
                case 8:
                    result += firstDigitStr[8];
                    break;
                case 9:
                    result += firstDigitStr[9];
                    break;

                default:
                    break;
            }
        }
    }
    return result;
}
function findBiggestNum(first, second, third) {
    var biggest = first;
    if (second > first) {
        biggest = second;
        if (third > second) {
            biggest = third;
        }
    }
    else if (third > first) {
        biggest = third;
    }
    return biggest;
}

function sortArr(array){
    var i, j, k, temp;
    // 1  3  7  9
    // 9  4  2  1
    for(i=0; i< array.length -1; i++){
        k=i;
        for(j=1+i; j< array.length; j++){
            if(array[j]>array[k]){
                k=j;
            }
        }
        if(k!=i) {
            temp = array[k];
            array[k] = array[i];
            array[i] = temp;
        }
    }
return array;
}