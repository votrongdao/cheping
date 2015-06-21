angular.module('cheping.services.caseCreate', [])
    .service('CaseCreateService', function($http, URLS, AuthService) {
        var service = this;

        var newCase = {};

        service.resetNewOrder = function(carType) {
            newCase = {};
            newCase.caseType = carType;
        };
    });
