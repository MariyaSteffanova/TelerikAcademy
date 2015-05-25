var point= {
    x: 0,
    y:0
}

function planarCoordinates(){
    var pointFirst = pointBuilder(50, 80),
        pointSecond = pointBuilder(150, 180);
    var distance = calcDistance(pointFirst,pointSecond);
    var a, b, c, d, e, f,l1,l2,l3;
    var points = [
        a = pointBuilder(1000, 80),
        b = pointBuilder(1100, 80),
        c = pointBuilder(1000, 150),
        d = pointBuilder(1050, 150),
        e = pointBuilder(1000, 220),
        f = pointBuilder(1150, 220)
    ];
    var lines = [
        l1 = lineBuilder(a,b),
        l2 = lineBuilder(c,d),
        l3 = lineBuilder(e,f)
    ];
    var canFormTriangle = checkIfCanFormTriangle(lines);

    var guiPoints = document.getElementById('lines-container').children;
    document.getElementById('calculated-distance').textContent = "d = " + Math.round(distance) ;

    //set coordinates to the points
    for (var p = 0; p < guiPoints.length; p++) {
        guiPoints[p].style.left = points[p].x + 'px';
        guiPoints[p].style.top = points[p].y + 'px';
    }

    var answerTriangles =  document.getElementById('result-task1');
    answerTriangles.textContent = canFormTriangle;
    answerTriangles.style.position = 'absolute';
    answerTriangles.style.left = lines[0].P1.x + 'px';
    answerTriangles.style.marginTop = -100 + 'px';
    answerTriangles.style.color = 'orange';
    answerTriangles.style.border = '1px solid orange';
    answerTriangles.style.borderRadius = '5px';
    //create lines & labels for lenght
    createLinesGUI(lines);





}


function pointBuilder(x,y){
    return {
        x: x,
        y: y
    }
}

function lineBuilder( a,  b){
    return {
        P1: a ,
        P2: b,
        lenght: calcDistance(a,b)
    }
}

function calcDistance(pointFirst,pointSecond){
    return Math.sqrt(  (pointSecond.x-pointFirst.x)*(pointSecond.x-pointFirst.x) +
        (pointSecond.y-pointFirst.y)*(pointSecond.y-pointFirst.y));

}

function createLinesGUI(lines) {
    for (var l in lines) {
        var guiLine = document.createElement('HR');
        var lenghtLabel = document.createElement('span');
        //create lines and styles
        guiLine.style.position = 'absolute';
        guiLine.style.left = (lines[l].P1.x + 10) + 'px';
        guiLine.style.top = (lines[l].P1.y - 7) + 'px';
        guiLine.style.width = (lines[l].lenght - 15) + 'px';
        document.getElementById('lines-container').appendChild(guiLine);

        //create labels and styles
        lenghtLabel.style.position = 'absolute';
        lenghtLabel.style.left = (lines[l].P1.x + 17) + 'px';
        lenghtLabel.style.top = (lines[l].P1.y - 17) + 'px';
        lenghtLabel.style.color = 'orange';
        lenghtLabel.textContent = 'l = ' + lines[l].lenght;

        document.getElementById('lines-container').appendChild(lenghtLabel);
    }
}

function checkIfCanFormTriangle(lines){
    var result;
    lines = lines.sort(compare);
    result = lines[0].lenght + lines[1].lenght >= lines[2].lenght;
    if(result){
        return lines[0].lenght + ' + ' + lines[1].lenght + ' >= ' + lines[2].lenght + ' => YES, the segments CAN form triangle.'
    }
    else{
        return lines[0].lenght + ' + ' + lines[1].lenght + ' < ' + lines[2].lenght + ' => NO, the segments CAN NOT form triangle.'
    }
}

function compare(a,b) {
    if (a.lenght < b.lenght)
        return -1;
    if (a.lenght > b.lenght)
        return 1;
    return 0;
}