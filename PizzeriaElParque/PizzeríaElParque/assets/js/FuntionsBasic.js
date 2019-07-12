function hide(id) {
    document.getElementById(id).style.display = 'none';

}
function show(id) {
    document.getElementById(id).style.display = 'block';
}

function showModal() {
    $(document).ready(function () {
            $("#MyModal").modal({backdrop: 'static', keyboard: false});
    });
}

function showModalConfirm() {
    $(document).ready(function () {
        $("#MyModal2").modal({ backdrop: 'static', keyboard: false });
    });
}

function showModalOrder() {
    $(document).ready(function () {
        $("#MyModal2").modal({ backdrop: 'static', keyboard: false });
    });
}
function agregarFila() {
    document.getElementById("tablaprueba").insertRow(-1).innerHTML = '<td></td><td></td><td></td><td></td>';
}

function eliminarFila() {
    var table = document.getElementById("tablaprueba");
    var rowCount = table.rows.length;
    //console.log(rowCount);

    if (rowCount <= 1)
        alert('No se puede eliminar el encabezado');
    else
        table.deleteRow(rowCount - 1);
}



