var app = angular.module('app',
    ['ngRoute',
     'angularModalService',
     'angularUtils.directives.dirPagination',
     'moment-picker',
     'ui-notification',
     'ngSanitize']);

app.config(function (NotificationProvider) {
    NotificationProvider.setOptions({
        delay: 3000,
        startTop: 55,
        startRight: 10,
        verticalSpacing: 20,
        horizontalSpacing: 20,
        positionX: 'center',
        positionY: 'top'
    });
});

app.config(function ($routeProvider) {
    $routeProvider
        .when('/', {
            redirectTo: '/reservarTurno',
        })

         .when('/reservarTurno', {
             templateUrl: 'Views/reservarTurno.html',
             controller: 'reservarTurnoController'
         })
        //.when('/facturasPorFirmar', {
        //    templateUrl: 'Views/facturasPorFirmar.html',
        //    controller: 'facturasPorFirmarController'
        //})
        //.when('/facturasIngresadas', {
        //    templateUrl: 'Views/facturasIngresadas.html',
        //    controller: 'facturasIngresadasController'
        //})

});


app.directive('fileModel', ['$parse', function ($parse) {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            var model = $parse(attrs.fileModel);
            var modelSetter = model.assign;

            element.bind('change', function () {
                scope.$apply(function () {
                    modelSetter(scope, element[0].files[0]);
                });
            });
        }
    };
}]);