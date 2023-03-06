$(document).ready(function () {
    var LeadId = $('#LeadId').val();

    BuscarCotacao(LeadId);
})

function BuscarCotacao(leadId) {
    $.ajax({
        type: "GET",
        url: '/Lead/BuscarCotacao',
        data: {
            leadId: leadId
        },
        cache: false,
        async: false,
        success: function (data) {
            $('#partialCotacoes').html(data);
        }
    })
}

function InserirCotacao(leadId) {

    var DataEmissao = $('#DataEmissao').val();
    var DataVencimento = $('#DataVencimento').val();
    var Valor = $('#Valor').val();
    var SeguradoraId = $('#SeguradoraId').val();

    $.ajax({
        type: "GET",
        url: '/Lead/InserirCotacao',
        data: {
            dataEmissao: DataEmissao,
            dataVencimento: DataVencimento,
            valor: Valor,
            leadId: leadId,
            seguradoraId: SeguradoraId
        },
        cache: false,
        async: false,
        success: function (data) {
            $('#partialCotacoes').html(data);
        }
    })
}