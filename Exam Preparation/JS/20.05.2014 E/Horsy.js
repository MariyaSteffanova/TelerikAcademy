function solve(args) {
    var dimensions = args[0].split(' ');
    var rows = dimensions[0];
    var cols = dimensions[1];

    var dirMatrix = [];
    var matrix = [];

    for (var r = 0; r < rows; r++) {

        dirMatrix[r] = [];
        matrix[r] = [];
        matrix[r][0] = Math.pow(2, r);

        for (var c = 0; c < cols; c++) {

            dirMatrix[r][c] = parseInt(args[r + 1][c]);
            matrix[r][c] = matrix[r][0] - c;

        }

    }

    var count = 0;
    var sum = 0;
    var row = rows - 1;
    var col = cols - 1;

    while(true) {

        sum += matrix[row][col];
        if (matrix[row][col] == 'v') {
            return console.log('Sadly the horse is doomed in ' + count + ' jumps');
        }
        count += 1;

        matrix[row][col] = 'v';


        switch (dirMatrix[row][col]) {
            case 1: row -= 2; col += 1; break;
            case 2: row -= 1; col += 2; break;
            case 3: row += 1; col += 2; break;
            case 4: row += 2; col += 1; break;
            case 5: row += 2; col -= 1; break;
            case 6: row += 1; col -= 2; break;
            case 7: row -= 1; col -= 2; break;
            case 8: row -= 2; col -= 1; break;
        }
        if (row < 0 || col < 0 || row >= rows || col >= cols) {
            return console.log('Go go Horsy! Collected ' + sum + ' weeds');
        }
    }

}