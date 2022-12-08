
$(document).ready(function() {
    listarGrid(),
    listarDisciplina()
});



function limpar() {
    $('#notainput').html("");
    $('#comentarioinput').html("");
    $('#disciplinainput').html("");
    $('#idInput').html("");

}


function atualizar(){

    let avaliação = {
        id: document.getElementById("idInput").value,
        avaliacao1: document.getElementById("notainput").value,
        comentario: document.getElementById("comentarioinput").value,
        idDisciplina: document.getElementById("disciplinainput").value
    };

    $.ajax({
        type: 'PUT',
        url: 'https://20.226.108.178:5001/Avaliacao/Alterar',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(avaliação),
        success: function() {
            alert("Eleitor alterado com sucesso!");
            limpar();
            location.reload(true);
        },
        error: function() {
            alert("Erro ao realizar operação!");
        }
    });
}


function excluir(id) {
    console.log(id)
    $.ajax({
        type: 'DELETE',
        url: 'https://20.226.108.178:5001/Avaliacao/Excluir/' + id,
        contentType: "application/json; charset=utf-8",
        success: function(resposta) { 
            alert("Avaliação removida com sucesso!");
            location.reload(true);
        },
        error: function(erro, mensagem, excecao) { 
            alert("Erro ao realizar a remoção!");
        }
    });
}

function visualizar(id){
    $.get('https://20.226.108.178:5001/Avaliacao/Visualizar?id=' + id)
    .done(function(resposta){
        let ID = resposta.id
        let avali = resposta.avaliacao1
        let coment = resposta.comentario
        let disc = resposta.idDisciplina


        alert("O comentario de ID numero: " + ID + "\nDeu uma nota de " + avali + " estrelas"+ "\nPara a disciplina " + disc + "\nCom o comentario: \n " + coment)
    })
    
}

function alterar(id){
    $.get('https://20.226.108.178:5001/Avaliacao/Visualizar?id='+id)
        .done(function(resposta) { 
            $('#idInput').val(resposta.id);
            $('#notainput').val(resposta.avaliacao1);
            $('#comentarioinput').val(resposta.comentario);
            $('#disciplinainput').val(resposta.idDisciplina);
        })
        .fail(function(erro, mensagem, excecao) { 
            alert("Erro ao realizar a alteração!");
        });
}


function grid(resposta) {
    console.log(resposta);
            $('#grid tr').remove();
            for(i = 0; i < resposta.length; i++) {                
                let linha = $('<tr class="text-center"></tr>');
            
                linha.append($('<td></td>').html(resposta[i].avaliacao1));
                linha.append($('<td></td>').html(resposta[i].comentario));
                linha.append($('<td></td>').html(resposta[i].idDisciplinaNavigation.nome));
                
                let botaoExcluir = $('<button class="btn btn-danger"></button>').attr('type', 'button').html('Excluir').attr('onclick', 'excluir(' + resposta[i].id + ')');
                let botaoVisualizar = $('<button class="btn btn-danger"></button>').attr('type', 'button').html('Visualizar').attr('onclick', 'visualizar(' + resposta[i].id + ')')
                let botaoAlterar = $('<button class="btn btn-danger"></button>').attr('type', 'button').html('Alterar').attr('onclick', 'alterar(' + resposta[i].id + ')')

                let acoes = $('<td></td>');
                acoes.append(botaoExcluir);
                acoes.append(botaoVisualizar);
                acoes.append(botaoAlterar);

                linha.append(acoes);
                
                $('#grid').append(linha);
            }
        

}

function listarGrid(){
    $.get('https://20.226.108.178:5001/Avaliacao/Listar')
        .done(function(resposta) { 
            grid(resposta);
        })
        .fail(function(erro, mensagem, excecao) { 
            alert(mensagem + ': ' + excecao);
        });
}

function listarGridDecrescente(){
    $.get('https://20.226.108.178:5001/Disciplina/Listar?order=d')
        .done(function(resposta) { 
            grid(resposta);
        })
        .fail(function(erro, mensagem, excecao) { 
            alert(mensagem + ': ' + excecao);
        });
}

function listarGridCrescente(){
    $.get('https://20.226.108.178:5001/Disciplina/Listar?order=c')
        .done(function(resposta) { 
            grid(resposta);
        })
        .fail(function(erro, mensagem, excecao) { 
            alert(mensagem + ': ' + excecao);
        });
}


function listaAvaliacaoPorDisciplina() {

    var element = document.getElementById("disciplinaSelect");
    var valueAvaliacao = element.options[element.selectedIndex].value;
    var textAvaliacao = element.options[element.selectedIndex].text;
    
    if(valueAvaliacao == 0){
        listarGrid();
    }
    else
    {
        $.get('https://20.226.108.178:5001/Disciplina/ListarPorDisciplina?nome=' + textAvaliacao)
            .done(function(resposta) { 
                grid(resposta);
            })
            .fail(function(erro, mensagem, excecao) { 
                alert("Erro ao consultar a API!");
            });
        }
}

function listarDisciplina(){
    $.get('https://20.226.108.178:5001/Avaliacao/ListarDisciplina')
        .done(function(resposta) { 
            for(i = 0; i < resposta.length; i++) {
                $('#disciplinaSelect').append($('<option></option>').val(i+1).html(resposta[i]));
            }
        })
        .fail(function(erro, mensagem, excecao) { 
            alert(mensagem + ': ' + excecao);
        });
}



