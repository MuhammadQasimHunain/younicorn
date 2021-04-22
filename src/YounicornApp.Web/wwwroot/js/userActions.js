$(document).ready(function () {
    var userId = window.localStorage.getItem("userid");
    if (userId == null || userId == "") {
        window.location.href = "../Home/Login";
    }
    var oTable = $('#myDatatable').DataTable({
        "ajax": {
            "url": '/UserActions/GetUserActions',
            "type": "get",
            "datatype": "json"
        },
        "columns": [
            { "data": "actionId", "autoWidth": true },
            {
                "data": "actionDatetime", "autoWidth": true , "render": function (data) {
                    return moment(data).format('l');
                }
            },
            { "data": "userAddress", "autoWidth": true },
            { "data": "actionType", "autoWidth": true },
            { "data": "actionDetails", "autoWidth": true },
            { "data": "ispDetail", "autoWidth": true },
            { "data": "ispOfferDetail", "autoWidth": true },
            {
                "data": "actionId", "width": "50px", "render": function (data) {
                    return '<a class="popup" href="/UserActions/UserActionDetail/' + data + '">Details</a>';
                }
            }
        ]
    })
    $('.tablecontainer').on('click', 'a.popup', function (e) {
        e.preventDefault();
        OpenPopup($(this).attr('href'));
    })

    function OpenPopup(pageUrl) {
        var $pageContent = $('<div/>');
        $pageContent.load(pageUrl, function () {
            $('#popupForm', $pageContent).removeData('validator');
            $('#popupForm', $pageContent).removeData('unobtrusiveValidation');
            //$.validator.unobtrusive.parse('form');

        });

        $dialog = $('<div class="popupWindow" style="overflow:auto"></div>')
            .html($pageContent)
            .dialog({
                draggable: true,
                autoOpen: false,
                resizable: false,
                model: true,
                title: 'User Actions',
                height: 450,
                width: 650,
                close: function () {
                    $dialog.dialog('destroy').remove();
                }
            })

        $('.popupWindow').on('submit', '#popupForm', function (e) {
            var url = $('#popupForm')[0].action;
            var model = new FormData($('#popupForm').get(0));
            $.ajax({
                type: "GET",
                url: url,
                data: model,
                dataType: "json",
                contentType: false,
                processData: false,
                success: function (data) {
                    if (data.status) {
                        $dialog.dialog('close');
                        oTable.ajax.reload();
                    }
                }
            })

            e.preventDefault();
        })

        $dialog.dialog('open');
    }
})
