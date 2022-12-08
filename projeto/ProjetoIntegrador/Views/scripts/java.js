$(document).ready(function() {
    listarGrid();
});

function enviar(){
    
    let aval = null;
    for(var i = 5; i > 0; i--){
        if ($("#star_" +i).is(":checked")){
            aval = {
                avaliacao1: i,
                comentario: document.getElementById("comentario1").value,
                idDisciplina: document.getElementById("disciplina").value
            }
        }
    }        

    if(!!aval) {
        alert("Obrigado por avaliar a aula");

        console.log(aval);
        $.ajax({
            type: 'POST',
            url: 'https://20.226.108.178:5001/Avaliacao/Enviar',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(aval),
            success: function() {
                alert("Avaliação enviada com sucesso!");
                limpar();
                location.reload(true);
            },
            error: function() {
                alert("Erro ao enviar a avaliação!");
            }
        });
    }
    else {
        alert("Por favor avalie a aula de 1 a 5")
    }
}