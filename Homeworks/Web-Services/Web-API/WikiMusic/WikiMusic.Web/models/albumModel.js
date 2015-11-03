var albumModel = (function () {
    var currentId;

    function getById(id) {
        console.log(id);
        return AjaxReq.get('/api/albums/' + id);
    }

    function getAllAlbums() {
        console.log("in model");
        return AjaxReq.get("/api/albums");
    }

    function addAlbum(album) {
        return AjaxReq.post("/api/albums", { data: album });
    }

    function deleteAlbumById(id) {
        return AjaxReq.delete("/api/albums", { data: id });
    }

    function updateAlbum(id, updates) {
        console.log(id);
        return AjaxReq.put("/api/albums", { data: { id: id, songs: updates } });
    }

    function updateAlbumById(id, updates) {
        return AjaxReq.put("/api/albums/" + id, { data: updates });
    }

    // TODO: Fix this sh*t 
    function currentAlbumId(id) {
        if (!id) {
            return currentId;
        } else {
            currentId = id;
        }
    }
    return {
        all: getAllAlbums,
        getById: getById,
        add: addAlbum,
        remove: deleteAlbumById,
        edit: updateAlbum,
        editById: updateAlbumById,
        currentId: currentAlbumId
    }
}())