var singleArtistController = (function () {

    // TODO: Extract as constants
    var ARTIST_FORMS = {
        ARTIST_NAME: '#tb-artist-name',
        ARTIST_COUNTRY: '#tb-artist-country',
        ARTIST_BDATE: '#tb-artist-bdate',
        ARTIST_IMG: '#tb-artist-img'
    };

    function show(context) {
        var artistId = artistModel.currentId();
        var artist;
        artistModel.getById(artistId)
            .then(function (artistRes) {
                artist = artistRes;
                return templatesManager.get('info-artist');
            })
            .then(function (partial) {
                context.$element().html(partial(artist));
            }).then(function () {
                $('#wrpper-editable-options').on('click', 'button', function (e) {
                    var $target = $(e.target)[0],
                        target = e.target;

                    if ($(target).hasClass('edit')) {
                        edit($target, context);
                    } else if ($(target).hasClass('delete')) {
                        remove($target);
                    }
                });

                $('#wrapper-albums').on('click', 'button', function (e) {
                    var $target = $(e.target)[0];
                    var id = $target.id.replace('btn-album-', '');
                    albumModel.currentId(id);
                    context.redirect('#/info-album');
                });
            });
    }

    function edit($target, context) {
        var artistId = $target.id.replace('btn-edit-', '');
        var artist;
        artistModel.getById(artistId)
            .then(function (resArtist) {
                artist = resArtist;
                console.log(artist);
                return templatesManager.get('edit-artist');
            })
            .then(function (partial) {
                context.$element().html(partial(artist));
            })
             .then(function () {

                 $('.btn-add-song').on('click', function () {
                     //<input type="text" class="form-control" id="tb-artist-country"
                     var $song = $('<div/>').addClass('song');
                     $('<input/>')
                         .addClass('form-control')
                         .addClass('col-md-6')
                         .addClass('song-title')
                         .attr('placeholder', 'Name')
                         .appendTo($song);

                     $('<input/>')
                        .addClass('form-control')
                        .addClass('col-md-6')
                         .addClass('song-year')
                        .attr('placeholder', 'Year')
                        .appendTo($song);

                     $('<input/>')
                        .addClass('form-control')
                        .addClass('col-md-6')
                         .addClass('song-genre')
                        .attr('placeholder', 'Producer')
                        .appendTo($song);

                     $song.appendTo($('#songs'));
                 });

                 $('#btn-edit-artist').on('click', function () {
                     var songs = [];

                     var songsRaw = $('#songs').children('.song');
                     // console.log(songsRaw[0]);
                     for (var i = 0; i < songsRaw.length; i++) {
                         var $song = $(songsRaw[i]);
                         songs.push({
                             Title: $song.children('.song-title').val(),
                             Year: $song.children('.song-year').val(),
                             Producer: $song.children('.song-genre').val(),
                             ImgLink: 'none for now'
                         });
                     }

                     var newArtist = {
                         name: $(ARTIST_FORMS.ARTIST_NAME).val() || $(ARTIST_FORMS.ARTIST_NAME).attr('placeholder'),
                         country: $(ARTIST_FORMS.ARTIST_COUNTRY).val() || $(ARTIST_FORMS.ARTIST_COUNTRY).attr('placeholder'),
                         birthDate: "2015/10/10", //$(ARTIST_FORMS.ARTIST_BDATE).val,
                         imglink: $(ARTIST_FORMS.ARTIST_IMG).val() || $(ARTIST_FORMS.ARTIST_IMG).attr('placeholder'),
                         songs: [],
                         albums: songs
                     };
                     artistModel.edit(artistId, newArtist);
                 });
             });
    }

    function remove($target) {
        var artistId = $target.id.replace('btn-delete-', '');
        artistModel.remove(artistId);
    }

    return {
        show: show
    }
}())