$(function () { 

    $(document).on('click', '#mev-hesap', function (event) {



        var anaPara = $('#ana-para').val();
        var faizOrani = $('#faiz-orani').val();
        var vadeGun = $("#vade-gun option:selected").val();
        var stopaj = $('#stopaj-orani').val();

        var StartExchange = $("#StartBuyingExchangeRate").val();
        var FinishExchange = $('#FinishBuyingExchangeRate').val();

        var mev = anaPara * faizOrani * vadeGun / 36500;
        
        if (StartExchange === "") {
            console.log(StartExchange);
            $(".start-kur-error").css("display", "block")
        }
        if (FinishExchange === "") {
            console.log(FinishExchange);
            $(".finish-kur-error").css("display", "block")
        }
        
        
   
        $('.mev-sonuc').text(mev);
        $('.mev-net-sonuc').text(mev - (mev * stopaj / 100));


        var kurSonuc = ((anaPara / StartExchange) * FinishExchange) - anaPara;
        console.log(kurSonuc);
        $('.kur-net-sonuc').text(kurSonuc);
    });


    $(document).on('change', '#vade-gun', function (event) {
        var vadeGun = $("#vade-gun option:selected").val();

        console.log(vadeGun);

        var vadeGun = $("#vade-gun option:selected").val();

        console.log(vadeGun);

        if (vadeGun <= 180) {
            $('#stopaj-orani').val(5);
        } else if (vadeGun < 365) {
            $('#stopaj-orani').val(3);
        } else {
            $('#stopaj-orani').val(1);
        }
    });
});