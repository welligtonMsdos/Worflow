
function novaTarefa(data) {

    $('#data').val(data.toString());
   
}

function inserirTarefa() {

    var Data = $('#data').val();
    var Horario = $('#horario').val();
    var Comentario = $('#comentario').val();
    
    $.ajax({
        type: "GET",
        url: '/Agenda/InserirTarefa',
        data: {
            data: Data,
            horario: Horario,
            comentario: Comentario
        },
        cache: false,
        async: false,
        success: function (data) {

            toastr.success('Tarefa salva com sucesso!');

        }
    })
}