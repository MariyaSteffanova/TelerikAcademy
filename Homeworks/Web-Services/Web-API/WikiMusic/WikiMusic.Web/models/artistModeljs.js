var artistModel = (function () {

    var currentId;

    function getById(id) {
        console.log(id);
        return AjaxReq.get('/api/artists/' + id);
    }

    function getAllArtists() {
        console.log("in model");
        return AjaxReq.get("/api/artists");
    }

    function addArtist(artist) {
        return AjaxReq.post("/api/artists", { data: artist });
    }

    function deleteArtistById(id) {
        return AjaxReq.delete("/api/artists", { data: id });
    }

    function updateArtist(id, updates) {
        return AjaxReq.put("/api/artists", { data: { id: id, updates: updates } });
    }

    // TODO: Fix this sh*t 
    function currentArtistId( id) {
        if (!id) {
            return currentId;
        } else {
            currentId = id;
        }
    }
    return {
        all: getAllArtists,
        getById : getById,
        add: addArtist,
        remove: deleteArtistById,
        edit: updateArtist,
        currentId : currentArtistId
    }

}())