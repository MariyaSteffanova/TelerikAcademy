var albumController = (function () {

    function show(context) {
        var albumId = albumModel.currentId();
        var album;
        albumModel.getById(albumId)
            .then(function(albumRes) {
                album = albumRes;
                return templatesManager.get('info-album');
            })
            .then(function(partial) {
                context.$element().html(partial(album));
            })
            .then(function() {
                $('#wrpper-editable-options').on('click', 'button', function (e) {
                    var $target = $(e.target)[0],
                        target = e.target;

                    if ($(target).hasClass('edit')) {
                        edit($target, context);
                    } else if ($(target).hasClass('delete')) {
                        remove($target);
                    }
                });
            });
    }



    return {
        show: show
    }
}())