
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

            if (data.isCreated == undefined) {

                toastr.success('Tarefa salva com sucesso!');

            } else if (!data.isCreated) {

                toastr.error(data.errorMessage);

            }

        }
    })
}

function abrirEditarAgenda(agendaId) {

    $.ajax({
        type: "GET",
        url: '/Agenda/BuscarEditarAgenda',
        data: {
            agendaId: agendaId
        },
        cache: false,
        async: false,
        success: function (data) {
            $('#partialEditarAgenda').html(data);

            $('#EditarAgenda').modal('show');  
        }
    })
}

function atualizarAgenda(agendaId) {

    var Data = $('#dataAtualizarAgenda').val();
    var Horario = $('#horaAtualizarAgenda').val();
    var Comentario = $('#comentarioAtualizarAgenda').val();

    $.ajax({
        type: "GET",
        url: '/Agenda/AtualizarAgenda',
        data: {
            data: Data,
            horario: Horario,
            comentario: Comentario,
            agendaId: agendaId
        },
        cache: false,
        async: false,
        success: function (data) {

            if (data.isCreated == undefined) {              

                toastr.success('Tarefa salva com sucesso!');

            } else if (!data.isCreated) {

                toastr.error(data.errorMessage);

            }

        },
        error: function (data) {
            toastr.error('Erro');
        }
    })
}

function abrirExcluirAgenda(agendaId) {
    $.ajax({
        type: "GET",
        url: '/Agenda/BuscarExcluirAgenda',
        data: {
            agendaId: agendaId
        },
        cache: false,
        async: false,
        success: function (data) {

            $('#partialExcluirAgenda').html(data);

            $('#ExcluirAgenda').modal('show');
        }
    })
}

function excluirAgenda(agendaId) {

    $.ajax({
        type: "GET",
        url: '/Agenda/ExcluirAgenda',
        data: {
            agendaId: agendaId    
        },
        cache: false,
        async: false,
        success: function (data) {           
            toastr.success('Tarefa excluída com sucesso!');
        },
        error: function (data) {
            toastr.error('Erro.', 'Cotação');
        }
    })
}