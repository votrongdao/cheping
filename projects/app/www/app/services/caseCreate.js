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

        service.getBrands = function() {
            return $http.get(URLS.CONFIG.BRANDS)
                .then(function(result) {
                    return result.data;
                });
        };

        service.getSeries = function(brand) {
            var url = URLS.CONFIG.SERIES + '?brand=' + brand;

            return $http.get(url)
                .then(function(result) {
                    return result.data;
                });
        };

        service.getModelings = function(brand, series) {
            var url = URLS.CONFIG.MODELINGS + '?brand=' + brand + '&series=' + series;

            return $http.get(url)
                .then(function(result) {
                    return result.data;
                });
        };
    });
