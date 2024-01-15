// CommentForm
$(function () {
    $("#commentForm").on("click", (e) => {
        $.post(`/Comment/AddWithJS`, {
            postViewModelId: $("#comment-postId").val(),
            author: $("#comment-author").val(),
            content: $("#comment-content").val()
        } ,(data) => {
            $("#comment-list").append(data);
        });
    });
});