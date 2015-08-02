/* globals $ */

/* 

 Create a function that takes an id or DOM element and an array of contents

 * if an id is provided, select the element
 * Add divs to the element
 * Each div's content must be one of the items from the contents array
 * The function must remove all previous content from the DOM element provided
 * Throws if:
 * The provided first parameter is neither string or existing DOM element
 * The provided id does not select anything (there is no element that has such an id)
 * Any of the function params is missing
 * Any of the function params is not as described
 * Any of the contents is neight `string` or `number`
 * In that case, the content of the element **must not be** changed
 */

module.exports = function () {

    return function (elem, contents) {
        var element = document.getElementById(elem) || elem,
            fragment,
            div;

        if (elem == undefined || contents == undefined) {
            throw 'Missing function params';
        }
        if (element == undefined) {
            throw 'Element is invalid! Must be string (id) or HTML element!';
        }

        contents.forEach(function (_, i) {
            if (typeof  contents[i] !== "string" && isNaN(parseInt(contents[i]))) {
                throw  'All contents must be of type string or number!';
            }
        });

        element.innerHTML = null;

        fragment = document.createDocumentFragment();

        for (var i = 0; i < contents.length; i += 1) {
            div = document.createElement('div');

            div.innerHTML = contents[i];
            fragment.appendChild(div);
        }

        element.appendChild(fragment);

    };
};