var followService = function () {
    var postFollowing = function (dto, done, fail) {
        alert("POST");
            $.post("/api/following", dto)
            .done(done)
            .fail(fail);
        };

    var deleteFollowing = function (dto, done, fail) {
        alert("DELETE");
        var url = "/api/following/" + dto.ArtistId;
            $.ajax({
                url: url,
                type: "DELETE"
            })
                .done(done)
                .fail(fail);
        };

        return {
            postFollowing: postFollowing,
            deleteFollowing: deleteFollowing
        }
}();