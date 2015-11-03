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
                console.log(artists);
                return templatesManager.get("artists");
            }, function (err) {
                console.log(err);
                toastr.error(err);
            }).then(function (partial) {
                context.$element().html(partial(artists));
            }).then(function () {
                $('#wrapper-artists').on('click', 'a', function (e) {
                    var $target = $(e.target)[0],
                        target = e.target;

                  if ($(target).hasClass('more-info')) {
                        artistModel.currentId($target.id.replace('btn-more-', ''));
                        context.redirect("#/info-artist");
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
                            toastr.success('Artist  successfully created');
                            context.redirect('#/artists');
                        }, function (err) {
                            toastr.error(err.responseJSON);
                        });
                });
            });
    }

   

    function showInfo($target, context) {
        var artistId = $target.id.replace('btn-more-', '');
        var artist;
        artistModel.getById(artistId)
            .then(function(artistRes) {
                artist = artistRes;
                return templatesManager.get('info-artist');
            })
            .then(function(partial) {
                context.$element().html(partial(artist));
            });
    }

    return {
        all: all,
        add: add
    }

}())