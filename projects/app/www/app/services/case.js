angular.module('cheping.services.case', [
])
    .service('CaseService', function($http, URLS, AuthService, CacheService) {
        var service = this;

        service.getCases = function(pageIndex, carType) {
            var url = URLS.CASE.GETCASELIST + '?' + 'pageIndex=' + pageIndex + '&pageSize=10&carType=' + carType;

            return $http.get(url, {
                cache: CacheService.get('caseCache')
            }).then(function(result) {
                return result.data;
            });

        };

        service.getCase = function(caseId) {
            var url = URLS.CASE.GETVEHICLEINFO + '?' + 'caseId=' + caseId;

            return $http.get(url, {
                cache: CacheService.get('caseCache')
            }).then(function(result) {
                return result.data;
            });

        };

        service.getVehicleInfo = function(caseId) {
            var url = URLS.CASE.GETVEHICLEINFO + '?' + 'caseId' + caseId;

            return $http.get(url, {
                cache: CacheService.get('caseCache')
            }).then(function(result) {
                return result.data;
            });

        };
    });