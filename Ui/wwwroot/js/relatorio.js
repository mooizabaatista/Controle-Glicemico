$(document).ready(() => {
  let myChart = null; // Variável para armazenar o gráfico

  function inicializar() {
    $(".nav-7").addClass("active"); // Adiciona a classe 'active' ao item de 7 dias
    $(".nav-15").removeClass("active"); // Remove a classe 'active' dos outros itens
    $(".nav-all").removeClass("active");

    getDadosRelatorio(7);
  }

  inicializar();

  $(".nav-7").click(function () {
    $(this).addClass("active");
    $(".nav-15").removeClass("active");
    $(".nav-all").removeClass("active");

    getDadosRelatorio(7);
  });

  $(".nav-15").click(function () {
    $(this).addClass("active");
    $(".nav-7").removeClass("active");
    $(".nav-all").removeClass("active");

    getDadosRelatorio(15);
  });

  $(".nav-all").click(function () {
    $(this).addClass("active");
    $(".nav-15").removeClass("active");
    $(".nav-7").removeClass("active");

    getDadosRelatorio();
  });

  function getDadosRelatorio(dias) {
    $.ajax({
      method: "GET",
      url: `Relatorios/GetDadosPorDataChart/?dias=${dias}`,
    })
      .done(function (res) {
        if (res && res.dados && Array.isArray(res.dados)) {
          const ctx = document
            .getElementById("graficoPorData")
            .getContext("2d");

          // Destrói o gráfico anterior se existir
          if (myChart) {
            myChart.destroy();
          }

          // Extraia labels e dados para cada período
          const labels = res.dados.map((item) => item.data);
          const valorGlicemiaManha = res.dados.map(
            (item) => item.valorGlicemiaManha
          );
          const valorGlicemiaTarde = res.dados.map(
            (item) => item.valorGlicemiaTarde
          );
          const valorGlicemiaNoite = res.dados.map(
            (item) => item.valorGlicemiaNoite
          );

          // Criação do novo gráfico
          myChart = new Chart(ctx, {
            type: "bar", // Tipo de gráfico
            data: {
              labels: labels,
              datasets: [
                {
                  label: "Valor Glicêmico Manhã",
                  data: valorGlicemiaManha,
                  backgroundColor: "rgba(54, 162, 235, 0.5)",
                  borderColor: "rgba(54, 162, 235, 1)",
                  borderWidth: 1,
                },
                {
                  label: "Valor Glicêmico Tarde",
                  data: valorGlicemiaTarde,
                  backgroundColor: "rgba(15, 155, 69, 0.5)",
                  borderColor: "rgba(15, 155, 69, 1)",
                  borderWidth: 1,
                },
                {
                  label: "Valor Glicêmico Noite",
                  data: valorGlicemiaNoite,

                  backgroundColor: "rgba(255, 99, 132, 0.5)",
                  borderColor: "rgba(255, 99, 132, 1)",
                  borderWidth: 1,
                },
              ],
            },
            options: {
              responsive: true,
              maintainAspectRatio: false,
              plugins: {
                legend: {
                  labels: {
                    font: {
                      size: 10, // Tamanho da fonte das labels da legenda
                    },
                  },
                },
                tooltip: {
                  bodyFont: {
                    size: 13, // Tamanho da fonte do tooltip
                  },
                },
              },
              scales: {
                x: {
                  ticks: {
                    font: {
                      size: 10, // Tamanho da fonte dos rótulos do eixo X
                    },
                  },
                  title: {
                    display: true,
                    font: {
                      size: 14, // Tamanho da fonte do título do eixo X
                    },
                  },
                },
                y: {
                  beginAtZero: true,
                  ticks: {
                    font: {
                      size: 8, // Tamanho da fonte dos rótulos do eixo Y
                    },
                  },
                  title: {
                    display: true,
                    text: "Valor Glicêmico",
                    font: {
                      size: 10, // Tamanho da fonte do título do eixo Y
                    },
                  },
                },
              },
            },
          });
        } else {
          console.error("Dados inválidos recebidos:", res);
        }
      })
      .fail(function (jqXHR, textStatus, errorThrown) {
        console.error("Erro na requisição:", textStatus, errorThrown);
      });
  }
});
