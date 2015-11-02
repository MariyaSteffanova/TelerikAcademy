var uiElementCreator = (function () {

    function createTripleForm(itemName, properties) {
        var $item = $('<div/>').addClass('item');
        $('<input/>')
            .addClass('form-control')
            .addClass('col-md-6')
            .addClass(itemName + '-' + properties[0])
            .attr('placeholder', properties[0])
            .appendTo($item);

        $('<input/>')
           .addClass('form-control')
           .addClass('col-md-6')
            .addClass(itemName + '-' + properties[1])
           .attr('placeholder', properties[1])
           .appendTo($item);

        $('<input/>')
           .addClass('form-control')
           .addClass('col-md-6')
            .addClass(itemName + '-' + properties[2])
           .attr('placeholder', properties[2])
           .appendTo($item);

        return $item;
    }

    function createButton($parent, text) {
        return $('<button/>')
            .text(text)
            .addClass('btn')
            .addClass('btn-primary')
            .appendTo($parent);
    }
    return {
        createTripleForm: createTripleForm,
        createButton: createButton
    }
}())