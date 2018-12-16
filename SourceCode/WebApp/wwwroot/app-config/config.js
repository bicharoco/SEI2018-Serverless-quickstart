(function () {
    'use strict';

    angular.module('sei2018app')
        .config(function ($routeProvider) {
            $routeProvider
                .when('/', {
                    templateUrl: 'views/index.html',
                    controller: 'MainController'
                })
        });
})();