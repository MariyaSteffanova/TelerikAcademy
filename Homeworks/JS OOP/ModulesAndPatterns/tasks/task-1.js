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
 *
 * Create method getAllStudents that returns an array of students in the format:
 * {firstname: 'string', lastname: 'string', id: StudentID}
 *
 * Create method submitHomework
 * Accepts studentID and homeworkID
 * homeworkID 1 is for the first presentation
 * homeworkID 2 is for the second one
 * ...
 * Throws if any of the IDs are invalid
 * Create method pushExamResults
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


    function validateTitle(title) {
        if (title.length != title.trim().length || /\s{2,}/.test(title) || title.length === 0) {
            throw  new Error('Invalid title!');
        }
        return true;
    }

    function validatePresentationsList(presentations) {
        var ind,
            len = presentations.length;
        if (len === 0) {
            throw  new Error('Presentations list is empty!');
        }
        for (ind = 0; ind < len; ind += 1) {
            if (!validateTitle(presentations[ind])) {
                throw new Error('Title validation had to throw before me');
            }
        }
        return true;
    }

    function validateStudentNames(name) {
        if (/^[A-Z][a-z]*/.test(name)) {
            return true;
        }
        return false;
    }

    var Course = {

        init: function (title, presentations) {
            this.title = title;
            this.presentations = presentations;
            this.studentId = 1;
            return this;
        },
        addStudent: function (name) {
            if (!name || typeof name !== 'string') {
                throw new Error('Invalid student name!');
            }
            var names = name.split(' ');
            if (names.length !== 2) {
                throw  new Error('Student  must have exactly two names: first name and last name!');
            }

            if (!validateStudentNames(names[0]) || !validateStudentNames(names[1])) {
                throw  new Error('Invalid student name!');
            }
            this.studentId += 1;
            this.students = {
                firstname: names[0],
                lastname: names[1],
                id: this.studentId
            };
            return this.studentId;
        },
        getAllStudents: function () {
            return this.students || [];
        },
        submitHomework: function (studentID, homeworkID) {
            if (homeworkID === 0 || homeworkID > this.presentations.length) {
                throw new Error('Homework ID is not valid');
            }
            if (studentID <= 0 || studentID > this.studentId) {
                throw  new Error('Student ID is not valid!');
            }
        },
        pushExamResults: function (results) {
        },
        getTopStudents: function () {
        }
    };

    Object.defineProperty(Course, 'title', {
        get: function () {
            return this._title;
        },
        set: function (title) {
            if (validateTitle(title)) {
                this._title = title;
            }
        }
    });

    Object.defineProperty(Course, 'presentations', {
        get: function () {
            return this._presentations;
        },
        set: function (presentations) {
            if (validatePresentationsList(presentations)) {
                this._presentations = presentations;
            }
        }
    });

    Object.defineProperty(Course, 'students', {
        get: function () {
            return this._students;
        },
        set: function (student) {
            this._students = this._students || [];
            this._students.push(student);
        }
    });

    Object.defineProperty(Course, 'studentId', {
        get: function () {
            return this._studentId;
        },
        set: function (value) {
            this._studentId = value;
        }
    });
    return Course;
}


module.exports = solve;
