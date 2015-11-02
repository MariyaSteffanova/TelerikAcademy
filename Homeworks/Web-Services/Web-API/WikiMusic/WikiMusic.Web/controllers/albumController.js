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
                $('#wrpper-editable-options').on('click', 'button', function (e) {
                    var $target = $(e.target)[0],
                        target = e.target;

                    if ($(target).hasClass('edit')) {
                        edit($target, context);
                    } else if ($(target).hasClass('delete')) {
                        remove($target);
                    } else if ($(target).hasClass('add-song')) {
                        addSong($(target));
                    }
                });
            });
    }

    function addSong() {
        uiElementCreator
            .createTripleForm('song', ['title', 'year', 'genre'])
            .appendTo($('#songs'));

        uiElementCreator.createButton($('#songs'),'Save Song').on('click', function() {
            var songs= saveSongs();
            songModel.add(songs);
            //attachSongsToAlbum(songs);
            console.log(+albumModel.currentId());
            albumModel.edit(albumModel.currentId(), songs);

        });
    }

    function edit($target, context) {
       
    }

    function attachSongsToAlbum(songs) {
        albumModel.edit(albumModel.currentId, songs);
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

    return {
        show: show
    }
}())