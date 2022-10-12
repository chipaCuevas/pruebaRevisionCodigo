app.controller("reservarTurnoController", ['$scope', '$rootScope', '$http', 'ModalService', 'Notification', 'turnoService', function ($scope, $rootScope, $http, ModalService, Notification, turnoService) {
    
    obtenerTurnos();
    $scope.fecha = moment(new Date()).locale('es').format('dddd D [de] MMMM [de] YYYY');

    $scope.validarUsuario = function (rut) {
        $scope.editar = false
        $("#btnValidar").button('loading');
        turnoService.validarUsuario(rut)
        .then(function (result) {
            console.log(result);
            switch (result.errorcode) {
                case "1":
                    $scope.obtenerDatosUsuarios(rut);
                    $("#btnValidar").button('reset');
                    break;
                case "2":
                    swal({
                        title: "AVISO",
                        text: result.message,
                        type: "error",
                        showConfirmButton: true
                    });
                    $scope.limpiar();
                    $("#btnValidar").button('reset');
                    break;
                case "3":
                    swal({
                        title: "AVISO",
                        text: result.message,
                        type: "error",
                        showConfirmButton: true
                    });
                    $scope.limpiar();
                    $("#btnValidar").button('reset');
                    break;
                case "4":
                    swal({
                        title: "AVISO",
                        text: result.message,
                        type: "error",
                        showConfirmButton: true
                    });
                    $scope.limpiar();
                    $("#btnValidar").button('reset');
                    break;
                case "5":
                    swal({
                        title: "Editar ?",
                        text: result.message,
                        type: 'question',
                        showCancelButton: true,
                        confirmButtonColor: '#3085d6',
                        cancelButtonColor: '#d33',
                        confirmButtonText: 'Si, editar',
                        cancelButtonText: "No, salir",
                        allowOutsideClick: false
                    }).then(function (result) {
                        if (result == true) {  //SI
                            //Grabo
                            $("#btnValidar").button('reset');
                            $scope.obtenerDatosUsuarios(rut);
                            $scope.editar = true;
                            
                        }
                    }, function (reason) {  //NO
                        $("#btnValidar").button('reset');
                        //NO grabo
                    });
                    
                    break;
                case "6":
                    swal({
                        title: "AVISO",
                        text: result.message,
                        type: "error",
                        showConfirmButton: true
                    });
                    $scope.limpiar();
                    $("#btnValidar").button('reset');
                    break;
                case "7":
                    swal({
                        title: "AVISO",
                        text: result.message,
                        type: "error",
                        showConfirmButton: true
                    });
                    $scope.limpiar();
                    $("#btnValidar").button('reset');
                    break;
                case "8":
                    swal({
                        title: "AVISO",
                        text: result.message,
                        type: "error",
                        showConfirmButton: true
                    });
                    $scope.limpiar();
                    $("#btnValidar").button('reset');
                    break;

                default:
                
                    swal({
                        title: "AVISO",
                        text: "Ha ocurrido un error al validar al usuario",
                        type: "error",
                        showConfirmButton: true
                    });
                    $("#btnValidar").button('reset');
            }

        }, function (reason) {
            msg = { title: 'Rut no encontado, por favor revise que esté correcto.' };
            Notification.error(msg);
            $("#btnValidar").button('reset');
        });
    };


    $scope.obtenerDatosUsuarios = function (rut) {
        turnoService.getDatosUsuario(rut)
        .then(function (result) {
            $scope.vDatosUsuario = result.data;
            if ($scope.vDatosUsuario.cantidadEmpleador == 2 && !$scope.editar) {
                $scope.empleadorConCupo = [];
                for (let empleador of $scope.vDatosUsuario.Diputados) {
                    if (empleador.CupoDisponible > 0) {
                        $scope.empleadorConCupo.push(empleador);
                    }                   
                }
                if ($scope.empleadorConCupo.length == 0) {
                    swal({
                        title: "AVISO",
                        text: "Ninguno de los diputados con los que ud. trabaja tiene cupo disponible.",
                        type: "error",
                        showConfirmButton: true
                    });
                    $scope.limpiar();
                    $("#btnValidar").button('reset');
                } else if ($scope.empleadorConCupo.length == 1) {
                    swal({
                        title: "INFORMACIÓN",
                        text: "Solo el diputado(a) " + $scope.empleadorConCupo[0].Nombre + " tiene cupo disponible.",
                        type: "warning",
                        showConfirmButton: true
                    });
                    $("#btnValidar").button('reset');
                    $scope.diputadoSeleccionado = $scope.empleadorConCupo[0];
                    $scope.vDatosUsuario.nombreDiputado = $scope.empleadorConCupo[0].Nombre;
                    $scope.vDatosUsuario.parid = $scope.empleadorConCupo[0].idDip;
                } else {
                    $scope.diputadoSeleccionado = $scope.empleadorConCupo.find(empleador => empleador.idDip === $scope.vDatosUsuario.parid)
                }
                
            }
            
            //$scope.Empleadores = $scope.vDatosUsuario.diputados
            console.log($scope.vDatosUsuario);
            obtenerTurnosXRut(rut);
        }, function (reason) {
            msg = { title: 'Rut no encontado, por favor revise que esté correcto.' };
            Notification.error(msg);

        });
    };

    function obtenerTurnos() {
        turnoService.getTurnos()
        .then(function (result) {
            $scope.tiposTurno = result.data;
            console.log($scope.tiposTurno);
        }, function (reason) {
            msg = { title: 'Ocurrió un error al obtener los turnos disponibles.' };
            Notification.error(msg);
        });
    }

    function obtenerTurnosXRut(rut) {
        turnoService.getTurnosXRut(rut)
        .then(function (result) {
            $scope.tiposTurno = result.data;
        }, function (reason) {
            msg = { title: 'Ocurrió un error al obtener los turnos disponibles.' };
            Notification.error(msg);
        });
    }

    $scope.guardarReserva = function (reserva, turno) {
        if ($scope.vDatosUsuario.cantidadEmpleador = 2) {
            console.log("reserva: ", $scope.reserva);
            console.log("turno: ", turno);
            console.log("datos usuario", $scope.vDatosUsuario);
        }
        $scope.grabando = true
        $scope.saving = true;
        $scope.reserva.turno = turno;
        $scope.reserva.idDip = $scope.vDatosUsuario.parid;
        turnoService.grabarReserva($scope.reserva)
            .then(function (result) {

                swal({
                    title: "Registro exitoso",
                    text: result.message,
                    type: "success",
                    showConfirmButton: true
                });
                $scope.limpiar();
            }, function (reason) {
                swal({
                    title: "Aviso",
                    text: result.message,
                    type: "error",
                    showConfirmButton: true
                });
                $scope.grabando = false;
            });
    }

    $scope.anularReserva = function (rut) {
        $scope.grabando = true
        $scope.saving = true;
        turnoService.anularReserva(rut)
            .then(function (result) {

                swal({
                    title: "Aviso",
                    text: result.message,
                    type: "success",
                    showConfirmButton: true
                });
                $scope.limpiar();
            }, function (reason) {
                swal({
                    title: "Aviso",
                    text: result.message,
                    type: "error",
                    showConfirmButton: true
                });
                $scope.grabando = false;
            });
    }

    $scope.limpiar = function () {
        $scope.reserva = null;
        $scope.vDatosUsuario = null;
        $("#btnValidar").button('reset');
    }

    $scope.mostrarCapacidad = function (turno) {
        turnoService.getCapacidad(turno.id)
        .then(function (result) {
            $scope.tiposTurno = result.data;
        }, function (reason) {
            msg = { title: 'Ocurrió un error al obtener capacidad disponible.' };
            Notification.error(msg);
        });
        $scope.capacidad = turno.capacidad;
        
        $scope.disponibilidad = turno.disponibilidad;

    };

    $scope.changeEmpleador = function (empleador) {
        $scope.vDatosUsuario.nombreDiputado = empleador.Nombre;
        $scope.vDatosUsuario.parid = empleador.idDip;
    }

}]);