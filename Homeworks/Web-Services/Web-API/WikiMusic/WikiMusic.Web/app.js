(function () {

    var sammyApp = Sammy("#main-content", function () {

        this.get('#/', homeController.get);
        this.get('#/artists', artistsController.all);
        this.get('#/add-artist', artistsController.add);
        this.get('#/test', homeController.test);

    });

    $(function () {
        sammyApp.run('#/');
    });
}());
