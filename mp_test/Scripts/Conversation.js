$(document).ready(function () {
    $("#message").html("Waiting for update...");
    var threadId = $("#threadId").val();
    var refreshId = setInterval(
        "updateChatArea(threadId)",
        5000);
});

function updateChatArea(threadId) {
    $.getJSON(
        "/Messages/GetMessages/",
        { threadId: threadId },
        function (data) {
            $("#message").html += "Fetching...";
            $("#chatarea").html("");
            var x;
            if (data.length > 0) {
                for (x in data) {
                    $("#chatarea").html(
                        $("#chatarea").html() +
                        "<p><b>" +
                        data[x].AuthorId + "</b> <i>(" +
                        data[x].PostDateTime + ")</i> - " +
                        data[x].MessageText + "</p>");
                    $("#threadId").val(data[x].ThreadId);
                }
            }
            else {
                $("#chatarea").html("<p>No Messages</p>");
            }
        }).done(function (data) { $("#message").html("Messages loaded."); });
}

function sendNewMessage(offerId, authorId, recepientId) {
    $.post(
        "/Messages/AddMessage", {
            message:
            {
                AuthorId: authorId,
                RecepientId: recepientId,
                MessageText: $("#newmessage_messagebody").val()
            },
            offerId: offerId,
            threadId: $("#threadId").val()
        }
    );
    $("#newmessage_messagebody").val("");
    updateChatArea($("#threadId").val());
}