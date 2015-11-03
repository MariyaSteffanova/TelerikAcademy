var songModel = (function() {
    
    function getById(id) {
        console.log(id);
        return AjaxReq.get('/api/songs/' + id);
    }

    function getAllSongs() {
        console.log("in model");
        return AjaxReq.get("/api/songs");
    }

    function addSong(song) {
        console.log('SONG MODEL ADD');
        console.log(song);
        return AjaxReq.post("/api/songs", { data: song });
    }

    function deleteSongById(id) {
        return AjaxReq.delete("/api/songs", { data: id });
    }

    function updateSong(id, updates) {
        return AjaxReq.put("/api/songs", { data: { id: id, updates: updates } });
    }

   return {
        all: getAllSongs,
        getById: getById,
        add: addSong,
        remove: deleteSongById,
        edit: updateSong
    }

}())