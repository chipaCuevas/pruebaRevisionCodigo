<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="reservaAutoservicio._default" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reserva cupo en autoservicio</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />


    <!-- Bootstrap -->
    <link rel="stylesheet" href="http://appcam.camara.cl/libs/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link rel="stylesheet" href="http://appcam.camara.cl/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="http://appcam.camara.cl/libs/angular-moment-picker/0.10.1/angular-moment-picker.min.css" />
    <link rel="stylesheet" href="http://appcam.camara.cl/libs/angular-ui-notification/0.3.6/angular-ui-notification.min.css" />
    <link rel="stylesheet" href="http://appcam.camara.cl/libs/bootstrap-select/1.12.4/css/bootstrap-select.min.css" />
    <link rel="stylesheet" href="http://appcam.camara.cl/libs/angularjs/1.6.1/angularUtils-pagination/dirPagination.js" />
    <link rel="stylesheet" href="http://textangular.com/dist/textAngular.css" type="text/css" />
    <link rel="stylesheet" href="css/styles.css" />

</head>

<body ng-app="app" ng-controller="defaultController">
    <div id="header">
        <div class="container">
            <div class="row">
                <div class="hidden-xs col-sm-1">
                    <img src="img/logo_blanco.png" alt="" />
                </div>
                <div class="col-xs-12 col-sm-8">
                    <h3>Módulo para reserva de cupo en autoservicio     {{fecha}}</h3>
                </div>

                <div class="hidden-xs col-sm-3">
                    <div class="btn-group pull-right">
                        <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <span class="glyphicon glyphicon-home"></span>&nbsp;
                        </button>
                        <ul class="dropdown-menu">
                            <li><a href="http://camdip.camara.cl" target="_self"><span class="glyphicon glyphicon-arrow-left"></span>&nbsp;Volver a camdip</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="main" class="container">
        <div class="row">
            <div class="col-sm-12 hidden-xs">

                <nav class="navbar navbar-default">
                    <div class="container-fluid">
                                                <div class="navbar-header">
                           
                        </div>

                        <ul class="nav navbar-nav navbar-left" >
                        <li class="active"><a data-toggle="tab" href="#!reservarTurno" data-target="#reservarTurno">Reserva de cupo</a></li>
                        <%--<li><a data-toggle="tab" href="#!facturasPorFirmar" data-target="#facturasPorFirmar">Facturas por visar <span class="label label-danger" ng-show="cantidadRegistros > 0">{{cantidadRegistros}}</span></a></li>--%>
                        <%--<li><a data-toggle="tab" href="#!facturasIngresadas" data-target="#facturasIngresadas">Facturas ingresadas</a></li>--%>
                        <%--    <li class="active"><a data-toggle="tab" href="#!listadoDocumentos" data-target="#listadoDocumentos">Firmar documento</a></li>--%>
                        </ul>
                    </div>
                </nav>
                        <div class="row"> </div>
                <div class="tab-content" ng-view style="margin-top:20px;">
                </div>
            </div>
        </div>
    </div>

    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="http://appcam.camara.cl/libs/jquery/3.1.1/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="http://appcam.camara.cl/libs/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <script src="http://appcam.camara.cl/libs/bootstrap-select/1.12.4/js/bootstrap-select.min.js"></script>

    <script src="http://appcam.camara.cl/libs/angularjs/1.6.1/angular.min.js"></script>
    <script src="http://appcam.camara.cl/libs/angularjs/1.6.1/angular-route.min.js"></script>
    <script src="http://appcam.camara.cl/libs/angularjs/1.6.1/i18n/angular-locale_es-cl.js"></script>
    <script src="http://appcam.camara.cl/libs/angularjs/1.6.1/angularUtils-pagination/dirPagination.js"></script>
    <script src="http://appcam.camara.cl/libs/angular-modal-service/angular-modal-service.js"></script>
    <script src="http://appcam.camara.cl/libs/moment/2.18.1/moment-with-locales.js"></script>
    <script src="http://appcam.camara.cl/libs/angular-ui-notification/0.3.6/angular-ui-notification.min.js"></script>
    <script src="http://appcam.camara.cl/libs/angular-moment-picker/0.10.1/angular-moment-picker.min.js"></script>


    <script src='http://textangular.com/dist/textAngular-rangy.min.js'></script>
    <script src='http://textangular.com/dist/textAngular-sanitize.min.js'></script>
    <script src='http://textangular.com/dist/textAngular.min.js'></script>



    <script src="js/app.js"></script>
    <script src="js/sweetalert2.all.min.js"></script>
    <script src="js/sweetalert2.js"></script>
    <script src="js/sweetalert2.min.js"></script>


<%--CONTROLADORES--%>
    <script src="js/Controllers/defaultController.js?v=<%=preventCache%>"></script>         
    <script src="js/Controllers/reservarTurnoController.js?v=<%=preventCache%>"></script>    
<%--SERVICIOS--%>
    <script src="js/Services/turnoService.js?v=<%=preventCache%>"></script>    

</body>
</html>


