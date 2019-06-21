function hide() {
    document.getElementById('insertar').style.display = 'none';

}
function show(id) {
    document.getElementById(id).style.display = 'block';
}

function showModal() {
    $(document).ready(function () {
            $("#MyModal").modal({backdrop: 'static', keyboard: false});
    });
}

function validatePasswors() {

    var password1 = document.getElementById("newPassword").value;
    var password2 = document.getElementById("validatePassword").value;

    if (password1 == "" || password2 == "") {
        toastr.warning("Existen campos sin llenar");
    } else {
        if (password1 == password2) {

            darClick();

            toastr.success("Creaste tu contraseña");
        } else {
            toastr.error("Las contraseñas no son iguales");
        }
    }

}
function darClick() {

    var boton = document.getElementById('<%=newPasswordUser.ClientID%>');

    boton.click(); 

}



