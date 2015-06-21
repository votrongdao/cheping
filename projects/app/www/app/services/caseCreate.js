angular.module('cheping.services.caseCreate', [])
    .service('CaseCreateService', function($http, URLS, AuthService) {
        var service = this;

        var newCase = {};

        service.resetNewCase = function(carType) {
            newCase = {};
            newCase.caseType = carType;
            newCase.modifiedContent = '无';
        };

        service.getNewCase = function() {
            return newCase;
        };

        service.createCase = function() {
            return newCase;
        };
    });
