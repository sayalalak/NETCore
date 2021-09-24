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
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: 'Something went wrong!',
                    })
                    event.stopPropagation();
                }
                form.classList.add('was-validated');
            }, false);
        });
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === true) {
                    event.preventDefault();
                    insert();
                }
                form.classList.add('was-validated');
            }, false);
        });
    }, false);
})();
$(document).ready(function () {
    $('#myTable').DataTable({
        "filter": true,
        "ajax": {
            "url": "/Persons/GetAllData",
            "datatype": "json",
            "dataSrc": ""
        },
        "dom": 'Bfrtip',
        "buttons": [
            {
                extend: 'excelHtml5',
                exportOptions: {
                    columns: [1, 2, 3, 4, 5]
                },
                className: 'btn btn-sm btn-outline-secondary',
                bom: true
            },
            {
                extend: 'pdfHtml5',
                exportOptions: {
                    columns: [1, 2, 3, 4, 5]

                },
                className: 'btn btn-sm btn-outline-secondary',
                bom: true
            },
            {
                extend: 'print',
                exportOptions: {
                    columns: [1, 2, 3, 4, 5]
                },
                className: 'btn btn-sm btn-outline-secondary',
                bom: true
            },
        ],
        
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
                /*"autoWidth": true,*/
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
                        onclick="detail('${row["nik"]}')">Detail</button></td>
                        <button type="button"
                        class="btn btn-danger"
                        onclick="remove('${row["nik"]}')">Delete</button></td>
                        `;
                },
                //"render": function (data, type, row) {
                //    return ``;
                //},
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
        url: "/Persons/GetById/"+nik,
    }).done((result) => {
        console.log(nik);
        console.log(result);
        //menampil kan data
        var text = "";
        text = `<ul>
                    <li class="list-group">: ${result.birthDate}</li>
                    <li class="list-group">: ${result.email}</li>
                    <li class="list-group">: ${result.gender}</li>
                    <li class="list-group">: ${result.degree}</li>
                    <li class="list-group">: ${result.gpa}</li>
                    <li class="list-group">: ${result.salary}</li>
                    <li class="list-group">: ${result.universityId}</li>
                </ul>
         `;
        //$("#dataModal").modal('show');
        $("#data").html(text);
    }).fail((result) => {
        console.log(result);
    });
};
function  remove(nik){
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            //let val = document.getElementById('nik');
            //console.log(nik);
            //val.remove();
            $.ajax({
                url: "https://localhost:44348/API/Persons/"+nik,
                method: 'DELETE',
                success: function () {
                    console.log(nik);
                    Swal.fire(
                        'Deleted!',
                        'Your file has been deleted.',
                        'success'
                    )
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
    })
}

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
        url: "/Persons/PostReg",
        type: 'POST',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(obj),
        success: function (data) {
            console.log(data);
            Swal.fire('Registration Success');
            /*$('#addModal').modal("hide");*/
            $('#addModal').hide();
            $('.modal-backdrop').remove();
            $('#formatRegister').trigger('reset');
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