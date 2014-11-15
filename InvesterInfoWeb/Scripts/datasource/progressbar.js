
$(document).ready(function () {
    var pb = $("#progressBar").kendoProgressBar({        
        min: 0,
        max: 100,
        type: "value",
        animation: {
            duration: 400
        }
    }).data("kendoProgressBar");

    $(document).ajaxStart(function() {
        pb.value(10);
    });
    
    $(document).ajaxSend(function () {
        pb.value(20);
    });
    
    $(document).ajaxSuccess(function () {
        pb.value(90);
    });

    $(document).ajaxError(function (evt, jqXHR, settings, err) {
        pb.value(false);
    });

    $(document).ajaxComplete(function () {
        pb.value(100);
    });
    
    $(document).ajaxStop(function () {
        pb.value(1);
    });
});