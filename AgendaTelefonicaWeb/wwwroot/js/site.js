function aplicarMascaraTelefone() {
    const telefoneInput = document.querySelectorAll('.telefone');

    if (telefoneInput) {
        Inputmask({
            mask: ['(99) 9999-9999', '(99) 99999-9999'],
            keepStatic: true,
            removeMaskOnSubmit: true
        }).mask(telefoneInput);
    }
}

document.addEventListener('DOMContentLoaded', aplicarMascaraTelefone);


$(document).ready(function () {
    $('#tabelaContatos').DataTable({
        "paging": true, 
        "pageLength": 5, 
        "lengthChange": true, 
        "info": true, 
        "autoWidth": false, 
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.10.21/i18n/Portuguese-Brasil.json"
        }
    });
});