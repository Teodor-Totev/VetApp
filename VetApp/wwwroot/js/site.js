// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var allExistingOwners = [];

function fetchOwners() {
    $.get('https://localhost:7188/api/owner', function (data) {
            allExistingOwners = data;
        }
    );
}

function displayExistingOwners(searchString) {
    var filteredOwners = allExistingOwners.filter(function (owner) {
        return owner.name.toLowerCase().startsWith(searchString.toLowerCase());
    });

    var ownerList = $('#ownerList');
    ownerList.empty();
    if (filteredOwners.length > 0 && searchString !== '') {
        $.each(filteredOwners, function (index, owner) {
            ownerList.append('<a class="dropdown-item text-white" href="#">' + owner.name + '</a>');
        });
        ownerList.show();
    } else {
        ownerList.hide();
    }
}
