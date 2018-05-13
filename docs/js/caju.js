$(document).ready(function () {

    $("form input[type=submit]").click(function () {
        $("input[type=submit]", $(this).parents("form")).removeAttr("clicked");
        $(this).attr("clicked", "true");
    });

    $('#mainForm').on('submit', function (e) {
        $(this).addClass('was-validated');

        var re = /^[a-zA-Z0-9]{1,32}$/;
        var is_good_name = re.test($('#project-name').val());

        if (is_good_name) {
            var buttonId = $("input[type=submit][clicked=true]")[0].id;

            if (buttonId == 'hexagonal') {
                orderHexagonal();
            }

            if (buttonId == 'clean') {
                orderClean();
            }

            if (buttonId == 'eventsourcing') {
                orderEventSourcing();
            }
        }

        e.preventDefault();
        e.stopPropagation();

        return false;
    });

    function orderHexagonal() {

        var actionurl = 'https://grape.westus2.cloudapp.azure.com/cart/api/Orders/Hexagonal';

        var order = new Object();
        order.name = $('#Hexagonal_Name').text();
        order.useCases = $('#Hexagonal_UseCases')[0].value;
        order.userInterface = $('#Hexagonal_IncludeWebApi').is(":checked") ? 'webapi' : 'none';
        order.dataAccess = $('#Hexagonal_DataAccess')[0].value;
        order.tips = $('#Hexagonal_IncludeDocumentation').is(":checked");
        order.skipRestore = !$('#Hexagonal_SkipRestore').is(":checked");

        $.ajax({
            url: actionurl,
            type: 'post',
            contentType: "application/json; charset=utf-8",
            dataType: 'application/json',
            data: JSON.stringify(order),
            success: function (data) {
                setInterval(function () { getTracking(JSON.parse(returnval.responseText).orderId); }, 1000);
                $('#preferences').hide();
                $('#running').show();
            },
            error: function (returnval) {
                setInterval(function () { getTracking(JSON.parse(returnval.responseText).orderId); }, 1000);
                $('#preferences').hide();
                $('#running').show();
            }
        });

        return false;
    };

    function orderClean() {

        var actionurl = 'https://grape.westus2.cloudapp.azure.com/cart/api/Orders/Clean';

        var order = new Object();
        order.name = $('#Clean_Name').text();
        order.useCases = $('#Clean_UseCases')[0].value;
        order.userInterface = $('#Clean_IncludeWebApi').is(":checked") ? 'webapi' : 'none';
        order.dataAccess = $('#Clean_DataAccess')[0].value;
        order.tips = $('#Clean_IncludeDocumentation').is(":checked");
        order.skipRestore = !$('#Clean_SkipRestore').is(":checked");

        $.ajax({
            url: actionurl,
            type: 'post',
            contentType: "application/json; charset=utf-8",
            dataType: 'application/json',
            data: JSON.stringify(order),
            success: function (data) {
                setInterval(function () { getTracking(JSON.parse(returnval.responseText).orderId); }, 1000);
                $('#preferences').hide();
                $('#running').show();
            },
            error: function (returnval) {
                setInterval(function () { getTracking(JSON.parse(returnval.responseText).orderId); }, 1000);
                $('#preferences').hide();
                $('#running').show();
            }
        });
    }

    function orderEventSourcing() {

        var actionurl = 'https://grape.westus2.cloudapp.azure.com/cart/api/Orders/EventSourcing';

        var order = new Object();
        order.name = $('#EventSourcing_Name').text();
        order.useCases = $('#EventSourcing_UseCases')[0].value;
        order.userInterface = $('#EventSourcing_IncludeWebApi').is(":checked") ? 'webapi' : 'none';
        order.dataAccess = $('#EventSourcing_DataAccess')[0].value;
        order.tips = $('#EventSourcing_IncludeDocumentation').is(":checked");
        order.skipRestore = !$('#EventSourcing_SkipRestore').is(":checked");
        order.serviceBus = $('#EventSourcing_IncludeServiceBus').is(":checked") ? 'kafka' : 'none';

        $.ajax({
            url: actionurl,
            type: 'post',
            contentType: "application/json; charset=utf-8",
            dataType: 'application/json',
            data: JSON.stringify(order),
            success: function (data) {
                setInterval(function () { getTracking(JSON.parse(returnval.responseText).orderId); }, 1000);
                $('#preferences').hide();
                $('#running').show();
            },
            error: function (returnval) {
                setInterval(function () { getTracking(JSON.parse(returnval.responseText).orderId); }, 1000);
                $('#preferences').hide();
                $('#running').show();
            }
        });
    }

    $('#project-name').keyup(function () {
        $('#Hexagonal_Name').text($(this).val());
        $('#Clean_Name').text($(this).val());
        $('#EventSourcing_Name').text($(this).val());
    });

    function getTracking(id) {

        var actionurl = 'https://grape.westus2.cloudapp.azure.com/tracking/api/Orders/' + id;

        $.get(actionurl, function (data, status) {

            if ($('#step1_Waiting').is(":visible")) {
                $('#commandlines').text(data.commandLines);

                $('#linkpreview').text(data.downloadUrl);
                $('#step3_Ready a').attr("href", data.downloadUrl);
                $('#step3_Ready a').text(data.downloadUrl);
                $('#downloadRow a').attr("href", data.downloadUrl);
                $('#step1_Waiting').hide();
                $('#step1_Ready').show();
            }

            if ((new Date(data.dotNetNewFinishedUtcDate)).getFullYear() >= 2018) {
                if (data.dotNetNewOutput || 0 !== data.dotNetNewOutput.length)
                    $('#outputlines').text(data.dotNetNewOutput);

                $('#step2_Waiting').hide();
                $('#step2_Ready').show();
            }

            if ($('#step3_Waiting').is(":visible")) {
                if ((new Date(data.uploadFinished)).getFullYear() >= 2018) {
                    $('#step3_Waiting a').attr("href", data.downloadUrl);
                    $('#step3_Waiting').hide();
                    $('#step3_Ready').show();
                    $('#downloadRow').show();
                }
            }

        });
    }

});