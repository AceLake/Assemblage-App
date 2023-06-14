$(document).on("click", ".group-box-selected", function (event) {
    event.preventDefault();
    var groupID = $(this).val();
    console.log("select Group button was clicked on ID" + groupID)

    $.ajax({
        datatype: "test/plain",
        url: 'Messaging/ShowGroupMessage',
        data: { ID : groupID },
        success: function (data) {
            console.log(data);
            $(".message-section").html(data);
        }
    });
});