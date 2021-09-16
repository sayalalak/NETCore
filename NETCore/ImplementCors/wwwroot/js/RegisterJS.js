(function () {
    'use strict';
    window.addEventListener('load', function () {
        // Fetch all the forms we want to apply custom Bootstrap validation styles to
        var forms = document.getElementsByClassName('needs-validation');
        // Loop over them and prevent submission
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                    insert();
                }
                form.classList.add('was-validated');
            }, false);
        });
    }, false);
})();
$(document).ready(function () {
    $('#myTable').DataTable({
        "dom": 'Bfrtip',
        "buttons": [
            {
                extend: 'print',
                type : 'button',
                text: 'Cetak Tabel',
                class: 'btn btn-primary',
            }
        ],
        "filter": true,
        "ajax": {
            "url": "https://localhost:44348/API/Persons/GetRegister",
            "datatype": "json",
            "dataSrc": "result"
        },
        
        //"responsive": {
        //    "details": {
        //        "display": $.fn.dataTable.Responsive.display.modal({
        //            "header": function (row) {
        //                var data = row.data();
        //                return 'Details for ' + data['namaLengkap'];
        //            }
        //        }),
        //        "renderer": $.fn.dataTable.Responsive.renderer.tableAll({
        //            "tableClass": 'table'
        //        })
        //    }
        //},
        "columns": [
            {
                "data": null,
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                },
                "autoWidth": true,
                "orderable": false
            },
            { "data": "nik", "autoWidth": true },
            { "data": "namaLengkap", "autoWidth": true },
            { "data": "email", "autoWidth": true },
            {
                "data": null,
                "orderable": false,
                "render": function (data, type, row) {

                    return "+62" + row["phoneNumber"].substr(1);
                },
                "autoWidth": true
            },
            {
                "data": null,
                "render": function (data, type, row) {

                    return "RP. " + row["salary"];
                },
                "autoWidth": true
            },
            {
                "render": function (data, type, row) {
                    return `<button type="button"
                        class="btn btn-primary"
                        data-toggle="modal"
                        data-target="#exampleModal"
                        onclick="detail('${row["nik"]}')">Detail</button></td>`;
                },
                "autoWidth": true,
                "orderable": false
            }
        ]
    });
    //$("#btnSubmit").click(e => {
    //    e.preventDefault();
        
    //});
});
function detail(nik) {
    $.ajax({
        url: "https://localhost:44348/API/Persons/GetRegister/"+nik,
    }).done((result) => {
        console.log(nik);
        //menampil kan data
        var text = "";
        text = `<ul>
                    <li class="list-group">: ${result.result.birthDate}</li>
                    <li class="list-group">: ${result.result.email}</li>
                    <li class="list-group">: ${result.result.gender}</li>
                    <li class="list-group">: ${result.result.degree}</li>
                    <li class="list-group">: ${result.result.gpa}</li>
                    <li class="list-group">: ${result.result.salary}</li>
                    <li class="list-group">: ${result.result.universityName}</li>
                </ul>
         `;
        //$("#dataModal").modal('show');
        $("#data").html(text);
    }).fail((result) => {
        console.log(result);
    });
};

function insert() {
    var obj = {
        "NIK": $('#nik').val(),
        "FirstName": $('#firstname').val(),
        "LastName": $('#lastname').val(),
        "PhoneNumber": $('#phone').val(),
        "BirthDate": $('#dateBirth').val(),
        "Salary": parseInt($('#salary').val()),
        "Email": $('#email').val(),
        "Gender": parseInt($('#gender').val()),
        "Password": $('#password').val(),
        "UniversityId": parseInt($('#university').val()),
        "Degree": $('#degree').val(),
        "GPA": $('#gpa').val()
    };
    console.log(JSON.stringify(obj));
    $.ajax({
        url: "https://localhost:44348/API/Persons/Register",
        method: 'POST',
        dataType: 'json',
        contentType: 'application/json',
        data: JSON.stringify(obj),
        success: function (data) {
            console.log(data.message);
            $('#addModal').modal('hide');
            $('#formRegister').trigger("reset");
            Swal.fire('Registration Success');
            $('#myTable').DataTable().ajax.reload();
        },
        error: function (xhr, status, error) {
            Swal.fire({
                icon: 'error',
                icon: 'error',
                title: 'Oops...',
                text: 'Something went wrong!'
            });
        }
    })
}
//function Insert() {
//    var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
//    obj.NIK = $("nik").val();
//    obj.FirstName = $("#firstName").val();
//    obj.LastName = $("#lastName").val();
//    obj.PhoneNumber = $("#phone").val();
//    obj.BirthDate = $("#dateBirth").val();
//    obj.Gender = $("#gender").val();
//    obj.Salary = $("salary").val();
//    obj.Email = $("#email").val();
//    obj.Password = $("#password").val();
//    obj.Degree = $("#degree").val();
//    obj.GPA = $("#gpa").val();
//    obj.UniversityId = $("#university").val();
//    console.log(obj);
//    //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
//    $.ajax({
//        url: "https://localhost:44348/API/Persons/Register",
//        type: "POST",
//        data: obj
//}).done((result) => {
//    //buat alert pemberitahuan jika success
//    console.log(data);
//    //$('#addModal').modal('hide');
//    //Swal.fire('Registration Success');
//    //$('#myTable').DataTable().ajax.reload();
//}).fail((error) => {
//    //alert pemberitahuan jika gagal
//})
//}