

$(document).ready(function () {

    graficoBarras();

    graficoPizza();

});

function graficoBarras() {

    const ctx = document.getElementById('grafico_barras');

    const labels = ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho'];

    const data = {
        labels: labels,
        datasets: [{
            label: 'Nº de Leads',
            data: [65, 59, 80, 81, 56, 55, 40],
            backgroundColor: [
                'rgba(255,99,132,0.2)',
                'rgba(255,159,64,0.2)',
                'rgba(255,205,86,0.2)',
                'rgba(75,192,192,0.2)',
                'rgba(54,162,235,0.2)',
                'rgba(153,102,255,0.2)'
            ],
            borderColor: [
                'rgba(255,99,132)',
                'rgba(255,159,64)',
                'rgba(255,205,86)',
                'rgba(75,192,192)',
                'rgba(54,162,235)',
                'rgba(153,102,255)'
            ],
            borderWidth: 1
        }]
    };

    new Chart(ctx, {
        type: 'bar',
        data: data,
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });

}

function graficoPizza() {

    const ctx = document.getElementById('grafico_pizza');

    const data = {
        labels: [
            'Red',
            'Blue',
            'Yellow'
        ],
        datasets: [{
            label: 'Total por produto',
            data: [150, 25, 50],
            backgroundColor: [
                'rgb(255,99,132)',
                'rgb(54,162,235',
                'rgb(255,205,86)'
            ],
            hoverOffset: 4
        }]
    };

    new Chart(ctx, {
        type: 'doughnut',
        data: data,
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
}