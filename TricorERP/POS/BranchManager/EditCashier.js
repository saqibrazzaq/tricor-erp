$(document).ready(function () {
    $(".ItemRowDelete").click(function () {
        ItemRowDelete_onClick($(this));
    });

    $(".confirm").confirm({

        text: "Are you sure you want to delete?",
        title: "Delete",
        confirm: function (button) {
            $(".DeleteAddress").trigger("click");
        },
        cancel: function (button) {
            // nothing to do
        },
        confirmButton: "Yes",
        cancelButton: "No",
        post: true,
        confirmButtonClass: "btn-danger",
        cancelButtonClass: "btn-default"
    });
});

function ItemRowDelete_onClick(arg) {
    // Get the order item details from table
    var row = arg.closest("tr");    // Find the row
    var itemID = row.find(".AddressID").text();
    $(".txtAddressID").val(itemID);
}