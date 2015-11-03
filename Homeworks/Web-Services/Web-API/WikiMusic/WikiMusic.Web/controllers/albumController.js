var albumController = (function () {

    function show(context) {
        var albumId = albumModel.currentId();
        var album;
        albumModel.getById(albumId)
            .then(function (albumRes) {
                album = albumRes;
                return templatesManager.get('info-album');
            })
            .then(function (partial) {
                context.$element().html(partial(album));
            })
            .then(function () {
                $('#wrapper-editable-options').on('click', 'button', function (e) {
                    var $target = $(e.target)[0],
                        target = e.target;

                    if ($(target).hasClass('edit')) {
                        edit($target, context);
                    } else if ($(target).hasClass('delete')) {
                        remove($target, context);
                    } else if ($(target).hasClass('add-song')) {
                        addSong(context);
                    }
                });
            });
    }

    function addSong(context) {
        uiElementCreator
            .createTripleForm('song', ['title', 'year', 'genre'])
            .appendTo($('#songs'));

        uiElementCreator.createButton($('#songs'), 'Save Song').on('click', function () {
            var songs = saveSongs();
            songModel.add(songs);
            albumModel.edit(albumModel.currentId(), songs)
                .then(function() {
                    context.redirect('#/info-artist');
                });

        });
    }

    function edit($target, context) {
        var albumId = $target.id.replace('btn-edit-', '');
        console.log(albumId);
        uiElementCreator.createTripleForm('album', ['title', 'year', 'imglink'])
            .prependTo('#wrapper-editable-options');

        uiElementCreator.createButton($('#wrapper-editable-options'), 'Save Changes').on('click', function () {
            var updates = $($('#wrapper-editable-options').children('.item')[0]);
            var updatedAlbum = {
                Title: updates.children('.album-title').val() || null,
                Year: updates.children('.album-year').val() || null,
                ImgLink: updates.children('.album-imglink').val() || null
            }
            console.log(updatedAlbum);
            albumModel.editById(albumModel.currentId(), updatedAlbum);
            context.redirect('#/info-artist');

        });
    }

    function saveSongs() {
        var songs = [];
        var songsRaw = $('#songs').children('.item');

        for (var i = 0; i < songsRaw.length; i++) {
            var $song = $(songsRaw[i]);
            songs.push({
                Title: $song.children('.song-title').val(),
                Year: $song.children('.song-year').val(),
                Genre: $song.children('.song-genre').val()
            });
        }
        return songs;
    }

    function remove($target,context) {
        var albumId = $target.id.replace('btn-delete-', '');
        albumModel.remove(albumId)
            .then(function() {
                toastr.success('Album successfully deleted');
                context.redirect('#/info-artist');
            });
    }

    return {
        show: show
    }
}())