$("button[data-vote]").each(function (el) {
    $(this).click(function () {

        var IsPositive = Boolean(parseInt($(this).attr("data-vote")));
        var postId = parseInt(this.parentElement.getAttribute("id"));

        var antiForgeryToken = $('#antiForgeryForm input[name=__RequestVerificationToken]').val();
        var data = { postId: postId, IsPositive: IsPositive };

        $.ajax({
            type: "POST",
            url: "/api/Likes",
            data: JSON.stringify(data),
            headers: {
                'X-CSRF-TOKEN': antiForgeryToken
            },
            success: function (data) {
                $('#disslikesValue_' + postId).html(data.dissLikes);
                $('#likesValue_' + postId).html(data.likes);
            },
            contentType: 'application/json',
        });
    })
});