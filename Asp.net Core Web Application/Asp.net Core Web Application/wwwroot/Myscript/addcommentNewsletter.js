
$("#YE").click(function () {
    var name = $("#nameAndSurname").val();
    var myTitle = $("#commentTitle").val();
    var commentContent = $("#comment").val();
    let comment = {
        CommentUserName = name,
        CommentTitle= myTitle,
        CommentContent = commentContent
    }
    $.ajax({
        type: "post",
        url: "/Comment/SenComment/ ",
        data: comment,
        success: function (data) {
           alert("sdfg")
        }
    })
})


$("#x").click(function () {
    var mail = $("#mailX").val();
    $.ajax({
        type: "post",
        url: "/NewsLetter/SendMail?Mail=" + mail,
        contentType: "charset=utf-8",
        async: true,
        success: function (data) {

        }
    })
})

