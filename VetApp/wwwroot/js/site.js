var allExistingOwners = [];

function fetchOwners() {
    $.get('https://localhost:7188/api/owner', function (data) {
        allExistingOwners = data;
    }
    );
}

function displayExistingOwners(searchString) {
    let filteredOwners = allExistingOwners.filter(function (owner) {
        return owner.name.toLowerCase().startsWith(searchString.toLowerCase());
    });

    let ownerList = $('#ownerList');
    ownerList.empty();
    if (filteredOwners.length > 0 && searchString !== '') {
        $.each(filteredOwners, function (index, owner) {

            let button = $('<button class="dropdown-item text-white">' + owner.name + '</button>');
            button.on('click', function (e) {
                e.stopPropagation();
                e.preventDefault(); 
                selectOwner(owner.name);
            });

            ownerList.append(button);
        });
        ownerList.show();
    } else {
        ownerList.hide();
    }

   
}

function selectOwner(ownerName) {
    let currentOwner = allExistingOwners.find(function (owner) {
        return owner.name === ownerName;
    });

    $('#ownerName').val(currentOwner.name);
    $('#ownerEmail').val(currentOwner.email);
    $('#ownerPhoneNumber').val(currentOwner.phoneNumber);
    $('#ownerAddress').val(currentOwner.address);
    $('#ownerList').hide();
}