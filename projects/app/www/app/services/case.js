angular.module('cheping.services.case', [])
    .service('CaseService', function($http, URLS, AuthService, CacheService) {
        var service = this;

        service.getCase = function(caseId) {
            var url = URLS.CASE.GETVEHICLEINFO + '?' + 'caseId=' + caseId;

            return $http.get(url, {
                cache: CacheService.get('caseCache')
            }).then(function(result) {
                return result.data;
            });

        };

        service.getCases = function(pageIndex, carType) {
            var url = URLS.CASE.GETCASELIST + '?' + 'pageIndex=' + pageIndex + '&pageSize=10&carType=' + carType;

            return $http.get(url, {
                cache: CacheService.get('caseCache')
            }).then(function(result) {
                return result.data;
            });

        };

        service.getTodos = function() {
            var url = URLS.CASE.GETTODOS;

            return $http.get(url, {
                cache: CacheService.get('caseCache')
            }).then(function(result) {
                return result.data;
            });
        };

        service.getVehicleInfo = function(caseId) {
            var url = URLS.CASE.GETVEHICLEINFO + '?' + 'caseId=' + caseId;

            return $http.get(url, {
                cache: CacheService.get('caseCache')
            }).then(function(result) {
                return result.data;
            });

        };

        service.reject = function(caseId, reason) {
            var url = URLS.CASE.REJECT + '?' + 'caseId=' + caseId + '&message=' + reason;

            return $http.get(url).then(function(result) {
                return result.data;
            });
        };

        service.addYancheInfo = function(data) {
            var url = URLS.CASE.ADDYANCHEINFO;

            return $http.post(url, data).then(function(result) {
                return result.data;
            });
        };
    });
