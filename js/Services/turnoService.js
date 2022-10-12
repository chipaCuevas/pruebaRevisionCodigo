app.factory('turnoService', ['$http', '$q', function ($http, $q) {
    var turnoServ = [];


    turnoServ.validarUsuario = function (rut) {
        var deferred = $q.defer();

        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/validarUsuario?prmRut=' + rut
        }).then(onSuccess, onFailure);
        function onSuccess(response) {
            if (response.data.result) {
                deferred.resolve(response.data);
            } else {
                deferred.reject(response.data)
            }
        }
        function onFailure(response) {
            deferred.reject(response);
        };
        return deferred.promise;

    };

    turnoServ.getDatosUsuario = function (rut) {
        var deferred = $q.defer();

        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getDatosUsuario?prmRut=' + rut
        }).then(onSuccess, onFailure);
        function onSuccess(response) {
            if (response.data.result) {
                deferred.resolve(response.data);
            } else {
                deferred.reject(response.data)
            }
        }
        function onFailure(response) {
            deferred.reject(response);
        };
        return deferred.promise;

    };

    turnoServ.getTurnos = function () {
        var deferred = $q.defer();

        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getTurnos'
        }).then(onSuccess, onFailure);
        function onSuccess(response) {
            if (response.data.result) {
                deferred.resolve(response.data);
            } else {
                deferred.reject(response.data)
            }
        }
        function onFailure(response) {
            deferred.reject(response);
        };
        return deferred.promise;

    };

    turnoServ.getTurnosXRut = function (rut) {
        var deferred = $q.defer();

        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getTurnosXRut?prmRut=' + rut
        }).then(onSuccess, onFailure);
        function onSuccess(response) {
            if (response.data.result) {
                deferred.resolve(response.data);
            } else {
                deferred.reject(response.data)
            }
        }
        function onFailure(response) {
            deferred.reject(response);
        };
        return deferred.promise;

    };

    turnoServ.getCapacidad = function (prmIdTurno) {
        var deferred = $q.defer();

        $http({
            method: "GET",
            async: true,
            url: 'doGet.asmx/getCapacidad'
        }).then(onSuccess, onFailure);
        function onSuccess(response) {
            if (response.data.result) {
                deferred.resolve(response.data);
            } else {
                deferred.reject(response.data)
            }
        }
        function onFailure(response) {
            deferred.reject(response);
        };
        return deferred.promise;

    };

    turnoServ.grabarReserva = function (reserva) {
        var deferred = $q.defer();
        var myFormData = new FormData();
        myFormData.append("reserva", angular.toJson(reserva));
        console.log(reserva);

        $http({
            method: 'POST',
            url: 'doPost.asmx/grabarTurno',
            data: myFormData,
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        }).then(onSuccess, onFailure);
        function onSuccess(response) {
            if (response.data.result)
            { deferred.resolve(response.data); }
            else
            { deferred.reject(response.data) }
        }
        function onFailure(response) {
            deferred.reject(response);;
        };

        return deferred.promise;
    }

    turnoServ.anularReserva = function (rut) {
        var deferred = $q.defer();
        var myFormData = new FormData();
        myFormData.append("rut", rut);
        console.log(rut);

        $http({
            method: 'POST',
            url: 'doPost.asmx/anularReserva',
            data: myFormData,
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        }).then(onSuccess, onFailure);
        function onSuccess(response) {
            if (response.data.result)
            { deferred.resolve(response.data); }
            else
            { deferred.reject(response.data) }
        }
        function onFailure(response) {
            deferred.reject(response);;
        };

        return deferred.promise;
    }

    return turnoServ;
}]);