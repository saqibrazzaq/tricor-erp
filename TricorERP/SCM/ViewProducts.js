// Initializing operations
$(document).ready(function () {


    $(".ProductDelete").click(function () {
        ProductDelete_onClick($(this));
    });

    $(".confirm").confirm({
        text: "Are you sure you want to delete?",
        title: "Delete",
        confirm: function (button) {
            $(".DeleteProduct").trigger("click");
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

function ProductDelete_onClick(arg) {
    // Get the order item details from table
    var row = arg.closest("tr");    // Find the row
    var itemID = row.find(".ItemCol_ID").text();
    $(".txtProductID").val(itemID);
}

