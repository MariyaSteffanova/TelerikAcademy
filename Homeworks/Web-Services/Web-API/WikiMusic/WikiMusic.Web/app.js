(function () {

    var sammyApp = Sammy("#main-content", function () {

        this.get('#/', homeController.get);
        this.get('#/artists', artistsController.all);
        this.get('#/add-artist', artistsController.add);
        this.get('#/info-artist', singleArtistController.show);
        this.get('#/info-album', albumController.show);
        this.get('#/songs', songController.all);
    });

    $(function () {
        sammyApp.run('#/');
    });
}());
