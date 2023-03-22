$(document).ready(function () {


    $('#tabela-leads').DataTable({
        "searching": false,
        "paging": true,
        "select": false,
        "order": [[0, 'desc']],
        "language": {
            url: '//cdn.datatables.net/plug-ins/1.13.4/i18n/pt-BR.json',
        }    
    });

});

