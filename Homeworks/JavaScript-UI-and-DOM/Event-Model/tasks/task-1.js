/* globals $ */


function solve() {
    return function (selector) {
        var element,
            buttons,
            content,
            btnContent;

        element = document.getElementById(selector) || selector;
        buttons = element.getElementsByClassName('button');

        for (var i = 0; i < buttons.length; i += 1) {
            buttons[i].innerHTML = 'hide';

            buttons[i].addEventListener('click', toggleContent)
        }

        function toggleContent() {
            btnContent = this.innerHTML;

            content = this.nextElementSibling;
            while (content && content.className.indexOf('content') < 0) {
                content = content.nextElementSibling;
            }

            if (btnContent === 'hide') {
                this.innerHTML = 'show';
                content.style.display = "none";
            }

            else if (btnContent === 'show') {
                this.innerHTML = 'hide';
                content.style.display = "";
            }
        }

    };
};

module.exports = solve;