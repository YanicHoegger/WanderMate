// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API

var initDotnetCallback;
var initialMapOptions;

window.blazorGoogleMap = {

    initMapCallback: function () {
        var currentThis = this === window
            ? this.blazorGoogleMap
            : this;

        currentThis.map = new google.maps.Map(document.getElementById('map'), initialMapOptions);
        initDotnetCallback.invokeMethodAsync('OnInitFinished');
        return true;
    },

    initMap: function (initialMapOptionsTemp) {
        initialMapOptions = initialMapOptionsTemp;
    },

    registerEventInvokers: function (initDotnetCallbackTemp) {
        initDotnetCallback = initDotnetCallbackTemp;
    }
};
