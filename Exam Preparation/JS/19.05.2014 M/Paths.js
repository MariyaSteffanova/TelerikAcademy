function solve(args){
    var dimensions = args[0].split(' ');
    var rows = dimensions[0];
    var cols = dimensions[1];
    var dirMatrix = []  ;
    var matrix = [];
    for (var row = 0; row < rows; row++) {
        var dirs = args[row+1].split(' ');
        dirMatrix[row] = [];
        matrix[row] = [];
        matrix[row][0] = Math.pow(2, row);

        for (var col = 0; col < cols; col++) {

            dirMatrix[row][col] = dirs[col];
            matrix[row][col] = matrix[row][0] + col;
        }
    }

    var r = 0;
    var c = 0;

    var sum = 0;

    while(true){

        if(matrix[r][c] == 'v'){
            return console.log('failed at (' + r + ', ' + c + ')');
        }
        sum += matrix[r][c];
        matrix[r][c] = 'v';

        switch(dirMatrix[r][c]){
            case 'dr': r+=1; c+=1; break;
            case 'dl': r+=1; c-=1; break;
            case 'ur': r-=1; c+=1; break;
            case 'ul': r-=1; c-=1; break;
        }

        if(r < 0 || r >=rows || c < 0 || c >= cols )
        {
            return console.log('successed with ' + sum);
        }
    }
}



