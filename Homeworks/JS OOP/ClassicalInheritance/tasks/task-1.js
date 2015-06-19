/* Task Description */
/* 
	Create a function constructor for Person. Each Person must have:
	*	properties `firstname`, `lastname` and `age`
		*	firstname and lastname must always be strings between 3 and 20 characters, containing only Latin letters
		*	age must always be a number in the range 0 150
			*	the setter of age can receive a convertible-to-number value
		*	if any of the above is not met, throw Error 		
	*	property `fullname`
		*	the getter returns a string in the format 'FIRST_NAME LAST_NAME'
		*	the setter receives a string is the format 'FIRST_NAME LAST_NAME'
			*	it must parse it and set `firstname` and `lastname`
	*	method `introduce()` that returns a string in the format 'Hello! My name is FULL_NAME and I am AGE-years-old'
	*	all methods and properties must be attached to the prototype of the Person
	*	all methods and property setters must return this, if they are not supposed to return other value
		*	enables method-chaining
*/
function solve() {
	var Person = (function () {

		function Person(firstName, lastName, age) {
			var _firstName, _lastName, _age;
			this.firstname = firstName;
			this.lastname = lastName;
			this.age = age;
		}

		var validator = {
			validateName: function(name) {
				var regexValidationName = /^[A-Za-z]{0,}$/i;
				if(!regexValidationName.test(name)) {
					throw new Error('First name and Last name must always be strings , containing only Latin letters!');
				}
				if(name.length < 3 || name.length > 20){
					throw  new Error('First name and Last name must always be strings between 3 and 20 characters!');
				}
			},
			validateAge: function(age) {
				age = parseInt(age);
				if(isNaN(age) ){
					throw  new Error('Age must be a valid number!');
				}

				if(age < 0 || age > 150){
					throw  new Error('Age must be in the range between 0 and 150!');
				}
			}
		}

		Person.prototype.introduce =  function introducePerson(){
				return  ('Hello! My name is ' + this.fullname + ' and I am ' + this.age + '-years-old');
		}

		Object.defineProperty(Person.prototype, 'lastname',
			{
				get: function(){
					return this._lastName;
				},
				set: function(value) {
					validator.validateName(value);
					this._lastName = value;
				}
			});

		Object.defineProperty(Person.prototype, 'firstname',
			{
				get: function(){
					return this._firstName;
				},
				set: function(value) {
					validator.validateName(value);
					this._firstName = value;
				}
			});

		Object.defineProperty(Person.prototype, 'age',
			{
				get: function(){
					return this._age;
				},
				set: function(value) {
					validator.validateAge(value);
					this._age = value;
				}
			});

		Object.defineProperty(Person.prototype, 'fullname',
			{
				get: function(){
					return this.firstname + ' ' + this.lastname;
				},
				set: function(value) {
					var names = value.split(' ');
					if(names.length != 2){
						throw new Error('Full name consist first and last names separated by a single space! ' +
							'Full name cannot be a single string or more than two strings!')
					}
					this.firstname = names[0];
					this.lastname = names[1];
				}
			});

		return Person;
	} ());

	return Person;
}
module.exports = solve;