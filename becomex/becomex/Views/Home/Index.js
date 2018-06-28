$(document).ready(function () {


    $.post(GetAtualWebApiUrl, {}, function (data) {
        if (data.success) {
            if (data.robo.bracoDireito.Cotovelo === 0) {
                $('#situacaoAtualBracoDireitoContracao').html("Em Repouso");
            }
            else if (data.robo.bracoDireito.Cotovelo === 1) {
                $('#situacaoAtualBracoDireitoContracao').html("Levemente Contraído");
            }
            else if (data.robo.bracoDireito.Cotovelo === 2) {
                $('#situacaoAtualBracoDireitoContracao').html("Contraído");
            }
            else if (data.robo.bracoDireito.Cotovelo === 3) {
                $('#situacaoAtualBracoDireitoContracao').html("Fortemente Contraído");
            }

            $('#situacaoAtualBracoDireitoRotacao').html(data.robo.bracoDireito.Pulso);

            if (data.robo.bracoEsquerdo.Cotovelo === 0) {
                $('#situacaoAtualBracoEsquerdoContracao').html("Em Repouso");
            }
            else if (data.robo.bracoEsquerdo.Cotovelo === 1) {
                $('#situacaoAtualBracoEsquerdoContracao').html("Levemente Contraído");
            }
            else if (data.robo.bracoEsquerdo.Cotovelo === 2) {
                $('#situacaoAtualBracoEsquerdoContracao').html("Contraído");
            }
            else if (data.robo.bracoEsquerdo.Cotovelo === 3) {
                $('#situacaoAtualBracoEsquerdoContracao').html("Fortemente Contraído");
            }

            $('#situacaoAtualBracoEsquerdoRotacao').html(data.robo.bracoEsquerdo.Pulso);
            $('#situacaoAtualCabecaRotacao').html(data.robo.cabeca.Rotacao);
            if (data.robo.cabeca.Inclinacao === 0) {
                $('#situacaoAtualCabecaInclinacao').html("Em Repouso");
            }
            else if (data.robo.cabeca.Inclinacao === -1) {
                $('#situacaoAtualCabecaInclinacao').html("Para Baixo");
            }
            else if (data.robo.cabeca.Inclinacao === 1) {
                $('#situacaoAtualCabecaInclinacao').html("Para Cima");
            }
            $('#ConexaoWebApi').html("Sim");
            
        }
        else {
            $('#ConexaoWebApi').html("Nao");
            
        }
    });

    $('#Reseta').on('click', function () {

        $.post(ResetaRoboWebApiUrl, {}, function (data) {
            if (data.success) {
                if (data.robo.bracoDireito.Cotovelo === 0) {
                    $('#situacaoAtualBracoDireitoContracao').html("Em Repouso");
                }
                else if (data.robo.bracoDireito.Cotovelo === 1) {
                    $('#situacaoAtualBracoDireitoContracao').html("Levemente Contraído");
                }
                else if (data.robo.bracoDireito.Cotovelo === 2) {
                    $('#situacaoAtualBracoDireitoContracao').html("Contraído");
                }
                else if (data.robo.bracoDireito.Cotovelo === 3) {
                    $('#situacaoAtualBracoDireitoContracao').html("Fortemente Contraído");
                }

                $('#situacaoAtualBracoDireitoRotacao').html(data.robo.bracoDireito.Pulso);

                if (data.robo.bracoEsquerdo.Cotovelo === 0) {
                    $('#situacaoAtualBracoEsquerdoContracao').html("Em Repouso");
                }
                else if (data.robo.bracoEsquerdo.Cotovelo === 1) {
                    $('#situacaoAtualBracoEsquerdoContracao').html("Levemente Contraído");
                }
                else if (data.robo.bracoEsquerdo.Cotovelo === 2) {
                    $('#situacaoAtualBracoEsquerdoContracao').html("Contraído");
                }
                else if (data.robo.bracoEsquerdo.Cotovelo === 3) {
                    $('#situacaoAtualBracoEsquerdoContracao').html("Fortemente Contraído");
                }

                $('#situacaoAtualBracoEsquerdoRotacao').html(data.robo.bracoEsquerdo.Pulso);
                $('#situacaoAtualCabecaRotacao').html(data.robo.cabeca.Rotacao);
                if (data.robo.cabeca.Inclinacao === 0) {
                    $('#situacaoAtualCabecaInclinacao').html("Em Repouso");
                }
                else if (data.robo.cabeca.Inclinacao === -1) {
                    $('#situacaoAtualCabecaInclinacao').html("Para Baixo");
                }
                else if (data.robo.cabeca.Inclinacao === 1) {
                    $('#situacaoAtualCabecaInclinacao').html("Para Cima");
                }
                $('#ConexaoWebApi').html("Sim");
                
            }
            else {
                $('#ConexaoWebApi').html("Nao");
                
            }
        });

    });


    $('#ContrairBracoDireito').on('click', function () {

        $.post(ContrairBracoDireitoUrl, { }, function (data) {
            if (data.success) {
                if (data.robo.bracoDireito.Cotovelo === 0) {
                    $('#situacaoAtualBracoDireitoContracao').html("Em Repouso");
                }
                else if (data.robo.bracoDireito.Cotovelo === 1) {
                    $('#situacaoAtualBracoDireitoContracao').html("Levemente Contraído");
                }
                else if (data.robo.bracoDireito.Cotovelo === 2) {
                    $('#situacaoAtualBracoDireitoContracao').html("Contraído");
                }
                else if (data.robo.bracoDireito.Cotovelo === 3) {
                    $('#situacaoAtualBracoDireitoContracao').html("Fortemente Contraído");
                }
                
                
            }
            else {
                
            }
        });

    });

    $('#DescontrairBracoDireito').on('click', function () {

        $.post(DescontrairBracoDireitoUrl, { }, function (data) {
            if (data.success) {
                if (data.robo.bracoDireito.Cotovelo === 0) {
                    $('#situacaoAtualBracoDireitoContracao').html("Em Repouso");
                }
                else if (data.robo.bracoDireito.Cotovelo === 1) {
                    $('#situacaoAtualBracoDireitoContracao').html("Levemente Contraído");
                }
                else if (data.robo.bracoDireito.Cotovelo === 2) {
                    $('#situacaoAtualBracoDireitoContracao').html("Contraído");
                }
                else if (data.robo.bracoDireito.Cotovelo === 3) {
                    $('#situacaoAtualBracoDireitoContracao').html("Fortemente Contraído");
                }
                
            }
            else {
                
            }
        });

    });


    $('#RotacaoBracoDireito').on('click', function () {

        $.post(RotacaoBracoDireitoUrl, { }, function (data) {
            if (data.success) {
                $('#situacaoAtualBracoDireitoRotacao').html(data.robo.bracoDireito.Pulso);
                
            }
            else {
                
            }
        });

    });

    $('#RotacaoBracoDireitoAtni').on('click', function () {


        $.post(RotacaoBracoDireitoAtniUrl, { }, function (data) {
            if (data.success) {
                $('#situacaoAtualBracoDireitoRotacao').html(data.robo.bracoDireito.Pulso);
                
            }
            else {
                
            }
        });

    });

    $('#ContrairBracoEsquerdo').on('click', function () {

        
        $.post(ContrairBracoEsquerdoUrl, { }, function (data) {
            if (data.success) {
                if (data.robo.bracoEsquerdo.Cotovelo === 0) {
                    $('#situacaoAtualBracoEsquerdoContracao').html("Em Repouso");
                }
                else if (data.robo.bracoEsquerdo.Cotovelo === 1) {
                    $('#situacaoAtualBracoEsquerdoContracao').html("Levemente Contraído");
                }
                else if (data.robo.bracoEsquerdo.Cotovelo === 2) {
                    $('#situacaoAtualBracoEsquerdoContracao').html("Contraído");
                }
                else if (data.robo.bracoEsquerdo.Cotovelo === 3) {
                    $('#situacaoAtualBracoEsquerdoContracao').html("Fortemente Contraído");
                }


                
            }
            else {
                
            }
        });

    });

    $('#DescontrairBracoEsquerdo').on('click', function () {

        $.post(DescontrairBracoEsquerdoUrl, { }, function (data) {
            if (data.success) {
                
                if (data.robo.bracoEsquerdo.Cotovelo === 0) {
                    $('#situacaoAtualBracoEsquerdoContracao').html("Em Repouso");
                }
                else if (data.robo.bracoEsquerdo.Cotovelo === 1) {
                    $('#situacaoAtualBracoEsquerdoContracao').html("Levemente Contraído");
                }
                else if (data.robo.bracoEsquerdo.Cotovelo === 2) {
                    $('#situacaoAtualBracoEsquerdoContracao').html("Contraído");
                }
                else if (data.robo.bracoEsquerdo.Cotovelo === 3) {
                    $('#situacaoAtualBracoEsquerdoContracao').html("Fortemente Contraído");
                }
            }
            else {
                
            }
        });

    });


    $('#RotacaoBracoEsquerdo').on('click', function () {

        $.post(RotacaoBracoEsquerdoUrl, { }, function (data) {
            if (data.success) {
                $('#situacaoAtualBracoEsquerdoRotacao').html(data.robo.bracoEsquerdo.Pulso);
                
            }
            else {
                
            }
        });

    });

    $('#RotacaoBracoEsquerdoAtni').on('click', function () {

        $.post(RotacaoBracoEsquerdoAtniUrl, { }, function (data) {
            if (data.success) {
                $('#situacaoAtualBracoEsquerdoRotacao').html(data.robo.bracoEsquerdo.Pulso);
                
            }
            else {
                
            }
        });

    });


    $('#RotacaoCabeca').on('click', function () {

        $.post(RotacaoCabecaUrl, { }, function (data) {
            if (data.success) {
                $('#situacaoAtualCabecaRotacao').html(data.robo.cabeca.Rotacao);
                
            }
            else {
                
            }
        });

    });

    $('#RotacaoCabecaAtni').on('click', function () {

        $.post(RotacaoCabecaAtniUrl, { }, function (data) {
            if (data.success) {
                $('#situacaoAtualCabecaRotacao').html(data.robo.cabeca.Rotacao);
                
            }
            else {
                
            }
        });

    });


    $('#InclinacaoCabecaCima').on('click', function () {

        $.post(InclinacaoCabecaCimaUrl, { }, function (data) {
            if (data.success) {
                if (data.robo.cabeca.Inclinacao === 0) {
                    $('#situacaoAtualCabecaInclinacao').html("Em Repouso");
                }
                else if (data.robo.cabeca.Inclinacao === -1) {
                    $('#situacaoAtualCabecaInclinacao').html("Para Baixo");
                }
                else if (data.robo.cabeca.Inclinacao === 1) {
                    $('#situacaoAtualCabecaInclinacao').html("Para Cima");
                }
            }
            else {
                
            }
        });

    });

    $('#InclinacaoCabecaBaixo').on('click', function () {

        $.post(InclinacaoCabecaBaixoUrl, { }, function (data) {
            if (data.success) {
                if (data.robo.cabeca.Inclinacao === 0) {
                    $('#situacaoAtualCabecaInclinacao').html("Em Repouso");
                }
                else if (data.robo.cabeca.Inclinacao === -1) {
                    $('#situacaoAtualCabecaInclinacao').html("Para Baixo");
                }
                else if (data.robo.cabeca.Inclinacao === 1) {
                    $('#situacaoAtualCabecaInclinacao').html("Para Cima");
                }
                
            }
            else {
                
            }
        });

    });


});