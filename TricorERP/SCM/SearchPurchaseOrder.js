// Initializing operations
$(document).ready(function () {


    $(".PurchaseOrderDelete").click(function () {
        PurchaseOrderDelete_onClick($(this));
    });

    $(".confirm").confirm({
        text: "Are you sure you want to delete?",
        title: "Delete",
        confirm: function (button) {
            $(".DeletePurchaseOrder").trigger("click");
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

function PurchaseOrderDelete_onClick(arg) {
    // Get the order item details from table
    var row = arg.closest("tr");    // Find the row
    var itemID = row.find(".ItemCol_ID").text();
    $(".txtPurchaseOrderID").val(itemID);
}

