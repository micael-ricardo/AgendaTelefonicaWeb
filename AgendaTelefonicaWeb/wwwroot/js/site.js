﻿const ContatosModule = (function () {
      let telefoneIndex = 1;
     function reindexarTelefones() {
        let index = 0;
        $('.telefone-group').each(function () {
            $(this).find('input').attr('name', 'Telefones[' + index + ']')
                .attr('id', 'Telefones_' + index + '_');
            $(this).find('span').attr('asp-validation-for', 'Telefones[' + index + ']');
            index++;
        });
        telefoneIndex = index;
    }

    function aplicarMascaraTelefone(element) {
        Inputmask({
            mask: ['(99) 9999-9999', '(99) 99999-9999'],
            keepStatic: true,
            removeMaskOnSubmit: true
        }).mask(element);
    }

    function inicializarMascaras() {
        $('.telefone').each(function () {
            aplicarMascaraTelefone(this);
        });
    }

    function inicializarDataTable() {
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
    }

    function adicionarTelefone() {
        const newGroup = $('.telefone-group:first').clone();
        newGroup.find('input').val('')
            .attr('asp-for', '')
            .attr('name', 'Telefones[' + telefoneIndex + ']')
            .attr('id', 'Telefones_' + telefoneIndex + '_');
        newGroup.find('span').attr('asp-validation-for', 'Telefones[' + telefoneIndex + ']');
        newGroup.find('.remover-telefone').prop('disabled', false);

        $('#telefonesContainer').append(newGroup);
        aplicarMascaraTelefone(newGroup.find('.telefone')[0]);
        telefoneIndex++;

        revalidarFormulario();
    }
    function removerTelefone() {
        if ($('.telefone-group').length > 1) {
            $(this).closest('.telefone-group').remove();
            reindexarTelefones();
            revalidarFormulario();
        }
    }

    function revalidarFormulario() {
        $('#contatoForm').removeData('validator')
            .removeData('unobtrusiveValidation');
        $.validator.unobtrusive.parse('#contatoForm');
    }

    return {
        init: function () {
            inicializarMascaras();
            inicializarDataTable();
            $('#adicionarTelefone').off('click').on('click', adicionarTelefone);
            $(document).off('click', '.remover-telefone').on('click', '.remover-telefone', removerTelefone);
        }
    };
})();

$(document).ready(function () {
    ContatosModule.init();
});