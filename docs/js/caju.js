$(document).ready(function () {

    $("#mainForm").validator();

    $("#mainForm").on("submit", function (e) {

        if (!e.isDefaultPrevented()) {

            if (document.activeElement.id === 'hexagonal')
                orderHexagonal();
            else if (document.activeElement.id === 'clean')
                orderClean();
            else if (document.activeElement.id === 'eventsourcing')
                orderEventSourcing();

            return false;
        }
    });


    function orderHexagonal() {

        var actionurl = 'https://grape.westus2.cloudapp.azure.com/cart/api/Orders/Hexagonal';

        var order = new Object();
        order.name = $('#Hexagonal_Name').text();
        order.useCases = $('#Hexagonal_UseCases')[0].value;
        order.userInterface = $('#Hexagonal_IncludeWebApi')[0].value == true ? 'webapi' : 'none';
        order.dataAccess = $('#Hexagonal_DataAccess')[0].value;
        order.tips = $('#Hexagonal_IncludeDocumentation')[0].value == true;
        order.skipRestore = $('#Hexagonal_SkipRestore')[0].value == true;

        $.ajax({
            url: actionurl,
            type: 'post',
            contentType: "application/json; charset=utf-8",
            dataType: 'application/json',
            data: JSON.stringify(order),
            success: function (data) {
                setInterval(function () { getTracking(JSON.parse(returnval.responseText).orderId); }, 1000);
                $('#mainForm').hide();
                $('#running').show();
            },
            error: function (returnval) {
                setInterval(function () { getTracking(JSON.parse(returnval.responseText).orderId); }, 1000);
                $('#mainForm').hide();
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
        order.userInterface = $('#Clean_IncludeWebApi')[0].value == true ? 'webapi' : 'none';
        order.dataAccess = $('#Clean_DataAccess')[0].value;
        order.tips = $('#Clean_IncludeDocumentation')[0].value == true;
        order.skipRestore = $('#Clean_SkipRestore')[0].value == true;

        $.ajax({
            url: actionurl,
            type: 'post',
            contentType: "application/json; charset=utf-8",
            dataType: 'application/json',
            data: JSON.stringify(order),
            success: function (data) {
                setInterval(function () { getTracking(JSON.parse(returnval.responseText).orderId); }, 1000);
                $('#mainForm').hide();
                $('#running').show();
            },
            error: function (returnval) {
                setInterval(function () { getTracking(JSON.parse(returnval.responseText).orderId); }, 1000);
                $('#mainForm').hide();
                $('#running').show();
            }
        });
    }

    function orderEventSourcing() {

        var actionurl = 'https://grape.westus2.cloudapp.azure.com/cart/api/Orders/EventSourcing';

        var order = new Object();
        order.name = $('#EventSourcing_Name').text();
        order.useCases = $('#EventSourcing_UseCases')[0].value;
        order.userInterface = $('#EventSourcing_IncludeWebApi')[0].value == true ? 'webapi' : 'none';
        order.dataAccess = $('#EventSourcing_DataAccess')[0].value;
        order.tips = $('#EventSourcing_IncludeDocumentation')[0].value == true;
        order.skipRestore = $('#EventSourcing_SkipRestore')[0].value == true;
        order.serviceBus = $('#EventSourcing_IncludeServiceBus')[0].value == true ? 'kafka' : 'none';

        $.ajax({
            url: actionurl,
            type: 'post',
            contentType: "application/json; charset=utf-8",
            dataType: 'application/json',
            data: JSON.stringify(order),
            success: function (data) {
                setInterval(function () { getTracking(JSON.parse(returnval.responseText).orderId); }, 1000);
                $('#mainForm').hide();
                $('#running').show();
            },
            error: function (returnval) {
                setInterval(function () { getTracking(JSON.parse(returnval.responseText).orderId); }, 1000);
                $('#mainForm').hide();
                $('#running').show();
            }
        });
    }

    $('#project-name').on('input', function () {
        var input = $(this);
        var re = /^[a-zA-Z0-9]{1,32}$/;
        var is_good_name = re.test(input.val());
        if (is_good_name) {
            input.removeClass("invalid").addClass("valid");
        }
        else {
            input.removeClass("valid").addClass("invalid");
        }
    });

    $('#project-name').keyup(function (event) {
        var input = $(this);
        var re = /^[a-zA-Z0-9]{1,32}$/;
        var is_good_name = re.test(input.val());
        if (is_good_name) {
            input.removeClass("invalid").addClass("valid");
        }
        else {
            input.removeClass("valid").addClass("invalid");
        }
    });

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