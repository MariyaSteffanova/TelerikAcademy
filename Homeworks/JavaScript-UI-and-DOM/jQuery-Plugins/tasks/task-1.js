function solve() {
    return function (selector) {

        var itemClass = 'dropdown-item',
            currentClass = 'current',
            containerClass = "options-container",
            $options = $(selector).children(),
            $divItem,
            $divContainer,
            $dropDownList,
            $first,
            $current;

        $(selector).hide();

        $dropDownList = $('<div></div>')
            .addClass("dropdown-list")
            .append($(selector));

        $divContainer = $("<div></div>")
            .addClass(containerClass)
            .hide();

        $current = $('<div>Select Option</div>').addClass("current").on('click', function () {
            $divContainer.toggle();
        });

        for (var i = 1; i <= $options.length; i += 1) {
            $divItem = $('<div></div>')
                .addClass(itemClass)
                .attr("data-value",  $($options[i]).val())
                .attr("data-index", i)
                .text('Option ' + i);

            $divItem.appendTo($divContainer);
        }

        $('.current').on('click', function () {
            console.log('CLICK CURRENT');
            $divContainer.toggle();
        });

        $divContainer.on('click', '.dropdown-item', function(){

            $divContainer.toggle();
            $(selector).val($(this).attr('data-value'));
            $('.current').html($(this).html());
            console.log(data);
        });
        $dropDownList.append($current);
        $divContainer.appendTo($dropDownList);
        $dropDownList.appendTo($('body'));
    };
}

module.exports = solve;