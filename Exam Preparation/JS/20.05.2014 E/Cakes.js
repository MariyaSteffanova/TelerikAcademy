function solve(params) {
    var s = parseInt(params[0]);
    // Your solution here
    var c1 =parseInt(params[1]);
    var c2 = parseInt(params[2]);
    var c3 = parseInt(params[3]);
    var rest;
    var minRest = s;
    for (var tr = 0; tr <= s / c1; tr++) {

        for (var c = 0; c <= s / c2; c++) {
            for (var trik = 0; trik <= s / c3; trik++) {

                var curSum = (trik * c3) + (c * c2) + (tr * c1);

                rest = s - curSum;
                if(minRest > rest && rest >= 0){
                    minRest = rest;
                }
            }
        }
    }
    console.log(s-minRest);
}

