function solve() {
    return function () {
        $.fn.listview = function (data) {
            var dataTemplate = this.attr('data-template'),
                template = $('#' + dataTemplate).html(),
                compiledHTML = handlebars.compile(template),
                i,
                len = data.length;

            for (i = 0; i < len; i += 1) {
                this.append(compiledHTML(data[i]));
            }

            return this;
        };

    };
}

module.exports = solve;
