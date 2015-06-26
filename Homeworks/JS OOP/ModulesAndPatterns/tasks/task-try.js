/* Task Description */
/* 
 * Create a module for a Telerik Academy course
 * The course has a title and presentations
 * Each presentation also has a title
 * There is a homework for each presentation
 * There is a set of students listed for the course
 * Each student has firstname, lastname and an ID
 * IDs must be unique integer numbers which are at least 1
 * Each student can submit a homework for each presentation in the course
 * Create method init
 * Accepts a string - course title
 * Accepts an array of strings - presentation titles
 * Throws if there is an invalid title
 * Titles do not start or end with spaces
 * Titles do not have consecutive spaces
 * Titles have at least one character
 * Throws if there are no presentations
 * Create method addStudent which lists a student for the course
 * Accepts a string in the format 'Firstname Lastname'
 * Throws if any of the names are not valid
 * Names start with an upper case letter
 * All other symbols in the name (if any) are lowercase letters
 * Generates a unique student ID and returns it
 * Create method getAllStudents that returns an array of students in the format:
 * {firstname: 'string', lastname: 'string', id: StudentID}
 *
 * Create method submitHomework
 * Accepts studentID and homeworkID
 * homeworkID 1 is for the first presentation
 * homeworkID 2 is for the second one
 * ...
 * Throws if any of the IDs are invalid
 *
 * Create method examResults
 * Accepts an array of items in the format {StudentID: ..., Score: ...}
 * StudentIDs which are not listed get 0 points
 * Throw if there is an invalid StudentID
 * Throw if same StudentID is given more than once ( he tried to cheat (: )
 * Throw if Score is not a number
 * Create method getTopStudents which returns an array of the top 10 performing students
 * Array must be sorted from best to worst
 * If there are less than 10, return them all
 * The final score that is used to calculate the top performing students is done as follows:
 * 75% of the exam result
 * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
 */

function solve() {

    var Course = {
        init: function (title, presentations) {
            this.title = title;
            this.presentations = presentations;
        },
        addStudent: function (name) {
            // Adds student at the setter of this.students. Validation is executing also there
            this.students = name;
            //console.log(this.students[this.students.length-1].id);
            return this.students[this.students.length-1].id;
        },
        getAllStudents: function () {
            return this.students;
        },
        submitHomework: function (studentID, homeworkID) {
            if(studentID > this.students.length || studentID == 0){
                throw  new Error('Invalid StudentID');
            }
            if(homeworkID > this.presentations.length || homeworkID == 0){
                throw new Error('Invalid HomeworkID');
            }

        },
        examResults: function (results) {
        },
        getTopStudents: function () {
        },
        get title() {
            return this._title;
        },
        set title(value) {
            if (/^[A-Z]+([a-zA-z0-9\S]+[ ]{1})+\S+/.test(value)) {
                this._title = value;
                return this;
            }
            else {
                throw new Error('Invalid title');
            }

        },
        get presentations() {
            return this._presentations;
        },
        set presentations(value) {

            if (Array.isArray(value) && value.length == 0) {
                throw  new Error('No presentations added');
            }
            this._presentations = this._presentations || [];
            for (var i = 0; i < value.length; i += 1) {
                if (/^[A-Z]+([a-zA-z0-9\S]+[ ]{1})+\S+/.test(value[i])) {
                    this._presentations.push(value[i]);
                }
                else {
                    throw  new Error('ALA BALA');
                }
            }
            return this;
        },
        get students() {
            return this._students;
        },
        set students(name) {
            var names,
                firstName,
                lastName,
                ID;
            if(!name){
                throw  new Error('Student names not entred');
            }
            names = name.split(' ');
            if (names.length != 2) {
                throw  new Error('Student must have exactly two names (first name and last name)!');
            }
            firstName = names[0];
            lastName = names[1];
            if(!this.validateStudentNames(firstName) || !this.validateStudentNames(lastName)){
                throw new Error('Invalid student name');
            }
            else{
                this._students = this._students || [];

                ID =  this.students.length+1;
                this._students.push({
                    firstname: firstName,
                    lastname: lastName,
                    id: ID
                });
            }
        },
            validateStudentNames: function (name) {
                if (/^[A-Z][a-z]*/.test(name)) {
                    return true;
                }
                else {
                    return false;
                }
            }

    };

    return Course;
}

module.exports = solve;
