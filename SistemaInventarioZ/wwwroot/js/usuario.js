﻿let datatable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    datatable = $('#tblDatos').DataTable({
        "language": {
            "lengthMenu": "Mostrar _MENU_ Registros Por Pagina",
            "zeroRecords": "Ningun Registro",
            "info": "Mostrar paginas _PAGE_ de _PAGES_",
            "infoEmpty": "no hay registros",
            "infoFiltered": "(filtered from _MAX_ total registros)",
            "search": "Buscar",
            "paginate": {
                "first": "Primero",
                "last": "Último",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "ajax": {
            "url": "/Admin/Usuario/ObtenerTodos"
        },
        "columns": [
            { "data": "email"},
            { "data": "nombre" },
            { "data": "apellidos" },
            { "data": "phoneNumber" },
            { "data": "role" },
            {
                "data": {
                    id: "id", lockoutEnd: "lockoutEnd"
                },
                "render": function (data) {
                    let hoy = new Date().getTime();
                    let bloqueo = new Date(data.lockoutEnd).getTime();
                    if (bloqueo > hoy) {
                        //Usuario esta bloqueado
                        return `
                            <div class="text-center">
                            
                                <a onClick=BloquearDesbloquear('${data.id}') class="btn btn-danger text-white" style="cursor:pointer, width:150px">
                                    <i class="bi bi-unlock"></i> Desbloquear
                                </a>
                            </div>
                        `;
                    }
                    else {
                        return `
                            <div class="text-center">
                            
                                <a onClick=BloquearDesbloquear('${data.id}') class="btn btn-success text-white" style="cursor:pointer", width:150px>
                                    <i class="bi bi-lock"></i> Bloquear
                                </a>
                            </div>
                        `;
                    }
                    
                }
            }
        ]
    });
}

function BloquearDesbloquear(id) {
    $.ajax({
        type: "POST",
        url: '/Admin/Usuario/BloquearDesbloquear',
        data: JSON.stringify(id),
        contentType: "application/json",
        success: function (data) {
            if (data.success) {
                toastr.success(data.message);
                datatable.ajax.reload();
            } else {
                toastr.error(data.message);
             }
        },
    });
}