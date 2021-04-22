$(document).ready(function () {
    var userId = window.localStorage.getItem("userid");
    if (userId == null || userId == "") {
        window.location.href = "../Home/Login";
    }
    var oTable = $('#myDatatable').DataTable({
        "ajax": {
            "url": '/IspOffer/GetOffers',
            "type": "get",
            "datatype": "json",
            "data": { providerId: $('#hidProviderId').val() }
        },
        "columns": [
            { "data": "id", "autoWidth": true },
            { "data": "offername", "autoWidth": true },
            { "data": "displayname", "autoWidth": true },
            { "data": "speed", "autoWidth": true },
            { "data": "data", "autoWidth": true },
            { "data": "pricemonth", "autoWidth": true },
            { "data": "priceannual", "autoWidth": true },
            {
                "data": "id", "autoWidth": true, "render": function (data) {
                    var html = '<a class="popup offerbox" title="Edit" href="/IspOffer/save/' + data + '"><i class="fa fa-pencil-square-o"></i></a>';
                    html += '<a class="popup offerbox" title="Delete" href="/IspOffer/Delete/' + data + '"><i class="fa fa-trash"></i></a>';
                    return html;
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
                title: 'ISP Offer',
                height: 650,
                width: 850,
                close: function () {
                    $dialog.dialog('destroy').remove();
                }
            })

        $('.popupWindow').on('submit', '#popupForm', function (e) {
            var url = $('#popupForm')[0].action;
            $.ajax({
                type: "POST",
                url: url,
                data: $('#popupForm').serialize(),
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
