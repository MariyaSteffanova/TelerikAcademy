/* globals $ */

/*
 Create a function that takes a selector and:
 * Finds all elements with class `button` or `content` within the provided element
 * Change the content of all `.button` elements with "hide"
 * When a `.button` is clicked:
 * Find the topmost `.content` element, that is before another `.button` and:
 * If the `.content` is visible:
 * Hide the `.content`
 * Change the content of the `.button` to "show"
 * If the `.content` is hidden:
 * Show the `.content`
 * Change the content of the `.button` to "hide"
 * If there isn't a `.content` element **after the clicked `.button`** and **before other `.button`**, do nothing
 * Throws if:
 * The provided ID is not a **jQuery object** or a `string`

 */
function solve() {
    return function (selector) {
        var $element,
            buttons,
            $content,
            btnContent;

        $element = $(selector);// || selector;
        if (!selector || $element.size() === 0) {
            throw 'No params';
        }

        buttons = $('.button');

        for (var i = 0; i < buttons.length; i += 1) {
            buttons[i].innerHTML = 'hide';

            buttons[i].addEventListener('click', toggleContent)
        }

        function toggleContent() {
            btnContent = this.innerHTML;

            $content = $(this).nextAll('.content:first');

            if (btnContent === 'hide') {
                this.innerHTML = 'show';
                $content.toggle();
            }

            else if (btnContent === 'show') {
                this.innerHTML = 'hide';
                $content.css("display", "");
            }
        }
    };
};

module.exports = solve;