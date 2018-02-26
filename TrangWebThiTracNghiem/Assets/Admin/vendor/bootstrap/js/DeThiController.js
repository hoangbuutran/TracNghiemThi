var capthi = {
    init: function () {
        capthi.loadCapthi();
    },
    loadCapthi: function () {
        var html = "";
        $ajax({
            url: "CapThi/LoadCapThi",
            type: "POST",
            dateType: "json",
            success: function (response) {
                if (response.status == true) {
                    alert("11111");
                }
            }
        })
    }
}


capthi: init();