function getAnalyticsValues() {
    //$.toast('Getting chart values');
    $.post("/Dashboard/GetAnalyticValues",
        {
            DateFrom: $('#filterDateFrom').val(),
            DateTo: $('#filterDateTo').val(),
            Provider: $('#filterIspDetails').children(":selected").attr("id"),
            Plan: $('#filterIspOffers').children(":selected").attr("id")
        },
        function (data) {
            populateChart(data);
        });
}
function clearFilters() {
    $('#filterDateFrom').val('');
    $('#filterDateTo').val('');
    $('#filterIspDetails').val('select');
    $('#filterIspOffers').val('select');
}
function populateChart(values) {
    var options = {
        animationEnabled: true,
        title: {
            text: "Site Activity",
            fontColor: "Peru"
        },
        axisY: {
            tickThickness: 0,
            lineThickness: 0,
            valueFormatString: " ",
            gridThickness: 0
        },
        axisX: {
            tickThickness: 0,
            lineThickness: 0,
            labelFontSize: 9,
            labelFontColor: "Peru"
        },
        data: [{
            indexLabelFontSize: 26,
            toolTipContent: "<span style=\"color:#62C9C3\">{indexLabel}:</span> <span style=\"color:#CD853F\"><strong>{y}</strong></span>",
            indexLabelPlacement: "inside",
            indexLabelFontColor: "white",
            indexLabelFontWeight: 600,
            indexLabelFontFamily: "Verdana",
            color: "#62C9C3",
            type: "bar",
            dataPoints: values
        }]
    };

    $("#chartContainer").CanvasJSChart(options);

}
function getISP() {
    $.get('/UserActions/GetISP',
        function (data) {
            if (data.length > 1 && data != null) {
                for (var i = 0, l = data.length; i < l; i++) {
                    $('#filterIspDetails').append($('<option id="' + data[i].id + '">' + data[i].value + '</option>'));
                }
            }
            else {
                $.toast('Error in getting Options.');
            }
        });
}
function getISPOffers() {
    $.get('/UserActions/GetISPOffer',
        function (data) {
            if (data.length > 1 && data != null) {

                for (var i = 0, l = data.length; i < l; i++) {
                    $('#filterIspOffers').append($('<option id="' + data[i].id + '">' + data[i].value + '</option>'));
                }
            }
            else {
                $.toast('Error in getting Options.');
            }
        });
}