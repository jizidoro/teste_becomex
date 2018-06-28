$(document).ready(function () {

    

    $('#ContrairBracoDireitoRepouso').on('click', function () {

        console.log("ContrairBracoDireitoRepouso");

        $.post(ContrairBracoDireitoRepousoUrl, { }, function (data) {
            if (data.success) {
                $('#situacaoAtualBracoDireitoContracao').html("0");
                console.log("oi");
            }
            else {
                console.log("errado");
            }
        });

    });

    $('#ContrairBracoDireito').on('click', function () {

        console.log("ContrairBracoDireito");

        $.post(ContrairBracoDireitoUrl, { }, function (data) {
            if (data.success) {
                $('#situacaoAtualBracoDireitoContracao').html("1");
                console.log("oi");
            }
            else {
                console.log("errado");
            }
        });

    });

    $('#DescontrairBracoDireito').on('click', function () {

        console.log("DescontrairBracoDireito");

        $.post(DescontrairBracoDireitoUrl, { }, function (data) {
            if (data.success) {
                $('#situacaoAtualBracoDireitoContracao').html("2");
                console.log("oi");
            }
            else {
                console.log("errado");
            }
        });

    });

    $('#RotacaoBracoDireitoRepouso').on('click', function () {

        console.log("RotacaoBracoDireitoRepouso");

        $.post(RotacaoBracoDireitoRepousoUrl, { }, function (data) {
            if (data.success) {
                $('#situacaoAtualBracoDireitoRotacao').html("0");
                console.log("oi");
            }
            else {
                console.log("errado");
            }
        });

    });

    $('#RotacaoBracoDireito').on('click', function () {

        console.log("RotacaoBracoDireito");

        $.post(RotacaoBracoDireitoUrl, { }, function (data) {
            if (data.success) {
                $('#situacaoAtualBracoDireitoRotacao').html("1");
                console.log("oi");
            }
            else {
                console.log("errado");
            }
        });

    });

    $('#RotacaoBracoDireitoAtni').on('click', function () {

        console.log("RotacaoBracoDireitoAtni");

        $.post(RotacaoBracoDireitoAtniUrl, { }, function (data) {
            if (data.success) {
                $('#situacaoAtualBracoDireitoRotacao').html("2");
                console.log("oi");
            }
            else {
                console.log("errado");
            }
        });

    });

    $('#ContrairBracoEsquerdoRepouso').on('click', function () {

        console.log("ContrairBracoEsquerdoRepouso");

        $.post(ContrairBracoEsquerdoRepousoUrl, { }, function (data) {
            if (data.success) {
                $('#situacaoAtualBracoEsquerdoContracao').html("0");
                console.log("oi");
            }
            else {
                console.log("errado");
            }
        });

    });

    $('#ContrairBracoEsquerdo').on('click', function () {

        console.log("ContrairBracoEsquerdo");

        
        
        $.post(ContrairBracoEsquerdoUrl, { }, function (data) {
            if (data.success) {
                $('#situacaoAtualBracoEsquerdoContracao').html("1");
                console.log("oi");
            }
            else {
                console.log("errado");
            }
        });

    });

    $('#DescontrairBracoEsquerdo').on('click', function () {

        console.log("DescontrairBracoEsquerdo");

        $.post(DescontrairBracoEsquerdoUrl, { }, function (data) {
            if (data.success) {
                $('#situacaoAtualBracoEsquerdoContracao').html("2");
                console.log("oi");
            }
            else {
                console.log("errado");
            }
        });

    });

    $('#RotacaoBracoEsquerdoRepouso').on('click', function () {

        console.log("RotacaoBracoEsquerdoRepouso");

        $.post(RotacaoBracoEsquerdoRepousoUrl, { }, function (data) {
            if (data.success) {
                $('#situacaoAtualBracoEsquerdoRotacao').html("0");
                console.log("oi");
            }
            else {
                console.log("errado");
            }
        });

    });

    $('#RotacaoBracoEsquerdo').on('click', function () {

        console.log("RotacaoBracoEsquerdo");

        $.post(RotacaoBracoEsquerdoUrl, { }, function (data) {
            if (data.success) {
                $('#situacaoAtualBracoEsquerdoRotacao').html("1");
                console.log("oi");
            }
            else {
                console.log("errado");
            }
        });

    });

    $('#RotacaoBracoEsquerdoAtni').on('click', function () {

        console.log("RotacaoBracoEsquerdoAtni");

        $.post(RotacaoBracoEsquerdoAtniUrl, { }, function (data) {
            if (data.success) {
                $('#situacaoAtualBracoEsquerdoRotacao').html("2");
                console.log("oi");
            }
            else {
                console.log("errado");
            }
        });

    });

    $('#RotacaoCabecaRepouso').on('click', function () {

        console.log("RotacaoCabecaRepouso");

        $.post(RotacaoCabecaRepousoUrl, { }, function (data) {
            if (data.success) {
                $('#situacaoAtualCabecaRotacao').html("0");
                console.log("oi");
            }
            else {
                console.log("errado");
            }
        });

    });

    $('#RotacaoCabeca').on('click', function () {

        console.log("RotacaoCabeca");

        $.post(RotacaoCabecaUrl, { }, function (data) {
            if (data.success) {
                $('#situacaoAtualCabecaRotacao').html("1");
                console.log("oi");
            }
            else {
                console.log("errado");
            }
        });

    });

    $('#RotacaoCabecaAtni').on('click', function () {

        console.log("RotacaoCabecaAtni");

        $.post(RotacaoCabecaAtniUrl, { }, function (data) {
            if (data.success) {
                $('#situacaoAtualCabecaRotacao').html("2");
                console.log("oi");
            }
            else {
                console.log("errado");
            }
        });

    });

    $('#InclinacaoCabecaRepouso').on('click', function () {

        console.log("InclinacaoCabecaRepouso");

        $.post(InclinacaoCabecaRepousoUrl, { }, function (data) {
            if (data.success) {
                $('#situacaoAtualCabecaInclinacao').html("0");
                console.log("oi");
            }
            else {
                console.log("errado");
            }
        });

    });

    $('#InclinacaoCabecaCima').on('click', function () {

        console.log("vai");

        $.post(InclinacaoCabecaCimaUrl, { }, function (data) {
            if (data.success) {
                $('#situacaoAtualCabecaInclinacao').html("1");
                console.log("oi");
            }
            else {
                console.log("errado");
            }
        });

    });

    $('#InclinacaoCabecaBaixo').on('click', function () {

        console.log("vai");

        $.post(InclinacaoCabecaBaixoUrl, { }, function (data) {
            if (data.success) {
                $('#situacaoAtualCabecaInclinacao').html("2");
                console.log("oi");
            }
            else {
                console.log("errado");
            }
        });

    });


});