$(document).ready(function () {
    $.ajax({
        url: "/Persons/GetAllData",
        type: "GET"
    }).done((res) => {
        console.log(res);
        var female = res.filter(data => data.gender === 1).length;
        var male = res.filter(data => data.gender === 0).length;

        var sarjana = res.filter(data => data.degree === 'Sarjana').length;
        var magister = res.filter(data => data.degree === 'Magister').length;
        var doktor = res.filter(data => data.degree === 'Doktor').length;
        var diploma = res.filter(data => data.degree === "Diploma I").length + (data => data.degree === "Diploma II").length + (data => data.degree === "Diploma III").length + (data => data.degree === "Diploma IV").length;

        var udinus = res.filter(data => data.universityId === 1).length;
        var undip = res.filter(data => data.universityId === 2).length;

        console.log(sarjana);
        console.log(male);
        console.log(undip);
        var options = {
            series: [{
                data: [diploma, sarjana, magister, doktor],
            }],
            chart: {
                height: 350,
                type: 'bar',
            },
            plotOptions: {
                bar: {
                    borderRadius: 10,
                    dataLabels: {
                        position: 'top', // top, center, bottom
                    },
                }
            },
            dataLabels: {
                enabled: true,
                formatter: function (val) {
                    return val ;
                },
                offsetY: -20,
                style: {
                    fontSize: '12px',
                    colors: ["#304758"]
                }
            },
            xaxis: {
                categories: ['Diploma', 'Sarjana', 'Magister', 'Doktor'],
                position: 'top',
                axisBorder: {
                    show: false
                },
                axisTicks: {
                    show: false
                },
                crosshairs: {
                    fill: {
                        type: 'gradient',
                        gradient: {
                            colorFrom: '#D8E3F0',
                            colorTo: '#BED1E6',
                            stops: [0, 100],
                            opacityFrom: 0.4,
                            opacityTo: 0.5,
                        }
                    }
                },
                tooltip: {
                    enabled: true,
                }
            },
            yaxis: {
                axisBorder: {
                    show: false
                },
                axisTicks: {
                    show: false,
                },
                labels: {
                    show: false,
                    formatter: function (val) {
                        return val;
                    }
                }
            }
        };
        var chart = new ApexCharts(document.querySelector("#myDegreeChart"), options);
        chart.render();
        
        var gender = {
            series: [male, female],
            chart: {
                width: 280,
                type: 'pie',
            },
            labels: ['Male', 'Female'],
            responsive: [{
                breakpoint: 480,
                options: {
                    chart: {
                        width: 200
                    },
                    legend: {
                        show: true,
                        position: 'right',
                    }
                }
            }]
        };
        var chartGender = new ApexCharts(document.querySelector("#myGenderChart"), gender);
        chartGender.render();
        var university = {
            series: [udinus, undip],
            chart: {
                width: 280,
                type: 'donut',
            },
            labels: ['UDINUS', 'UNDIP'],
            responsive: [{
                breakpoint: 480,
                options: {
                    chart: {
                        width: 200
                    },
                    legend: {
                        show: true,
                        position: 'right',
                    }
                }
            }]
        };
        var chartUniv = new ApexCharts(document.querySelector("#myUnivChart"), university);
        chartUniv.render();
    }).fail((error) => {
        Swal.fire({
            title: 'Error!',
            icon: 'Error',
            confirmButtonText: 'Next'
        })
    });
});
