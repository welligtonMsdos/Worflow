
$(".delete").click(function () {
    var id = $(this).attr("data-id");
   
    $("#modal").load("_Excluir?id=" + id, function () {
        $("#modal").modal();
    })
});