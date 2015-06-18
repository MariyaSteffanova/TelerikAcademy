/* Task description */
/*
	Write a function a function that finds all the prime numbers in a range
		1) it should return the prime numbers in an array
		2) it must throw an Error if any on the range params is not convertible to `string`
		3) it must throw an Error if any of the range params is missing
*/

function solve(from, to) {
	var divider,
		isPrime,
		primes = [],
		to = +to,
		from = +from;

	if(isNaN(to) || isNaN(from)){
		throw  new Error();
	}
	for (var number = from; number <= to; number += 1) {
		divider = Math.sqrt(number);
		isPrime = true;

		if(number < 2){
			isPrime = false;
			continue;
		}

		for (var i = 2; i <= divider; i += 1) {
			if(number%i==0){
				isPrime = false;
			}
		}
		if(isPrime){
			primes.push(number);
		}
	}

	return primes;
}


module.exports = solve;