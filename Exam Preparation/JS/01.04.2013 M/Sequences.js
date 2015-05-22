function Solve(params) {
    var N = parseInt(params[0]);
    var answer = 1;
    var arr = [];
    arr[1] = parseInt(params[2]);

    for (var i = 0; i <= N; i++) {
        arr[i] = parseInt(params[i+1]);

    }
    for (var index = 1; index <= arr.length; index++) {
        if(arr[index]<arr[index-1]){
            answer+=1;
        }
    }

    return console.log(answer);
}
