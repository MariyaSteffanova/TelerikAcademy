var homeController = (function () {

    function get(context) {

        templatesManager.get('home')
            .then(function (partial) {
                context.$element().html(partial()); // here i can insert data
            });
    }

    function test(context) {

        templatesManager.get('test')
            .then(function (partial) {
                context.$element().html(partial()); // here i can insert data
            });
    }

    return {
        get: get,
        test:test
    }
}());
