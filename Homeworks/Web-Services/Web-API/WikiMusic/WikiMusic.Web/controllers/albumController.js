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
            });
    }

    return {
        show: show
    }
}())