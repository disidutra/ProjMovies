var listDeleteRange = [];
var urlDelete = '';
var urlDeleteRange = '';

// Mostra o Modal de Confirmação para deletar um item
function modalDeleteShow(id) {
    $('#modal-delete').data('id', id).modal('show');
}

//Chama o método de delete item, apos o usuário clicar no em sim
function confirmDelete() {
    var _id = $('#modal-delete').data('id');

    $.ajax({
        url: self.urlDelete,
        data: { id: _id },
        dataType: 'json',
        type: 'delete',
        success: function () {
            $('#modal-delete').data('id', '0').modal('hide');
            $('#item-' + _id).remove();
        },
        error: function () {
            $('#modal-delete').data('id', '0').modal('hide');
        },
        complete: function () {
            
        }
    });
}

//Esse metodo é chamado no onclick do checkbox de delete itens
function checkedClick(checked) {
    var self = this;
    var item = parseInt(checked.value);

    //Se o valor do checked é true inclui o id na lista, caso contrário o remove
    if (checked.checked) {
        self.listDeleteRange.push(item);
    } else {
        self.listDeleteRange = self.listDeleteRange.filter((value) => item != value);
    }

    //Habilita o Botao de deletar selecionados se tiver pelo menos um checekd setado, caso contrário o desabilita
    if (self.listDeleteRange.length > 0) {
        $("#btn-delete-range").attr("disabled", false);
    } else {
        $("#btn-delete-range").attr("disabled", true);
    }
}

// Mostra o Modal de Confirmação para deletar os items selecionados
function modalDeleteRangeShow() {
    $('#modal-delete-range').modal('show');
}

//Chama o método de delete items selecionados, apos o usuário clicar no em sim
function confirmDeleteRange() {
    var self = this;
    $.ajax({
        url: self.urlDeleteRange,
        data: { items: self.listDeleteRange },
        dataType: 'json',
        type: 'delete',
        success: function () {
            self.listDeleteRange.forEach((item) => $('#item-' + item).remove());
            self.listDeleteRange = []
            $('#modal-delete-range').modal('hide');
        },
        error: function () {
            $('#modal-delete-range').modal('hide');
        },
        complete: function () {
            
        }
    });
}