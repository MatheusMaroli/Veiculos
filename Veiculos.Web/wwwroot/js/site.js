
 const selectMarca = document.getElementById('select_marca');
 const selectModelo = document.getElementById('select_modelo');
 const selectTipoCombustivel = document.getElementById('select_tipo_combustivel');





(function carregarSelectMarca (){
   
    selectMarca &&
    $.get("/Marca/Buscar", (dados) =>{
        selectMarca.innerHTML = `<option value="">Selecione uma marca</option>`;
        for(let marca in dados)        
            if (dados[marca].id == selectMarca.attributes['value'].value)
                 selectMarca.innerHTML = `${selectMarca.innerHTML}<option selected value="${dados[marca].id}">${dados[marca].nome}</option>`;
       
            else
                selectMarca.innerHTML = `${selectMarca.innerHTML}<option value="${dados[marca].id}">${dados[marca].nome}</option>`;                  
    });
})();


(function carregarSelectModelo (){
    selectModelo &&
    $.get(`/Modelo/Buscar`, (dados) =>{
        selectModelo.innerHTML = `<option value="">Selecione um modelo</option>`;
        for(let modelo in dados)        
            if (dados[modelo].id == selectModelo.attributes['value'].value)
            selectModelo.innerHTML = `${selectModelo.innerHTML}<option selected value="${dados[modelo].id}">${dados[modelo].nome}</option>`;
       
            else
            selectModelo.innerHTML = `${selectModelo.innerHTML}<option value="${dados[modelo].id}">${dados[modelo].nome}</option>`;                  
    });
})();


(function carregarSelectTipoCombustivel(){

    selectTipoCombustivel &&
    $.get(`/Anuncio/BuscarTipoCombustivel`, (dados) =>{
        for(let modelo in dados)        
            if (dados[modelo].id == selectTipoCombustivel.attributes['value'].value)
            selectTipoCombustivel.innerHTML = `${selectTipoCombustivel.innerHTML}<option selected value="${dados[modelo].id}">${dados[modelo].nome}</option>`;       
        else
            selectTipoCombustivel.innerHTML = `${selectTipoCombustivel.innerHTML}<option value="${dados[modelo].id}">${dados[modelo].nome}</option>`;                  
    });
})();

(function carregarSelectModeloPorMarcaSelecionada(){    
    selectModelo && selectMarca &&
    selectMarca.addEventListener('blur', (e)=>{
        $.get(`/Modelo/BuscarPorMarca?idMarca=${selectMarca.options[selectMarca.options.selectedIndex].value}`, (dados) =>{
            selectModelo.innerHTML = `<option value="">Selecione um modelo</option>`;
            for(let modelo in dados)        
                if (dados[modelo].id == selectModelo.attributes['value'].value)
                selectModelo.innerHTML = `${selectModelo.innerHTML}<option selected value="${dados[modelo].id}">${dados[modelo].nome}</option>`;
           
                else
                selectModelo.innerHTML = `${selectModelo.innerHTML}<option value="${dados[modelo].id}">${dados[modelo].nome}</option>`;                  
        });
    });
})();

(function carregarFormCadastro(){
    const formCadastro = document.getElementById('form-cadastro');
    const RespostaStatus = {
        success : 'Success',
        error : 'Error', 
        warning : 'Warning'
    };

    const modalRespostaCadastro = (r) => {  
        const rotaRetorno = document.getElementById('rota-retorno');
        rotaRetorno.attributes['href'].value = r.rotaRetorno;
        $('#modal-cadastro-sucesso').modal();
    };

    const erroModal = () => {
        $('#modal-cadastro-erro').modal();
    }

    const errorCallBack =(r) => {
        const respostaServidor = r.responseJSON;;
       
        const inputs = formCadastro.getElementsByTagName('input') & formCadastro.getElementsByTagName('select') ;
        for (let input in inputs)
        {
            const lbl = document.getElementById(`erro${inputs[input].name}`);
            if (lbl)
            {
                lbl.innerHTML = '';
                lbl.classList.add('hidden');
            }
        }

        if (respostaServidor.status === RespostaStatus.warning)
        {
            for(let error in respostaServidor.errors)
            {

                const lbl = document.getElementById(`erro${respostaServidor.errors[error].propertyName}`);
                if (lbl)
                {
                    lbl.innerHTML = respostaServidor.errors[error].message;
                    lbl.classList.remove('hidden');
                }

            }  
        }
        else {
            erroModal();
        }
        
    }


    formCadastro && formCadastro.addEventListener('submit', function(e) {
        e.preventDefault();
        debugger
        ;
        var rota = $(this).attr('action');
        var dados = $(this).serialize();
        $.ajax({
            type: "POST",
            url: rota,
            data: dados,
            success: modalRespostaCadastro,
            error: errorCallBack
        });
    });
})();
