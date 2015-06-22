angular.module('cheping.services.caseCreate', [])
    .service('CaseCreateService', function($http, URLS, AuthService, ConfigService) {
        var service = this;

        var newCase = {};

        service.resetNewCase = function(carType) {
            newCase = {};
            newCase.photos = [];
            newCase.caseType = carType;
            newCase.modifiedContent = '无';
            return newCase;
        };

        service.addPhoto = function(content) {
            if(newCase.photos.length <= 10) {
                return $http.post(URLS.CASE.ADDPHOTO, {
                    caseId: 0,
                    content: content
                }).then(function(result) {
                    newCase.photos.push({
                        id: result.data.result,
                        content : content
                    });
                });
            }
        };

        service.getNewCase = function() {
            return newCase;
        };

        service.createCase = function() {
            newCase.photoIds = [];

            _.forEach(newCase.photos, function(p) {
                newCase.photoIds.push(p.id);
            });

            newCase.photoIds = [];

            return $http.post(URLS.CASE.ADDCASE, newCase)
                .then(function(result) {
                    return result.data;
                });
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

        service.getColors = function(){
            return ConfigService.getColors();
        };

        service.getCitis = function(){
            return ConfigService.getCitis();
        };

        service.getCooperationMethod = function(){
            return ConfigService.getCooperationMethod();
        };
    });
