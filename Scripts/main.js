$(document).ready(function () {

    $("#btn_print").click(function () {
        event.preventDefault();
        console.log("print btn clicked ");

        var $printArea = $('<div>');
        $printArea.text($('#tb_viewer').text());
        $printArea.print();
    });
});