// Initializing operations
$(document).ready(function () {
    // OnClick method for show Jumbotron button
    $('.btnShowJumbotron').on("click", function () {
        return btnShowJumbotron_onClick();
    });

    // OnClick method for hide Jumbotron button
    $('.btnHideJumbotron').on("click", function () {
        return btnHideJumbotron_onClick();
    });
});

function btnShowJumbotron_onClick() {
    // Remove the hidden class
    $(".jumbotron").removeClass("hidden");
    return false; // because server control submits the form
}

function btnHideJumbotron_onClick() {
    // Hide jumbotron, by adding class hidden
    $(".jumbotron").addClass("hidden");
    return false; // because server control submits the form
}