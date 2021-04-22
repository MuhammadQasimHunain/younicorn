$(document).ready(function () {
    var userId = window.localStorage.getItem("userid");
    if (userId == null || userId == "")
        window.location.href = "../Home/Login";

    var oTable = $('#myDatatable').DataTable({
        "ajax": {
            "url": '/Provider/GetProviders',
            "type": "get",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "autoWidth": true },
            { "data": "ispname", "autoWidth": true },
            { "data": "displayname", "autoWidth": true },
            {
                "data": "isprating", "autoWidth": true, "render": function (data) {
                    var rating = parseInt(data);
                    var html = "";
                    for (var i = 0; i < rating; i++) {
                        html += '<i class="fa fa-star text-dark-tangerine"></i>';
                    }
                    if (((data % 1) * 100) > 0)
                        html += '<i class="fa fa-star-half text-dark-tangerine"></i>';

                    html += " (" + data + ")";
                    return html;
                }
            },
            {
                "data": "id", "autoWidth": true, "render": function (data) {
                    var html = '<a class="offerbox" title="Offers" href="/IspOffer/Index/' + data + '">Offers</a>';
                    html += '<a class="popup offerbox" title="Edit"  href="/Provider/save/' + data + '"><i class="fa fa-pencil-square-o"></i></a>';
                    html += '<a class="popup offerbox" title="Delete" href="/Provider/Delete/' + data + '"><i class="fa fa-trash"></i></a>';
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
                title: 'Isp Provider',
                height: 420,
                width: 650,
                close: function () {
                    $dialog.dialog('destroy').remove();
                }
            })

        $('.popupWindow').on('submit', '#popupForm', function (e) {
            var url = $('#popupForm')[0].action;
            var model = new FormData($('#popupForm').get(0));
            $.ajax({
                type: "POST",
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
});
