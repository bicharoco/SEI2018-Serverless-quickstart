(function () {
    'use strict';

    angular.module('sei2018app')
        .config(['$routeProvider','$httpProvider', 'adalAuthenticationServiceProvider',
        function ($routeProvider, $httpProvider, adalProvider) {
            $routeProvider
                .when('/', {
                    templateUrl: 'views/index.html',
                    controller: 'MainController',
                    // requireADLogin: window.location.hostname != 'localhost' 
                });

            adalProvider.init(
                {
                    instance: 'https://login.microsoftonline.com/',
                    tenant: '5749cc65-ab22-4be8-8559-c120ed2bc694',
                    clientId: '695c6a41-89bd-4b28-8848-d14dec57b246',
                    extraQueryParameter: 'nux=1',
                    redirectUri: 'https://sei-2018-main-function.azurewebsites.net/api/note'
                    //cacheLocation: 'localStorage', // enable this for IE, as sessionStorage does not work for localhost.
                },
                $httpProvider
            );
        }]);
})();