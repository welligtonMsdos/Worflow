$(document).ready(function () {
    buscarCalendar();
})


function buscarCalendar() {
    $.ajax({
        type: "GET",
        url: '/Agenda/BuscarCalendar',
        data: {
           
        },
        cache: false,
        async: false,
        success: function (data) {

            $('#partialCalendar').html(data);

        }
    })
}