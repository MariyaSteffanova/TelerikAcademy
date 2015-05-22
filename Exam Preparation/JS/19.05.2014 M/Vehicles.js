function solve(params) {
    var s = parseInt(params);
    var count = 0;
    // Your solution here
    var trucks = 10;
    var cars = 4;
    var trikes = 3;

    for (var tr = 0; tr <= s / trucks; tr++) {


        for (var c = 0; c <= s / cars; c++) {


            for (var trik = 0; trik <= s / trikes; trik++) {
                var curSum = (trik * trikes) + (c * cars) + (tr * trucks);
                if (s === curSum) {
                    count = count + 1;
                }
            }
        }
    }
    console.log(count);
}

