var artistsController = (function () {
    var ARTIST_FORMS = {
        ARTIST_NAME: '#tb-artist-name',
        ARTIST_COUNTRY: '#tb-artist-country',
        ARTIST_BDATE: '#tb-artist-bdate',
        ARTIST_IMG: '#tb-artist-img'
    };
    function all(context) {
        var artists;
        artistModel.all()
            .then(function (resArtists) {
                artists = resArtists;
                return templatesManager.get("artists");
            }, function (err) {
                toastr.error(err);
            }).then(function (partial) {
                context.$element().html(partial(artists));
            }).then(function () {
                $('#wrapper-artists').on('click', 'button', function (e) {
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

    function add(context) {
        return templatesManager.get('add-artist')
            .then(function (partial) {
                context.$element().html(partial);

                $('#btn-add-artist').on('click', function () {
                    var newArtist = {
                        name: $(ARTIST_FORMS.ARTIST_NAME).val(),
                        country: $(ARTIST_FORMS.ARTIST_COUNTRY).val(),
                        birthDate: "2015/10/10",//$(ARTIST_FORMS.ARTIST_BDATE).val,
                        imglink: $(ARTIST_FORMS.ARTIST_IMG).val() || null
                    };

                    artistModel.add(newArtist)
                        .then(function (res) {
                            toastr.success('Artist  successfully created!');
                        }, function (err) {
                            toastr.error(err.responseJSON);
                        });
                });
            });
    }

    function edit($target, context) {
        var artistId = $target.id.replace('btn-edit-', '');
        var artist;
        artistModel.getById(artistId)
            .then(function (resArtist) {
                artist = resArtist;
                return templatesManager.get('edit-artist');
            })
            .then(function (partial) {
                context.$element().html(partial(artist));
            })
             .then(function () {
                 $('#btn-edit-artist').on('click', function () {
                     var newArtist = {
                         name: $(ARTIST_FORMS.ARTIST_NAME).val() || $(ARTIST_FORMS.ARTIST_NAME).attr('placeholder'),
                         country: $(ARTIST_FORMS.ARTIST_COUNTRY).val() || $(ARTIST_FORMS.ARTIST_COUNTRY).attr('placeholder'),
                         birthDate: "2015/10/10", //$(ARTIST_FORMS.ARTIST_BDATE).val,
                         imglink: $(ARTIST_FORMS.ARTIST_IMG).val() || $(ARTIST_FORMS.ARTIST_IMG).attr('placeholder'),
                         songs: [],
                         albums: []
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
        all: all,
        add: add
    }

}())