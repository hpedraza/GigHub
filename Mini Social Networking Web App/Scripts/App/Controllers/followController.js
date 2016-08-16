var followController = function (followService) {
        var button;

        var init = function (container) {
            $(container).on("click" , ".js-toggle-following" , toggleFollowing);
        };
        
        var toggleFollowing = function (e) {
            button = $(e.target);


            var dto = {
                ArtistId: button.attr("data-artist-id")
            };

            if (button.text() === "Follow")
                followService.postFollowing(dto , done, fail);
            else
                followService.deleteFollowing(dto.ArtistId, done, fail);
        };


        var done = function () {
            var text = (button.text() === "Follow" ? "Following" : "Follow");
            button.toggleClass("btn-link").toggleClass("btn-primary").text(text);
        }

        var fail = function () {
            alert("something failed!");
        }

        return {
            init : init
        }

}(followService);