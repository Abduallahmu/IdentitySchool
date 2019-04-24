"use strict"
function DeleteListItem(html_id, delete_url) {
    $.get(delete_url, function (data, status) {
        //alert("Data: " + data + "\nStatus: " + status);
        $('#' + html_id).replaceWith(data);
    });
}



function ConfrimDeleteListItem(html_id, delete_url, item_id) {
    $.post(delete_url,
        {
            itemid: item_id
        },
        function (data, status) {
            if (status === 'success') {
                $('#' + html_id).replaceWith(data);
            }
            else if (status === 'Notfound') {
                $('#' + html_id).replaceWith('');
                alert("Your list is old, pleace refrece.");
            }
            else if (status === 'badrequset') {
                $('#' + html_id).replaceWith('');
                alert("Your list is old, pleace refrece.");
            }
            else {
                console.log('error: ' + status);
            }
        }
    );
}