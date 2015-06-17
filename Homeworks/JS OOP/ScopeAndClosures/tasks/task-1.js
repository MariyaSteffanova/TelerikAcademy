/* Task Description */
/* 
	*	Create a module for working with books
		*	The module must provide the following functionalities:
			*	Add a new book to category
				*	Each book has unique title, author and ISBN
				*	It must return the newly created book with assigned ID
				*	If the category is missing, it must be automatically created
			*	List all books
				*	Books are sorted by ID
				*	This can be done by author, by category or all
			*	List all categories
				*	Categories are sorted by ID
		*	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
			*	When adding a book/category, the ID is generated automatically
		*	Add validation everywhere, where possible
			*	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
			*	Author is any non-empty string
			*	Unique params are Book title and Book ISBN
			*	Book ISBN is an unique code that contains either 10 or 13 digits
			*	If something is not valid - throw Error
*/
function solve() {
	var library = (function () {
		var books = [];
		var categories = [];
		var categoriesCount;
		var filtred = [];

		function listBooks() {
			var args = arguments[0];
			if(books.length === 0){
				return [];
			}

			if(books.length === 1){
				// Important: the check for !args should be before trying to check args.category
				// otherwise if args is undefind, trying to read property of undefind will lead to Type Error
				if(!args ||books[0].category === args.category){
					return books;
				}
				else{
					return [];
				}
			}

			if(args) {
				filtred = books.filter(function (b) {
					return b.category === args.category;
				});
			}
			else{
				filtred = books;
			}
			return filtred.sort(function(a,b){
				return a.ID- b.ID;
			})

		}

		function addBook(book) {

			//Validation of the new book, before adding it to the list
			if(books.some(isTitleAlreadyExisting)){
				throw  new Error('Already exist book with the same title!');
			}

			if(books.some(isISBNAlreadyExisting)){
				throw  new Error('Already exist book with the same ISBN!');
			}

			if(!book.category){
				book.category = '';
			}

			if(book.title && (book.title.length < 2 || book.title.length > 100)){
				throw  new Error('Book title must be between 2 and 100 characters!');
			}

			if(!book.author){
				throw  new Error('Author can not be an enpty string!');
			}

			if(!(book.isbn.length === 10 || book.isbn.length === 13)){
				throw  new Error('Book ISBN must be 10 or 13 digits!');
			}

			if(!isFinite(+book.isbn)){
				throw  new Error('Book ISBN must be a number!');
			}

			book.ID = books.length + 2;
			books.push(book);

			var newCategory = {
				category: book.category,
				ID: categories.length +2
			}
			 if(categories.length === 0){
				categories.push(newCategory);
			}
			else if(categories && !categories.some(function(elem){
					 return elem.category === newCategory.category;
				 })){
				categories.push(newCategory);
			}

			return book;

			// internal functions for validation of Books properties
			function isISBNAlreadyExisting(existingBook){
				if(books.length === 0){
					return false;
				}
				return existingBook.isbn === book.isbn;
			}

			function isTitleAlreadyExisting(existingBook){
				if(books.length === 0){
					return false;
				}
				return existingBook.title === book.title;
			}
		}

		function listCategories() {
			 categories.sort(function(a,b){
				return a.ID - b.ID;
			});

			return categories.map(function(element){
				return element.category;
			})
		}

		return {
			books: {
				list: listBooks,
				add: addBook
			},
			categories: {
				list: listCategories
			}
		};
	} ());


	return library;

	if (!Array.prototype.some) {
		Array.prototype.some = function(fun/*, thisArg*/) {
			'use strict';

			if (this == null) {
				throw new TypeError('Array.prototype.some called on null or undefined');
			}

			if (typeof fun !== 'function') {
				throw new TypeError();
			}

			var t = Object(this);
			var len = t.length >>> 0;

			var thisArg = arguments.length >= 2 ? arguments[1] : void 0;
			for (var i = 0; i < len; i++) {
				if (i in t && fun.call(thisArg, t[i], i, t)) {
					return true;
				}
			}

			return false;
		};
	}
}
module.exports = solve;
