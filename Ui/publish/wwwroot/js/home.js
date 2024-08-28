$(document).ready(() => {
  new DataTable("#tbControle", {
    responsive: true,
    language: {
      sEmptyTable: "Nenhum dado disponível na tabela",
      sInfo: "Mostrando _START_ a _END_ de _TOTAL_ entradas",
      sInfoEmpty: "Mostrando 0 a 0 de 0 entradas",
      sInfoFiltered: "(filtrado de _MAX_ entradas no total)",
      sInfoPostFix: "",
      sInfoThousands: ",",
      sLengthMenu: "Mostrar _MENU_ entradas",
      sLoadingRecords: "Carregando...",
      sProcessing: "Processando...",
      sSearch: "Pesquisar:",
      sZeroRecords: "Nenhum registro encontrado",
      oPaginate: {
        sFirst: "Primeira",
        sLast: "Última",
        sNext: "Próxima",
        sPrevious: "Anterior",
      },
      oAria: {
        sSortAscending:
          ": ativar para classificar a coluna de forma ascendente",
        sSortDescending:
          ": ativar para classificar a coluna de forma descendente",
      },
    },
    columnDefs: [
      {
        orderable: false,
        targets: [3], // Adapte conforme a coluna que não deve ser ordenável
      },
    ],
    scrollX: true, // Adiciona rolagem horizontal
  });
});

function LimparCampos() {
  $("#data").val("");
  $("#periodo").val("");
  $("#valorGlicemico").val("");
  $("#exampleModal").modal("show");
}

function Editar(id) {
  $.ajax({
    method: "POST",
    url: "/Home/Index",
    data: { id: id },
  }).done(function (success) {
    var data = new Date(success.data).toISOString().split("T")[0];
    $("#id").val(success.id);
    $("#data").val(data);
    $("#periodo").val(success.periodo);
    $("#valorGlicemico").val(success.valorGlicemico);
    $("#exampleModal").modal("show");
  });
}

function Deletar(id) {
  Swal.fire({
    title: "Você tem certeza?",
    text: "O registro não poderá ser recuperado...",
    icon: "warning",
    showCancelButton: true,
    confirmButtonText: "Confirmar",
    cancelButtonText: "Cancelar",
  }).then((result) => {
    if (result.isConfirmed) {
      $.ajax({
        method: "POST",
        url: "/Home/Delete",
        data: { id: id },
      }).done(function () {
        Swal.fire("Excluído!", "O registro foi excluído.", "success").then(
          (reslt) => {
            location.reload();
          }
        );
      });
    } else {
      Swal.fire("Cancelado", "A operação foi cancelada.", "info");
    }
  });
}
